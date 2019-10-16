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
        private readonly IPrecioCatalogoRepository repository;

        public PrecioCatalogoService(IPrecioCatalogoRepository repository)
        {
            this.repository = repository;
        }
      
        public IList<TbPrPrecioCatalogo> GetAll()
        {
            return repository.GetAll() ;
        }
        public IList<TbPrPrecioCatalogo> GetAllPrecioCatalogo()
        {
            return repository.GetAllPrecioCatalogo();
        }



        public TbPrPrecioCatalogo GetPrecioCatalogoById(int id)
        {
            return repository.GetPrecioCatalogoById(id);
        }

       

        public IList<TbPrPrecioCatalogo> GetPreciosWithReqs()
        {
            return repository.GetPreciosWithReqs();
        }

        
        public bool Update(IList<TbPrPrecioCatalogo> domain)
        {
            return repository.UpdatePrecio(domain);
        }
        public bool SaveFromInventario(long idIventario)
        {
            return repository.SaveFromInventario(idIventario);
        }
        public  bool SaveFromPrecios(int idTipoPrecio)
        {
            return  repository.SaveFromPrecios(idTipoPrecio);
        }
        
    }
}
