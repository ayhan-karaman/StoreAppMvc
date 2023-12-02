using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Dtos;
using Entities.Models;
using Entities.RequestParameters;

namespace Services.Contracts
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts(bool tracking);
        IEnumerable<Product> GetAllProductsWithDetails(ProductRequestParameter parameter, bool tracking);
        IEnumerable<Product> GetLatestProducts(int n, bool tracking);
        IEnumerable<Product> GetShowcaseProducts(bool tracking);
        Product? GetOneProduct(int id, bool tracking);
        void CreateOneProduct(ProductDtoForInsertion productDtoForInsertion);
        void UpdateOneProduct(ProductDtoForUpdate productDtoForUpdate);
        void DeleteOneProduct(int id);
        ProductDtoForUpdate GetOneProductForUpdate(int id, bool tracking);
    }
}