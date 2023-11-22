using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICateogoryRepository _cateogoryRepository;

        public CategoryManager(ICateogoryRepository cateogoryRepository)
        {
            _cateogoryRepository = cateogoryRepository;
        }

        public IEnumerable<Category> GetAllCategories(bool tracking)
        {
            var categories =  _cateogoryRepository.FindAll(tracking);
            return categories.ToList();
        }

        public Category? GetByIdCategory(int id, bool tracking)
        {
            var category =  _cateogoryRepository.FindByCondition(x => x.Id == id, tracking);
            return category;
        }
    }
}