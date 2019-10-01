using AltivaWebApp.Domains;
using AltivaWebApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.ViewModels;

namespace AltivaWebApp.Services
{
    public class MovimientoService: IMovimientoService
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
        public bool SaveMD(IList<TbFaMovimientoDetalle> domain)
        {
            return repository.SaveMD(domain);
        }
        public TbFaMovimiento Update(TbFaMovimiento domain)
        {
            return repository.Update(domain);
        }
        public bool SaveMovimientoJustificante(IList<TbFaMovimientoJustificante> domain)
        {
            return repository.SaveMovimientoJustificante(domain);
        }
        public bool UpdateMovimientoJustificante(IList<TbFaMovimientoJustificante> domain)
        {
            return repository.UpdateMovimientoJustificante(domain);
        }
        public TbFaMovimiento GetMovimientoById(long id)
        {
            return repository.GetMovimientoById(id);
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
        public IList<DocumentosContactoViewModel> GetDocumentosContacto(long id, bool cxp, long idMovimiento)
        {
            return repository.GetDocumentosContacto(id, cxp, idMovimiento);
        }
    }
}
