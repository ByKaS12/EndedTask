using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndedTask.Interfaces
{
    public interface IRepository<T>
        where T : class
    {
        IEnumerable<T> GetAllList(); // GET ALL
        T Get(Guid id); // GET id
        void Create(T item);
        void Update(T item);    
        void Delete(Guid id); 
    }
}
