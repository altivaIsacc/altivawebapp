using AltivaWebApp.Context;
using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public class MovimientoRepository: BaseRepository<TbFaMovimiento>, IMovimientoRepository
    {
        public MovimientoRepository(EmpresasContext context) : base(context)
        {

        }
        public TbFaMovimiento GetMovimientoById(long id)
        {
            try
            {
                return context.TbFaMovimiento.Include(t => t.IdTipoDocumentoNavigation).FirstOrDefault(o => o.IdMovimiento == id);
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }

        }
        public TbFaMovimiento GetMovimientoByNota(long id)
        {
            try
            {
                return context.TbFaMovimiento.Include(m => m.IdTipoDocumentoNavigation).FirstOrDefault(o => o.IdDocumento == id);
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }

        }
        public IList<TbFaMovimiento> GetAllMovimientos()
        {
            try
            {
                return context.TbFaMovimiento.ToList();
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }

        }
        public bool SaveMovimientoJustificante(IList<TbFaMovimientoJustificante> domain)
        {
            try
            {
                context.TbFaMovimientoJustificante.AddRange(domain);
                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");

                throw;
            }
        }

        public bool UpdateMovimientoJustificante(IList<TbFaMovimientoJustificante> domain)
        {
            try
            {
                context.TbFaMovimientoJustificante.UpdateRange(domain);
                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");

                throw;
            }
        }
        public IList<TbFaMovimientoJustificante> GetJustificantesByMovimientoId(long id)
        {
            try
            {
                return context.TbFaMovimientoJustificante.Where(o => o.IdMovimientoNavigation.IdMovimiento == id).ToList();
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");

                throw;
            }
        }
        public bool DeleteMovimientoJustificante(IList<int> domain, int idMovimiento)
        {
            try
            {
                var od = context.TbFaMovimiento.Include(o => o.TbFaMovimientoJustificante).FirstOrDefault(o => o.IdMovimiento == idMovimiento);

                var eliminados = new List<TbFaMovimientoJustificante>();

                foreach (var item in od.TbFaMovimientoJustificante)
                {
                    foreach (var i in domain)
                    {
                        if (item.IdMovimientoJustificante == i)
                            eliminados.Add(item);
                    }
                }

                context.TbFaMovimientoJustificante.RemoveRange(eliminados);
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
