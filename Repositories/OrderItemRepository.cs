using EndedTask.Interfaces;
using EndedTask.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndedTask.Repositories
{
    public class OrderItemRepository : IRepository<OrderItem>
    {
        private readonly ApplicationDbContext db;
       public  OrderItemRepository(ApplicationDbContext context)
        {
            db = context;
        }
        public void Create(OrderItem item)
        {
            db.OrderItems.Add(item);
        }

        public void Delete(Guid id)
        {
            OrderItem orderItem = db.OrderItems.Find(id);
            if (orderItem!=null)
            {
                db.OrderItems.Remove(orderItem);
            }
        }

        public OrderItem Get(Guid id)
        {
            return db.OrderItems.Find(id);
        }
        public OrderItem Get(Guid idOne,Guid idTwo)
        {
            return db.OrderItems.FirstOrDefault(u => u.ProductId == idOne && u.OrderId == idTwo);
        }
        public IEnumerable<OrderItem> GetAllList()
        {
            return db.OrderItems;
        }

        public void Update(OrderItem item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
