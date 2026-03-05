using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Repositories.Contracts;

namespace Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly IProductRepository _productRepository;
        private readonly ICateogoryRepository _cateogoryRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IAddressRepository _addressRepository;
        public RepositoryManager(RepositoryContext context, IProductRepository productRepository, ICateogoryRepository cateogoryRepository, IOrderRepository orderRepository, IAddressRepository addressRepository)
        {
            _context = context;
            _productRepository = productRepository;
            _cateogoryRepository = cateogoryRepository;
            _orderRepository = orderRepository;
            _addressRepository = addressRepository;
        }

        public IProductRepository ProductRepository => _productRepository;

        public ICateogoryRepository CateogoryRepository => _cateogoryRepository;

        public IOrderRepository OrderRepository => _orderRepository;
        public IAddressRepository AddressRepository => _addressRepository;

        public void SaveChanges()
        => _context.SaveChanges();
    }
}