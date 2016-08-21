using LightpointApp.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using LightpointApp.DataAccess.Contexts;
using System.Data.Entity;
using LightpointApp.DataAccess.Entities;

namespace LightpointApp.BusinessLogic.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected LightpointContext context;
        protected DbSet<TEntity> dbSet;

        public Repository(LightpointContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
                                        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                        params string[] includeProperties)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).AsEnumerable();
            }
            
            return query.AsEnumerable();
        }

        public TEntity GetById(int id)
        {
            return dbSet.Find(id);
        }

        public void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            var entry = context.Entry(entity);
            entry.State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var entity = dbSet.Find(id);
            Delete(entity);
        }

        public void Delete(TEntity entity)
        {
            var entry = context.Entry(entity);
            entry.State = EntityState.Deleted;
        }
    }
}
