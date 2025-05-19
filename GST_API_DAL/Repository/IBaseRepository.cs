using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GST_API_DAL.Repository
{
    public interface IBaseRepository<T> : IDisposable where T : class
    {
        void beginTransaction();
        void rollback();
        void commit();
        T Add(T t);
        Task<T> AddAsyn(T t);
        int Count();
        Task<int> CountAsync();
        int Delete(T entity);
        Task<int> DeleteAsyn(T entity);
        void Dispose();
        IQueryable<T> Filter(Expression<Func<T, bool>> match);
        IQueryable<T> Filter(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50);
        Task<bool> AnyAsync(Expression<Func<T, bool>> match);
        T Find(Expression<Func<T, bool>> match);
        ICollection<T> FindAll(Expression<Func<T, bool>> match);
        Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match);
        Task<T> FindAsync(Expression<Func<T, bool>> match);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        Task<ICollection<T>> FindByAsyn(Expression<Func<T, bool>> predicate);
        void Save();
        Task<int> SaveAsync();
        Task<int> UpdateAsyn(T t, object key);

    }

}
