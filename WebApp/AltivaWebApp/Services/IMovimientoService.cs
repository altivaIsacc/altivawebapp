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
        TbFaMovimiento Save(TbFaMovimiento domain);
        TbFaMovimiento Update(TbFaMovimiento domain);
        IList<TbFaMovimientoDetalle> SaveMovDetalle(IList<TbFaMovimientoDetalle> domain);
        TbFaMovimiento GetMovimientoByIdDocumento(long idDoc);
        IList<TbFaMovimientoDetalle> GetMovimientoByIdDocConPagos(long idDoc);
        IList<TbFaMovimientoDetalle> UpdateMovDetalle(IList<TbFaMovimientoDetalle> domain);
        long GetUltimoMovimientoPagoId(long idDoc);
        IList<TbFaMovimiento> GetSaldoContacto(long idContacto);
        TbFaMovimiento GetMovimientoById(long idMov);
        
      
        bool SaveMovimientoJustificante(IList<TbFaMovimientoJustificante> domain);
        bool UpdateMovimientoJustificante(IList<TbFaMovimientoJustificante> domain);
        TbFaMovimiento GetMovimientoById(long id);
        IList<TbFaMovimiento> GetAllMovimientos();
        TbFaMovimiento GetMovimientoByNota(long id);
        IList<TbFaMovimientoJustificante> GetJustificantesByMovimientoId(long id);
        bool DeleteMovimientoJustificante(IList<int> domain, int idMovimiento);
         IList<DocumentosContactoViewModel> GetDocumentosContacto(long id, bool cxp, long idMovimiento);
        bool SaveMD(IList<TbFaMovimientoDetalle> domain);
        TbFaMovimientoDetalle GetMovimientoDetalleByIdMovimiento(long idMovimiento);
        bool UpdateMD(IList<TbFaMovimientoDetalle> domain);
        bool DeleteMD(long id);



    }
}
