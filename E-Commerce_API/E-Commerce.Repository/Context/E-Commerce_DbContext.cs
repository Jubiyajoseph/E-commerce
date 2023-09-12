using E_Commerce.Model.Models.AddressModel;
using E_Commerce.Model.Models.OrderModel;
using E_Commerce.Model.Models.ProductsModel;
using E_Commerce.Model.Models.UserModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Repository.Context
{
    public class E_Commerce_DbContext:DbContext
    {
        public E_Commerce_DbContext(DbContextOptions options) : base(options) 
        {
             
        }   
        public DbSet<User> User { get; set; } = null!;
        public DbSet<City> City { get; set; } = null!;
        public DbSet<State> State { get; set; } = null!;
        public DbSet<Country> Country { get; set; } = null!;
        public DbSet<Address> Address { get; set; } = null!;
        public DbSet<Brand> Brand { get; set; } = null!;
        public DbSet<Category> Category { get; set; } = null!;
        public DbSet<Product> Product { get; set; } = null!;
        public DbSet<WishList> WishList { get; set; } = null!;
        public DbSet<OrderStatus> OrderStatus { get; set; } = null!;
        public DbSet<Order> Order { get; set; } = null!;
        public DbSet<OrderDetail> OrderDetail { get; set; } = null!;
        public DbSet<Cart> Cart { get; set; } = null!;
        public DbSet<DefaultAddress> DefaultAddress { get; set; } = null!;



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assemblyName = Assembly.GetExecutingAssembly();
            if(assemblyName is not null)
                modelBuilder.ApplyConfigurationsFromAssembly(assemblyName);
        }
    }
}
