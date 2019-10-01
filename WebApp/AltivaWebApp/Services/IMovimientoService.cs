using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;

namespace AltivaWebApp.Services
{
   public interface IMovimientoService
   {
        TbFaMovimiento Save(TbFaMovimiento domain);
        TbFaMovimiento Update(TbFaMovimiento domain);
        bool SaveMovimientoJustificante(IList<TbFaMovimientoJustificante> domain);
        bool UpdateMovimientoJustificante(IList<TbFaMovimientoJustificante> domain);
        TbFaMovimiento GetMovimientoById(long id);
        IList<TbFaMovimiento> GetAllMovimientos();
        TbFaMovimiento GetMovimientoByNota(long id);
        IList<TbFaMovimientoJustificante> GetJustificantesByMovimientoId(long id);
        bool DeleteMovimientoJustificante(IList<int> domain, int idMovimiento);
         IList<DocumentosContactoViewModel> GetDocumentosContacto(long id, bool cxp, long idMovimiento);
        bool SaveMD(IList<TbFaMovimientoDetalle> domain);


   }
}
