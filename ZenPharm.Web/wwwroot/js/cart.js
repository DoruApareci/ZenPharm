const productsKey = 'products';
function updateLocalStorage(cartItems) {
    localStorage.setItem(productsKey, JSON.stringify(cartItems));
}

function addToCart(productId) {
    var cartData = localStorage.getItem(productsKey);
    var cartItems = cartData ? JSON.parse(cartData) : [];
    var existingItem = cartItems.find(item => item.prodId === productId);
    if (existingItem) {
        existingItem.quantity += 1;
    } else {
        cartItems.push({ prodId: productId, quantity: 1 });
    }
    updateLocalStorage(cartItems);
}

function removeFromCart(productId) {
    var cartData = localStorage.getItem(productsKey);
    var cartItems = cartData ? JSON.parse(cartData) : [];
    cartItems = cartItems.filter(item => item.prodId !== productId);
    updateLocalStorage(cartItems);
    renderCartItems();
}

function increaseQuantity(productId) {
    var cartData = localStorage.getItem(productsKey);
    var cartItems = cartData ? JSON.parse(cartData) : [];
    var itemToUpdate = cartItems.find(item => item.prodId === productId);
    if (itemToUpdate) {
        itemToUpdate.quantity++;
    }
    updateLocalStorage(cartItems);
    renderCartItems();
}

function decreaseQuantity(productId) {
    var cartData = localStorage.getItem(productsKey);
    var cartItems = cartData ? JSON.parse(cartData) : [];
    var itemToUpdate = cartItems.find(item => item.prodId === productId);
    if (itemToUpdate && itemToUpdate.quantity > 1) {
        itemToUpdate.quantity--;
    }
    updateLocalStorage(cartItems);
    renderCartItems();
}

function getProductsFromLocalStorage() {
    var cartData = localStorage.getItem(productsKey);
    if (cartData) {
        var orderProducts = JSON.parse(cartData);
        return orderProducts;
    } else {
        return [];
    }
}

//not working properly(mby the back isn't sending data ok)
async function renderCartItems() {
    var products = getProductsFromLocalStorage();
    var cartItemsContainer = document.getElementById('cart-items');
    cartItemsContainer.innerHTML = '';
    var tprice = 0;
    //if (products.length == 0) {
    //    document.getElementById("placeOrderBtn").disabled = true;
    //}
    for (const product of products) {
        try {
            const response = await fetch(`/orders/prodDetails?prodId=${product.prodId}`);
            if (!response.ok) {
                throw new Error('Failed to fetch product details');
            }
            const prod = await response.json();
            var item = document.createElement('div');
            item.classList.add('item');
            item.innerHTML = `
            <div class="buttons" on>
                <button class="delete-btn" type="button" onclick="removeFromCart('${product.prodId}')">
                    <i class="fa-solid fa-trash"></i>
                </button>
            </div>

            <div class="image">
                <img src="${prod.path}" alt="" /> 
            </div>

            <div class="description">
                <span>${prod.name} </span>
                <span>${prod.price}</span>
            </div>

            <div class="quantity">
                <button class="plus-btn" type="button" onclick="increaseQuantity('${product.prodId}')">
                    <i class="fa-solid fa-plus"></i>
                </button>
                <input type="text" name="name" value="${product.quantity}">
                <button class="minus-btn" type="button" onclick="decreaseQuantity('${product.prodId}')">
                    <i class="fa-solid fa-minus"></i>
                </button>
            </div>

            <div class="total-price">${prod.price * product.quantity}</div> 
        `;
            tprice += prod.price * product.quantity;
            var totalPrice = document.getElementById('total-price');
            totalPrice.innerHTML = `Total price: ${tprice} MDL`;
            cartItemsContainer.appendChild(item);

        } catch (error) {
            console.error('Error fetching product details:', error);
        }
    }
}

async function placeOrder() {
    var products = getProductsFromLocalStorage();
    if (products.length != 0) {
        var data = JSON.stringify({ order: products })
        try {
            const response = await fetch(`/orders/placeOrder`, {
                method: 'POST',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },

                body: JSON.stringify({ OrderItems: products })
            });
            console.log(response);
            if (!response.ok) {
                throw new Error('Failed to place order');
            }
            else {
                localStorage.removeItem(productsKey);
                window.location.href = "/home/index";
            }
        } catch (e) {
            console.error('Error placing the order:', e);
        }
    }
}

window.addEventListener('load', function () {
    renderCartItems();
});