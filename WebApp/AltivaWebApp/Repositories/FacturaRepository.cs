using AltivaWebApp.Context;
using AltivaWebApp.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public class FacturaRepository: BaseRepository<TbFdFactura>, IFacturaRepository
    {
        public FacturaRepository(EmpresasContext context):base(context)
        {

        }

        public IList<TbFdFactura> GetAllFacturas()
        {
            var facturas = context.TbFdFactura.Include(c => c.IdClienteNavigation).ToList();

            foreach (var item in facturas)
            {
                item.IdClienteNavigation.TbFdFactura = null;
            }

            return facturas;
        }

        public TbFdFactura GetFacturaById(long id)
        {
            return context.TbFdFactura.FirstOrDefault(f => f.Id == id);
        }

        public IList<TbFdFacturaDetalle> GetFacturaDetalleById(long id)
        {
            return context.TbFdFacturaDetalle.Where(f => f.IdFactura == id).ToList();
        }

        public IList<TbFdFacturaDetalle> SaveFacturaDetalle(IList<TbFdFacturaDetalle> domain)
        {
            try
            {
                context.TbFdFacturaDetalle.AddRange(domain);

                context.SaveChanges();

                return domain;
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }
        }

        public IList<TbFdFacturaDetalle> UpdateFacturaDetalle(IList<TbFdFacturaDetalle> domain)
        {
            try
            {
                context.TbFdFacturaDetalle.UpdateRange(domain);

                context.SaveChanges();

                return domain;
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");

                throw;
            }
        }

        public bool DeleteFacturaDetalle(IList<long> domain)
        {
            try
            {
                //
                context.TbFdFacturaDetalle.RemoveRange(context.TbFdFacturaDetalle.Where(r => domain.Any(id => id == r.Id)));

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
