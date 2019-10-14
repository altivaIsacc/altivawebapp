using AltivaWebApp.Domains;
using AltivaWebApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Services
{
    public class PreciosService: IPreciosService
    {
        private readonly IPreciosRepository repository;

        public PreciosService(IPreciosRepository repository)
        {
            this.repository = repository;
        }
        public TbPrPrecios GetFirstPrecioCatalogo()
        {
            return repository.GetFirstPrecioCatalogo();
        }
        public IList<TbPrPrecios> GetAll()
        {
            return repository.GetAll(); ;
        }

        public TbPrPrecios GetPreciosByDesc(int Id)
        {
            return repository.GetPreciosByDesc(Id);
        }

        public TbPrPrecios GetPreciosById(int id)
        {
            return repository.GetPreciosById(id);
        }

        public IList<TbPrPrecios> GetPreciosSinAnular()
        {
            return repository.GetPreciosSinAnular();
        }

        public IList<TbPrPrecios> GetPreciosWithReqs()
        {
            return repository.GetPreciosWithReqs();
        }

        public TbPrPrecios Save(TbPrPrecios domain)
        {
            return repository.Save(domain);
        }
        public TbPrPrecios Update(TbPrPrecios domain)
        {
            return repository.Update(domain);
        }
    }
}
