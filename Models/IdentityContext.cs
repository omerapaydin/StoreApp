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
    public class IdentityContext:IdentityDbContext<IdentityUser>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options): base(options)
        {
            
        }

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



        }





    }
}