using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;
using Entities.RequestParameters;

namespace Repositories.Contracts
{
    public interface IProductRepository:IRepositoryBase<Product>
    {
        List<Product> GetAllProducts(bool tracking);
        List<Product> GetAllProductsWithDetails(ProductRequestParameter parameter, bool tracking);
        List<Product> GetShowcaseProducts(bool tracking);
        Product? GetOneProduct(int id, bool tracking);
        void CreateProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
    }
}