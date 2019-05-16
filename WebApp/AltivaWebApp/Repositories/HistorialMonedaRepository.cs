using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Context;
using AltivaWebApp.GEDomain;
using AltivaWebApp.ViewModels;

namespace AltivaWebApp.Repositories
{
    public class HistorialMonedaRepository : BaseRepositoryGE<TbSeHistorialMoneda>, IHistorialMonedaRepository
    {
        public HistorialMonedaRepository(GrupoEmpresarialContext context) : base(context)
        {
        }

        

        public IList<TbSeHistorialMoneda> FiltrarByFecha(DateTime fecha1, DateTime fecha2)
        {
            var model = (from pu in context.TbSeHistorialMoneda
                       
                         where pu.Fecha >= fecha1  && pu.Fecha <= fecha2
                         select new TbSeHistorialMoneda
                         {
                             
                             CodigoMoneda = pu.CodigoMoneda,
                          
                             ValorCompra = pu.ValorCompra,
                             ValorVenta = pu.ValorVenta,
                             
                             Fecha = pu.Fecha
                         }

              ).ToList();
            return model;
        }
        public IList<TbSeHistorialMoneda> GetByDate(DateTime fecha)
        {

            var test1 = context.TbSeHistorialMoneda.Where(u => u.Fecha == fecha.Date).ToList();
            if (test1.Count() == 0)
            {
                return null;
            }
            else
            {
                var model = (from pu in context.TbSeHistorialMoneda
                             join p in context.TbSeMoneda on pu.CodigoMoneda equals p.Codigo

                             where pu.Fecha == fecha.Date
                             select new TbSeHistorialMoneda
                             {
                                 CodigoMoneda = pu.CodigoMoneda,

                                 ValorCompra = pu.ValorCompra,
                                 ValorVenta = pu.ValorVenta,
                                 IdUsuario = 23,
                                 Fecha = pu.Fecha
                             }

               ).GroupBy(u => u.Fecha).First().Take(3).ToList().ToList();

                //return model;
                //prueba = context.TbSeHistorialMoneda.Where(u => u.Fecha == fecha).GroupBy(u => u.Fecha).First().Take(3).ToList();
                return model;

            }
        }
            public IList<HistorialMonedaViewModel> GetAllByDate(DateTime fecha)
        {
           
          
           
            var test1 = context.TbSeHistorialMoneda.Where(u => u.Fecha == fecha).ToList();
            if (test1.Count() == 0 )
            {
                return null;
            }
            else
            {
                var model = (from pu in context.TbSeHistorialMoneda
                             join p in context.TbSeMoneda on pu.CodigoMoneda equals p.Codigo

                             where pu.Fecha == fecha
                             select new HistorialMonedaViewModel
                             {
                                 Id = pu.Id,
                                 Codigo = pu.CodigoMoneda,
                                 Nombre = p.Nombre,
                                   ValorCompra = pu.ValorCompra,
                                   ValorVenta = pu.ValorVenta,
                                 Simbolo = p.Simbolo,
                                 Fecha=pu.Fecha
    }

               ).GroupBy(u => u.Fecha).First().Take(3).ToList().ToList();

                //return model;
                //prueba = context.TbSeHistorialMoneda.Where(u => u.Fecha == fecha).GroupBy(u => u.Fecha).First().Take(3).ToList();
                return model;
            }
        
        }

      

       



        IList<TbSeHistorialMoneda> IHistorialMonedaRepository.GetAll()
        {
            throw new NotImplementedException();
        }

        IList<TbSeHistorialMoneda> IHistorialMonedaRepository.GetHistoriaByIdMoneda(int id)
        {
         
          return context.TbSeHistorialMoneda.Where(hm => hm.CodigoMoneda == id).ToList();
            
         
        }

        public int Guardar(IList<TbSeHistorialMoneda> domain)
        {
           // context.TbSeHistorialMoneda.AddRange(domain);
            return 1;
        }

        public void GuardarHistorial(IList<TbSeHistorialMoneda> historial)
        {
            context.TbSeHistorialMoneda.AddRange(historial);
            context.SaveChanges();
        }

        public TbSeHistorialMoneda GetById(long idHistorial)
        {
            return context.TbSeHistorialMoneda.Where(u => u.Id == idHistorial).FirstOrDefault();

        }

        

        public void ModificarHistoirial(List<TbSeHistorialMoneda> domain)
        {
            context.TbSeHistorialMoneda.UpdateRange(domain);
            context.SaveChanges();
        }
    }
}
