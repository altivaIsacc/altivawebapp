using AltivaWebApp.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace AltivaWebApp.Repositories
{
    public class BaseContaRepository<TEntity>
     where TEntity : class
    {

        protected readonly BaseConta context;


        protected readonly DbSet<TEntity> dbSet;

        public BaseContaRepository(BaseConta context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }
        public virtual IList<TEntity> GetAll()

        {
            return dbSet.ToList();
        }
        public virtual TEntity Save(TEntity entity)

        {
            try
            {
                dbSet.Add(entity);
                context.SaveChanges();
                return entity;

            }
            catch (Exception ex)

            {
                throw ex;
            }

        }
        public virtual TEntity Update(TEntity entity)

        {
            try
            {
                dbSet.Attach(entity);
                context.Entry(entity).State = EntityState.Modified;

                context.SaveChanges();
                return entity;
            }
            catch (Exception)
            {
                throw;
            }


        }
        public virtual bool Delete(TEntity entity)
        {
            try
            {
                if (context.Entry(entity).State == EntityState.Detached)
                {
                    dbSet.Attach(entity);
                }
                dbSet.Remove(entity);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
