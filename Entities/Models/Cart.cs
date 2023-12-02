using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; }

        public Cart()
        {
            Lines = new List<CartLine>();
        }

        public virtual void AddItem(Product product, int quantity)
        {
             CartLine? line = Lines.Where(x => x.Product.Id == product.Id).FirstOrDefault();
             if(line is null)
             {
                 Lines.Add(new CartLine()
                 {
                    Product = product, 
                    Quantity = quantity
                 });
             }
             else
             {
                line.Quantity += quantity;
             }
        }

        public virtual void RemoveItem(Product product)
        => Lines.RemoveAll(x => x.Product.Id == product.Id);

        public decimal ComputeTotalValue() => Lines.Sum(e => e.Product.Price * e.Quantity);

        public virtual void Clear() => Lines.Clear();
    }
}