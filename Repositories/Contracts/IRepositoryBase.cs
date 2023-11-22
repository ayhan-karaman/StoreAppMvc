using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IRepositoryBase<T>
    where T : class, new()
    {
        IQueryable<T> FindAll(bool tracking);
        T? FindByCondition(Expression<Func<T, bool>> expression, bool tracking);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}