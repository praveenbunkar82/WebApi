using Egras.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Egras.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> Get();
        Task<IEnumerable<T>> Get(int id);
        Task<IEnumerable<T>> GetItem(int id);
        //Task<T> GetItem(int id);
        Task<int> Add(T entity);
        Task<int> Delete(int id);
        Task<int> Update(T entity);
    }
}
