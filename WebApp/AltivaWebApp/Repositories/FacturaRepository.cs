using AltivaWebApp.Context;
using AltivaWebApp.Domains;
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
            catch (Exception)
            {

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
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteFacturaDetalle(IList<TbFdFacturaDetalle> domain)
        {
            try
            {
                context.TbFdFacturaDetalle.RemoveRange(domain);

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
