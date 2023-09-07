using E_Commerce.Model.Models.OrderModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Repository.Configurations
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(x => x.OrderDetailId);
            builder.Property(x => x.OrderDetailId).ValueGeneratedOnAdd();

            builder.Property(x=>x.ProductId).IsRequired();
            builder.HasOne(x => x.Product).WithMany().HasForeignKey(x => x.ProductId);

            builder.Property(x=>x.OrderId).IsRequired();
            builder.HasOne(x => x.Order).WithMany().HasForeignKey(x => x.OrderId);

            builder.Property(x => x.Quantity).IsRequired();

            builder.Property(p => p.UnitPrice).IsRequired().HasColumnType("decimal(10,3)");
        }
    }
}
