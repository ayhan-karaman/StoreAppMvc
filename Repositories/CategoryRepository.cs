using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;
using Repositories.Contracts;

namespace Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICateogoryRepository
    {
        public CategoryRepository(RepositoryContext context) : base(context)
        {
        }
    }
}