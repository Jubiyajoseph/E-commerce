using E_Commerce.Model.Models.ProductsModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Repository.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Weight).IsRequired().HasColumnType("decimal(8,5)");
            builder.Property(p => p.Stock).IsRequired();
            builder.Property(p => p.BrandId).IsRequired();
            builder.Property(p => p.CategoryId).IsRequired();
            builder.Property(p => p.UnitPrice).IsRequired().HasColumnType("decimal(10,3)");
        }
    }
}
