using System.Linq;

namespace ApplicationMVC.Repositories
{
    public interface IRepository<T>
    {
        T Add(T item);

        T GetById(int id);

        IQueryable<T> GetAll();

        T Update(int id, T item);

        void Delete(int id);
    }
}
