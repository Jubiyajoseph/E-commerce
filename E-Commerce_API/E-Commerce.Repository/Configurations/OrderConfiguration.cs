using E_Commerce.Model.Models.OrderModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Repository.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.OrderId);
            builder.Property(x => x.OrderId).ValueGeneratedOnAdd();

            builder.Property(x => x.OrderedOn).IsRequired();

            builder.Property(x=> x.UserId).IsRequired();
            builder.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId);

            builder.Property(x => x.BillingAddressId).IsRequired();
            
            builder.HasOne(x=> x.BillingAddress)
                .WithMany()
                .HasForeignKey(x=>x.BillingAddressId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.ShippingAddressId).IsRequired();
            builder.HasOne(x => x.ShippingAddress)
                .WithMany()
                .HasForeignKey(x => x.ShippingAddressId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.TotalPrice).IsRequired().HasColumnType("decimal(12,3)");

            builder.Property(x => x.OrderStatusId).IsRequired();
            builder.HasOne(x => x.OrderStatus)
                .WithMany()
                .HasForeignKey(x => x.OrderStatusId);
        }
    }
}
