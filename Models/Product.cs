using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EndedTask.Models
{
    public class Product
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Code { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        [MaxLength(30)]
        public string Category { get; set; }
        public string image { get; set; }
    }
}
