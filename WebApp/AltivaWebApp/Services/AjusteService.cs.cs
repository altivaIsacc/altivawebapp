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
        public IList<TbPrAjuste> GetAllAjustes()
        {
            return repository.GetAllAjustes();
        }
        public TbPrAjuste GetAjusteById(int id)
        {
            return repository.GetAjusteById(id);
        }
        public bool SaveAjusteInventario(IList<TbPrAjusteInventario> domain)
        {
            return repository.SaveAjusteInventario(domain);
        }
        public void DeleteAjusteInventario(IList<int> id, int idAjuste)
        {
            repository.DeleteAjusteInventario(id, idAjuste);
        }


        ///provisional
        ///

        public IList<TbCoCuentaContable> GetAllCC()
        {
            return repository.GetAllCC();
        }
        public IList<TbCoCentrosDeGastos> GetAllCG()
        {
            return repository.GetAllCG();
        }


    }
}
