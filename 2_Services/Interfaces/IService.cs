using _2_Services.Models;
using System.Threading.Tasks;

namespace _2_Services.Interfaces
{
    public interface IService<T>
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> GetById(int id);

        Task Add(T item);

        Task Update(T item);

        Task Delete(int id);
    }
}
