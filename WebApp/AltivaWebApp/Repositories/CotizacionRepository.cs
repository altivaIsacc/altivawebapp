using AltivaWebApp.Context;
using AltivaWebApp.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public class CotizacionRepository:BaseRepository<TbFaCotizacion>, ICotizacionRepository
    {
        public CotizacionRepository(EmpresasContext context): base(context)
        {
         
        }
     
        public IList<TbFaCotizacion> GetInfoCotizacion()
        {
            try
            {
                return context.TbFaCotizacion.Include(a => a.IdClienteNavigation).ToList();
                                
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }
        }

        public IList<TbFaCotizacionDetalle> GetAllCotizacionDetalleByIdCotizacion(int id)
        {
            try
            {
                return context.TbFaCotizacionDetalle.Where(c => c.IdCotizacionNavigation.IdCotizacion == id).ToList();
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }
        }

        public TbFaCotizacion GetCotizacionById(int id)
        {
            try
            {
                return context.TbFaCotizacion.FirstOrDefault(c => c.IdCotizacion == id);
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");

                throw;
            }
        }

        public IList<TbFaCotizacion> GetAllCotizacion()
        {
            try
            {
                return context.TbFaCotizacion
                                    .Include(a => a.IdClienteNavigation).ToList();
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }
        }

        public TbFaCotizacionDetalle SaveCotizacionDetalle(TbFaCotizacionDetalle domain)
        {
            try
            {
              

                context.TbFaCotizacionDetalle.Add(domain);
                context.SaveChanges();

                return domain;
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");

                throw;
            }
        }

        public bool DeleteCotizacionDetalle(TbFaCotizacionDetalle domain)
        {
            try
            {
                //var cd = context.TbPrCompraDetalle.FirstOrDefault(c => c.Id == idCD);
                context.TbFaCotizacionDetalle.Remove(domain);
                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }
        }

        public bool UpdateCotizacionDetalle(IList<TbFaCotizacionDetalle> domain)
        {
            try
            {
                context.TbFaCotizacionDetalle.UpdateRange(domain);
                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }
        }


        public TbFaCotizacionDetalle GetCotizacionDetalleById(long id)
        {
            try
            {
                return context.TbFaCotizacionDetalle.Include(c => c.IdCotizacionNavigation).FirstOrDefault(c => c.IdCotizacionDetalle == id);
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }
        }

    }
}
