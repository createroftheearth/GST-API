using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;

namespace GST_API_DAL.Repository
{
    internal abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private ApplicationDbContext _context;
        internal DbSet<T> dbSet;
        private bool shareContext = false;
        IDbContextTransaction trans;
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            dbSet = _context.Set<T>();
        }

        public async void beginTransaction()
        {
            trans = await _context.Database.BeginTransactionAsync();
        }

        public async void rollback()
        {
            await trans.RollbackAsync();
        }

        public async void commit()
        {
            await trans.CommitAsync();
        }


        protected DbSet<T> DbSet
        {
            get
            {
                return _context.Set<T>();
            }
        }
        public IQueryable<T> GetAll()
        {
            return DbSet.AsQueryable();
        }

        public virtual async Task<ICollection<T>> GetAllAsyn()
        {
            return await DbSet.AsQueryable().ToListAsync();//.ToListAsync();
        }

        public virtual T Get(int id)
        {
            return DbSet.Find(id);
        }

        public virtual async Task<T> GetAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual T Add(T t)
        {
            DbSet.Add(t);
            _context.SaveChanges();
            return t;
            //var newEntry = DbSet.Add(t);
            //if (!shareContext)
            //    _context.SaveChanges();
            //return newEntry;

        }

        public virtual async Task<T> AddAsyn(T t)
        {
            DbSet.Add(t);
            await _context.SaveChangesAsync();
            return t;

            //var newEntry = DbSet.Add(t);
            //if (!shareContext)
            //    await _context.SaveChanges();
            //return newEntry;
        }
        public IQueryable<T> Filter(Expression<Func<T, bool>> match)
        {
            return DbSet.Where(match);
        }
        public IQueryable<T> FilterAsyn(Expression<Func<T, bool>> match)
        {
            return DbSet.Where(match);
        }


        public IQueryable<T> Filter<Key>(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50)
        {
            int skipCount = index * size;
            var _resetSet = filter != null ? DbSet.Where(filter).AsQueryable() :
                DbSet.AsQueryable();
            _resetSet = skipCount == 0 ? _resetSet.Take(size) :
                _resetSet.Skip(skipCount).Take(size);
            total = _resetSet.Count();
            return _resetSet.AsQueryable();
        }

        public virtual async Task<bool> AnyAsync(Expression<Func<T, bool>> match)
        {
            return await _context.Set<T>().AnyAsync(match);
        }
        public virtual T Find(Expression<Func<T, bool>> match)
        {
            return _context.Set<T>().SingleOrDefault(match);
        }

        public virtual async Task<T> FindAsync(Expression<Func<T, bool>> match)
        {
            return await _context.Set<T>().SingleOrDefaultAsync(match);
        }

        public ICollection<T> FindAll(Expression<Func<T, bool>> match)
        {
            return _context.Set<T>().Where(match).ToList();
        }

        public async Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match)
        {
            return await _context.Set<T>().Where(match).ToListAsync();
        }

        public virtual int Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            return _context.SaveChanges();
        }

        public virtual async Task<int> DeleteAsyn(T entity)
        {
            _context.Set<T>().Remove(entity);
            return await _context.SaveChangesAsync();
        }
        //TODO:change to DBset
        public virtual int Update(T t, object key)
        {
            if (t == null)
                return 0;
            T exist = _context.Set<T>().Find(key);
            if (exist == null)
            {
                return 0;
            }
            _context.Entry(exist).CurrentValues.SetValues(t);
            return _context.SaveChanges();

        }
        //TODO:change to DBset
        public virtual async Task<int> UpdateAsyn(T t, object key)
        {

            if (t == null)
                return 0;

            T exist = await _context.Set<T>().FindAsync(key);
            if (exist == null)
            {
                return 0;
            }
            _context.Entry(exist).CurrentValues.SetValues(t);
            return await _context.SaveChangesAsync();
        }
        public virtual async Task<int> UpdateAsynPartB(T t, object key)
        {

            if (t == null)
                return 0;

            T exist = await _context.Set<T>().FindAsync(key);
            if (exist == null)
            {
                return 0;
            }
            _context.Entry(exist).CurrentValues.SetValues(t);
            return await _context.SaveChangesAsync();
        }
        //TODO:change to DBset
        public int Count()
        {
            return _context.Set<T>().Count();
        }
        //TODO:change to DBset
        public async Task<int> CountAsync()
        {
            return await _context.Set<T>().CountAsync();
        }

        public virtual void Save()
        {

            _context.SaveChanges();
        }
        //TODO:change to _context to all DBset
        public async virtual Task<int> SaveAsync()
        {
            var i = await _context.SaveChangesAsync();
            return i;
        }

        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _context.Set<T>().Where(predicate);
            return query;
        }

        public virtual async Task<ICollection<T>> FindByAsyn(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {

            IQueryable<T> queryable = GetAll();
            foreach (Expression<Func<T, object>> includeProperty in includeProperties)
            {

                queryable = queryable.Include(includeProperty);
            }

            return queryable;
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            if (shareContext && _context != null)
                _context.Dispose();
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }

}
