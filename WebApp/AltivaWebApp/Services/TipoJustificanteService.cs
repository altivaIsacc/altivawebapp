using AltivaWebApp.Domains;
using AltivaWebApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Services
{
    public class TipoJustificanteService: ITipoJustificanteService
    {
        private readonly ITipoJustificanteRepository repository;

        public TipoJustificanteService(ITipoJustificanteRepository repository)
        {
            this.repository = repository;
        }
        public TbFaTipoJustificante Save(TbFaTipoJustificante domain)
        {
            return repository.Save(domain);
        }
        public TbFaTipoJustificante Update(TbFaTipoJustificante domain)
        {
            return repository.Update(domain);
        }
        public IList<TbFaTipoJustificante> GetAll()
        {
            return repository.GetAll(); ;
        }      
        public TbFaTipoJustificante GetTipoJustificanteById(long id)
        {
            return repository.GetTipoJustificanteById(id);
        }
    }
}
