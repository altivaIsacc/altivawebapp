using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public interface IPrecioCatalogoRepository
    {
        
       bool UpdatePrecio(IList<TbPrPrecioCatalogo> domain);
        IList<TbPrPrecioCatalogo> GetAll();
        TbPrPrecioCatalogo GetPrecioCatalogoById(int id);
       
        IList<TbPrPrecioCatalogo> GetPreciosWithReqs();
        IList<TbPrPrecioCatalogo> GetAllPrecioCatalogo();
        bool SaveFromInventario(int idInventario);
         bool SaveFromPrecios(int idTipoPrecio);
    }
}
