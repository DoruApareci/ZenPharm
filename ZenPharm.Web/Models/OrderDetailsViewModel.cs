using ZenPharm.DAL.Models;

namespace ZenPharm.Web.Models;

public class OrderDetailsViewModel
{
    public Order Order { get; set; }
    public ZenPharmUser Buyer { get; set; }
}
