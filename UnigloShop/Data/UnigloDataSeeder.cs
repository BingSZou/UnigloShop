using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UnigloShop.Data.Entities;

namespace UnigloShop.Data
{
    public class UnigloDataSeeder
    {
        private readonly IWebHostEnvironment _hosting;
        private readonly UnigloDataContext _datacontext;

        public UnigloDataSeeder(UnigloDataContext dataContext, IWebHostEnvironment hosting)
        {
            _hosting = hosting;
            _datacontext = dataContext;
        }
        public void Seed()
        {
            _datacontext.Database.EnsureCreated();

            if(!_datacontext.Products.Any())
            {
                var filePath = Path.Combine(_hosting.ContentRootPath, "Data\\ProductData.json");
                var json = File.ReadAllText(filePath);
                var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);

                _datacontext.Products.AddRange(products);

                var order = _datacontext.Orders.Where(o => o.Id == 1).FirstOrDefault();
                if(order == null)
                {
                    order = new Order()
                    {
                        OrderNumber = "9ojaldkjf",
                        OrderDate = DateTime.Today
                    };
                    _datacontext.Orders.Add(order);
                }

                if(order != null)
                {
                    order.Items = new List<OrderItem>()
                    {
                        new OrderItem()
                        {
                            Product = products.First(),
                            Quantity = 10,
                            UnitPrice = products.First().Price
                        }
                    };
                }
                _datacontext.SaveChanges();
            }
        }
    }
}
