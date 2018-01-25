using DCA.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCA.Persistence
{
    public class EntityFrameworkGenericRepository<TEntity> : IEntityFrameworkGenericRepository<TEntity> where TEntity : class
    {
        private readonly DCADbContext _dbContext;

        public EntityFrameworkGenericRepository(DCADbContext dbContext)
        {          

            _dbContext = dbContext;
            DbSet = _dbContext.Set<TEntity>();
        }

        protected IDbSet<TEntity> DbSet { get; set; }

        public void Add(TEntity entity)
        {
            var entry = _dbContext.Entry(entity);

            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                DbSet.Add(entity);
            }
        }

        public void Delete(TEntity entity)
        {
            var entry = _dbContext.Entry(entity);

            if (entry.State != EntityState.Deleted)
            {
                entry.State = EntityState.Deleted;
            }
            else
            {
                DbSet.Attach(entity);
                DbSet.Remove(entity);
            }
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(object id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public void Update(TEntity entity)
        {
            var entry = _dbContext.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }

            entry.State = EntityState.Modified;
        }
    }
}
