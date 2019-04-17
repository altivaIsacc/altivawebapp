using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.GEDomain;
using AltivaWebApp.Repositories;
namespace AltivaWebApp.Services
{
    public class PaisService : IPaisService
    {

        IPaisRepository repository;

        public PaisService(IPaisRepository pPaisRepository)

        {

            repository = pPaisRepository;

        }

        public bool ConsultarPais(string nombre)
        {
            return repository.ConsultarPais(nombre);
        }

        public TbSePais Create(TbSePais collection)
        {
            return repository.Save(collection);
        }

        public TbSePais Delete(int id)
        {
            return repository.borrar(id);
        }

        public IList<TbSePais> GetAll()
        {
            return repository.GetAll();
        }

        public TbSePais GetPaisById(int id)
        {
            return repository.GetPaisById(id);
        }

        public TbSePais UpdatePais(TbSePais domain)
        {
             return repository.Update(domain);
        }
    }
}
