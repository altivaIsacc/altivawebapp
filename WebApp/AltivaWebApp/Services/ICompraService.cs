using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Services
{
    public interface ICompraService
    {
        TbPrCompra Save(TbPrCompra domain);
        TbPrCompra Update(TbPrCompra domain);
        IList<TbPrCompra> GetAllCompras();
        TbPrCompra GetCompraById(int id);
        IList<TbPrCompraDetalle> GetAllCompraDetalleByCompraId(int id);
        bool SaveCompraDetalle(IList<TbPrCompraDetalle> domain);
        bool DeleteCompraDetalle(IList<int> domain, int idCompra);
        bool UpdateCompraDetalle(IList<TbPrCompraDetalle> domain);
        bool ExisteDocumento(string numDoc, string tipo, int idProveedor);
    }
}
