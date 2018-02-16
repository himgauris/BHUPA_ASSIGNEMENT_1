using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace BHUPA_ASSIGNEMENT_1.DAL
{
    public class CommonDBOperations<TEntity> where TEntity : class
    {
        internal ASS_EventUsersEntities context;
        internal DbSet<TEntity> dbSet;

        public CommonDBOperations(ASS_EventUsersEntities context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> GetAllRecords(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual void InsertRecord(TEntity entity)
        {
            dbSet.Add(entity);
            context.SaveChanges();
        }

        public virtual void UpdateRecord(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }
    }
}