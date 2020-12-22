using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnigloShop.Data.Entities;

namespace UnigloShop.Data
{
    public class CartDataContext : DbContext
    {
        private DbSet<Cart> Cart { get; set; }
        public CartDataContext()
        {

        }
    }
}
