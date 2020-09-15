using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EndedTask.Models
{
    public class OrderItem
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        [Required]
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        [Required]
        public int ItemsCount { get; set; }
        [Required]
        public int ItemPrice { get; set; }

    }
}
