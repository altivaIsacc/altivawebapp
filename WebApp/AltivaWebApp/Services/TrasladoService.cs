using AltivaWebApp.Domains;
using AltivaWebApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Services
{
    public class TrasladoService : ITrasladoService
    {
        private readonly ITrasladoRepository repository;

        public TrasladoService(ITrasladoRepository repository) {
            this.repository = repository;
        }

        public bool Delete(TbPrTraslado domain)
        {
            return repository.Delete(domain);
        }

        public void DeleteTrasladoInventario(IList<long> id)
        {
            repository.DeleteTrasladoInventario(id);
        }

        //si
        public IList<TbPrTraslado> GetAllTraslado()
        {
            return repository.GetAllTraslado();
        }

        //si
        public TbPrTraslado GetTrasladoById(long id)
        {
            return repository.GetTrasladoById(id);
        }

        //si
        public TbPrTraslado Save(TbPrTraslado domain)
        {
            return repository.Save(domain);
        }

        //si
        public bool SaveTrasladoInventario(IList<TbPrTrasladoInventario> domain)
        {
            return repository.SaveTrasladoInventario(domain);
        }

        public TbPrTraslado Update(TbPrTraslado domain)
        {
            return repository.Update(domain);
        }

        //si
        public bool UpdateTrasladoInventario(IList<TbPrTrasladoInventario> domain)
        {
            return repository.UpdateTrasladoInventario(domain);
        }

        public IList<TbPrTraslado> GetTrasladosSinAnular()
        {
            return repository.GetTrasladosSinAnular();
        }
    }
}
