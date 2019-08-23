using AltivaWebApp.Domains;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public class InventarioMap : IInventarioMap
    {
        readonly IInventarioService service;
        private readonly IHostingEnvironment hostingEnvironment;

        public InventarioMap(IInventarioService service, IHostingEnvironment hostingEnvironment)
        {
            this.service = service;
            this.hostingEnvironment = hostingEnvironment;
        }

        //////////
        public TbPrInventarioBodega UpdateIBodega(InventarioBodegaViewModel viewModel)
        {
            return service.UpdateIBodega(ViewModelToDomainEditarIBodega(viewModel));
        }

        public TbPrInventarioBodega ViewModelToDomainEditarIBodega(InventarioBodegaViewModel viewModel)
        {
            var ib = new TbPrInventarioBodega
            {
                Id = viewModel.Id,
                IdInventario = viewModel.IdInventario,
                IdBodega = viewModel.IdBodega,
                ExistenciaMinima = viewModel.ExistenciaMinima,
                ExistenciaMaxima = viewModel.ExistenciaMaxima,
                ExistenciaBodega = viewModel.ExistenciaBodega,
                CostoPromedioBodega = viewModel.CostoPromedioBodega,
                SaldoBodega = viewModel.SaldoBodega,
                UltimoCostoBodega = viewModel.UltimoCostoBodega,
                ExistenciaMedia = viewModel.ExistenciaMedia
            };
                 return ib;
        }
        /////////

        public TbPrInventario Create(InventarioViewModel viewModel)
        {
            var inventario = service.Save(ViewModelToDomainNuevo(viewModel));

            return inventario;
        }

        public void CreateInventarioBodega(int idInventario, IList<InventarioBodegaViewModel> viewModelaRel)
        {


            foreach (var item in viewModelaRel)
            {
                item.IdInventario = idInventario;
            }


           
            service.SaveInventarioBodega(ViewModelToDomainIB(viewModelaRel));
            
        }

        public void CreateImagen(int id, IFormFile[] files)
        {
             service.SaveImagenInventario(ViewModelToDomainNuevoImagen(id, files));

         
        }
        public void CreateCaracteristica(int id, string caracteristica)
        {
            service.SaveCaracteristicaInventario(ViewModelToDomainNuevoCaracteristica(id, caracteristica));
        }

        public TbPrInventario Update(int id, InventarioViewModel viewModel)
        {
            return service.Update(ViewModelToDomainEditar(id, viewModel));
        }

        public IList<TbPrInventarioBodega> ViewModelToDomainIB(IList<InventarioBodegaViewModel> viewModel)
        {
            var domain = new List<TbPrInventarioBodega>();
            foreach (var item in viewModel)
            {
                var ib = new TbPrInventarioBodega
                {
                    CostoPromedioBodega = item.CostoPromedioBodega,
                    ExistenciaBodega = item.ExistenciaBodega,
                    ExistenciaMaxima = item.ExistenciaMaxima,
                    ExistenciaMedia = item.ExistenciaMedia,
                    ExistenciaMinima = item.ExistenciaMinima,
                    IdBodega = item.IdBodega,
                    IdInventario = item.IdInventario,
                    SaldoBodega = item.SaldoBodega,
                    UltimoCostoBodega = item.UltimoCostoBodega
                };

                domain.Add(ib);
            }

            return domain;
        }

        public IList<TbPrImagenInventario> ViewModelToDomainNuevoImagen(int id, IFormFile[] files)
        {
            var imgInventario = new List<TbPrImagenInventario>();

            var savePath = System.IO.Path.Combine(hostingEnvironment.WebRootPath, "Files");
            var fotos = FotosService.SubirAdjuntos(files, savePath);
            foreach (var item in fotos)
            {
                imgInventario.Add(new TbPrImagenInventario
                {
                    IdInventario = id,
                    Imagen = item
                });
            }

            return imgInventario;
            //service.SaveImagenInventario(imgInventario);
        }

        public TbPrInventarioCaracteristica ViewModelToDomainNuevoCaracteristica(int id, string caracteristica)
        {
            return new TbPrInventarioCaracteristica
            {
                IdInventario = id,
                Caracteristicas = caracteristica
            };
        }
        public TbPrInventario ViewModelToDomainNuevo(InventarioViewModel viewModel)
        {
            return new TbPrInventario
            {
                CantidadUnidad = viewModel.CantidadUnidad,
                Codigo = viewModel.Codigo,
                CodigoMoneda = viewModel.CodigoMoneda,
                CodigoMonedaVenta = viewModel.CodigoMonedaVenta,
                CostoPromedioGeneral = viewModel.CostoPromedioGeneral,
                Descripcion = viewModel.Descripcion,
                DescripcionVenta = viewModel.DescripcionVenta,
                ExistenciaGeneral = viewModel.ExistenciaGeneral,
                FactorAprovechamiento = viewModel.FactorAprovechamiento,
                FechaCreacion = DateTime.Now,
                HabilitarVentaDirecta = viewModel.HabilitarVentaDirecta,
                IdSubFamilia = viewModel.IdSubFamilia,
                IdUnidadMedida = viewModel.IdUnidadMedida,
                IdUsuario = viewModel.IdUsuario,
                ImpuestoVenta = viewModel.ImpuestoVenta,
                Inactiva = viewModel.Inactiva,
                PrecioCredito = viewModel.PrecioCredito,
                PrecioCreditoFinal = viewModel.PrecioCreditoFinal,
                Notas = viewModel.Notas,
                PrecioTemporal = viewModel.PrecioTemporal,
                PrecioTemporalFinal = viewModel.PrecioTemporalFinal,
                PrecioVenta = viewModel.PrecioVenta,
                PrecioVentaFinal = viewModel.PrecioVentaFinal,
                UtilidadCredito = viewModel.UtilidadCredito,
                UltimoPrecioCompra = viewModel.UltimoPrecioCompra,
                UtilidadDeseada = viewModel.UtilidadDeseada,
                UtilidadTemporal = viewModel.UtilidadTemporal,
                IdFamiliaOnline = viewModel.IdFamiliaOnline,
                NombreCarrito = viewModel.NombreCarrito,
                PrecioVentaOnline = viewModel.PrecioVentaOnline,
                AbreviacionFacturas = viewModel.AbreviacionFactura,
                IdMonedaVentaOnline = viewModel.CodigoMonedaOnline,
                HabilitarVentaOnline = viewModel.HabilitarVentaOnline,
                SkuOnline = viewModel.SkuOnline
                
            };
        }
        public TbPrInventario ViewModelToDomainEditar(int id, InventarioViewModel viewModel)
        {
            var inventario = service.GetInventarioById(id);

            inventario.CantidadUnidad = viewModel.CantidadUnidad;
            inventario.Codigo = viewModel.Codigo;
            inventario.CodigoMoneda = viewModel.CodigoMoneda;
            inventario.CodigoMonedaVenta = viewModel.CodigoMonedaVenta;
            inventario.CostoPromedioGeneral = viewModel.CostoPromedioGeneral;
            inventario.Descripcion = viewModel.Descripcion;
            inventario.DescripcionVenta = viewModel.DescripcionVenta;
            inventario.ExistenciaGeneral = viewModel.ExistenciaGeneral;
            inventario.FactorAprovechamiento = viewModel.FactorAprovechamiento;
            inventario.HabilitarVentaDirecta = viewModel.HabilitarVentaDirecta;
            inventario.IdSubFamilia = viewModel.IdSubFamilia;
            inventario.IdUnidadMedida = viewModel.IdUnidadMedida;
            inventario.IdUsuario = viewModel.IdUsuario;
            inventario.ImpuestoVenta = viewModel.ImpuestoVenta;
            inventario.Inactiva = viewModel.Inactiva;
            inventario.PrecioCredito = viewModel.PrecioCredito;
            inventario.PrecioCreditoFinal = viewModel.PrecioCreditoFinal;
            inventario.Notas = viewModel.Notas;
            inventario.PrecioTemporal = viewModel.PrecioTemporal;
            inventario.PrecioTemporalFinal = viewModel.PrecioTemporalFinal;
            inventario.PrecioVenta = viewModel.PrecioVenta;
            inventario.PrecioVentaFinal = viewModel.PrecioVentaFinal;
            inventario.UtilidadCredito = viewModel.UtilidadCredito;
            inventario.UltimoPrecioCompra = viewModel.UltimoPrecioCompra;
            inventario.UtilidadDeseada = viewModel.UtilidadDeseada;
            inventario.UtilidadTemporal = viewModel.UtilidadTemporal;
            inventario.IdFamiliaOnline = viewModel.IdFamiliaOnline;
            inventario.NombreCarrito = viewModel.NombreCarrito;
            inventario.PrecioVentaOnline = viewModel.PrecioVentaOnline;
            inventario.AbreviacionFacturas = viewModel.AbreviacionFactura;
            inventario.HabilitarVentaOnline = viewModel.HabilitarVentaOnline;
            inventario.SkuOnline = viewModel.SkuOnline;   
           
            return inventario;

        }


        public InventarioViewModel DomainToViewModel(TbPrInventario domain)
        {
            return new InventarioViewModel
            {
                CantidadUnidad = (float)domain.CantidadUnidad,
                Codigo = domain.Codigo,
                CodigoMoneda = domain.CodigoMoneda,
                CodigoMonedaVenta = domain.CodigoMonedaVenta,
                CostoPromedioGeneral = (float)domain.CostoPromedioGeneral,
                Descripcion = domain.Descripcion,
                DescripcionVenta = domain.DescripcionVenta,
                ExistenciaGeneral = (float)domain.ExistenciaGeneral,
                FactorAprovechamiento = (float)domain.FactorAprovechamiento,
                HabilitarVentaDirecta = domain.HabilitarVentaDirecta,
                IdInventario = domain.IdInventario,
                IdSubFamilia = domain.IdSubFamilia,
                IdUnidadMedida = domain.IdUnidadMedida,
                IdUsuario = domain.IdUsuario,
                ImpuestoVenta = (float)domain.ImpuestoVenta,
                Inactiva = domain.Inactiva,
                Notas = domain.Notas,
                PrecioCredito = (float)domain.PrecioCredito,
                PrecioCreditoFinal = (float)domain.PrecioCreditoFinal,
                PrecioTemporal = (float)domain.PrecioTemporal,
                PrecioTemporalFinal = (float)domain.PrecioTemporalFinal,
                PrecioVenta = (float)domain.PrecioVenta,
                PrecioVentaFinal = (float)domain.PrecioVentaFinal,
                UltimoPrecioCompra = (float)domain.UltimoPrecioCompra,
                UtilidadCredito = (float)domain.UtilidadCredito,
                UtilidadDeseada = (float)domain.UtilidadDeseada,
                UtilidadTemporal = (float)domain.UtilidadTemporal,        
                IdFamiliaOnline = (int)domain.IdFamiliaOnline,
                NombreCarrito = domain.NombreCarrito,
                PrecioVentaOnline = (float)domain.PrecioVentaOnline,
                AbreviacionFactura = domain.AbreviacionFacturas,
                CodigoMonedaOnline =(int) domain.IdMonedaVentaOnline,
                HabilitarVentaOnline = domain.HabilitarVentaOnline,
                SkuOnline = domain.SkuOnline,


                Bodegas = domain.TbPrInventarioBodega.ToList()
            };
        }

        public InventarioBodegaViewModel DomainToViewModelIBodega(TbPrInventarioBodega domain)
        {
            return new InventarioBodegaViewModel
            {
                Id = domain.Id,
                IdInventario = domain.IdInventario,
                IdBodega = domain.IdBodega,
                ExistenciaMinima = domain.ExistenciaMinima,
                ExistenciaMaxima = domain.ExistenciaMaxima,
                ExistenciaBodega = domain.ExistenciaBodega,
                CostoPromedioBodega = domain.CostoPromedioBodega,
                SaldoBodega = domain.SaldoBodega,
                UltimoCostoBodega = domain.UltimoCostoBodega,
                ExistenciaMedia = domain.ExistenciaMedia


            };
        }



    }
}
