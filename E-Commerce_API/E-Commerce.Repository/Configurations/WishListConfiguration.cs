using E_Commerce.Model.Models.OrderModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Repository.Configurations
{
    public class WishListConfiguration : IEntityTypeConfiguration<WishList>
    {
        public void Configure(EntityTypeBuilder<WishList> builder)
        {
            builder.HasKey(x => x.WishListID);
            builder.Property(x=>x.WishListID).ValueGeneratedOnAdd();
            
            builder.Property(x=>x.UserID).IsRequired();

            builder.Property(x=>x.ProductID).IsRequired();

            builder.Property(x=>x.IsDeleted).IsRequired().HasDefaultValue(false);
        }
    }
}
