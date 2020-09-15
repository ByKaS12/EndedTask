using EndedTask.Interfaces;
using EndedTask.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndedTask.Repositories
{
    public class OrderRepository : IRepository<Order>
    {
        private readonly ApplicationDbContext db;
        public OrderRepository(ApplicationDbContext context)
        {
            db = context;
        }
        public void Create(Order item)
        {
            db.Orders.Add(item);
        }

        public void Delete(Guid id)
        {
            Order order = db.Orders.Find(id);
            if (order != null)
            {
                db.Orders.Remove(order);
            }
        }

        public Order Get(Guid id)
        {
            return db.Orders.Find(id);
        }
        public Order Get(Client client)
        {
            return db.Orders.FirstOrDefault(u => u.ClientId == client.Id);
        }

        public IEnumerable<Order> GetAllList()
        {
            return db.Orders;
        }

        public void Update(Order item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
