using E_Commerce.Model.Models.AddressModel;
using E_Commerce.Model.Models.UserModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Repository.Configurations
{
    public class CityConfiguration:IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.Property(n => n.Name).IsRequired().HasMaxLength(50);
        }
    }
}
