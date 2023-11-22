using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("categories");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("category_id");
            builder.Property(x => x.Name).HasColumnName("category_name");
            builder.HasMany(x => x.Products);
            builder
            .HasData(
                new Category{Id = 1, Name = "Electronic"},
                new Category{Id = 2, Name = "Beyaz Eşya"},
                new Category{Id = 3, Name = "Hırdavat"}
            );
        }
    }
}