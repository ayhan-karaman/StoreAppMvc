using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class ProductManager : IProductService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public ProductManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public void CreateOneProduct(ProductDtoForInsertion productDtoForInsertion)
        {
             Product product = _mapper.Map<Product>(productDtoForInsertion);
            _manager.ProductRepository.CreateProduct(product);
            _manager.SaveChanges();
        }

        public void DeleteOneProduct(int id)
        {
            Product? product = GetOneProduct(id, false) ?? new Product();
            _manager.ProductRepository.DeleteProduct(product); 
            _manager.SaveChanges();
            
        }

        public IEnumerable<Product> GetAllProducts(bool tracking)
        {
           return _manager.ProductRepository.GetAllProducts(tracking);
        }

        public Product? GetOneProduct(int id, bool tracking)
        {
           return _manager.ProductRepository.GetOneProduct(id, tracking);
        }

        public ProductDtoForUpdate GetOneProductForUpdate(int id, bool tracking)
        {
            var product = GetOneProduct(id, tracking);
            var mappedProduct = _mapper.Map<ProductDtoForUpdate>(product);
            return mappedProduct;
        }

        public void UpdateOneProduct(ProductDtoForUpdate productDtoForUpdate)
        { 
            var mappedProduct = _mapper.Map<Product>(productDtoForUpdate);
            _manager.ProductRepository.Update(mappedProduct);
            _manager.SaveChanges();
        }
    }
}