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
        private readonly IPreciosRepository reposistory;

        public PreciosService(IPreciosRepository reposistory)
        {
            this.reposistory = reposistory;
        }
        public TbPrPrecios GetFirstPrecioCatalogo()
        {
            return reposistory.GetFirstPrecioCatalogo();
        }
        public IList<TbPrPrecios> GetAll()
        {
            return reposistory.GetAll(); ;
        }

        public TbPrPrecios GetPreciosByDesc(int Id)
        {
            return reposistory.GetPreciosByDesc(Id);
        }

        public TbPrPrecios GetPreciosById(int id)
        {
            return reposistory.GetPreciosById(id);
        }

        public IList<TbPrPrecios> GetPreciosSinAnular()
        {
            return reposistory.GetPreciosSinAnular();
        }

        public IList<TbPrPrecios> GetPreciosWithReqs()
        {
            return reposistory.GetPreciosWithReqs();
        }

        public TbPrPrecios Save(TbPrPrecios domain)
        {
            return reposistory.Save(domain);
        }
        public TbPrPrecios Update(TbPrPrecios domain)
        {
            return reposistory.Update(domain);
        }
    }
}
