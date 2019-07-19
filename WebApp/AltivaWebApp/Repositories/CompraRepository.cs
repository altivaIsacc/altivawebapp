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
        public IList<TbPrCompra> GetAllGastos()
        {

            /* var Gastos = new List<TbPrCompra>();
              foreach (var i in context.TbPrCompra)
              {
                  foreach (var item in context.TbCpComprasDetalleServicio)
                  {
                      if(i.Id == item.IdCompra)
                      {
                        var  gasto = context.TbPrCompra.FirstOrDefault(c => c.Id == item.IdCompra);
                          Gastos.Add(gasto);
                      }
                  }

              }*/

            var Gastos = context.TbPrCompra.Where(c => c.TbCpComprasDetalleServicio.Any(d => d.IdCompra == c.Id))
                .Include(c => c.IdContactoNavigation)
                .Select(c => new TbPrCompra
                {
                    Id = c.Id,
                    IdContacto = c.IdContacto,
                    NumeroDocumento = c.NumeroDocumento,
                    TipoDocumento = c.TipoDocumento,
                    FechaDocumento = c.FechaDocumento,
                    FechaCreacion = c.FechaCreacion,
                    IdMoneda = c.IdMoneda,
                    IdContactoNavigation = c.IdContactoNavigation

                }).ToList();


            //var Gastos = context.TbPrCompra.Include(c => c.IdContactoNavigation).Where(c => c.TbCpComprasDetalleServicio.Any(d => d.IdCompra == c.Id)).ToList();

            //var Gastos = context.TbPrCompra.FromSql(" select * from tb_PR_Compra as c " +
            // " where c.Id = Any(select cds.IdCompra from tb_CP_ComprasDetalleServicio as cds)"
            //    ).ToList();



            return Gastos;



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

       

        public long IdUltimoDocumento()
        {
            return context.TbPrCompra.Select(c => c.Id).LastOrDefault();
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

        public TbPrCompra GetCompraByIdWithoutD(int id)
        {
            try
            {
                return context.TbPrCompra.FirstOrDefault(c => c.Id == id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TbPrCompra GetCompraByDocumento(string nDoc, string tipoDoc, long idProveedor)
        {
            try
            {
                return context.TbPrCompra.AsNoTracking().FirstOrDefault(c => c.NumeroDocumento == nDoc && c.TipoDocumento == tipoDoc && c.IdContacto == idProveedor);
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
        public IList<TbCpComprasDetalleServicio> GetAllComprasDetalleServicioByCompraId(int id)
        {
            try
            {
                return context.TbCpComprasDetalleServicio.Where(c => c.IdCompraNavigation.Id == id).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TbPrCompraDetalle GetCompraDetalleById(long id)
        {
            try
            {
                return context.TbPrCompraDetalle.Include(c => c.IdCompraNavigation).FirstOrDefault(c => c.Id == id);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public TbCpComprasDetalleServicio GetComprasDetalleServicioById(long id)
        {
            try
            {
                return context.TbCpComprasDetalleServicio.Include(c => c.IdCompraNavigation).FirstOrDefault(c => c.IdCompra == id);
            }
            catch (Exception)
            {

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
            catch (Exception)
            {

                throw;
            }
        }
        public TbCpComprasDetalleServicio SaveComprasDetalleServicio(TbCpComprasDetalleServicio domain)
        {
            try
            {
                context.TbCpComprasDetalleServicio.Add(domain);
                context.SaveChanges();

                return domain;
            }
            catch (Exception)
            {

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
            catch (Exception)
            {

                throw;
            }
        }
        public bool UpdateComprasDetalleServicio(IList<TbCpComprasDetalleServicio> domain)
        {
            try
            {
                context.TbCpComprasDetalleServicio.UpdateRange(domain);
                context.SaveChanges();

                return true;
            }
            catch (Exception)
            {

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
            catch (Exception)
            {

                throw;
            }
        }
        public bool DeleteComprasDetalleServicio(TbCpComprasDetalleServicio domain)
        {
            try
            {
                context.TbCpComprasDetalleServicio.Remove(domain);
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
