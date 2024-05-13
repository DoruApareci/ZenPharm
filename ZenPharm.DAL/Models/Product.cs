using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ZenPharm.DAL.Models;

public class Product
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    [DisplayName("Product name:")]
    public string Name { get; set; }
    [Required]
    [DisplayName("Product description:")]
    public string Description { get; set; }
    [Required]
    [DisplayName("Price:")]
    public decimal Price { get; set; }
    [Required]
    [DisplayName("Stock:")]
    public int StockQuantity { get; set; }
    [Required]
    [DataType(DataType.Date)]
    [DisplayName("Expiry date:")]
    public DateTime ExpiryDate { get; set; }

    public string? Path { get; set; }
    public string? PubId {  get; set; }
    [NotMapped]
    [DisplayName("Product image:")]
    public IFormFile? FormFile { get; set; }

    public Guid? ProdTypeID { get; set; }
    public ProductType? ProductType { get; set; }
}
