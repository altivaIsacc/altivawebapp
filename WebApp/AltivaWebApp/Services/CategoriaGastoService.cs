using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.Repositories;

namespace AltivaWebApp.Services
{
    public class CategoriaGastoService : ICategoriaGastoService
    {
        private readonly ICategoriaGastoRepository repository;
        public CategoriaGastoService(ICategoriaGastoRepository repository)
        {
            this.repository = repository;
        }

        public IList<TbCpCategoriaGasto> GetAll()
        {
            return repository.GetAll();
        }

        public TbCpCategoriaGasto GetCGById(int id)
        {
            return repository.GetCGById(id);
        }

        public TbCpCategoriaGasto GetCGByNombre(string nombre)
        {
            return repository.GetCGByNombre(nombre);
        }

        public TbCpCategoriaGasto Save(TbCpCategoriaGasto domain)
        {
            return repository.Save(domain);
        }

        public TbCpCategoriaGasto Update(TbCpCategoriaGasto domain)
        {
            return repository.Update(domain);
        }
    }
}
