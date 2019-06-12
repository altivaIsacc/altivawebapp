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

        public IList<TbSeHistorialMoneda> CrearHistorialMoneda(IList<TbSeHistorialMoneda> historial)
        {
            try
            {
                context.TbSeHistorialMoneda.AddRange(historial);
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
                context.TbSeHistorialMoneda.Update(historial);
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
