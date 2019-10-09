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
        private readonly ITipoJustificanteRepository reposistory;

        public TipoJustificanteService(ITipoJustificanteRepository reposistory)
        {
            this.reposistory = reposistory;
        }
        public TbFaTipoJustificante Save(TbFaTipoJustificante domain)
        {
            return reposistory.Save(domain);
        }
        public TbFaTipoJustificante Update(TbFaTipoJustificante domain)
        {
            return reposistory.Update(domain);
        }
        public IList<TbFaTipoJustificante> GetAll()
        {
            return reposistory.GetAll(); ;
        }      
        public TbFaTipoJustificante GetTipoJustificanteById(long id)
        {
            return reposistory.GetTipoJustificanteById(id);
        }
    }
}
