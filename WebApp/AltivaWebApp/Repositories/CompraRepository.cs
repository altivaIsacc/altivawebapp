using AltivaWebApp.Context;
using AltivaWebApp.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public class CompraRepository : BaseRepository<TbPrCompra>, ICompraRepository
    {
        public CompraRepository(EmpresasContext context)
            : base(context)
        {

        }

        public IList<TbPrCompra> GetAllCompras()
        {
            try
            {
                return context.TbPrCompra.Include(c => c.IdContactoNavigation).AsNoTracking().Include(c => c.TbPrCompraDetalle).ThenInclude(cd => cd.IdInventarioNavigation).AsNoTracking().ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool ExisteDocumento(string numDoc, string tipo, int idProveedor)
        {
            return context.TbPrCompra.Any(u => u.NumeroDocumento == numDoc && u.TipoDocumento == tipo && u.IdContacto == idProveedor );
        }

        public TbPrCompra GetCompraById(int id)
        {
            try
            {
                return context.TbPrCompra.Include(c => c.TbPrCompraDetalle).ThenInclude(cd => cd.IdInventarioNavigation).FirstOrDefault(c => c.Id == id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TbPrCompra GetCompraByDocumento(string nDoc, string tipoDoc)
        {
            try
            {
                return context.TbPrCompra.FirstOrDefault(c => c.NumeroDocumento == nDoc && c.TipoDocumento == tipoDoc);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IList<TbPrCompraDetalle> GetAllCompraDetalleByCompraId(int id)
        {
            try
            {
                return context.TbPrCompraDetalle.Where(c => c.IdCompraNavigation.Id == id).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool SaveCompraDetalle(IList<TbPrCompraDetalle> domain)
        {
            try
            {
                context.TbPrCompraDetalle.AddRange(domain);
                context.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool UpdateCompraDetalle(IList<TbPrCompraDetalle> domain)
        {
            try
            {
                context.TbPrCompraDetalle.UpdateRange(domain);
                context.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteCompraDetalle(IList<int> domain, int idCompra)
        {
            try
            {
                var cd = context.TbPrCompra.Include(o => o.TbPrCompraDetalle).FirstOrDefault(o => o.Id == idCompra);

                var eliminados = new List<TbPrCompraDetalle>();

                foreach (var item in cd.TbPrCompraDetalle)
                {
                    foreach (var i in domain)
                    {
                        if (item.Id == i)
                            eliminados.Add(item);
                    }
                }

                context.TbPrCompraDetalle.RemoveRange(eliminados);
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
