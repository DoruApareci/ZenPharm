using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ZenPharm.DAL.Models;

public class ZenPharmUser : IdentityUser
{
    [PersonalData]
    [Display(Name = "Last name")]
    public string LastName { get; set; }

    [PersonalData]
    [Display(Name = "First name")]
    public string FirstName { get; set; }

    [PersonalData]
    [Display(Name = "Address")]
    public string Address { get; set; }
}
