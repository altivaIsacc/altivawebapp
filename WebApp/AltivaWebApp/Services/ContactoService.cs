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

        public IContactoRepository repository;
        public IContactoRelacionRepository crRepository;
        public ICondicionesDePagoRepository cpRepository;
        public ICuentasBancariasRepository cbRepository;
        public ContactoService(ICondicionesDePagoRepository ICondicionesDePagoRepository,ICuentasBancariasRepository ICuentasBancariasRepository,IContactoRepository ContactoRepository, IContactoRelacionRepository IContactoRelacionRepository)
        {
            this.cpRepository = ICondicionesDePagoRepository;
            this.cbRepository = ICuentasBancariasRepository;
            this.repository = ContactoRepository;
            this.crRepository = IContactoRelacionRepository;
        }

        public IList<TbFdCondicionesDePago> CreateOrUpdateCondicionPago(IList<TbFdCondicionesDePago> domain)
        {
            return this.cpRepository.CreateOrUpdate(domain);
        }

        public TbFdCuentasBancarias AgregarCuentasBancarias(TbFdCuentasBancarias domain)
        {
            return this.cbRepository.Save(domain);
        }

        public bool DeleteCuentasBancarias(TbFdCuentasBancarias domain)
        {
            return this.cbRepository.Delete(domain);
        }

        public TbCrContacto Update(TbCrContacto domain)
        {
            return this.repository.Update(domain);
        }

        public TbFdCondicionesDePago EditarCondicion(TbFdCondicionesDePago domain)
        {
            return this.cpRepository.Update(domain);
        }

        public TbFdCuentasBancarias EditarCuentasBancarias(TbFdCuentasBancarias domain)
        {
            return this.cbRepository.Update(domain);
        }

       

        public IList<TbCrContacto> GetAllProveedores()
        {
            return repository.GetAllProveedores();
        }


        public IList<TbCrContacto> GetAll()
        {
            return this.repository.GetAll();
        }

        public IList<TbCrContactoRelacion> GetContactoRelacion(int id)
        {
            return repository.GetContactosRelacion(id);
        }

        public IList<TbCrContacto> GetAllEmpresas()
        {
            return this.repository.GetAllEmpresas();
        }

        public IList<TbCrContacto> GetAllPersonas()
        {
            return this.repository.GetAllPersonas();
        }

        public IList<TbCrContacto> GetAllClientes()
        {
            return this.ContactoRepository.GetAllClientes();
        }

        public TbCrContacto GetByCedulaContacto(string cedula)
        {
            return repository.GetAllClientes();
        }

        public TbCrContacto GetByCedulaContacto(string cedula)
        {
            return this.repository.GetByCedulaContacto(cedula);
        }

        public IList<TbFdCuentasBancarias> GetByContacto(int idContacto)
        {
            return this.cbRepository.GetByContacto(idContacto);
        }


        public TbCrContacto GetByEmailContacto(string correo)
        {
            return this.repository.GetByEmailContacto(correo);
        }


        public bool EliminarRelacion(int idRelacion)
        {
            return repository.EliminarRelacion(idRelacion);
        }

        public TbCrContacto GetByIdContacto(long id)
        {
            return this.repository.GetByIdContacto(id);
        }

        public IList<TbCeCanton> GetCantones(int idProvincia)
        {
            return this.repository.GetCantones(idProvincia);
        }

        public IList<TbFdCondicionesDePago> GetCondicionesByIdContacto(int idContacto)
        {
            return this.cpRepository.GetByIdContacto(idContacto);
        }


        public TbFdCuentasBancarias GetCuentaById(int id)
        {
            return this.cbRepository.GetCuentaById(id);
        }

        public IList<TbFdCuentasBancarias> GetCuentasByContacto(int id)
        {
            return cbRepository.GetByContacto(id);
        }

        public IList<TbCeDistrito> GetDistrito(int idDistrito, int idProvincia)
        {
            return this.repository.GetDistrito(idDistrito, idProvincia);
        }

        public IList<TbCeProvincias> GetProvincias()
        {
           return this.repository.GetProvincias();
        }

        public IList<TbFdTarea> GetTareas(int idContacto)
        {
            return this.repository.GetTareas(idContacto);
        }

        public TbCrContactoRelacion SaveRelacion(TbCrContactoRelacion domain)
        public IList< TbCrContacto> GetAllClientes()
        {
            return this.ContactoRepository.GetAllClientes();
        }

        public TbCrContactoRelacion InsertarRelacion(TbCrContactoRelacion domain)
        {
            return this.crRepository.Save(domain);
        }

        public TbCrContactoRelacion UpdateRelacion(TbCrContactoRelacion domain)
        {
            return this.crRepository.Update(domain);
        }

        public TbCrContactoRelacion GetRelacionById(int id)
        {
            return crRepository.GetById(id);
        }

        public TbCrContacto Save(TbCrContacto domain)
        {
            if (!domain.Cliente)
            {
                domain.IdTipoCliente = 0;
                domain.IdFamiliaCliente = 0;
                domain.IdSubFamiliaCliente = 0;
            }
            if (!domain.Proveedor)
            {
                domain.IdTipoProveedor = 0;
                domain.IdFamiliaProveedor = 0;
                domain.IdSubFamiliaProveedor = 0;
            }

            return this.repository.Save(domain);
        }

        public TbCrContactoRelacion GetByIdPadreAndIdHijo(int idPadre, int idHijo)
        {
            return crRepository.GetByIdPadreAndIdHijo(idPadre, idHijo);
        }
    }
}
