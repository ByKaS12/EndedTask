using EndedTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndedTask.Repositories
{
    public class UnitOfWork : IDisposable
    {

        private readonly ApplicationDbContext _db;
       public  UnitOfWork(ApplicationDbContext context)
        {
            _db = context;
        }
        private  ClientRepository clientRepository;
        private  OrderItemRepository orderItemRepository;
        private  OrderRepository orderRepository;
        private  ProductRepository productRepository;
        private UserRepository userRepository;

        public ClientRepository Clients
        {
            get
            {
                if (clientRepository == null)
                    clientRepository = new ClientRepository(_db);
                return clientRepository;
            }
        }
        public OrderRepository Orders
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new OrderRepository(_db);
                return orderRepository;
            }
        }
        public OrderItemRepository OrderItems
        {
            get
            {
                if (orderItemRepository==null)
                    orderItemRepository = new OrderItemRepository(_db);
                return orderItemRepository;
            }
        }
        public ProductRepository Products
        {
            get
            {
                if (productRepository == null)
                    productRepository = new ProductRepository(_db);
                return productRepository;
            }
        }
        public UserRepository Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(_db);
                return userRepository;
            }
        }
        public void Save()
        {
            _db.SaveChanges();
        }
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
