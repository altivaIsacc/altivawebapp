using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;

namespace AltivaWebApp.Services
{
    public interface IOrdenService
    {
        TbPrOrden Save(TbPrOrden domain);
        TbPrOrden Update(TbPrOrden domain);
        bool Delete(TbPrOrden domain);
        IList<TbPrOrden> GetAllAjustes();
        TbPrOrden GetOrdenById(int id);
        TbPrOrden GetAllOrdenDetalleByOrdenId(int id);
        bool SaveOrdenDetalle(IList<TbPrOrdenDetalle> domain);
        bool DeleteOrdenDetalle(IList<TbPrOrdenDetalle> domain);
    }
}
