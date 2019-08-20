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
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");

                throw;
            }
        }

        public bool ExisteDocumento(string numDoc, string tipo, int idProveedor)
        {
            return context.TbPrCompra.Any(u => u.NumeroDocumento == numDoc && u.TipoDocumento == tipo && u.IdContacto == idProveedor );
        }

        public long IdUltimoDocumento()
        {
            return context.TbPrCompra.Select(c => c.Id).LastOrDefault();
        }

        public TbPrCompra GetCompraById(int id)
        {
            try
            {
                return context.TbPrCompra.AsNoTracking().Include(c => c.TbPrCompraDetalle).ThenInclude(cd => cd.IdInventarioNavigation).ThenInclude(i => i.TbPrInventarioBodega).FirstOrDefault(c => c.Id == id);
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }
        }

        public TbPrCompra GetCompraByIdWithoutD(int id)
        {
            try
            {
                return context.TbPrCompra.AsNoTracking().FirstOrDefault(c => c.Id == id);
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");

                throw;
            }
        }

        public TbPrCompra GetCompraByDocumento(string nDoc, string tipoDoc, long idProveedor)
        {
            try
            {
                return context.TbPrCompra.AsNoTracking().FirstOrDefault(c => c.NumeroDocumento == nDoc && c.TipoDocumento == tipoDoc && c.IdContacto == idProveedor);
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");

                throw;
            }
        }

        public IList<TbPrCompraDetalle> GetAllCompraDetalleByCompraId(int id)
        {
            try
            {
                return context.TbPrCompraDetalle.Where(c => c.IdCompraNavigation.Id == id).ToList();
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");

                throw;
            }
        }

        public TbPrCompraDetalle GetCompraDetalleById(long id)
        {
            try
            {
                return context.TbPrCompraDetalle.AsNoTracking().Include(c => c.IdCompraNavigation).Include(i => i.IdInventarioNavigation).ThenInclude(b => b.TbPrInventarioBodega).FirstOrDefault(c => c.Id == id);
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");

                throw;
            }
        }

        public TbPrCompraDetalle SaveCompraDetalle(TbPrCompraDetalle domain)
        {
            try
            {
                

                if(!ExisteRelacionInventarioBodega(domain.IdInventario, domain.IdBodega))
                {
                    var ib = new TbPrInventarioBodega {
                        ExistenciaBodega = 0,
                        CostoPromedioBodega = 0,
                        IdBodega = domain.IdBodega,
                        IdInventario = domain.IdInventario,
                        ExistenciaMaxima = 3,
                        ExistenciaMedia = 2,
                        ExistenciaMinima = 1,
                        SaldoBodega = 0,
                        UltimoCostoBodega = 0
                        
                    };
                    context.TbPrInventarioBodega.Add(ib);
                }

                context.TbPrCompraDetalle.Add(domain);
                context.SaveChanges();

                return domain;
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");

                throw;
            }
        }
        public bool ExisteRelacionInventarioBodega(long idInventario, long idBodega)
        {
            return context.TbPrInventarioBodega.Any(i => i.IdInventario == idInventario && i.IdBodega == idBodega);
        }
        public bool UpdateCompraDetalle(IList<TbPrCompraDetalle> domain)
        {
            try
            {
                context.TbPrCompraDetalle.UpdateRange(domain);
                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");

                throw;
            }
        }

        public bool DeleteCompraDetalle(TbPrCompraDetalle domain)
        {
            try
            {
                //var cd = context.TbPrCompraDetalle.FirstOrDefault(c => c.Id == idCD);
                context.TbPrCompraDetalle.Remove(domain);
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
