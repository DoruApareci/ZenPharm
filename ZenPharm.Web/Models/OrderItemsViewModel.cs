namespace ZenPharm.Web.Models;

public class OrderItemsViewModel
{
    public class Item
    {
        public Guid ProdId { get; set; }
        public int Quantity { get; set; }
    }

    public List<Item> OrderItems { get; set; }
}
