using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EndedTask.Models
{
    public class Client
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        public string Address { get; set; }
        public int Discount { get; set; }
        public List<Order> Orders { get; set; }
      //  public Guid UserId { get; set; }
       // public User User { get; set; }

    }
}
