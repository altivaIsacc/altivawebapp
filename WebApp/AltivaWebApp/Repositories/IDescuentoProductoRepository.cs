using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public interface IDescuentoProductoRepository
    {

        bool SaveDescProd(IList<TbFaDescuentoProducto> domain);
        IList<TbFaDescuentoProducto> GetAll();
        TbFaDescuentoProducto GetDescuentoProductoById(int id);
        bool Delete(TbFaDescuentoProducto domain);
    }
}
