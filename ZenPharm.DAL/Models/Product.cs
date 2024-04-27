using System.ComponentModel.DataAnnotations;
namespace ZenPharm.DAL.Models;

public class Product
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public DateTime ExpiryDate { get; set; }
}
