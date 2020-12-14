using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnigloShop.Data.Entities;

namespace UnigloShop.Data
{
    public interface IUnigloRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategory(string category);
        IEnumerable<Order> GetAllOrders(bool includeDetail = false);
        Order GetOrderById(int id);
        void AddOrder(Order order);
        bool SaveAll();
    }
}
