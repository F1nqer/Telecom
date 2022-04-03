using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IRepository <T> : IDisposable where T : class
    {
        IEnumerable<T> GetAll(); 
        T GetById(int id); 
        void Create(T item);
        void Update(T item);
        void DeleteById(int id);
        void Save();  
    }
}
