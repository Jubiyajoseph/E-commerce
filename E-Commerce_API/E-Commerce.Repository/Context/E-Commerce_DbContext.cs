using E_Commerce.Model.Models.AddressModel;
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




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assemblyName = Assembly.GetExecutingAssembly();
            if(assemblyName is not null)
                modelBuilder.ApplyConfigurationsFromAssembly(assemblyName);
        }
    }
}
