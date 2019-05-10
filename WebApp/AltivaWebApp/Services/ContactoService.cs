using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
using AltivaWebApp.Repositories;
namespace AltivaWebApp.Services
{
    public class ContactoService : IContactoService
    {

        public IContactoRepository ContactoRepository;
        public IContactoRelacionRepository IContactoRelacionRepository;
        public ICondicionesDePagoRepository ICondicionesDePagoRepository;
        public ICuentasBancariasRepository ICuentasBancariasRepository;
        public ContactoService(ICondicionesDePagoRepository ICondicionesDePagoRepository,ICuentasBancariasRepository ICuentasBancariasRepository,IContactoRepository ContactoRepository, IContactoRelacionRepository IContactoRelacionRepository)
        {
            this.ICondicionesDePagoRepository = ICondicionesDePagoRepository;
            this.ICuentasBancariasRepository = ICuentasBancariasRepository;
            this.ContactoRepository = ContactoRepository;
            this.IContactoRelacionRepository = IContactoRelacionRepository;
        }

        public TbFdCondicionesDePago AgregarCondicion(TbFdCondicionesDePago domain)
        {
            return this.ICondicionesDePagoRepository.Save(domain);
        }

        public TbFdCuentasBancarias AgregarCuentas(TbFdCuentasBancarias domain)
        {
            return this.ICuentasBancariasRepository.Save(domain);
        }

        public TbFdCuentasBancarias AgregarCuentasBancarias(TbFdCuentasBancarias domain)
        {
            return this.ICuentasBancariasRepository.Save(domain);
        }

        public bool DeleteCuentasBancarias(TbFdCuentasBancarias domain)
        {
            return this.ICuentasBancariasRepository.Delete(domain);
        }

        public TbCrContacto Edit(TbCrContacto domain)
        {
            return this.ContactoRepository.Update(domain);
        }

        public TbFdCondicionesDePago EditarCondicion(TbFdCondicionesDePago domain)
        {
            return this.ICondicionesDePagoRepository.Update(domain);
        }

        public TbFdCuentasBancarias EditarCuentas(TbFdCuentasBancarias domain)
        {
            return this.ICuentasBancariasRepository.Update(domain);
        }
        public IList<TbCrContacto> GetAllProveedores()
        {
            return ContactoRepository.GetAllProveedores();
        }

        public TbCrContactoRelacion EditarRelacion(EditarRelacionContactoViewModel domain)
        {
            return this.IContactoRelacionRepository.Update(viewModelEditarRelacion(domain));
        }

        public IList<TbCrContacto> GetAll()
        {
            return this.ContactoRepository.GetAll();
        }


        public IList<TbCrContacto> GetAllEmpresas()
        {
            return this.ContactoRepository.GetAllEmpresas();
        }

        public IList<TbCrContacto> GetAllPersonas()
        {
            return this.ContactoRepository.GetAllPersonas();
        }

        public TbCrContacto GetByCedulaContacto(string cedula)
        {
            return this.ContactoRepository.GetByCedulaContacto(cedula);
        }

        public IList<TbFdCuentasBancarias> GetByContacto(int idContacto)
        {
            return this.ICuentasBancariasRepository.GetByContacto(idContacto);
        }

        public ContactoViewModel GetByEdit(int id)
        {
            return this.ContactoRepository.GetByEdit(id);
        }

        public TbCrContacto GetByEmailContacto(string correo)
        {
            return this.ContactoRepository.GetByEmailContacto(correo);
        }

        public ContactoViemModelDetalle getById(int id)
        {
            return this.ContactoRepository.getById(id);
        }

        public TbCrContacto GetByIdContacto(long id)
        {
            return this.ContactoRepository.GetByIdContacto(id);
        }

        public IList<TbCeCanton> GetCantones(int idProvincia)
        {
            return this.ContactoRepository.GetCantones(idProvincia);
        }

        public IList<TbFdCondicionesDePago> GetCondiciones(int idContacto)
        {
            return this.ICondicionesDePagoRepository.GetById(idContacto);
        }

        public IList<ContactoRelacionGETViewModel> GetContactosRelacion(int id)
        {
            return this.ContactoRepository.GetContactosRelacion(id);
        }

        public TbFdCuentasBancarias GetCuentasById(int id)
        {
            return this.ICuentasBancariasRepository.GetById(id);
        }

        public IList<TbCeDistrito> GetDistrito(int idDistrito, int idProvincia)
        {
            return this.ContactoRepository.GetDistrito(idDistrito, idProvincia);
        }

        public IList<TbCeProvincias> GetProvincias()
        {
           return this.ContactoRepository.GetProvincias();
        }

        public TbCrContacto GetTareas(int idContacto)
        {
            return this.ContactoRepository.GetTareas(idContacto);
        }

        public TbCrContactoRelacion InsertarRelacion(TbCrContactoRelacion domain)
        {
            return this.IContactoRelacionRepository.Save(domain);
        }

        public TbCrContacto Save(TbCrContacto domain)
        {
            return this.ContactoRepository.Save(domain) ;
        }

        public TbCrContactoRelacion viewModelEditarRelacion(EditarRelacionContactoViewModel domain)
        {
            TbCrContactoRelacion cr = new TbCrContactoRelacion();
            cr = this.IContactoRelacionRepository.GetById(Convert.ToInt32(domain.IdRelacion));

            cr.NotaRelacion = domain.Nota;
            return cr;
        }
    }
}
