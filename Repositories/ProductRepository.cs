using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;
using Entities.RequestParameters;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.Extensions;

namespace Repositories
{
    public sealed class ProductRepository : RepositoryBase<Product>, IProductRepository
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

        public List<Product> GetAllProductsWithDetails(ProductRequestParameter parameter, bool tracking)
        {
            return _context.Products
            .FilteredByCategoryId(parameter.CategoryId)
            .FilteredBySearchTerm(parameter.SearchTerm)
            .FilteredByMinAndMaxPrice(parameter.MinPrice, parameter.MaxPrice, parameter.IsValidPrice)
            .ToPaginate(parameter.PageNumber, parameter.PageSize)
            .ToList();
        }

        public Product? GetOneProduct(int id, bool tracking)
        => FindByCondition(x => x.Id == id, tracking);

        public List<Product> GetShowcaseProducts(bool tracking)
        => FindAll(tracking).Where(x => x.ShowCase.Equals(true)).ToList();

        public void UpdateProduct(Product product)
        => Update(product);
    }
}