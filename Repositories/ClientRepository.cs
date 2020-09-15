using EndedTask.Interfaces;
using EndedTask.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndedTask.Repositories
{
    public class ClientRepository : IRepository<Client>
    {
        private readonly ApplicationDbContext db;
       public ClientRepository(ApplicationDbContext context)
        {
            db = context;
        }
        public void Create(Client item)
        {
            db.Clients.Add(item);
        }

        public void Delete(Guid id)
        {
            Client client = db.Clients.Find(id);
            if (client != null)
                db.Clients.Remove(client);
        }
        public Client Get(Guid id)
        {
            return db.Clients.Find(id);
        }

        public IEnumerable<Client> GetAllList()
        {
            return db.Clients;
        }
        public void Update(Client item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
