using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MVC_7_Identity_43.Areas.Identity.Data;

// Add profile data for application users by adding properties to the AppUser class
public class AppUser : IdentityUser
{
    [MaxLength(30)]
    public string FirstName { get; set; }

    [MaxLength(30)]
    public string LasttName { get; set; }

}

