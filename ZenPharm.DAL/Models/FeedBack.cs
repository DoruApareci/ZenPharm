using System.ComponentModel.DataAnnotations;

namespace ZenPharm.DAL.Models;

public class FeedBack
{
    [Key]
    public Guid ID { get; set; }
    [Required]
    public string FullName { get; set; }
    [EmailAddress]
    [Required]
    public string Email { get; set; }
    [Required]
    public string Topic { get; set; }
    [Phone]
    [Required]
    public string Phone{ get; set; }
    [Required]
    public string Message {  get; set; }

    public DateTime? Placed { get; set; }
}
