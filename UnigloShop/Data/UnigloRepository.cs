using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using UnigloShop.Data.Entities;

namespace UnigloShop.Data
{
    public class UnigloRepository : IUnigloRepository
    {
        private readonly UnigloDataContext _dbContext;

        public UnigloRepository(UnigloDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddOrder(Order order)
        {
            _dbContext.Orders.Add(order);
        }

        public IEnumerable<Order> GetAllOrders(bool includeDetail = false)
        {
            if (!includeDetail)
                return _dbContext.Orders
                                    .OrderBy(o => o.Id).ToList();

            return _dbContext.Orders
                                .Include(o => o.Items)
                                .ThenInclude(i => i.Product)
                                .OrderBy(o => o.Id)
                                .ToList();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _dbContext.Products
                        .OrderBy(p => p.Title)
                        .ToList();
        }
        public Order GetOrderById(int orderid)
        {
            return _dbContext.Orders
                        .Include(o => o.Items)
                        .ThenInclude(i => i.Product)
                        .FirstOrDefault(o => o.Id == orderid);
        }

        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return _dbContext.Products
                                .Where(p => p.Category == category)
                                .OrderBy(o => o.Title)
                                .ToList();
        }

        public bool SaveAll()
        {
            return _dbContext.SaveChanges() > 0;
        }
    }
}
