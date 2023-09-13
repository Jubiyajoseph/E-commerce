using E_Commerce.Model.Models.AddressModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Repository.Configurations
{
    public class DefaultAddressConfiguration : IEntityTypeConfiguration<DefaultAddress>
    {
        public void Configure(EntityTypeBuilder<DefaultAddress> builder)
        {
            builder.HasKey(x => x.DefaultAddressId);
            builder.Property(x => x.DefaultAddressId).ValueGeneratedOnAdd();

            builder.Property(x => x.AddressId).IsRequired();
            builder.HasOne(x => x.Address)
                .WithMany()
                .HasForeignKey(x => x.AddressId);

            builder.Property(x => x.UserId).IsRequired();
            builder.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict); ;
        }
    }
}
