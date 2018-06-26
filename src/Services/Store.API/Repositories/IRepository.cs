using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Store.API.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> filter);
        Task<T> GetById(int id);
        Task<T> Create(T entity);
        Task<T> Delete(int id);
        Task<T> Update(T entity);
    }
}