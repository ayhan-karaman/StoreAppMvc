using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Dtos;
using Entities.Models;

namespace Services.Contracts
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts(bool tracking);
        Product? GetOneProduct(int id, bool tracking);
        void CreateOneProduct(ProductDtoForInsertion productDtoForInsertion);
        void UpdateOneProduct(ProductDtoForUpdate productDtoForUpdate);
        void DeleteOneProduct(int id);
        ProductDtoForUpdate GetOneProductForUpdate(int id, bool tracking);
    }
}