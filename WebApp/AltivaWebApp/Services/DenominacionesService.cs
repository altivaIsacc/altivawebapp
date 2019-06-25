using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.Repositories;

namespace AltivaWebApp.Services
{
    public class DenominacionesService:IDenominacionesService
    {
        private readonly IDenominacionRepository repository;

        public DenominacionesService(IDenominacionRepository DenominacionesRepository)
        {
            repository = DenominacionesRepository;
        }

        public IList<TbFaDenominacion> GetAllDenominaciones()
        {
            return repository.GetAllDenominaciones();
        }

        public TbFaDenominacion Update(TbFaDenominacion domain)
        {
            return repository.Update(domain);
        }

        public TbFaDenominacion Save(TbFaDenominacion domain)
        {
            return repository.Save(domain);
        }

        public TbFaDenominacion GetDenominacionesById(int id)
        {
            return repository.GetDenominacionesById(id);
        }

    }
}
