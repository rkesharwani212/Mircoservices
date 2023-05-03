using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Model
{
    public class ProductModel
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public int? Size { get; set; }
        [Required]
        public double? Price { get; set; }
        public string Design { get; set; }
    }
}
