using AltivaWebApp.Domains;
using AltivaWebApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Services
{
    public class UnidadService: IUnidadService
    {
        readonly IUnidadRepository repository;
        public UnidadService(IUnidadRepository repository)
        {
            this.repository = repository;
        }

        public TbPrUnidadMedida GetUnidadById(int id)
        {
            return repository.GetUnidadById(id);
        }

        public IList<TbPrUnidadMedida> GetAll()
        {
            return repository.GetAll();
        }

        public TbPrUnidadMedida Save(TbPrUnidadMedida domain)
        {
            return repository.Save(domain);
        }
        public TbPrUnidadMedida Update(TbPrUnidadMedida domain)
        {
            return repository.Update(domain);
        }
        public bool Delete(TbPrUnidadMedida domain)
        {
            return repository.Delete(domain);
        }
        public IList<TbPrUnidadMedida> GetUnidadesConConversiones()
        {
            return repository.GetUnidadesConConversiones();
        }

    }
}
