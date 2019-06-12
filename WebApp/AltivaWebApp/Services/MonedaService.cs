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
    public class MonedaService : IMonedaService
    {

         IMonedaRepository repository;

        public MonedaService(IMonedaRepository monedaRepository)
        {
            repository = monedaRepository;
        }

        public IList<TbSeHistorialMoneda> CrearHistorialMoneda(IList<TbSeHistorialMoneda> historial)
        {
            return repository.CrearHistorialMoneda(historial);
        }

        public TbSeHistorialMoneda EditarHistorialMoneda(TbSeHistorialMoneda historial)
        {
            return repository.EditarHistorialMoneda(historial);
        }

        public IList<TbSeMoneda> GetAll()
        {
            return repository.GetAll();
        }

        public IList<TbSeHistorialMoneda> GetAllHMPorMoneda(int codigo)
        {
            return repository.GetAllHMPorMoneda(codigo);
        }

        public TbSeMoneda GetMonedaById(int id)
        {
            return repository.GetMonedaById(id);
        }

        public IList<TbSeMoneda> SaveMoneda(IList<TbSeMoneda> domain)
        {
            return repository.SaveMoneda(domain);
        }

        public IList<TbSeMoneda> UpdateMoneda(IList<TbSeMoneda> domain)
        {
            return repository.UpdateMoneda(domain);
        }
    }
}
