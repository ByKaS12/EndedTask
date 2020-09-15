using EndedTask.Interfaces;
using EndedTask.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndedTask.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly ApplicationDbContext db;
        public ProductRepository(ApplicationDbContext context)
        {
            db = context;
        }
        public void Create(Product item)
        {
            db.Products.Add(item);
        }

        public void Delete(Guid id)
        {
            Product product = db.Products.Find(id);
            if (product != null)
            {
                db.Products.Remove(product);
            }
        }

        public Product Get(Guid id)
        {
            return db.Products.Find(id);
        }

        public IEnumerable<Product> GetAllList()
        {
            return db.Products;
        }

        public void Update(Product item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
