const productsKey = 'products';
function updateLocalStorage(cartItems) {
    localStorage.setItem(productsKey, JSON.stringify(cartItems));
}

function addToCart(productId, name, price, productImg) {
    var cartData = localStorage.getItem(productsKey);
    var cartItems = cartData ? JSON.parse(cartData) : [];
    var existingItem = cartItems.find(item => item.prodId === productId);
    if (existingItem) {
        existingItem.quantity += 1;
    } else {
        cartItems.push({ prodId: productId, name: name, pricePerUnit: price, productImg: productImg, quantity: 1 });
    }

    updateLocalStorage(cartItems);
}

function removeFromCart(productId) {
    var cartData = localStorage.getItem(productsKey);
    var cartItems = cartData ? JSON.parse(cartData) : [];
    cartItems = cartItems.filter(item => item.prodId !== productId);
    updateLocalStorage(cartItems);
    location.reload();
}

function increaseQuantity(productId) {
    var cartData = localStorage.getItem(productsKey);
    var cartItems = cartData ? JSON.parse(cartData) : [];
    var itemToUpdate = cartItems.find(item => item.prodId === productId);
    if (itemToUpdate) {
        itemToUpdate.quantity++;
    }
    updateLocalStorage(cartItems);
    location.reload();
}

function decreaseQuantity(productId) {
    var cartData = localStorage.getItem(productsKey);
    var cartItems = cartData ? JSON.parse(cartData) : [];
    var itemToUpdate = cartItems.find(item => item.prodId === productId);
    if (itemToUpdate && itemToUpdate.quantity > 1) {
        itemToUpdate.quantity--;
    }
    updateLocalStorage(cartItems);
        location.reload();
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

function renderCartItems() {
    var products = getProductsFromLocalStorage();
    var cartItemsContainer = document.getElementById('cart-items');
    console.log(cartItemsContainer);
    // Loop through cart items and create table rows
    for (const product of products) {

        var item = document.createElement('div');
        item.classList.add('item');
        item.innerHTML = `
            <div class="buttons" on>
                <button class="delete-btn" type="button" onclick="removeFromCart('${product.prodId}')">
                    <span class="gg-remove"></span>
                </button>
            </div>

            <div class="image">
                <img src="${product.productImg}" alt="" />
            </div>

            <div class="description">
                <span>${product.name} </span>
                <span>${product.pricePerUnit}</span>
            </div>

            <div class="quantity">
                <button class="plus-btn" type="button" onclick="increaseQuantity('${product.prodId}')">
                    <span class="gg-math-plus"></span>
                </button>
                <input type="text" name="name" value="${product.quantity}">
                <button class="minus-btn" type="button" onclick="decreaseQuantity('${product.prodId}')">
                    <span class="gg-math-minus"></span>
                </button>
            </div>

            <div class="total-price">${product.pricePerUnit * product.quantity}</div>
        `;
        cartItemsContainer.appendChild(item);
    };
}

renderCartItems();