using AltivaWebApp.Context;
using AltivaWebApp.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public class TomaRepository : BaseRepository<TbPrToma>, ITomaRepository
    {
        public TomaRepository(EmpresasContext context) : base(context)
        {

        }

        public TbPrToma GetTomaByID(long id)
        {
            return context.TbPrToma.FirstOrDefault(t => t.Id == id);
        }

        public IList<TbPrToma> GetAllTomaConBodega()
        {
            //return context.TbPrToma.Include(t => t.IdBodegaNavigation).ToList();

            return (from t in context.TbPrToma
                    join b in context.TbPrBodega on t.IdBodega equals b.Id
                    select new TbPrToma
                    {
                        Id = t.Id,
                        IdBodega = t.IdBodega,
                        Anulado = t.Anulado,
                        Borrador = t.Borrador,
                        EsInicial = t.EsInicial,
                        FechaCreacion = t.FechaCreacion,
                        FechaToma = t.FechaToma,
                        Ordenado = t.Ordenado,
                        IdBodegaNavigation = new TbPrBodega
                        {
                            Id = b.Id,
                            Estado = b.Estado,
                            Nombre = b.Nombre,
                            UsuarioEncargado = b.UsuarioEncargado
                        },
                        IdUsuarioCreacion = t.IdUsuarioCreacion
                    }
                    ).ToList();

        }

        public IList<TbPrTomaDetalle> GetDetallesByTomaId(long id)
        {
            return context.TbPrTomaDetalle.Where(t => t.IdToma == id).ToList();
        }

        public IList<TbPrTomaDetalle> GetAllDetalleByIdD(IList<int> domain)
        {
            return context.TbPrTomaDetalle.Where(r => domain.Any(id => id == r.Id)).ToList();
        }

        public IList<TbPrTomaDetalle> SaveTomaDetalle(IList<TbPrTomaDetalle> domain)
        {
            try
            {
                context.AddRange(domain);
                context.SaveChanges();
                return domain;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IList<TbPrTomaDetalle> GenerateTD(TbPrToma domain)
        {
            var ultimaTd = new TbPrToma();
            ultimaTd = context.TbPrToma.LastOrDefault(t => t.Borrador == false);

            //var ultimoSaldo = (from td in context.TbPrTomaDetalle
            //                   join t in context.TbPrToma on td.IdToma equals t.Id
            //                   where t.Borrador == false
            //                   select new TbPrTomaDetalle{


            //                   }
            //                   ).ToList();

            var ultimoSaldo = new List<TbPrTomaDetalle>();
            ultimoSaldo = context.TbPrTomaDetalle.Where(t => t.IdTomaNavigation.Borrador == false).ToList();

            var tdXAjuste = (from a in context.TbPrAjuste
                             join ai in context.TbPrAjusteInventario on a.Id equals ai.IdAjuste
                             join b in context.TbPrBodega on a.IdBodega equals b.Id
                             join ib in context.TbPrInventarioBodega on b.Id equals ib.IdBodega
                             join i in context.TbPrInventario on ai.IdInventario equals i.IdInventario
                             join subf in context.TbPrFamilia on i.IdSubFamilia equals subf.IdFamilia
                             join f in context.TbPrFamilia on subf.IdFamilia equals f.Id
                             
                             where b.Id == domain.IdBodega  && a.Anulada == false // && a.FechaDocumento > ultimaTd.FechaToma
                             select  new TbPrTomaDetalle
                             {
                                 CostoPromedio = ib.CostoPromedioBodega,
                                 Entradas = a.TbPrAjusteInventario.Where(m => m.Movimiento == true).Count(),
                                 Salidas = a.TbPrAjusteInventario.Where(m => m.Movimiento == false).Count(),
                                 Existencia = ib.ExistenciaBodega,
                                 IdInventario = ib.IdInventario,
                                 Inicial = 0,//ultimoSaldo.FirstOrDefault(i => i.IdInventario == ib.IdInventario).Inicial,
                                 Toma = 0
                             }).ToList();

            //var tdXAjuste = (from b in context.TbPrBodega
            //                 join ib in context.TbPrInventarioBodega on b.Id equals ib.IdBodega
            //                 join a in context.TbPrAjuste on b.Id equals a.IdBodega
            //                 join ai in context.TbPrAjusteInventario on a.Id equals ai.IdAjuste
            //                 where b.Id == domain.IdBodega && a.FechaDocumento > ultimaTd.FechaToma && a.Anulada == false
            //                 select new TbPrTomaDetalle
            //                 {
            //                     CostoPromedio = ib.CostoPromedioBodega,
            //                     Entradas = 

            //                 }).ToList();

            //var tdXCompra = (from b in context.TbPrBodega
            //                 join ib in context.TbPrInventarioBodega on b.Id equals ib.IdBodega
            //                 join cd in context.TbPrCompraDetalle on b.Id equals cd.IdBodega
            //                 join c in context.TbPrCompra on cd.IdCompra equals c.Id
            //                 where b.Id == domain.IdBodega && c.FechaDocumento > ultimaTd.FechaToma
            //                 select new TbPrTomaDetalle
            //                 {


            //                 }).ToList();
            //var tdXReq = (from b in context.TbPrBodega
            //              join ib in context.TbPrInventarioBodega on b.Id equals ib.IdBodega
            //              join r in context.TbPrRequisicion on b.Id equals r.IdBodega
            //              join rd in context.TbPrRequisicionDetalle on r.Id equals rd.IdRequisicion

            //              where b.Id == domain.IdBodega && r.Fecha > ultimaTd.FechaToma
            //              select new TbPrTomaDetalle
            //              {


            //              }).ToList();




            return tdXAjuste;
        }

        public IList<TbPrTomaDetalle> EliminarTomaDetalle(IList<TbPrTomaDetalle> domain)
        {
            try
            {
                context.RemoveRange(domain);
                context.SaveChanges();
                return domain;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public IList<TbPrTomaDetalle> UpdateTomaDetalle(IList<TbPrTomaDetalle> domain)
        {
            try
            {
                context.UpdateRange(domain);
                context.SaveChanges();
                return domain;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
