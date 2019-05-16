using System;
using System.Collections.Generic;
using AltivaWebApp.GEDomain;
using AltivaWebApp.ViewModels;
namespace AltivaWebApp.Repositories
{
    public interface IHistorialMonedaRepository
    {
        IList<TbSeHistorialMoneda> GetByDate(DateTime fecha);
       void ModificarHistoirial(List<TbSeHistorialMoneda> domain);
        TbSeHistorialMoneda Save(TbSeHistorialMoneda domain);
        TbSeHistorialMoneda GetById(long idHistorial);
        TbSeHistorialMoneda Update(TbSeHistorialMoneda domain);
        int Guardar(IList<TbSeHistorialMoneda> domain);
        void GuardarHistorial(IList<TbSeHistorialMoneda> historial);
     
        IList<TbSeHistorialMoneda> FiltrarByFecha(DateTime fecha1,DateTime fecha2);
        IList<TbSeHistorialMoneda> GetAll();
        IList<HistorialMonedaViewModel> GetAllByDate(DateTime fecha);
        IList<TbSeHistorialMoneda> GetHistoriaByIdMoneda(int id);
    }
}
