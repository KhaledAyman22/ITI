using CompanyConsoleAPP.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyConsoleAPP.Configurations
{
    internal class BranchConfigration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> EntityBuilder)
        {
            EntityBuilder.Property(B => B.Name).HasMaxLength(20);
            EntityBuilder.Property(B => B.City).HasMaxLength(10).IsUnicode();
        }
    }
}
