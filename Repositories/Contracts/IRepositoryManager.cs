using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IRepositoryManager
    {
        IProductRepository ProductRepository { get; }
        ICateogoryRepository CateogoryRepository { get; }

        void SaveChanges();

    }
}