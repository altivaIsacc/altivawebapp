using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Context;
using AltivaWebApp.Domains;
using AltivaWebApp.GEDomain;
using AltivaWebApp.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace AltivaWebApp.Repositories
{
    public class MonedaRepository : BaseRepositoryGE<TbSeMoneda>, IMonedaRepository
    {
        public MonedaRepository(GrupoEmpresarialContext context) : base(context)
        {
        }



        public IList<TbSeMoneda> SaveMoneda(IList<TbSeMoneda> domain)
        {
            try
            {
                context.TbSeMoneda.AddRange(domain);
                context.SaveChanges();

                return domain;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IList<TbSeMoneda> UpdateMoneda(IList<TbSeMoneda> domain)
        {
            try
            {
                context.TbSeMoneda.UpdateRange(domain);
                context.SaveChanges();

                return domain;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TbSeHistorialMoneda GetHMById(long id)
        {
            return context.TbSeHistorialMoneda.FirstOrDefault(h => h.Id == id);
        }

        public IList<TbSeHistorialMoneda> GetAllHMPorMoneda(int codigo)
        {
            try
            {
               return context.TbSeHistorialMoneda.Include(m =>m.CodigoMonedaNavigation)
                    .Include(m => m.IdUsuarioNavigation)
                    .Select(m => new TbSeHistorialMoneda
                    {
                        CodigoMoneda = m.CodigoMoneda,
                        CodigoMonedaNavigation = new TbSeMoneda
                        {
                            Nombre = m.CodigoMonedaNavigation.Nombre,
                            Simbolo = m.CodigoMonedaNavigation.Simbolo
                        },
                        Fecha = m.Fecha,
                        Id = m.Id,
                        IdUsuario = m.IdUsuario,
                        ValorCompra = m.ValorCompra,
                        ValorVenta = m.ValorVenta,
                        IdUsuarioNavigation = new TbSeUsuario
                        {
                            Id = m.IdUsuarioNavigation.Id,
                            Nombre = m.IdUsuarioNavigation.Nombre,
                            Codigo = m.IdUsuarioNavigation.Codigo
                        }
                    })
                    .Where(m => m.CodigoMoneda == codigo).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TbSeHistorialMoneda CrearHistorialMonedaSingle(TbSeHistorialMoneda domain)
        {
            try
            {
                var historial = context.TbSeHistorialMoneda.Include(h => h.CodigoMonedaNavigation).FirstOrDefault(h => h.CodigoMoneda == domain.CodigoMoneda && h.Fecha == domain.Fecha);
                if(historial == null)
                    context.TbSeHistorialMoneda.Add(domain);
                else
                {
                    historial.ValorCompra = domain.ValorCompra;
                    historial.ValorVenta = domain.ValorVenta;

                    var date = DateTime.Now;
                    
                    if (historial.Fecha == date.Date)
                    {
                        historial.CodigoMonedaNavigation.ValorCompra = domain.ValorCompra;
                        historial.CodigoMonedaNavigation.ValorVenta = domain.ValorVenta;
                    }
                        

                }
                context.SaveChanges();
                return domain;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IList<TbSeHistorialMoneda> CrearHistorialMoneda(IList<TbSeHistorialMoneda> historial)
        {
            try
            {
                var date = DateTime.Now;
                var hEuro = context.TbSeHistorialMoneda.FirstOrDefault(h => h.Fecha == date.Date && h.CodigoMoneda == 3);
                var hDolar = context.TbSeHistorialMoneda.FirstOrDefault(h => h.Fecha == date.Date && h.CodigoMoneda == 2);

                if (hEuro == null && hDolar == null)
                    context.TbSeHistorialMoneda.AddRange(historial);
                else if(hEuro != null && hDolar == null)
                {
                    context.TbSeHistorialMoneda.Add(historial.First());
                    hEuro.ValorCompra = historial.Last().ValorCompra;
                    hEuro.ValorVenta = historial.Last().ValorVenta;
                }
                else if(hEuro == null && hDolar != null)
                {
                    context.TbSeHistorialMoneda.Add(historial.Last());
                    hDolar.ValorCompra = historial.First().ValorCompra;
                    hDolar.ValorVenta = historial.First().ValorVenta;
                }
                else if(hEuro != null && hDolar != null)
                {
                    hEuro.ValorCompra = historial.Last().ValorCompra;
                    hEuro.ValorVenta = historial.Last().ValorVenta;
                    hDolar.ValorCompra = historial.First().ValorCompra;
                    hDolar.ValorVenta = historial.First().ValorVenta;
                }

                context.SaveChanges();
                return historial;
            }
            catch (Exception)
            {

                throw;
            }
            
            
        }


        public TbSeHistorialMoneda EditarHistorialMoneda(TbSeHistorialMoneda historial)
        {
            try
            {
                var date = DateTime.Now;

                context.TbSeHistorialMoneda.Update(historial);
                if(historial.Fecha == date.Date)
                {
                    var moneda = context.TbSeMoneda.FirstOrDefault(m => m.Codigo == historial.CodigoMoneda);
                    moneda.ValorCompra = historial.ValorCompra;
                    moneda.ValorVenta = historial.ValorVenta;
                }
                

                context.SaveChanges();

                return historial;
            }
            catch (Exception)
            {
                throw;
            }
            

            
        }

        public TbSeMoneda GetMonedaById(int idMoneda)
        {
            return context.TbSeMoneda.Find(idMoneda);
        }

    }
}
