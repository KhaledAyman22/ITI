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
    public class ClientEntityConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> EntityBuilder)
        {
            EntityBuilder.Ignore(C => C.TimeStamp)
                  .HasKey(C => C.CID);

            EntityBuilder.Property(C => C.FName)
                .HasMaxLength(50);

            EntityBuilder.Property(C => C.LName)
                .HasMaxLength(50);

            EntityBuilder.Property(C => C.MName)
                .HasMaxLength(2)
                .IsFixedLength()
                .IsRequired(false);

            EntityBuilder.Property(C => C.Deposit)
                .HasColumnType("money")
                .HasColumnName("OrderDeposite");
        }
    }
}
