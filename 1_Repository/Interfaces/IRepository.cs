namespace _3_Repository.Interfaces
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAll();

        Task<T> GetById(int id);

        Task<T> Add(T item);

        Task Update(T item);

        Task Delete(int id);
    }
}
