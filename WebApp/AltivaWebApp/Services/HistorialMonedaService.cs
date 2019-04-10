using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
using AltivaWebApp.Repositories;
using AltivaWebApp.GEDomain;

namespace AltivaWebApp.Services
{
    public class HistorialMonedaService : IHistorialMonedaService
    {
        IHistorialMonedaRepository historialMonedaRepository;

        public HistorialMonedaService(IHistorialMonedaRepository pIHistorialMonedaRespository)
        {
            this.historialMonedaRepository = pIHistorialMonedaRespository;

        }
        public TbSeHistorialMoneda Create(TbSeHistorialMoneda domain)
        {
            return historialMonedaRepository.Save(domain);
        }

        public IList<TbSeHistorialMoneda> FiltrarByFecha(DateTime fecha1, DateTime fecha2)
        {
            return historialMonedaRepository.FiltrarByFecha(fecha1,fecha2);
        }

        public IList<TbSeHistorialMoneda> GetAll()
        {
            throw new NotImplementedException();
        }

        public IList<HistorialMonedaViewModel> GetAllByFecha(DateTime fecha)
        {
            return historialMonedaRepository.GetAllByDate(fecha);
        }

        public IList<TbSeHistorialMoneda> GetByDate(DateTime fecha)
        {
            return historialMonedaRepository.GetByDate(fecha);
        }

        public IList<TbSeHistorialMoneda> GetHistorialById(int id)
        {
            return historialMonedaRepository.GetHistoriaByIdMoneda(id);
        }

        public int Guardar(IList<TbSeHistorialMoneda> domain)
        {
            int d = 0;
            if (historialMonedaRepository.Guardar(domain) == 1)
            {
                return 1;
            }
            return d;
        }

        public void GuardarHistorial(IList<TbSeHistorialMoneda> historial)
        {
            this.historialMonedaRepository.GuardarHistorial(historial);
        }

        public TbSeHistorialMoneda Update(TbSeHistorialMoneda domain)
        {
            throw new NotImplementedException();
        }

        
    }
}
