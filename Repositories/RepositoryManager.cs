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
        public RepositoryManager(RepositoryContext context, IProductRepository productRepository, ICateogoryRepository cateogoryRepository)
        {
            _context = context;
            _productRepository = productRepository;
            _cateogoryRepository = cateogoryRepository;
        }

        public IProductRepository ProductRepository => _productRepository;

        public ICateogoryRepository CateogoryRepository => _cateogoryRepository;

        public void SaveChanges()
        => _context.SaveChanges();
    }
}