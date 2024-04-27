using System.ComponentModel.DataAnnotations;

namespace ZenPharm.DAL.Models;

public class OrderItem
{
    [Key]
    public Guid OrderItemID { get; set; }

    public Guid OrderItemProductID { get; set; }
    public Product? OrderItemProduct { get; set; }

    public int Quantity { get; set; }
}
