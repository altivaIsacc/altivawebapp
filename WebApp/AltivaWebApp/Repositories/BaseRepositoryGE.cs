using AltivaWebApp.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace AltivaWebApp.Repositories
{
    public class BaseRepositoryGE<TEntity>
     where TEntity : class
    {

        protected readonly GrupoEmpresarialContext context;


        protected readonly DbSet<TEntity> dbSet;

        public BaseRepositoryGE(GrupoEmpresarialContext context)
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

                //ErrorManager.ErrorHandler.HandleError(ex);

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
                //return false;
                throw;

            }

        }
    }
}

