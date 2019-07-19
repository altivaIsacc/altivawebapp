using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Services
{
    public interface ICompraService
    {
        IList<TbCpCategoriaGasto> GetAllCategoriaGasto();
        TbPrCompra Save(TbPrCompra domain);
        TbPrCompra Update(TbPrCompra domain);
        IList<TbPrCompra> GetAllCompras();
        TbPrCompra GetCompraById(int id);
        IList<TbPrCompraDetalle> GetAllCompraDetalleByCompraId(int id);
        TbPrCompraDetalle SaveCompraDetalle(TbPrCompraDetalle domain);
        bool DeleteCompraDetalle(TbPrCompraDetalle domain);
        bool UpdateCompraDetalle(IList<TbPrCompraDetalle> domain);
        bool ExisteDocumento(string numDoc, string tipo, int idProveedor);
        TbPrCompra GetCompraByDocumento(string nDoc, string tipoDoc, long idProveedor);
        TbPrCompraDetalle GetCompraDetalleById(long id);
        bool ExisteRelacionInventarioBodega(long idInventario, long idBodega);
        long IdUltimoDocumento();
        TbPrCompra GetCompraByIdWithoutD(int id);
        TbCpComprasDetalleServicio GetComprasDetalleServicioById(long id);
        bool UpdateComprasDetalleServicio(IList<TbCpComprasDetalleServicio> domain);
        TbCpComprasDetalleServicio SaveComprasDetalleServicio(TbCpComprasDetalleServicio domain);
        IList<TbCpComprasDetalleServicio> GetAllComprasDetalleServicioByCompraId(int id);
        bool DeleteComprasDetalleServicio(TbCpComprasDetalleServicio domain);
        IList<TbPrCompra> GetAllGastos();

    }
}
