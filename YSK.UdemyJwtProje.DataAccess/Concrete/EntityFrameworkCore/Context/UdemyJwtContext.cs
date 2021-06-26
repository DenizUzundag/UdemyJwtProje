using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using YSK.UdemyJwtProje.DataAccess.Concrete.EntityFrameworkCore.Mapping;
using YSKProje.UdemyJwtProje.Entities.Concrete;

namespace YSK.UdemyJwtProje.DataAccess.Concrete.EntityFrameworkCore.Context
{
    public class UdemyJwtContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=ASUS\\SQLEXPRESS;Database=UdemyJwtDb;Trusted_Connection=True;");
          
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)//Fluent Api için (mapping)
        {
            modelBuilder.ApplyConfiguration(new AppUserMap());
            modelBuilder.ApplyConfiguration(new AppUserRoleMap());
            modelBuilder.ApplyConfiguration(new AppRoleMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
        }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<AppUserRole> AppUserRoles { get; set; }
        public DbSet<Product> Products { get; set; }
    }
   
}
