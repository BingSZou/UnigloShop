using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using UnigloShop.Data.Entities;

namespace UnigloShop.Data
{
    public class UnigloDataContext : DbContext
    {
        public UnigloDataContext(DbContextOptions<UnigloDataContext> options)
            : base(options)
        { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set;  }
    }
}
