using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

internal class APID03Context : IdentityDbContext<User>
{

    public APID03Context(DbContextOptions<APID03Context> options) : base(options)
    {
        
    }
}