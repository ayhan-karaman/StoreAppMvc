using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;

namespace Services.Contracts
{
    public interface IOrderService
    {
        IQueryable<Order> Orders { get; }
        Order? GetOneOrder(int id);
        void Complete(int id);
        void SaveOrder(Order order);
        int NumberOfInProcess { get; }
    }
}