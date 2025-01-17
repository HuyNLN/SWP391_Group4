﻿using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ShoesDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Initial Catalog=ShoseStore;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                        .Property(o => o.OrderID)
                        .ValueGeneratedOnAdd();
        }

        public DbSet<Account> Account { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<CartItem> CartItem { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductVariant> ProductVariant { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<Import> Import { get; set; }
        public DbSet<Comment> Comment { get; set; }
    }
}
