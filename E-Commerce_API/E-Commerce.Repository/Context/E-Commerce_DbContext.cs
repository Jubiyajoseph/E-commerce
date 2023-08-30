using E_Commerce.Model.Models.User;
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
        public E_Commerce_DbContext(DbContextOptions options) : base(options) { }   
        public DbSet<User> User { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assemblyName = Assembly.GetExecutingAssembly();
            if(assemblyName is not null)
                modelBuilder.ApplyConfigurationsFromAssembly(assemblyName);
        }
    }
}
