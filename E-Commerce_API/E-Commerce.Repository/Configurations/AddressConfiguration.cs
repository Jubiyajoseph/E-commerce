using E_Commerce.Model.Models.AddressModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace E_Commerce.Repository.Configurations
{
    public class AddressConfiguration:IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(x => x.AddressId);
            builder.Property(x => x.AddressId).ValueGeneratedOnAdd();
            
            builder.Property(u=>u.ResidentialAddress).IsRequired().HasMaxLength(200);

            builder.Property(c => c.CityId).IsRequired();

            builder.Property(s=>s.StateId).IsRequired();

            builder.Property(c=>c.CountryId).IsRequired();

            builder.Property(u=>u.UserId).IsRequired();

            builder.Property(i=>i.IsDeleted).IsRequired();

            builder.Property(i=>i.IsDefault).IsRequired();
        }
    }
}
