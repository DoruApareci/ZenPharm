using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZenPharm.DAL.Models;

public class Order
{
    [Key]
    public Guid ID { get; set; }

    public Guid UserID { get; set; }

    public List<OrderItem> OrderItems { get; set; }
}
