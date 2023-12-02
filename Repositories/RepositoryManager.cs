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
        public RepositoryManager(RepositoryContext context, IProductRepository productRepository, ICateogoryRepository cateogoryRepository, IOrderRepository orderRepository)
        {
            _context = context;
            _productRepository = productRepository;
            _cateogoryRepository = cateogoryRepository;
            _orderRepository = orderRepository;
        }

        public IProductRepository ProductRepository => _productRepository;

        public ICateogoryRepository CateogoryRepository => _cateogoryRepository;

        public IOrderRepository OrderRepository => _orderRepository;

        public void SaveChanges()
        => _context.SaveChanges();
    }
}