﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;

namespace AltivaWebApp.Mappers
{
    public class ContactoMapper : IContactoMap
    {

        //variable service de contacto
        public IContactoService contactoService;
        public ICamposPersonalizadosService ICamposPersonalizados;
        public ContactoMapper(IContactoService pContactoService, ICamposPersonalizadosService ICamposPersonalizados)
        {
            this.contactoService = pContactoService;
            this.ICamposPersonalizados = ICamposPersonalizados;
        }

        public TbCrCamposPersonalizados Delete(int id)
        {
            TbCrCamposPersonalizados cp = new TbCrCamposPersonalizados();
            cp = this.ICamposPersonalizados.getById(id);
            cp.Estado = "Eliminado";

            return this.ICamposPersonalizados.Edit(cp);
        }

        public TbCrCamposPersonalizados Edit(CamposPersonalizadosViewModelSingle domain)
        {
            return this.ICamposPersonalizados.Edit(viewModelCamposEdit(domain));
        }

        public TbCrContacto EditarContacto(ContactoViewModel domain)
        {
            return this.contactoService.Edit(viewToModelContactoEditar(domain));
        }

        public TbCrContacto ingresarImagen(int id, string ruta)
        {
            TbCrContacto contacto = new TbCrContacto();

            contacto = this.contactoService.GetByIdContacto(id);
            contacto.Nombre = contacto.Nombre;
            contacto.Apellidos = contacto.Apellidos;
            contacto.TipoCedula = contacto.TipoCedula;
            contacto.Cedula = contacto.Cedula;
            contacto.Telefono = contacto.Telefono;
            contacto.Correo = contacto.Correo;
            contacto.Pais = contacto.Pais;
            contacto.Provincia = contacto.Provincia;
            contacto.Canton = contacto.Canton;
            contacto.Distrito = contacto.Distrito;
            contacto.Persona = contacto.Persona;
            contacto.Empresa = contacto.Empresa;
            contacto.Cliente = contacto.Proveedor;
            contacto.OtrasSenas = contacto.OtrasSenas;
            contacto.NombreComercial = contacto.NombreComercial;
            contacto.NombreJuridico = contacto.NombreJuridico;
            contacto.Ruta = ruta;
            contacto.IdUsuario = contacto.IdUsuario;
        
            return this.contactoService.Edit(contacto);
        }

        public TbCrContactoRelacion InsertarRelacion(ContactoRelacionViewModel domain)
        {
            return this.contactoService.InsertarRelacion(viewToModelContactoRelacion(domain));
           
        }

        public TbCrContacto NuevoContacto(ContactoViewModel domain)
        {
            return this.contactoService.Save(viewToModelContacto(domain));
        }

        public TbCrCamposPersonalizados viewModelCamposEdit(CamposPersonalizadosViewModelSingle domain)
        {
            TbCrCamposPersonalizados tp = new TbCrCamposPersonalizados();
            tp.Id = domain.Id;
            tp.Nombre = domain.Nombre;
            tp.Tipo = domain.Tipo;
            tp.Estado = domain.Estado;

            return tp;
        }

