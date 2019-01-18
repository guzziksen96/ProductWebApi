using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Common;

namespace Infrastructure.EntityFrameworkCore.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : class, IEntity
    {
        T Add(T t);
        Task<T> AddAsync(T t);
        int Count();
        void Delete(int id);
        Task<int> DeleteAsync(int id);
        void Dispose();
        T Get(int id);
        IQueryable<T> GetAll();
        Task<ICollection<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        void Save();
        Task<int> SaveAsync();
        T Update(T t, object key);
        Task<T> UpdateAsync(T t, object key);

    }
}
