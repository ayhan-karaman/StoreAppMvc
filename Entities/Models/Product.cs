using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public string? Summary { get; set; }
        public string? ImageUrl { get; set; }
        public Category? Category { get; set; } // Navigation Property
    }
}