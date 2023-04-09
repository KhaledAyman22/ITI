using Microsoft.AspNetCore.Identity;

namespace APis.Identity.Day3.Data;

public class Employee : IdentityUser
{
    public string Department { get; set; } = string.Empty;
}