        public TbCrContacto viewToModelContacto(ContactoViewModel domain)
        {
            String cedula ="";
            if (domain.Nombre != null)
            {
                domain.Persona = true;
            }else if (domain.NombreJuridico != null)
            {
                domain.Empresa = true;
            }
            if (domain.Cedula != null)
            {
                cedula = domain.Cedula;
            }else if (domain.juridica != null)
            {
                cedula = domain.juridica;
            }else if (domain.dimex != null)
            {
                cedula = domain.dimex;
            }else if (domain.nite != null)
            {
                cedula = domain.nite;
            }
            
            TbCrContacto contacto = new TbCrContacto();

            contacto = new TbCrContacto
            {
            Nombre = domain.Nombre,
            Apellidos = domain.Apellidos,
            TipoCedula = domain.TipoCedula,
            Cedula = cedula,
            NombreComercial = domain.NombreComercial,
            NombreJuridico =  domain.NombreJuridico,
            Telefono = domain.Telefono,
            Correo = domain.Correo,
            Pais = domain.Pais,
            Provincia = domain.Provincia,
            Cliente = domain.Cliente,
            Proveedor= domain.Proveedor,
            Canton = domain.Canton,
            Distrito = domain.Distrito,
            OtrasSenas = domain.OtrasSenas,
            Persona = domain.Persona,
            Empresa = domain.Empresa,
            IdUsuario = domain.IdUsuario,
            WebLink = domain.WebLink,
            MapLink = domain.MapLink,
            IdTipoCliente = domain.IdTipoCliente,
            IdFamiliaCliente = domain.IdFamiliaCliente,
            IdSubFamiliaCliente = domain.IdSubFamiliaCliente,
            IdTipoProveedor = domain.IdTipoProveedor,
            IdFamiliaProveedor = domain.IdFamiliaProveedor,
            IdSubFamiliaProveedor = domain.IdSubFamiliaProveedor
            };
            return contacto;

         
        }

        public TbCrContacto viewToModelContactoEditar(ContactoViewModel domain)
        {
            String cedula = "";
            if (domain.Nombre != null)
            {
                domain.Persona = true;
            }
            else if (domain.NombreJuridico != null)
            {
                domain.Empresa = true;
            }
            if (domain.Cedula != null)
            {
                cedula = domain.Cedula;
            }
            else if (domain.juridica != null)
            {
                cedula = domain.juridica;
            }
            else if (domain.dimex != null)
            {
                cedula = domain.dimex;
            }
            else if (domain.nite != null)
            {
                cedula = domain.nite;
            }
         
            TbCrContacto contacto = new TbCrContacto();

            contacto = this.contactoService.GetByIdContacto(domain.Id);
            contacto.Nombre = domain.Nombre;
            contacto.Apellidos = domain.Apellidos;
            contacto.TipoCedula = domain.TipoCedula;
            contacto.Cedula =cedula;
            contacto.Telefono = domain.Telefono;
            contacto.Correo = domain.Correo;
            contacto.Pais = domain.Pais;
            contacto.Provincia = domain.Provincia;
            contacto.Canton = domain.Canton;
            contacto.Distrito = domain.Distrito;
            contacto.Persona = domain.Persona;
            contacto.Empresa = domain.Empresa;
            contacto.Cliente = domain.Cliente;
            contacto.Proveedor = domain.Proveedor;
            contacto.OtrasSenas = domain.OtrasSenas;
            contacto.NombreComercial = domain.NombreComercial;
            contacto.NombreJuridico = domain.NombreJuridico;
            contacto.IdUsuario = domain.IdUsuario;
            contacto.WebLink = domain.WebLink;
            contacto.MapLink = domain.MapLink;
            contacto.IdTipoCliente = domain.IdTipoCliente;
            contacto.IdFamiliaCliente = domain.IdFamiliaCliente;
            contacto.IdSubFamiliaCliente = domain.IdSubFamiliaCliente;
            contacto.IdTipoProveedor = domain.IdTipoProveedor;
            contacto.IdFamiliaProveedor = domain.IdFamiliaProveedor;
            contacto.IdSubFamiliaProveedor = domain.IdSubFamiliaProveedor;
          
            return contacto;
        }

        public TbCrContactoRelacion viewToModelContactoRelacion(ContactoRelacionViewModel domain)
        {
            TbCrContactoRelacion contactoRelacion = new TbCrContactoRelacion();

            contactoRelacion.IdContactoPadre = domain.IdContactoPadre;
            contactoRelacion.IdContactoHijo = domain.IdContactoHijo;
            contactoRelacion.NotaRelacion = domain.NotaRelacion;

            return contactoRelacion;
        }
    }
}
