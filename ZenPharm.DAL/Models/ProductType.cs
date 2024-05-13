using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ZenPharm.DAL.Models;

public class ProductType
{
    [Key]
    public Guid ProdTypeID { get; set; }
    public string TypeName { get; set; }
    public string TypeDescription { get; set; }
    [JsonIgnore]
    public ICollection<Product>? Products { get; set; }
}
