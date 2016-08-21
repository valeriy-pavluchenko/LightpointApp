using LightpointApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LightpointApp.BusinessLogic.Interfaces
{
    public interface IRepository<TEntity>
        where TEntity : BaseEntity
    {
        IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params string[] includeProperties);

        TEntity GetById(int id);

        void Insert(TEntity entity);

        void Update(TEntity entityToUpdate);

        void Delete(int id);

        void Delete(TEntity entityToDelete);
    }
}
