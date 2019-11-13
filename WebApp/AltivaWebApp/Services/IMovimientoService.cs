using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.ViewModels;

namespace AltivaWebApp.Services
{
    public interface IMovimientoService
    {
      double? GetMaximoCredito(int idCliente);
        double GetTotalCredito(int idCliente);
        TbFaMovimientoDetalle GetMovimientoDetalleByIdMovimientoHasta(long idMovimientoHasta);
        TbFaMovimiento Save(TbFaMovimiento domain);
        TbFaMovimiento Update(TbFaMovimiento domain);
        IList<TbFaMovimientoDetalle> SaveMovDetalle(IList<TbFaMovimientoDetalle> domain);
        TbFaMovimiento GetMovimientoByIdDocumento(long idDoc, long tipoDoc);
        IList<TbFaMovimientoDetalle> GetMovimientoByIdDocConPagos(long idDoc, int tipoDoc);
        IList<TbFaMovimientoDetalle> UpdateMovDetalle(IList<TbFaMovimientoDetalle> domain);
        long GetUltimoMovimientoPagoId(long idDoc);
        IList<TbFaMovimiento> GetSaldoContacto(long idContacto);
        TbFaMovimiento GetMovimientoById(long idMov);
        void DeleteMovimientoDetalle(IList<TbFaMovimientoDetalle> domain);
        bool SaveMovimientoJustificante(IList<TbFaMovimientoJustificante> domain);
        bool UpdateMovimientoJustificante(IList<TbFaMovimientoJustificante> domain);
        IList<TbFaMovimiento> GetAllMovimientos();
        TbFaMovimiento GetMovimientoByNota(long id);
        IList<TbFaMovimientoJustificante> GetJustificantesByMovimientoId(long id);
        bool DeleteMovimientoJustificante(IList<int> domain, int idMovimiento);
         IList<DocumentosContactoViewModel> GetDocumentosContacto(long id, bool cxp, long idDocumento);
        bool SaveMD(IList<TbFaMovimientoDetalle> domain);
        TbFaMovimientoDetalle GetMovimientoDetalleByIdMovimiento(long idMovimiento);
        bool UpdateMD(IList<TbFaMovimientoDetalle> domain);
        bool DeleteMD(long id);
        IList<DocumentosContactoViewModel> GetDocumentosPendientesContacto(long idContacto);
        IList<TbFaMovimientoDetalle> GetMovimientosDetalleByIdMovimiento(long idMovimiento);



    }
}
