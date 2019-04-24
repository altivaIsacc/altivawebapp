using AltivaWebApp.Domains;
using AltivaWebApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Services
{
    public class AjusteService: IAjusteService
    {
        private readonly IAjusteRepository repository;

        public AjusteService(IAjusteRepository repository)
        {
            this.repository = repository;
        }

        public TbPrAjuste Save(TbPrAjuste domain)
        {
            return repository.Save(domain);
        }
        public TbPrAjuste Update(TbPrAjuste domain)
        {
            return repository.Update(domain);
        }
        public bool Delete(TbPrAjuste domain)
        {
            return repository.Delete(domain);
        }
        public IList<TbPrAjuste> GetAll()
        {
            return repository.GetAll();
        }
        public TbPrAjuste GetAjusteById(int id)
        {
            return repository.GetAjusteById(id);
        }
        public TbPrAjusteInventario SaveAjusteInventario(TbPrAjusteInventario domain)
        {
            return repository.SaveAjusteInventario(domain);
        }
        public void DeleteAjusteInventario(int id)
        {
            repository.DeleteAjusteInventario(id);
        }

    }
}
