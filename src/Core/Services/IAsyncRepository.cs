using Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IAsyncRepository<T> where T : BaseModel
    {
        Task<T> GetByIdAsync(int id);
        Task<List<T>> ListAllAsync();
       // Task<List<T>> ListAsync(ISpecification<T> spec);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
