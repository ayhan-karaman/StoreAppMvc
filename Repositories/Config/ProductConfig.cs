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
            builder.ToTable("products");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("product_id");
            builder.Property(x => x.Name).HasColumnName("product_name");
            builder.Property(x => x.CategoryId).HasColumnName("category_id");
            builder.Property(x => x.Price).HasColumnName("price");
            builder.Property(x => x.ImageUrl).HasColumnName("image_url");
            builder.Property(x => x.Summary).HasColumnName("summary");
            builder.HasOne(x => x.Category);
            builder
            .HasData(
                new Product{Id = 1, ImageUrl="/img/products/1.jpg", CategoryId= 1, Name = "Bilgisayar", Price = 17500},
                new Product{Id = 2, ImageUrl="/img/products/2.jpg", CategoryId = 2, Name = "Çamaşır makinası", Price = 7100},
                new Product{Id = 3, ImageUrl="/img/products/3.jpg", CategoryId = 1, Name = "Mouse", Price = 500},
                new Product{Id = 4, ImageUrl="/img/products/4.jpg", CategoryId= 2, Name = "Buz Dolabı", Price = 8250}
                );
        }
    }
}