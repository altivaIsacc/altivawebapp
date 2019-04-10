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

        public void CrearMoneda(IList<TbSeMoneda> historial)
        {

            this.repository.CrearMoneda(historial);
        }

        public TbSeMoneda Create(TbSeMoneda domain)
        {
            return repository.Save(domain);
        }

        public void Delete(TbSeMoneda domain)
        {
            
        }

        public IList<TbSeMoneda> GetAll()
        {
            return repository.GetAll();
        }

        public TbSeMoneda GetMoneda(int id)
        {
            
                return repository.GetMonedaById(id);
           
        }

       
        public TbSeMoneda UpdateMoneda(TbSeMoneda domain)
        {
            return repository.Update(domain);
        }
    }
}
