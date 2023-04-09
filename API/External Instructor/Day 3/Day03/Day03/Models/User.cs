using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

public class User : IdentityUser
{
    public int Age { get; set; }
}