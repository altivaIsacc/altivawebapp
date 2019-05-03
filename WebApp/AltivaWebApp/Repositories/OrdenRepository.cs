using AltivaWebApp.Context;
using AltivaWebApp.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public class OrdenRepository: BaseRepository<TbPrOrden>, IOrdenRepository     
    {
        public OrdenRepository(EmpresasContext context) : base(context)
        {

        }

        public IList<TbPrOrden> GetAllOrdenes()
        {
            try
            {
                return context.TbPrOrden.Include(o => o.IdProveedorNavigation).Include(o => o.TbPrOrdenDetalle).ThenInclude(od => od.IdInventarioNavigation).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public TbPrOrden GetOrdenById(int id)
        {
            try
            {
                return context.TbPrOrden.Include(o => o.IdProveedorNavigation).FirstOrDefault(o => o.Id == id);
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public TbPrOrden GetAllOrdenDetalleByOrdenId(int id)
        {
            try
            {
                return context.TbPrOrden.Include(o => o.TbPrOrdenDetalle).ThenInclude(od => od.IdInventarioNavigation).FirstOrDefault(o => o.Id == id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool SaveOrdenDetalle(IList<TbPrOrdenDetalle> domain)
        {
            try
            {
                context.TbPrOrdenDetalle.AddRange(domain);
                context.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteOrdenDetalle(IList<TbPrOrdenDetalle> domain)
        {
            try
            {
                context.TbPrOrdenDetalle.RemoveRange(domain);
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
