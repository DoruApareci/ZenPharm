using ZenPharm.DAL.Models;

namespace ZenPharm.Web.Models;

public class OrderDetailsViewModel
{
    public Order Order { get; set; }
    public ZenPharmUser Buyer { get; set; }

    public int TotalItems()
    {
        return Order.OrderItems.Sum(c => c.Quantity);
    }

    public decimal TotalCost()
    {
        return Order.OrderItems.Sum(x => x.OrderItemProduct.Price * x.Quantity);
    }
}
