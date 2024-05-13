using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json.Serialization;
using ZenPharm.DAL.Models;

namespace ZenPharm.Web.Models;

public class AddProductViewModel
{
    public Product Product{ get; set; }
    [JsonIgnore]
    public IEnumerable<SelectListItem>? Types { get; set; }
    public AddProductViewModel()
    {
        Types = new List<SelectListItem>();
        Product = new ();
    }
}
