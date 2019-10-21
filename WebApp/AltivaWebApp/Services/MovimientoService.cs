using AltivaWebApp.Domains;
using AltivaWebApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.ViewModels;

namespace AltivaWebApp.Services
{
    public class MovimientoService : IMovimientoService
    {
        private readonly IMovimientoRepository repository;
        public MovimientoService(IMovimientoRepository repository)
        {
            this.repository = repository;
        }
        public TbFaMovimiento Save(TbFaMovimiento domain)
        {
            return repository.Save(domain);
        }
        public TbFaMovimiento GetMovimientoById(long idMov)
        {
            return repository.GetMovimientoById(idMov);
        }
        public IList<TbFaMovimientoDetalle> SaveMovDetalle(IList<TbFaMovimientoDetalle> domain)
        {
            return repository.SaveMovDetalle(domain);
        }
        public IList<TbFaMovimientoDetalle> UpdateMovDetalle(IList<TbFaMovimientoDetalle> domain)
        {
            return repository.UpdateMovDetalle(domain);
        }
        public IList<TbFaMovimientoDetalle> GetMovimientoByIdDocConPagos(long idDoc)
        {
            return repository.GetMovimientoByIdDocConPagos(idDoc);
        }

        public TbFaMovimiento GetMovimientoByIdDocumento(long idDoc)
        {
            return repository.GetMovimientoByIdDocumento(idDoc);
        }
        public long GetUltimoMovimientoPagoId(long idDoc)
        {
            return repository.GetUltimoMovimientoPagoId(idDoc);
        }
        public IList<TbFaMovimiento> GetSaldoContacto(long idContacto)
        {
            return repository.GetSaldoContacto(idContacto);
        }
        public bool SaveMD(IList<TbFaMovimientoDetalle> domain)
        {
            return repository.SaveMD(domain);
        }
        public TbFaMovimiento Update(TbFaMovimiento domain)
        {
            return repository.Update(domain);
        }
        public bool UpdateMD(IList<TbFaMovimientoDetalle> domain)
        {
            return repository.UpdateMD(domain);
        }
        public bool DeleteMD(long id)
        {
            return repository.DeleteMD(id);
        }
        public bool SaveMovimientoJustificante(IList<TbFaMovimientoJustificante> domain)
        {
            return repository.SaveMovimientoJustificante(domain);
        }
        public bool UpdateMovimientoJustificante(IList<TbFaMovimientoJustificante> domain)
        {
            return repository.UpdateMovimientoJustificante(domain);
        }
            public TbFaMovimiento GetMovimientoByNota(long id)
        {
            return repository.GetMovimientoByNota(id);
        }
        public IList<TbFaMovimiento> GetAllMovimientos()
        {
            return repository.GetAllMovimientos();
        }
        public IList<TbFaMovimientoJustificante> GetJustificantesByMovimientoId(long id)
        {
            return repository.GetJustificantesByMovimientoId(id);
        }
        public bool DeleteMovimientoJustificante(IList<int> domain, int idMovimiento)
        {
            return repository.DeleteMovimientoJustificante(domain, idMovimiento);
        }

        public void DeleteMovimientoDetalle(IList<TbFaMovimientoDetalle> domain)
        {
            repository.DeleteMovimientoDetalle(domain);
        }
        public IList<DocumentosContactoViewModel> GetDocumentosContacto(long id, bool cxp, long idMovimiento)
        {
            return repository.GetDocumentosContacto(id, cxp, idMovimiento);
        }
        public TbFaMovimientoDetalle GetMovimientoDetalleByIdMovimiento(long idMovimiento)
        {
            return repository.GetMovimientoDetalleByIdMovimiento(idMovimiento);
        }
        public TbFaMovimiento Save(TbFaMovimiento domain)
        {
            return repository.Save(domain);
        }
    }
}
