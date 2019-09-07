using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.ViewModels;
namespace AltivaWebApp.Repositories
{
    public interface IOrdenRepository
    {
       
         IList<TbCrContacto> GetAllProveedores();
        IList<CompraAutomaticoViewModel> compraProveedor(int idProveedor);
        TbPrOrden Save(TbPrOrden domain);
        TbPrOrden Update(TbPrOrden domain);
        bool Delete(TbPrOrden domain);
        IList<TbPrOrden> GetAllOrdenes();
        TbPrOrden GetOrdenById(int id);
        //TbPrOrden GetAllOrdenDetalleByOrdenId(int id);
        IList<TbPrOrdenDetalle> GetAllOrdenDetalleByOrdenId(int id);
        bool SaveOrdenDetalle(IList<TbPrOrdenDetalle> domain);
        bool DeleteOrdenDetalle(IList<int> domain, int idOrden);
        bool UpdateOrdenDetalle(IList<TbPrOrdenDetalle> domain);

    }
}
