using GST_API_DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Linq.Expressions;
using System.Security.Claims;

namespace GST_API_DAL.Repository
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        internal DbSet<T> dbSet;
        private bool shareContext = false;
        IDbContextTransaction trans;
        public BaseRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor )
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            dbSet = _context.Set<T>();
        }

        private string? userId
        {
            get
            {
                return _httpContextAccessor?.HttpContext?.User?.Claims.FirstOrDefault(x => x.Type == "Id")?.Value;
            }
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
        public T Add(T t)
        {
            if (t is BaseEntity baseEntity)
            {
                baseEntity.CreatedById = userId;
                baseEntity.CreatedAt = DateTime.UtcNow;
            }
            DbSet.Add(t);
            _context.SaveChanges();
            return t;

        }

        public async Task<T> AddAsyn(T t)
        {
            if (t is BaseEntity baseEntity)
            {
                baseEntity.CreatedById = userId;
                baseEntity.CreatedAt = DateTime.UtcNow;
            }
            DbSet.Add(t);
            await _context.SaveChangesAsync();
            return t;

            //var newEntry = DbSet.Add(t);
            //if (!shareContext)
            //    await _context.SaveChanges();
            //return newEntry;
        }

        private Expression<Func<T, bool>> AddUserIdCheckInMatch(Expression<Func<T, bool>> match)
        {
            if (!typeof(BaseEntity).IsAssignableFrom(typeof(T)))
            {
                return match;
            }
            // x => x.CreatedById == userId
            var parameter = match?.Parameters!=null? match.Parameters[0]: Expression.Parameter(typeof(T), "x");
            var createdByProperty = Expression.Property(parameter, nameof(BaseEntity.CreatedById));
            var userIdConstant = Expression.Constant(userId);
            var createdByCheck = Expression.Equal(createdByProperty, userIdConstant);
            if (match == null)
            {
                return Expression.Lambda<Func<T, bool>>(createdByCheck, parameter);
            }

            // Combine with original match: x => (x.CreatedById == userId) && match(x)
            var userFilterLambda = Expression.Lambda<Func<T, bool>>(createdByCheck, parameter);
            var combinedBody = Expression.AndAlso(
                  createdByCheck,
                  Expression.Invoke(match, parameter)
              );

            return Expression.Lambda<Func<T, bool>>(combinedBody, parameter);
        }

        public IQueryable<T> Filter(Expression<Func<T, bool>> match)
        {
            match = AddUserIdCheckInMatch(match);
            return DbSet.Where(match);
        }


        public IQueryable<T> Filter(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50)
        {
            filter = AddUserIdCheckInMatch(filter);
            int skipCount = index * size;
            var query = filter!= null ? DbSet.Where(filter) : DbSet;
            total = query.Count();

            if (skipCount > 0)
                query = query.Skip(skipCount);

            query = query.Take(size);

            return query;

        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> match)
        {
            match = AddUserIdCheckInMatch(match);
            return await _context.Set<T>().AnyAsync(match);
        }
        public T Find(Expression<Func<T, bool>> match)
        {
            match = AddUserIdCheckInMatch(match);
            return _context.Set<T>().SingleOrDefault(match);
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> match)
        {
            match = AddUserIdCheckInMatch(match);
            return await _context.Set<T>().SingleOrDefaultAsync(match);
        }

        public ICollection<T> FindAll(Expression<Func<T, bool>> match)
        {
            match = AddUserIdCheckInMatch(match);
            return _context.Set<T>().Where(match).ToList();
        }

        public async Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match)
        {
            match = AddUserIdCheckInMatch(match);
            return await _context.Set<T>().Where(match).ToListAsync();
        }

        public int Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            return _context.SaveChanges();
        }

        public async Task<int> DeleteAsyn(T entity)
        {
            _context.Set<T>().Remove(entity);
            return await _context.SaveChangesAsync();
        }
        //TODO:change to DBset
        public int Update(T t, Expression<Func<T, bool>> match)
        {
            if (t == null)
                return 0;
            T exist = _context.Set<T>().Find(match);
            if (exist == null)
            {
                return 0;
            }
            if (t is BaseEntity baseEntity)
            {
                baseEntity.UpdatedAt = DateTime.UtcNow;
            }
            _context.Entry(exist).CurrentValues.SetValues(t);
            return _context.SaveChanges();

        }
        //TODO:change to DBset
        public async Task<int> UpdateAsyn(T t, object key)
        {

            if (t == null)
                return 0;

            T exist = await _context.Set<T>().FindAsync(key);
            if (exist == null)
            {
                return 0;
            }
            if (t is BaseEntity baseEntity)
            {
                baseEntity.UpdatedAt = DateTime.UtcNow;
            }
            _context.Entry(exist).CurrentValues.SetValues(t);
            return await _context.SaveChangesAsync();
        }

        //TODO:change to DBset
        public int Count()
        {
            var query = _context.Set<T>().AsQueryable();

            if (typeof(BaseEntity).IsAssignableFrom(typeof(T)))
            {
                var parameter = Expression.Parameter(typeof(T), "z");
                var property = Expression.Property(parameter, nameof(BaseEntity.CreatedById));
                var userIdConst = Expression.Constant(userId);
                var body = Expression.Equal(property, userIdConst);
                var lambda = Expression.Lambda<Func<T, bool>>(body, parameter);

                query = query.Where(lambda);
            }

            return query.Count();
        }
        //TODO:change to DBset
        public async Task<int> CountAsync()
        {
            var query = _context.Set<T>().AsQueryable();

            if (typeof(BaseEntity).IsAssignableFrom(typeof(T)))
            {
                var parameter = Expression.Parameter(typeof(T), "z");
                var property = Expression.Property(parameter, nameof(BaseEntity.CreatedById));
                var userIdConst = Expression.Constant(userId);
                var body = Expression.Equal(property, userIdConst);
                var lambda = Expression.Lambda<Func<T, bool>>(body, parameter);

                query = query.Where(lambda);
            }
            return await query.CountAsync();
        }

        public void Save()
        {

            _context.SaveChanges();
        }
        //TODO:change to _context to all DBset
        public async Task<int> SaveAsync()
        {
            var i = await _context.SaveChangesAsync();
            return i;
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            predicate = AddUserIdCheckInMatch(predicate);
            IQueryable<T> query = _context.Set<T>().Where(predicate);
            return query;
        }

        public async Task<ICollection<T>> FindByAsyn(Expression<Func<T, bool>> predicate)
        {
            predicate = AddUserIdCheckInMatch(predicate);
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        private bool disposed = false;
        protected void Dispose(bool disposing)
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
