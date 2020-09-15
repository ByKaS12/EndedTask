using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EndedTask.Models
{
    public class Order
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Guid ClientId { get; set; }
        public Client Client { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        public DateTime ShipmentDate { get; set; }
        public int OrderNumber { get; set; }
        public string Status { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
