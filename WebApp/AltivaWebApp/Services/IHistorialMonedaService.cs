using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.ViewModels;
using AltivaWebApp.Domains;
using AltivaWebApp.GEDomain;

namespace AltivaWebApp.Services
{
  public  interface IHistorialMonedaService
    {
        TbSeHistorialMoneda Create(TbSeHistorialMoneda domain);
        TbSeHistorialMoneda Update(TbSeHistorialMoneda domain);
        IList<TbSeHistorialMoneda> GetAll();
       int Guardar(IList<TbSeHistorialMoneda> domain);
         IList<TbSeHistorialMoneda> GetByDate(DateTime fecha);
        IList<TbSeHistorialMoneda> GetHistorialById(int id);
        IList<TbSeHistorialMoneda> FiltrarByFecha(DateTime fecha1,DateTime fecha2);
        IList<HistorialMonedaViewModel> GetAllByFecha(DateTime fecha);
        void GuardarHistorial(IList<TbSeHistorialMoneda> historial);
    }
}
