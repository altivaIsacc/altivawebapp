using AltivaWebApp.Domains;
using AltivaWebApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Services
{
    public class PrecioCatalogoService: IPrecioCatalogoService
    {
        private readonly IPrecioCatalogoRepository reposistory;

        public PrecioCatalogoService(IPrecioCatalogoRepository reposistory)
        {
            this.reposistory = reposistory;
        }

        public IList<TbPrPrecioCatalogo> GetAll()
        {
            return reposistory.GetAll() ;
        }
        public IList<TbPrPrecioCatalogo> GetAllPrecioCatalogo()
        {
            return reposistory.GetAllPrecioCatalogo();
        }



        public TbPrPrecioCatalogo GetPrecioCatalogoById(int id)
        {
            return reposistory.GetPrecioCatalogoById(id);
        }

       

        public IList<TbPrPrecioCatalogo> GetPreciosWithReqs()
        {
            return reposistory.GetPreciosWithReqs();
        }

        
        public bool Update(IList<TbPrPrecioCatalogo> domain)
        {
            return reposistory.UpdatePrecio(domain);
        }
        public bool SaveFromInventario(int idIventario)
        {
            return reposistory.SaveFromInventario(idIventario);
        }
        public  bool SaveFromPrecios(int idTipoPrecio)
        {
            return  reposistory.SaveFromPrecios(idTipoPrecio);
        }
        
    }
}
