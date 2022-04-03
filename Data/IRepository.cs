using System.Linq;

namespace Data
{
    public interface IRepository<T> where T : class
    {
        public IQueryable<T> GetAll();
        public T GetById(int id);
        public void Create(T item);
        public void Update(T item);
        public void DeleteById(int id);
        public void Save();
    }
}
