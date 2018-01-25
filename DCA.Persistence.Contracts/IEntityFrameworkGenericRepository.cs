using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCA.Persistence.Contracts
{
    public interface IEntityFrameworkGenericRepository<TEntity> 
        where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdAsync(object id);

        void Add(TEntity entity);       

        void Update(TEntity entity);

        void Delete(TEntity entity);
    }
}
