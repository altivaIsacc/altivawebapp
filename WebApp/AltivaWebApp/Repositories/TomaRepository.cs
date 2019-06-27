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


        public TbPrToma CombinarTomas(int id, IList<int> domain)
        {
            var model = context.TbPrToma.Include(t => t.TbPrTomaDetalle).Where(r => domain.Any(_id => _id == r.Id)).ToList();

            var toma = model.FirstOrDefault(t => t.Id == id);

            var nuevaToma = new TbPrToma
            {
                Anulado = toma.Anulado,
                Borrador = toma.Borrador,
                Id = 0,
                EsInicial = toma.EsInicial,
                FechaCreacion = toma.FechaCreacion,
                FechaToma = toma.FechaToma,
                IdBodega = toma.IdBodega,
                IdUsuarioCreacion = toma.IdUsuarioCreacion,
                Ordenado = toma.Ordenado
            };

            context.Add(nuevaToma);

            //nuevaToma.TbPrTomaDetalle = toma.TbPrTomaDetalle.Select(t => new TbPrTomaDetalle {
            //    CostoPromedio = t.CostoPromedio,
            //    Toma =t.Toma,
            //    Id = t.Id,
            //    Existencia = t.Existencia,
            //    Entradas = t.Entradas,
            //    IdInventario = t.IdInventario,
            //    IdInventarioNavigation = null,
            //    IdToma = 0,
            //    IdTomaNavigation = null,
            //    Inicial = t.Inicial,
            //    Salidas = t.Salidas

            //}).ToList();

            nuevaToma.TbPrTomaDetalle = toma.TbPrTomaDetalle;

            foreach (var item in nuevaToma.TbPrTomaDetalle)
            {
                item.IdToma = nuevaToma.Id;
                //item.Toma = 0;
            }

            var detalles = new List<TbPrTomaDetalle>();

            foreach (var item in model)
            {
                foreach (var i in item.TbPrTomaDetalle)
                {
                    detalles.Add(i);
                }
            }


            foreach (var i in nuevaToma.TbPrTomaDetalle)
            {
                i.Toma = detalles.Where(d => d.IdInventario == i.IdInventario).Sum(d => d.Toma);
            }

            context.TbPrTomaDetalle.UpdateRange(nuevaToma.TbPrTomaDetalle);

            context.RemoveRange(detalles.Where(d => d.IdToma != nuevaToma.Id));
            context.RemoveRange(model);

            context.SaveChanges();

            return nuevaToma;
        }

        public IList<TbPrToma> GetAllTomasByIds(IList<int> domain)
        {
            return context.TbPrToma.Include(t => t.TbPrTomaDetalle).Where(r => domain.Any(id => id == r.Id)).ToList();
        }
        public TbPrToma GetTomaByID(long id)
        {
            return context.TbPrToma.FirstOrDefault(t => t.Id == id);
        }

        public bool ExisteTomaInicial(int idBodega)
        {
            return context.TbPrToma.Any(t => t.Anulado == false && t.Borrador == false && t.EsInicial == true && t.IdBodega == idBodega);
        }

        public IList<TbPrToma> GetCombinables(int idBodega)
        {
            return context.TbPrToma.Include(t => t.IdBodegaNavigation).Where(t => t.Borrador == true && t.Anulado == false && t.IdBodega == idBodega).Select(t => new TbPrToma
            {

                Anulado = t.Anulado,
                Borrador = t.Borrador,
                EsInicial = t.EsInicial,
                FechaCreacion = t.FechaCreacion,
                FechaToma = t.FechaToma,
                Id = t.Id,
                IdBodega = t.IdBodega,
                IdBodegaNavigation = new TbPrBodega
                {
                    Id = t.IdBodegaNavigation.Id,
                    Nombre = t.IdBodegaNavigation.Nombre
                },
                IdUsuarioCreacion = t.IdUsuarioCreacion,
                Ordenado = t.Ordenado,
                TbPrTomaDetalle = null

            }).ToList();
        }

        public IList<TbPrToma> GetAllTomaConBodega()
        {

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
            return context.TbPrTomaDetalle.Include(i => i.IdInventarioNavigation).Where(t => t.IdToma == id).ToList();
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

        public double GetEntradas(TbPrAjusteInventario ai)
        {
            double mov = 0;

            if (ai.Movimiento)
                mov = ai.Cantidad;
            return mov;
        }

        public double GetSalidas(TbPrAjusteInventario ai)
        {
            double mov = 0;

            if (!ai.Movimiento)
                mov = ai.Cantidad;
            return mov;
        }

        public double GetInicial(IList<TbPrTomaDetalle> toma, long idInventario, DateTime fecha)
        {
            //&& t.IdTomaNavigation.Anulado == false && t.IdTomaNavigation.Borrador == false
            var _toma = toma.FirstOrDefault(t => t.IdTomaNavigation.FechaToma < fecha && t.IdInventario == idInventario);
            if (_toma == null)
                return 0;
            else
                return _toma.Toma;

        }

        public DateTime GetUltimaFechaToma(IList<TbPrTomaDetalle> toma, long idInventario)
        {
            if (toma.Any(t => t.IdInventario == idInventario))
            {
                var _fecha = toma.FirstOrDefault(t => t.IdInventario == idInventario).IdTomaNavigation.FechaCreacion;
                if (_fecha == null)
                    _fecha = DateTime.MinValue;
                return _fecha;
            }
            else
                return DateTime.MinValue;

        }

        public IList<TbPrTomaDetalle> GenerateTD(TbPrToma domain)
        {
            var tomaDetalle = new List<TbPrTomaDetalle>();
            var todoTD = new List<TbPrTomaDetalle>();

            var idList = new List<long>
            {
                0
            };

            //var ultimaFecha = context.TbPrTomaDetalle.Include(t => t.IdTomaNavigation)..Where(t => t.Borrador == false && t.Anulado == false);

            var ultimaTd = context.TbPrTomaDetalle.Include(t => t.IdTomaNavigation).OrderByDescending(t => t.IdTomaNavigation.FechaToma).Where(t => t.IdTomaNavigation.Borrador == false && t.IdTomaNavigation.Anulado == false && t.IdTomaNavigation.IdBodega == domain.IdBodega).ToList();


            var tdXAjuste = context.TbPrAjusteInventario
                .Include(a => a.IdAjusteNavigation)
                .Include(a => a.IdInventarioNavigation)
                    .ThenInclude(i => i.TbPrInventarioBodega)
                 .Where(a => a.IdAjusteNavigation.IdBodega == domain.IdBodega && a.IdAjusteNavigation.Anulada == false && a.IdAjusteNavigation.FechaCreacion > GetUltimaFechaToma(ultimaTd, a.IdInventario) && a.IdAjusteNavigation.FechaCreacion < DateTime.Now)

                 .Select(td => new TbPrTomaDetalle
                 {

                     Existencia = td.IdInventarioNavigation.TbPrInventarioBodega.FirstOrDefault(i => i.IdInventario == td.IdInventario).ExistenciaBodega,
                     IdInventario = td.IdInventario,
                     CostoPromedio = td.IdInventarioNavigation.TbPrInventarioBodega.FirstOrDefault(i => i.IdInventario == td.IdInventario).CostoPromedioBodega,
                     Entradas = GetEntradas(td),
                     Salidas = GetSalidas(td),
                     Inicial = 0,
                     Toma = 0,
                     IdInventarioNavigation = td.IdInventarioNavigation

                 }).ToList();




            todoTD.AddRange(tdXAjuste);


            var tdXCompra = context.TbPrCompraDetalle
                 .Include(c => c.IdCompraNavigation)
                 .Include(a => a.IdInventarioNavigation)
                    .ThenInclude(i => i.TbPrInventarioBodega)
                 .Where(c => c.IdBodega == domain.IdBodega && c.IdCompraNavigation.Borrador == false && c.IdCompraNavigation.Anulado == false && c.IdCompraNavigation.FechaCreacion > GetUltimaFechaToma(ultimaTd, c.IdInventario) && c.IdCompraNavigation.FechaCreacion < DateTime.Now)
                 .Select(td => new TbPrTomaDetalle
                 {

                     Existencia = td.IdInventarioNavigation.TbPrInventarioBodega.FirstOrDefault(i => i.IdInventario == td.IdInventario).ExistenciaBodega,
                     IdInventario = td.IdInventario,
                     CostoPromedio = td.IdInventarioNavigation.TbPrInventarioBodega.FirstOrDefault(i => i.IdInventario == td.IdInventario).CostoPromedioBodega,
                     Entradas = td.Cantidad,
                     Salidas = 0,
                     Inicial = 0,
                     Toma = 0,
                     IdInventarioNavigation = td.IdInventarioNavigation

                 }).ToList();


            todoTD.AddRange(tdXCompra);


            var tdXReq = context.TbPrRequisicionDetalle
                 .Include(rd => rd.IdRequisicionNavigation)
                 .Include(a => a.IdInventarioNavigation)
                    .ThenInclude(i => i.TbPrInventarioBodega)
                 .Where(rd => rd.IdRequisicionNavigation.IdBodega == domain.IdBodega && rd.IdRequisicionNavigation.Anulado == false && rd.IdRequisicionNavigation.FechaCreacion > GetUltimaFechaToma(ultimaTd, rd.IdInventario) && rd.IdRequisicionNavigation.FechaCreacion < DateTime.Now)

                 .Select(td => new TbPrTomaDetalle
                 {

                     Existencia = td.IdInventarioNavigation.TbPrInventarioBodega.FirstOrDefault(i => i.IdInventario == td.IdInventario).ExistenciaBodega,
                     IdInventario = td.IdInventario,
                     CostoPromedio = td.IdInventarioNavigation.TbPrInventarioBodega.FirstOrDefault(i => i.IdInventario == td.IdInventario).CostoPromedioBodega,
                     Entradas = 0,
                     Salidas = td.Cantidad,
                     Inicial = 0,
                     Toma = 0,
                     IdInventarioNavigation = td.IdInventarioNavigation

                 }).ToList();


            todoTD.AddRange(tdXReq);

            foreach (var item in todoTD)
            {
                if (!idList.Any(id => id == item.IdInventario))
                {
                    var arrayTD = todoTD.Where(td => td.IdInventario == item.IdInventario);
                    var tdAux = new TbPrTomaDetalle
                    {
                        CostoPromedio = item.CostoPromedio,
                        Entradas = 0,
                        Salidas = 0,
                        Existencia = item.Existencia,
                        Inicial = GetInicial(ultimaTd, item.IdInventario, domain.FechaToma),
                        Toma = item.Toma,
                        IdInventarioNavigation = item.IdInventarioNavigation,
                        IdInventario = item.IdInventario
                    };

                    foreach (var i in arrayTD)
                    {
                        tdAux.Entradas += i.Entradas;
                        tdAux.Salidas += i.Salidas;
                    }
                    tomaDetalle.Add(tdAux);
                    idList.Add(item.IdInventario);
                }

            }


            return tomaDetalle;
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

        public bool DeleteDetalles(IList<TbPrTomaDetalle> domain)
        {
            try
            {
                context.TbPrTomaDetalle.RemoveRange(domain);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public bool DeleteTomas(IList<TbPrToma> domain)
        {
            try
            {
                context.TbPrToma.RemoveRange(domain);
                context.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TbPrToma GetTomaByIDCompleto(long id)
        {
            return context.TbPrToma.Include(t => t.TbPrTomaDetalle).ThenInclude(i => i.IdInventarioNavigation).ThenInclude(b => b.TbPrInventarioBodega).FirstOrDefault(t => t.Id == id);
        }

        public bool TieneToma(DateTime fechaDoc)
        {
            return context.TbPrToma.Any(t => t.FechaCreacion >= fechaDoc && t.Borrador == false && t.Anulado == false);
        }

        public void AnularTomasBorrador(long id)
        {
            try
            {
                var tomas = context.TbPrToma.Where(t => t.Id != id && t.Borrador == true && t.Anulado == false).ToList();
                foreach (var item in tomas)
                {
                    item.Anulado = true;
                }

                context.SaveChanges();


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
