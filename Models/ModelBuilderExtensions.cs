using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StoreApp.Entity;

namespace StoreApp.Models
{
    public static class ModelBuilderExtensions
    {

          public static void Seed(this ModelBuilder modelBuilder)
        {


            
            var hasher = new PasswordHasher<ApplicationUser>();

            var user = new ApplicationUser
            {
                Id = "1",
                UserName = "omerapaydin",
                Email = "info@gmail.com",
                ImageFile = "p1.jpg",
                FullName = "Ömer Apaydın",
                EmailConfirmed = true // E-posta doğrulamasını sağlıyoruz
            };

            user.PasswordHash = hasher.HashPassword(user, "User123!");

            var user2 = new ApplicationUser
            {
                Id = "2",
                UserName = "ahmettambuga",
                Email = "info2@gmail.com",
                ImageFile = "p2.jpg",
                FullName = "Ahmet Tamboğa",
                EmailConfirmed = true 
            };
            user2.PasswordHash = hasher.HashPassword(user2, "User2Password!");

            modelBuilder.Entity<ApplicationUser>().HasData(user, user2);
            
             modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Telefonlar"  },
                new Category { CategoryId = 2, Name = "Bilgisayarlar" },
                new Category { CategoryId = 3, Name = "Aksesuarlar" }
            );

           
            modelBuilder.Entity<Post>().HasData(
                new Post { PostId = 1, Title = "Apple", Description = "Apple Iphone 12 64GB Sarı Cep Telefonu", PublishedOn = DateTime.Now.AddDays(-50), Image = "1t.jpeg",Price = 45000, IsActive= true,UserId = "1" ,CategoryId = 1},
                new Post { PostId = 2, Title = "Apple", Description = " Apple Iphone 14 128GB Sarı Cep Telefonu", PublishedOn = DateTime.Now.AddDays(-20), Image = "2t.jpeg",Price = 55000, IsActive= true, UserId = "1" ,CategoryId = 1},
                new Post { PostId = 3, Title = "Apple", Description = " Apple Iphone 15 64GB Sarı Cep Telefonu", PublishedOn = DateTime.Now.AddDays(-60), Image = "3t.jpeg", Price = 75000, IsActive= true,UserId = "2" ,CategoryId = 1}
            );
        }



        
    }
}