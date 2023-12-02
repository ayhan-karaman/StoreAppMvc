using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("orders");
            builder.Property(x => x.Id).HasColumnName("order_id");
            builder.Property(x => x.Name).HasColumnName("order_name");
            builder.Property(x => x.Line1).HasColumnName("line_1");
            builder.Property(x => x.Line2).HasColumnName("line_2");
            builder.Property(x => x.Line3).HasColumnName("line_3");
            builder.Property(x => x.City).HasColumnName("city");
            builder.Property(x => x.Shipped).HasColumnName("shipped");
            builder.Property(x => x.GiftWrap).HasColumnName("gift_wrap");
            builder.Property(x => x.OrderedAt).HasColumnName("ordered_at");
        }
    }
}