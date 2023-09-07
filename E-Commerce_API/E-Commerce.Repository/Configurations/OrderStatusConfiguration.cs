using E_Commerce.Model.Models.OrderModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Repository.Configurations
{
    public class OrderStatusConfiguration : IEntityTypeConfiguration<OrderStatus>
    {
        public void Configure(EntityTypeBuilder<OrderStatus> builder)
        {
            builder.HasKey(x => x.OrderStatusId);
            builder.Property(x => x.OrderStatusId).ValueGeneratedOnAdd();

            builder.Property(x => x.Status).IsRequired().HasMaxLength(30);

        }
    }
}
