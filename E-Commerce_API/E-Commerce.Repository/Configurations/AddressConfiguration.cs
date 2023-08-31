using E_Commerce.Model.Models.AddressModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Repository.Configurations
{
    public class AddressConfiguration:IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.Property(u=>u.ResidentialAddress).IsRequired().HasMaxLength(200);

            builder.Property(c => c.CityId).IsRequired();

            builder.Property(s=>s.StateId).IsRequired();

            builder.Property(c=>c.CountryId).IsRequired();

            builder.Property(u=>u.UserId).IsRequired();

            builder.Property(i=>i.IsDeleted).IsRequired();
        }
    }
}
