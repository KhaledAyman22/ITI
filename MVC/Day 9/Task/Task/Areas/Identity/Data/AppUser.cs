using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using FinalTask.Models;

namespace FinalTask.Areas.Identity.Data;

// Add profile data for application users by adding properties to the AppUser class
public class AppUser : IdentityUser
{
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;
    
    public DateTime Birthdate { get; set; }

    public string Country { get; set; } = string.Empty;
}

