using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StoreApp.Entity;

namespace StoreApp.Models
{
    public class IdentityContext:IdentityDbContext<ApplicationUser>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options): base(options)
        {
            
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; } 


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Seed();

            
                builder.Entity<Post>()
                    .HasOne(p => p.User)         
                    .WithMany(u => u.Posts)      
                    .HasForeignKey(p => p.UserId); 

                builder.Entity<Post>()
                    .HasOne(p => p.Category)       
                    .WithMany(c => c.Posts)     
                    .HasForeignKey(p => p.CategoryId); 

                builder.Entity<OrderItem>()
                        .HasOne(oi => oi.Order)        
                        .WithMany(o => o.OrderItems) 
                        .HasForeignKey(oi => oi.OrderId);

                builder.Entity<OrderItem>()
                        .HasOne(oi => oi.Post)       
                        .WithMany()                  
                        .HasForeignKey(oi => oi.PostId);


        }





    }
}