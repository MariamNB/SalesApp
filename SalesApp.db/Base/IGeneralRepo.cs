using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp.db.Base
{
    public interface IGeneralRepo<T> where T : class
    {

        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetById(Guid id);
        Task<int> AddAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(Guid id);
        
    }
}