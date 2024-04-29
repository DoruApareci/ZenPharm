namespace ZenPharm.Web.Models;

public class OrderItemsViewModel
{
    public List<Tuple<Guid, int>> OrderItems { get; set; }
}
