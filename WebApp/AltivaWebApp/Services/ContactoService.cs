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

        public ContactoService(IContactoRepository ContactoRepository, IContactoRelacionRepository IContactoRelacionRepository)
        {
            this.ContactoRepository = ContactoRepository;
            this.IContactoRelacionRepository = IContactoRelacionRepository;
        }

        public TbCrContacto Edit(TbCrContacto domain)
        {
            return this.ContactoRepository.Update(domain);
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

        public IList<ContactoRelacionGETViewModel> GetContactosRelacion(int id)
        {
            return this.ContactoRepository.GetContactosRelacion(id);
        }

        public IList<TbCeDistrito> GetDistrito(int idDistrito, int idProvincia)
        {
            return this.ContactoRepository.GetDistrito(idDistrito, idProvincia);
        }

        public IList<TbCeProvincias> GetProvincias()
        {
           return this.ContactoRepository.GetProvincias();
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
