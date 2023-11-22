using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;
using Repositories.Contracts;

namespace Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateProduct(Product product)
        => Create(product);

        public void DeleteProduct(Product product)
        => Delete(product);

        public List<Product> GetAllProducts(bool tracking)
        => FindAll(tracking).ToList();

        public Product? GetOneProduct(int id, bool tracking)
        => FindByCondition(x => x.Id == id, tracking);

        public void UpdateProduct(Product product)
        => Update(product);
    }
}