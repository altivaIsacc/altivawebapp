using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.Repositories;

namespace AltivaWebApp.Services
{
    public class MovimientoService : IMovimientoService
    {
        private readonly IMovimientoRepository repository;
        public MovimientoService(IMovimientoRepository repository)
        {
            this.repository = repository;
        }

        public TbFaMovimiento GetMovimientoById(long idMov)
        {
            return repository.GetMovimientoById(idMov);
        }

        public TbFaMovimiento GetMovimientoByIdDocumento(long idDoc)
        {
            return repository.GetMovimientoByIdDocumento(idDoc);
        }

        public IList<TbFaMovimiento> GetSaldoContacto(long idContacto)
        {
            return repository.GetSaldoContacto(idContacto);
        }

        public long GetUltimoMovimientoPagoId(long idDoc)
        {
            return repository.GetUltimoMovimientoPagoId(idDoc);
        }

        public TbFaMovimiento Save(TbFaMovimiento domain)
        {
            return repository.Save(domain);
        }

        public IList<TbFaMovimientoDetalle> SaveMovDetalle(IList<TbFaMovimientoDetalle> domain)
        {
            return repository.SaveMovDetalle(domain);
        }

        public TbFaMovimiento Update(TbFaMovimiento domain)
        {
            return repository.Update(domain);
        }

        public IList<TbFaMovimientoDetalle> UpdateMovDetalle(IList<TbFaMovimientoDetalle> domain)
        {
            return repository.UpdateMovDetalle(domain);
        }
    }
}
