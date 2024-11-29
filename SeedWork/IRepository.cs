using manga_project.Domain;

namespace manga_project.SeedWork
{
    public interface IRepository<T> :IDisposable
    {
        public void Insert(T entity);
        public void Update(T entity);
        public void Delete(int id);

        public IEnumerable<T> GetAll();
   
    }
}
