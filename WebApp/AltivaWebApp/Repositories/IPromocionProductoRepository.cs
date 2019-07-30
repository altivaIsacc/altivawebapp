using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
   public interface IPromocionProductoRepository
    {
        bool SavePromocion(IList<TbFaPromocionProducto> domain);
        IList<TbFaPromocionProducto> GetAll();
        TbFaPromocionProducto GetPromocionById(int id);
        bool Delete(TbFaPromocionProducto domain);
    }
}
