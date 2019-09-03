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

        public TrasladoService(ITrasladoRepository repository)
        {
            this.repository = repository;
        }


       
        public TbPrTraslado Save(TbPrTraslado domain)
        {
            return repository.Save(domain);
        }

        public TbPrTraslado Update(TbPrTraslado domain)
        {
            return repository.Update(domain);
        }

        public bool Delete(TbPrTraslado domain)
        {
            return repository.Delete(domain);
        }
      
        public IList<TbPrTraslado> GetAllTraslado()
        {
            return repository.GetAllTraslado();
        }
      
        public TbPrTraslado GetTrasladoById(long id)
        {
            return repository.GetTrasladoById(id);
        }

        public void DeleteTrasladoInventario(IList<long> id)
        {
            repository.DeleteTrasladoInventario(id);
        }

        public IList<TbPrTrasladoInventario> SaveOrUpdateTrasladoInventario(IList<TbPrTrasladoInventario> domain)
        {
            return repository.SaveOrUpdateTrasladoInventario(domain);
        }

        public IList<TbPrTraslado> GetTrasladosSinAnular()
        {
            return repository.GetTrasladosSinAnular();
        }

        public TbPrTraslado GetTrasladoForKardex(int id, IList<long> idDetalles)
        {
            return repository.GetTrasladoForKardex(id, idDetalles);
        }



    }
}
