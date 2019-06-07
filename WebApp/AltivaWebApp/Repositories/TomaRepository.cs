﻿using AltivaWebApp.Context;
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

        public bool ExisteTomaInicial()
        {
            return context.TbPrToma.Any(t => t.Anulado == false && t.Borrador == false && t.EsInicial == true);
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
            return context.TbPrTomaDetalle.Include(i=> i.IdInventarioNavigation).Where(t => t.IdToma == id).ToList();
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
            var _toma = toma.FirstOrDefault(t => t.IdTomaNavigation.FechaToma < fecha  && t.IdInventario == idInventario);
            if (_toma == null)
                return 0;
            else
                return _toma.Toma;

        }

        public DateTime GetUltimaFechaToma(IList<TbPrTomaDetalle> toma, long idInventario)
        {
            if(toma.Any(t => t.IdInventario == idInventario))
            {
                var _fecha = toma.FirstOrDefault(t => t.IdInventario == idInventario).IdTomaNavigation.FechaToma;
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
                 .Where(a => a.IdAjusteNavigation.IdBodega == domain.IdBodega && a.IdAjusteNavigation.Anulada == false && a.IdAjusteNavigation.FechaDocumento > GetUltimaFechaToma(ultimaTd, a.IdInventario) && a.IdAjusteNavigation.FechaDocumento < DateTime.Now)

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
                 .Where(c => c.IdBodega == domain.IdBodega && c.IdCompraNavigation.Borrador == false && c.IdCompraNavigation.Anulado == false && c.IdCompraNavigation.FechaDocumento > GetUltimaFechaToma(ultimaTd, c.IdInventario) && c.IdCompraNavigation.FechaDocumento < DateTime.Now)
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
                 .Where(rd => rd.IdRequisicionNavigation.IdBodega == domain.IdBodega && rd.IdRequisicionNavigation.Anulado == false && rd.IdRequisicionNavigation.Fecha > GetUltimaFechaToma(ultimaTd, rd.IdInventario) && rd.IdRequisicionNavigation.Fecha < DateTime.Now)

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

    }
}
