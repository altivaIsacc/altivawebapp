using AltivaWebApp.Domains;
using AltivaWebApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Services
{
    public class BodegaService: IBodegaService
    {
        IBodegaRepository repository;
        public BodegaService(IBodegaRepository repository)
        {
            this.repository = repository;
        }
        public TbPrBodega Save(TbPrBodega domain)
        {
            return repository.Save(domain);
        }
     
       public TbPrBodega Update(TbPrBodega domain)
        {
            return repository.Update(domain);
        }
        public bool Delete(TbPrBodega domain)
        {
            return repository.Delete(domain);
        }
        public IList<TbPrBodega> GetAllActivas()
        {
            return repository.GetAllActivas();
        }
        public IList<TbPrBodega> GetAllInactivas()
        {
            return repository.GetAllInactivas();
        }
        public TbPrBodega GetBodegaById(int id)
        {
            return repository.GetBodegaById(id);
        }
        public TbPrBodega GetBodegaByNombre(string nombre)
        {
            return repository.GetBodegaByNombre(nombre);
        }

        public IList<TbPrBodega> GetAllBodegasConInventario()
        {
            return repository.GetAllBodegasConInventario();
        }
        public void UpdateInventarioBodega(IList<TbPrInventarioBodega> inventarioBodega)
        {
            repository.UpdateInventarioBodega(inventarioBodega);
        }

        public IList<TbPrBodega> GetAll()
        {
            return repository.GetAll();
        }
        public IList<TbPrInventarioBodega> GetAllInventarioBodega()
        {
            return repository.GetAllInventarioBodega();
        }
    }
}
