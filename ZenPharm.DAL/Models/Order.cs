using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZenPharm.DAL.Models.Enums;

namespace ZenPharm.DAL.Models;

public class Order
{
    [Key]
    public Guid ID { get; set; }

    public Guid UserID { get; set; }

    public OrderStatus Status { get; set; } = OrderStatus.Open;

    public DateTime? Placed {  get; set; }

    public List<OrderItem> OrderItems { get; set; }
}
