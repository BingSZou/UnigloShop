using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UnigloShop.ViewModel
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Category { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
        [Required]
        [MinLength(5)]
        public string Title { get; set; }
        public string ArtDescription { get; set; }
        public string ArtDating { get; set; }
        [Required]
        public string ArtId { get; set; }
        [Required]
        [MinLength(5)]
        public string Artist { get; set; }
        public DateTime ArtistBirthDate { get; set; }
        public DateTime ArtistDeathDate { get; set; }
        public string ArtistNationality { get; set; }
    }
}
