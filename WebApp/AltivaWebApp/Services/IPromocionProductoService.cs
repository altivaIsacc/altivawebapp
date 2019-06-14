using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Services
{
    public interface IPromocionProductoService
    {
        bool Delete(TbFaPromocionProducto domain);
        TbFaPromocionProducto GetPromocionById(int id);
        IList<TbFaPromocionProducto> GetAll();
        bool Save(IList<TbFaPromocionProducto> domain);
    }
}
