using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using UnigloShop.Data.Entities;

namespace UnigloShop.ViewModel
{
    public class OrderItemViewModel
    {   public int OrderItemId { get; set; }
        public Product OrderItemProduct { get; set; }
        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        [Required]
        public int ProductId { get; set; }
        public string ProductCategory { get; set; }

        public decimal ProductPrice { get; set; }
        public string ProductTitle { get; set; }
        public string ProductArtDescription { get; set; }
        public string ProductArtist { get; set; }
    }
}
