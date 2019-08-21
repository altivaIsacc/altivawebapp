using AltivaWebApp.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace AltivaWebApp.Repositories
{
    public class BaseRepository<TEntity>
     where TEntity : class
    {

        protected readonly EmpresasContext context;
        

        protected readonly DbSet<TEntity> dbSet;

        public BaseRepository(EmpresasContext context)
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
                AltivaLog.Log.Insertar(ex.ToString(), "Error");

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
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");

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
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
               
            }
            
        }
    }
}
