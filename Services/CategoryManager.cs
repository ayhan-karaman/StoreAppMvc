using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Entities.Dtos.CategoryDtos;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class CategoryManager : ICategoryService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public CategoryManager(IMapper mapper, IRepositoryManager manager)
        {
            _mapper = mapper;
            _manager = manager;
        }

        public void CreateCategory(CategoryDtoForInsertion categoryDto)
        {
            var mappedEntity = _mapper.Map<Category>(categoryDto);
            _manager.CateogoryRepository.Create(mappedEntity);
            _manager.SaveChanges();
            
        }

        public IEnumerable<Category> GetAllCategories(bool tracking)
        {
            var categories =  _manager.CateogoryRepository.FindAll(tracking);
            return categories.ToList();
        }

        public Category? GetByIdCategory(int id, bool tracking)
        {
            var category =  _manager.CateogoryRepository.FindByCondition(x => x.Id == id, tracking);
            return category;
        }
    }
}