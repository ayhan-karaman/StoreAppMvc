using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
         
            builder.HasOne(x => x.Category);
            builder
            .HasData(
                new Product{Id = 1, ImageUrl="/img/products/1.jpg", CategoryId= 1, Name = "Samsung Galaxy A24 ", Price = 8099, ShowCase = true},
                new Product{Id = 2, ImageUrl="/img/products/2.png", CategoryId = 2, Name = "Dördüncü Kanat", Price = 247, ShowCase = false},
                new Product{Id = 3, ImageUrl="/img/products/3.jpg", CategoryId = 1, Name = "Casper Monitör", Price = 3599, ShowCase = true},
                new Product{Id = 4, ImageUrl="/img/products/4.jpg", CategoryId= 3, Name = "Ayakkabılık", Price = 79, ShowCase = false},
                new Product{Id = 5, ImageUrl="/img/products/5.jpeg", CategoryId= 2, Name = "Sır Perdesi", Price = 89, ShowCase = true},
                new Product{Id = 6, ImageUrl="/img/products/6.jpg", CategoryId= 2, Name = "Hoca Ahmet Yesevi", Price = 87, ShowCase = false},
                new Product{Id = 7, ImageUrl="/img/products/7.jpg", CategoryId= 3, Name = "Zigon Sehpa", Price = 249, ShowCase = true},
                new Product{Id = 8, ImageUrl="/img/products/8.jpg", CategoryId= 1, Name = "Casper VIA S40", Price = 3799, ShowCase = true},
                new Product{Id = 9, ImageUrl="/img/products/9.jpeg", CategoryId= 3, Name = "Tv Ünitesi", Price = 1638, ShowCase = false},
                new Product{Id = 10, ImageUrl="/img/products/10.jpeg", CategoryId= 1, Name = "Casper VIA X30", Price = 8520, ShowCase = true}
                );
        }
    }
}