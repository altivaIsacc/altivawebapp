using AltivaWebApp.DomainsConta;
using AltivaWebApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Services
{
    public class CatalogoContableService : ICatalogoContableService
    {
        ICatalogoContableRepository repository;
        public CatalogoContableService(ICatalogoContableRepository repository)
        {
            this.repository = repository;
        }
        public CatalogoContable Save(CatalogoContable domain)
        {
            return repository.Save(domain);
        }

        public CatalogoContable Update(CatalogoContable domain)
        {
            return repository.Update(domain);
        }
        public bool Delete(CatalogoContable domain)
        {
            return repository.Delete(domain);
        }
        public IList<CatalogoContable> GetAllActivas()
        {
            return repository.GetAllActivas();
        }
        public IList<CatalogoContable> GetAllInactivas()
        {
            return repository.GetAllInactivas();
        }
        public CatalogoContable GetCatalogoContableById(long id)
        {
            return repository.GetCatalogoContableById(id);
        }
        public CatalogoContable GetCatalogoContableByNombre(string nombre)
        {
            return repository.GetCatalogoContableByNombre(nombre);
        }

        public IList<CatalogoContable> GetAll()
        {
            return repository.GetAll();
        }
    }
}
