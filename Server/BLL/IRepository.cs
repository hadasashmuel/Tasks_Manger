namespace BLL
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void DeleteById(int id);
        void SaveChanges();
    }
}
