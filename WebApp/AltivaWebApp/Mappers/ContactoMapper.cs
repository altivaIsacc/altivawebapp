using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;

namespace AltivaWebApp.Mappers
{
    public class ContactoMap : IContactoMap
    {

        //variable service de contacto
        private readonly IContactoService contactoService;
        private readonly ICamposPersonalizadosService cpService;
        public ContactoMap(IContactoService pContactoService, ICamposPersonalizadosService ICamposPersonalizados)
        {
            this.contactoService = pContactoService;
            this.cpService = ICamposPersonalizados;
        }

        public TbCrCamposPersonalizados EliminarCP(int id)
        {
            TbCrCamposPersonalizados cp = new TbCrCamposPersonalizados();
            cp = this.cpService.getById(id);
            cp.Estado = "Eliminado";

            return this.cpService.Edit(cp);
        }

        public TbCrCamposPersonalizados UpdateCP(CamposPersonalizadosViewModel domain)
        {
            return this.cpService.Edit(ViewModelToDomainCP(domain));
        }

        public TbCrContacto UpdateContacto(ContactoViewModel domain)
        {
            return this.contactoService.Update(ViewModelToDomainC(domain));
        }

        public TbCrContacto UpdateImagen(int id, string ruta)
        {
            TbCrContacto contacto = new TbCrContacto();

            contacto = this.contactoService.GetByIdContacto(id);
            contacto.Ruta = ruta;

            return this.contactoService.Update(contacto);
        }

        public TbCrContactoRelacion CreateRelacion(ContactoRelacionViewModel domain)
        {
            return this.contactoService.SaveRelacion(ViewModelToDomainCR(domain));
        }

        public TbCrContactoRelacion UpdateRelacion(ContactoRelacionViewModel domain)
        {
            return this.contactoService.UpdateRelacion(ViewModelToDomainCR(domain));
        }

        public TbCrContacto CreateContacto(ContactoViewModel domain)
        {
            return this.contactoService.Save(ViewModelToDomainC(domain));
        }

        public TbCrCamposPersonalizados ViewModelToDomainCP(CamposPersonalizadosViewModel domain)
        {
            return new TbCrCamposPersonalizados
            {
                Id = domain.Id,
                Nombre = domain.Nombre,
                Tipo = domain.Tipo,
                Estado = domain.Estado
            };
        }

        public ContactoViewModel DomainToViewModelC(TbCrContacto domain)
        {


            return new ContactoViewModel
            {
                Nombre = domain.Nombre,
                Apellidos = domain.Apellidos,
                TipoCedula = domain.TipoCedula,
                Cedula = domain.Cedula,
                NombreComercial = domain.NombreComercial,
                NombreJuridico = domain.NombreJuridico,
                Telefono = domain.Telefono,
                Correo = domain.Correo,
                Pais = domain.Pais,
                Provincia = domain.Provincia,
                Cliente = (bool) domain.Cliente,
                Proveedor = (bool)domain.Proveedor,
                Canton = domain.Canton,
                Distrito = domain.Distrito,
                OtrasSenas = domain.OtrasSenas,
                Persona = (bool) domain.Persona,
                Empresa = (bool)domain.Empresa,
                IdUsuario = domain.IdUsuario,
                WebLink = domain.WebLink,
                MapLink = domain.MapLink,
                IdTipoCliente = (int) domain.IdTipoCliente,
                IdFamiliaCliente = (int)domain.IdFamiliaCliente,
                IdSubFamiliaCliente = (int)domain.IdSubFamiliaCliente,
                IdTipoProveedor = (int)domain.IdTipoProveedor,
                IdFamiliaProveedor = (int)domain.IdFamiliaProveedor,
                IdSubFamiliaProveedor = (int) domain.IdSubFamiliaProveedor,
                Ruta = domain.Ruta,
                IdContacto = domain.IdContacto,
            };

        }

        public TbCrContacto ViewModelToDomainC(ContactoViewModel viewModel)
        {


            return new TbCrContacto
            {
                Nombre = viewModel.Nombre,
                Apellidos = viewModel.Apellidos,
                TipoCedula = viewModel.TipoCedula,
                Cedula = viewModel.Cedula,
                NombreComercial = viewModel.NombreComercial,
                NombreJuridico = viewModel.NombreJuridico,
                Telefono = viewModel.Telefono,
                Correo = viewModel.Correo,
                Pais = viewModel.Pais,
                Provincia = viewModel.Provincia,
                Cliente = viewModel.Cliente,
                Proveedor = viewModel.Proveedor,
                Canton = viewModel.Canton,
                Distrito = viewModel.Distrito,
                OtrasSenas = viewModel.OtrasSenas,
                Persona = viewModel.Persona,
                Empresa = viewModel.Empresa,
                IdUsuario = viewModel.IdUsuario,
                WebLink = viewModel.WebLink,
                MapLink = viewModel.MapLink,
                IdTipoCliente = viewModel.IdTipoCliente,
                IdFamiliaCliente = viewModel.IdFamiliaCliente,
                IdSubFamiliaCliente = viewModel.IdSubFamiliaCliente,
                IdTipoProveedor = viewModel.IdTipoProveedor,
                IdFamiliaProveedor = viewModel.IdFamiliaProveedor,
                IdSubFamiliaProveedor = viewModel.IdSubFamiliaProveedor,
                Ruta = viewModel.Ruta,
                IdContacto = viewModel.IdContacto
            };

        }

        public TbCrContactoRelacion ViewModelToDomainCR(ContactoRelacionViewModel domain)
        {
            return new TbCrContactoRelacion
            {
                Id = domain.Id,
                IdContactoPadre = domain.IdContactoPadre,
                IdContactoHijo = domain.IdContactoHijo,
                NotaRelacion = domain.NotaRelacion
            };

        }

        public ContactoRelacionViewModel  DomainToViewModelCR(TbCrContactoRelacion domain)
        {
            return new ContactoRelacionViewModel
            {
                Id = domain.Id,
                IdContactoPadre = domain.IdContactoPadre,
                IdContactoHijo = domain.IdContactoHijo,
                NotaRelacion = domain.NotaRelacion

            };

        }

        public TbFdCuentasBancarias CreateCuentaBancaria(CuentaBancariaViewModel viewModel)
        {
            return contactoService.AgregarCuentasBancarias(ViewModelToDomainCB(viewModel));
        }
        public TbFdCuentasBancarias UpdateCuentaBancaria(CuentaBancariaViewModel viewModel)
        {
            return contactoService.EditarCuentasBancarias(ViewModelToDomainCB(viewModel));
        }

        public CuentaBancariaViewModel DomainToViewModelCB(TbFdCuentasBancarias domain)
        {
            return new CuentaBancariaViewModel
            {
                Banco = domain.Banco,
                CuentaBancaria = domain.CuentaBancaria,
                Id = domain.Id,
                IdContacto =(long) domain.IdContacto,
                Moneda = domain.Moneda,
                TipoCuenta = domain.TipoCuenta
            };
        }

        public TbFdCuentasBancarias ViewModelToDomainCB (CuentaBancariaViewModel viewModel)
        {
            return new TbFdCuentasBancarias
            {
                Banco = viewModel.Banco,
                CuentaBancaria = viewModel.CuentaBancaria,
                Id = viewModel.Id,
                IdContacto = (long)viewModel.IdContacto,
                Moneda = viewModel.Moneda,
                TipoCuenta = viewModel.TipoCuenta
            };
        }
    }
}
