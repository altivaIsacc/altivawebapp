using AltivaWebApp.Domains;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public class PuntoVentaMap: IPuntoVentaMap
    {
        private readonly IPuntoVentaService service;

        public PuntoVentaMap(IPuntoVentaService service)
        {
            this.service = service;
        }
        public TbSePuntoVenta Create(PuntoVentaViewModel viewModel)
        {
            return service.Save(ViewModelToDomain(viewModel));
        }

        public TbSePuntoVenta Update(PuntoVentaViewModel viewModel)
        {
            return service.Update(ViewModelToDomainEditar(viewModel));
        }

        public TbSePuntoVenta ViewModelToDomain(PuntoVentaViewModel viewModel)
        {
            return new TbSePuntoVenta
            {
                Nombre = viewModel.Nombre,
                Descripcion = viewModel.Descripcion,
                Inactivo = false,
                Tipo = viewModel.Tipo,
                EsPorDefecto = viewModel.EsPorDefecto,
                OpcionImpresion = viewModel.OpcionImpresion,
                IdContactoClienteDefecto = viewModel.IdContactoClienteDefecto,
                IdBodega = viewModel.IdBodega,
                IdMonedaPrecio = viewModel.IdMonedaPrecio,
                IdMonedaFacturaDefecto = viewModel.IdMonedaFacturaDefecto,
                TieneConcecutivoIndependiente = viewModel.TieneConcecutivoIndependiente,
                PrefijoConcecutivoIndepediente = viewModel.PrefijoConcecutivoIndepediente,
                InicioConcecutivoIndependiente = viewModel.InicioConcecutivoIndependiente,
                TieneEncabezadoIndependiente = viewModel.TieneEncabezadoIndependiente,
                TieneCajaIndependiente = viewModel.TieneCajaIndependiente,
                RazonSocial = viewModel.RazonSocial,
                CedulaJuridica = viewModel.CedulaJuridica,
                Email = viewModel.Email,
                Telefono = viewModel.Telefono,
                Web = viewModel.Web,
                Imagen = viewModel.Imagen,
                FechaCreacion = DateTime.Now,
                IdUsuarioCreacion = viewModel.IdUsuarioCreacion
            };
        }
        public TbSePuntoVenta ViewModelToDomainEditar(PuntoVentaViewModel viewModel)
        {
            var domain = service.GetPuntoVentaById((int)viewModel.IdPuntoVenta);

            domain.Nombre = viewModel.Nombre;
            domain.Descripcion = viewModel.Descripcion;
            domain.Inactivo = viewModel.Inactivo;
            domain.Tipo = viewModel.Tipo;
            domain.EsPorDefecto = viewModel.EsPorDefecto;
            domain.OpcionImpresion = viewModel.OpcionImpresion;
            domain.IdContactoClienteDefecto = viewModel.IdContactoClienteDefecto;
            domain.IdBodega = viewModel.IdBodega;
            domain.IdMonedaPrecio = viewModel.IdMonedaPrecio;
            domain.IdMonedaFacturaDefecto = viewModel.IdMonedaFacturaDefecto;
            domain.TieneConcecutivoIndependiente = viewModel.TieneConcecutivoIndependiente;
            domain.PrefijoConcecutivoIndepediente = viewModel.PrefijoConcecutivoIndepediente;
            domain.InicioConcecutivoIndependiente = viewModel.InicioConcecutivoIndependiente;
            domain.TieneEncabezadoIndependiente = viewModel.TieneEncabezadoIndependiente;
            domain.TieneCajaIndependiente = viewModel.TieneCajaIndependiente;
            domain.RazonSocial = viewModel.RazonSocial;
            domain.CedulaJuridica = viewModel.CedulaJuridica;
            domain.Email = viewModel.Email;
            domain.Telefono = viewModel.Telefono;
            domain.Web = viewModel.Web;
            domain.Imagen = viewModel.Imagen;


            return domain;
        }
        public PuntoVentaViewModel DomainToVIewModel(TbSePuntoVenta domain)
        {
            return new PuntoVentaViewModel
            {
                IdPuntoVenta = domain.IdPuntoVenta,
                Nombre = domain.Nombre,
                Descripcion = domain.Descripcion,
                Inactivo = domain.Inactivo,
                Tipo = domain.Tipo,
                EsPorDefecto = domain.EsPorDefecto,
                OpcionImpresion = domain.OpcionImpresion,
                IdContactoClienteDefecto = domain.IdContactoClienteDefecto,
                IdBodega = domain.IdBodega,
                IdMonedaPrecio = domain.IdMonedaPrecio,
                IdMonedaFacturaDefecto = domain.IdMonedaFacturaDefecto,
                TieneConcecutivoIndependiente = domain.TieneConcecutivoIndependiente,
                PrefijoConcecutivoIndepediente = domain.PrefijoConcecutivoIndepediente,
                InicioConcecutivoIndependiente = domain.InicioConcecutivoIndependiente,
                TieneEncabezadoIndependiente = domain.TieneEncabezadoIndependiente,
                TieneCajaIndependiente = domain.TieneCajaIndependiente,
                RazonSocial = domain.RazonSocial,
                CedulaJuridica = domain.CedulaJuridica,
                Email = domain.Email,
                Telefono = domain.Telefono,
                Web = domain.Web,
                Imagen = domain.Imagen,
                IdUsuarioCreacion = domain.IdUsuarioCreacion


            };
        }
    }
}
