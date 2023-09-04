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
    public class UserConfiguration:IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
      {
            builder.HasKey(x => x.UserId);
            builder.Property(x => x.UserId).ValueGeneratedOnAdd();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.HasIndex(x => x.Name).IsUnique();          

            builder.HasIndex(u => u.Email).IsUnique();
            builder.Property(u => u.Email).IsRequired().HasMaxLength(50);

            builder.Property(u => u.Phone).IsRequired().HasMaxLength(12);
            builder.HasIndex(u => u.Phone).IsUnique();

            builder.Property(u => u.Password).IsRequired();
            builder.Property(u => u.Password).HasMaxLength(15);
        }
    }
}
