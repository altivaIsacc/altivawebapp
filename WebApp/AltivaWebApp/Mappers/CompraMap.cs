using AltivaWebApp.Domains;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AltivaWebApp.Mappers
{
    public class CompraMap: ICompraMap
    {
        private readonly ICompraService service;
        private readonly IInventarioService inventarioService;
        private readonly IKardexMap kardexMap;

        public CompraMap(IInventarioService inventarioService, IKardexMap kardexMap, ICompraService service)
        {
            this.service = service;
            this.kardexMap = kardexMap;
            this.inventarioService = inventarioService;
        }

        public TbPrCompra Create(CompraViewModel viewModel)
        {
            var compra = service.Save(ViewModelToDomain(viewModel));
            var cd = compra.TbPrCompraDetalle.First();
            if (cd != null)
                if (!service.ExisteRelacionInventarioBodega(cd.IdInventario, cd.IdBodega))
                    inventarioService.CrearRelacionInventarioBodega((int)cd.IdInventario, (int)cd.IdBodega);
                
            return compra;
        }

        public TbPrCompra Update(CompraViewModel viewModel)
        {
            return service.Update(ViewModelToDomainEdit(viewModel));
        }

        public TbPrCompraDetalle CreateCD(CompraViewModel viewModel)
        {
            return service.SaveCompraDetalle(ViewModelToDomainCD(viewModel)[0]);
            
        }
        public TbCpComprasDetalleServicio CreateCDS(CompraViewModel viewModel)
        {
            return service.SaveComprasDetalleServicio(ViewModelToDomainCDS(viewModel)[0]);

        }
        public bool UpdateCD(CompraViewModel viewModel)
        {
            return service.UpdateCompraDetalle(ViewModelToDomainCD(viewModel));
        }
        public bool UpdateCDS(CompraViewModel viewModel)
        {
            return service.UpdateComprasDetalleServicio(ViewModelToDomainCDS(viewModel));
        }

        public CompraViewModel DomainToViewModel(TbPrCompra domain)
        {
            var viewModel = new CompraViewModel
            {
                Anulado = domain.Anulado,
                FechaDocumento = domain.FechaDocumento,
                Id = domain.Id,
                IdMoneda = domain.IdMoneda,
                IdProveedor = domain.IdContacto,
                IdUsuario = domain.IdUsuario,
                TipoCambioDolar = domain.TipoCambioDolar,
                TipoCambioEuro = domain.TipoCambioEuro,
                Borrador = domain.Borrador,
                NumeroDocumento = domain.NumeroDocumento,
                FechaCreacion = domain.FechaCreacion,
                TipoDocumento = domain.TipoDocumento,
                EnCola = domain.EnCola
                
            };

            if (domain.IdMoneda == 1)
            {
                viewModel.SubTotalExcento = domain.SubTotalExcentoBase;
                viewModel.SubTotalGravado = domain.SubTotalGravadoBase;
                viewModel.Total = domain.TotalBase;
                viewModel.TotalIva = domain.TotalIvabase;
                viewModel.TotalDescuento = domain.TotalDescuentoBase;
                viewModel.SubTotalExcentoNeto = domain.SubTotalExcentoNetoBase;
                viewModel.SubTotalGravadoNeto = domain.SubTotalGravadoNetoBase;
                viewModel.TotalFa = domain.TotalFabase;
            }
            else if (domain.IdMoneda == 2)
            {
                viewModel.SubTotalExcento = domain.SubTotalExcentoDolar;
                viewModel.SubTotalGravado = domain.SubTotalGravadoDolar;
                viewModel.Total = domain.TotalDolar;
                viewModel.TotalIva = domain.TotalIvadolar;
                viewModel.TotalDescuento = domain.TotalDescuentoDolar;
                viewModel.SubTotalExcentoNeto = domain.SubTotalExcentoNetoDolar;
                viewModel.SubTotalGravadoNeto = domain.SubTotalGravadoNetoDolar;
                viewModel.TotalFa = domain.TotalFadolar;
            }
            else if (domain.IdMoneda == 3)
            {
                viewModel.SubTotalExcento = domain.SubTotalExcentoEuro;
                viewModel.SubTotalGravado = domain.SubTotalGravadoEuro;
                viewModel.Total = domain.TotalEuro;
                viewModel.TotalIva = domain.TotalIvaeuro;
                viewModel.TotalDescuento = domain.TotalDescuentoEuro;
                viewModel.SubTotalExcentoNeto = domain.SubTotalExcentoNetoEuro;
                viewModel.SubTotalGravadoNeto = domain.SubTotalGravadoNetoEuro;
                viewModel.TotalFa = domain.TotalFaeuro;
            }


            return viewModel;
        }

        public TbPrCompra ViewModelToDomain(CompraViewModel viewModel)
        {

            var domain = new TbPrCompra
            {
                Id = viewModel.Id,
                IdMoneda = viewModel.IdMoneda,
                IdContacto = viewModel.IdProveedor,
                IdUsuario = viewModel.IdUsuario,
                Anulado = false,
                FechaCreacion = DateTime.Now,
                FechaDocumento = viewModel.FechaDocumento,
                NumeroDocumento = viewModel.NumeroDocumento,
                TipoDocumento = viewModel.TipoDocumento,
                Borrador = viewModel.Borrador,
                EnCola = false,
                TipoCambioDolar = viewModel.TipoCambioDolar,
                TipoCambioEuro = viewModel.TipoCambioEuro,

                TbPrCompraDetalle = ViewModelToDomainCD(viewModel)
            };

            if (viewModel.IdMoneda == 1)
            {
                domain.SubTotalExcentoBase = viewModel.SubTotalExcento;
                domain.SubTotalExcentoDolar = domain.SubTotalExcentoBase / domain.TipoCambioDolar;
                domain.SubTotalExcentoEuro = domain.SubTotalExcentoBase / domain.TipoCambioEuro;

                domain.SubTotalExcentoNetoBase = viewModel.SubTotalExcentoNeto;
                domain.SubTotalExcentoNetoDolar = domain.SubTotalExcentoNetoBase / domain.TipoCambioDolar;
                domain.SubTotalExcentoNetoEuro = domain.SubTotalExcentoNetoBase / domain.TipoCambioEuro;

                domain.SubTotalGravadoBase = viewModel.SubTotalGravado;
                domain.SubTotalGravadoDolar = domain.SubTotalGravadoBase / domain.TipoCambioDolar;
                domain.SubTotalGravadoEuro = domain.SubTotalGravadoBase / domain.TipoCambioEuro;

                domain.SubTotalGravadoNetoBase = viewModel.SubTotalGravadoNeto;
                domain.SubTotalGravadoNetoDolar = domain.SubTotalGravadoNetoBase / domain.TipoCambioDolar;
                domain.SubTotalGravadoNetoEuro = domain.SubTotalGravadoNetoBase / domain.TipoCambioEuro;


                domain.TotalIvabase = viewModel.TotalIva;
                domain.TotalIvadolar = domain.TotalIvabase / domain.TipoCambioDolar;
                domain.TotalIvaeuro = domain.TotalIvabase / domain.TipoCambioEuro;

                domain.TotalFabase = viewModel.TotalFa;
                domain.TotalFadolar = domain.TotalFabase / domain.TipoCambioDolar;
                domain.TotalFaeuro = domain.TotalFabase / domain.TipoCambioEuro;

                domain.TotalBase = viewModel.Total;
                domain.TotalDolar = domain.TotalBase / domain.TipoCambioDolar;
                domain.TotalEuro = domain.TotalBase / domain.TipoCambioEuro;

                domain.TotalDescuentoBase = viewModel.TotalDescuento;
                domain.TotalDescuentoDolar = domain.TotalDescuentoBase / domain.TipoCambioDolar;
                domain.TotalDescuentoEuro = domain.TotalDescuentoBase / domain.TipoCambioEuro;

            }
            else if (viewModel.IdMoneda == 2)
            {
                domain.SubTotalExcentoBase = viewModel.SubTotalExcento * domain.TipoCambioDolar;
                domain.SubTotalExcentoDolar = viewModel.SubTotalExcento;
                domain.SubTotalExcentoEuro = domain.SubTotalExcentoBase / domain.TipoCambioEuro;

                domain.SubTotalExcentoNetoBase = viewModel.SubTotalExcentoNeto * domain.TipoCambioDolar;
                domain.SubTotalExcentoNetoDolar = viewModel.SubTotalExcentoNeto;
                domain.SubTotalExcentoNetoEuro = domain.SubTotalExcentoNetoBase / domain.TipoCambioEuro;

                domain.SubTotalGravadoBase = viewModel.SubTotalGravado * domain.TipoCambioDolar;
                domain.SubTotalGravadoDolar = viewModel.SubTotalGravado;
                domain.SubTotalGravadoEuro = domain.SubTotalGravadoBase / domain.TipoCambioEuro;

                domain.SubTotalGravadoNetoBase = viewModel.SubTotalGravadoNeto * domain.TipoCambioDolar;
                domain.SubTotalGravadoNetoDolar = viewModel.SubTotalGravadoNeto;
                domain.SubTotalGravadoNetoEuro = domain.SubTotalGravadoNetoBase / domain.TipoCambioEuro;


                domain.TotalIvabase = viewModel.TotalIva * domain.TipoCambioDolar;
                domain.TotalIvadolar = viewModel.TotalIva;
                domain.TotalIvaeuro = domain.TotalIvabase / domain.TipoCambioEuro;

                domain.TotalFabase = viewModel.TotalFa * domain.TipoCambioDolar;
                domain.TotalFadolar = viewModel.TotalFa;
                domain.TotalFaeuro = domain.TotalFabase / domain.TipoCambioEuro;

                domain.TotalBase = viewModel.Total * domain.TipoCambioDolar;
                domain.TotalDolar = viewModel.Total;
                domain.TotalEuro = domain.TotalBase / domain.TipoCambioEuro;

                domain.TotalDescuentoBase = viewModel.TotalDescuento * domain.TipoCambioDolar;
                domain.TotalDescuentoDolar = viewModel.TotalDescuento;
                domain.TotalDescuentoEuro = domain.TotalDescuentoBase / domain.TipoCambioEuro;
            }
            else if (viewModel.IdMoneda == 3)
            {

                domain.SubTotalExcentoBase = viewModel.SubTotalExcento * domain.TipoCambioEuro;
                domain.SubTotalExcentoDolar = domain.SubTotalExcentoBase / domain.TipoCambioDolar;
                domain.SubTotalExcentoEuro = viewModel.SubTotalExcento;

                domain.SubTotalExcentoNetoBase = viewModel.SubTotalExcentoNeto * domain.TipoCambioEuro;
                domain.SubTotalExcentoNetoDolar = domain.SubTotalExcentoNetoBase / domain.TipoCambioDolar;
                domain.SubTotalExcentoNetoEuro = viewModel.SubTotalExcentoNeto;

                domain.SubTotalGravadoBase = viewModel.SubTotalGravado * domain.TipoCambioEuro;
                domain.SubTotalGravadoDolar = domain.SubTotalGravadoBase / domain.TipoCambioDolar;
                domain.SubTotalGravadoEuro = viewModel.SubTotalGravado;

                domain.SubTotalGravadoNetoBase = viewModel.SubTotalGravadoNeto * domain.TipoCambioEuro;
                domain.SubTotalGravadoNetoDolar = domain.SubTotalGravadoNetoBase / domain.TipoCambioDolar;
                domain.SubTotalGravadoNetoEuro = viewModel.SubTotalGravadoNeto;


                domain.TotalIvabase = viewModel.TotalIva * domain.TipoCambioEuro;
                domain.TotalIvadolar = domain.TotalIvabase / domain.TipoCambioDolar;
                domain.TotalIvaeuro = viewModel.TotalIva;

                domain.TotalFabase = viewModel.TotalFa * domain.TipoCambioEuro;
                domain.TotalFadolar = domain.TotalFabase / domain.TipoCambioDolar;
                domain.TotalFaeuro = viewModel.TotalFa;

                domain.TotalBase = viewModel.Total * domain.TipoCambioEuro;
                domain.TotalDolar = domain.TotalBase / domain.TipoCambioDolar;
                domain.TotalEuro = viewModel.Total;

                domain.TotalDescuentoBase = viewModel.TotalDescuento * domain.TipoCambioEuro;
                domain.TotalDescuentoDolar = domain.TotalDescuentoBase / domain.TipoCambioDolar;
                domain.TotalDescuentoEuro = viewModel.TotalDescuento;
            }

            return domain;

        }

        public TbPrCompra ViewModelToDomainEdit(CompraViewModel viewModel)
        {
            
            var domain = service.GetCompraById((int)viewModel.Id);
            
            
            domain.IdContacto = viewModel.IdProveedor;
            domain.IdUsuario = viewModel.IdUsuario;
            domain.Anulado = false;
            domain.EnCola = viewModel.EnCola;
            //domain.FechaCreacion = DateTime.Now;
            domain.FechaDocumento = viewModel.FechaDocumento;
            domain.TipoDocumento = viewModel.TipoDocumento;
            domain.NumeroDocumento = viewModel.NumeroDocumento;
            domain.Borrador = viewModel.Borrador;
            

            if(domain.TipoCambioDolar != viewModel.TipoCambioDolar || domain.TipoCambioEuro != viewModel.TipoCambioEuro)
            {
                domain.TipoCambioDolar = viewModel.TipoCambioDolar;
                domain.TipoCambioEuro = viewModel.TipoCambioEuro;
                UpdateTotales(domain);
                kardexMap.CreateKardexEliminarCD(domain);
                kardexMap.CreateKardexCD((int)domain.Id);
            }

            domain.IdMoneda = viewModel.IdMoneda;


            //domain.TbPrCompraDetalle = ViewModelToDomainCD(viewModel);

            if (viewModel.IdMoneda == 1)
            {
                domain.SubTotalExcentoBase = viewModel.SubTotalExcento;
                domain.SubTotalExcentoDolar = domain.SubTotalExcentoBase / domain.TipoCambioDolar;
                domain.SubTotalExcentoEuro = domain.SubTotalExcentoBase / domain.TipoCambioEuro;

                domain.SubTotalExcentoNetoBase = viewModel.SubTotalExcentoNeto;
                domain.SubTotalExcentoNetoDolar = domain.SubTotalExcentoNetoBase / domain.TipoCambioDolar;
                domain.SubTotalExcentoNetoEuro = domain.SubTotalExcentoNetoBase / domain.TipoCambioEuro;

                domain.SubTotalGravadoBase = viewModel.SubTotalGravado;
                domain.SubTotalGravadoDolar = domain.SubTotalGravadoBase / domain.TipoCambioDolar;
                domain.SubTotalGravadoEuro = domain.SubTotalGravadoBase / domain.TipoCambioEuro;

                domain.SubTotalGravadoNetoBase = viewModel.SubTotalGravadoNeto;
                domain.SubTotalGravadoNetoDolar = domain.SubTotalGravadoNetoBase / domain.TipoCambioDolar;
                domain.SubTotalGravadoNetoEuro = domain.SubTotalGravadoNetoBase / domain.TipoCambioEuro;


                domain.TotalIvabase = viewModel.TotalIva;
                domain.TotalIvadolar = domain.TotalIvabase / domain.TipoCambioDolar;
                domain.TotalIvaeuro = domain.TotalIvaeuro / domain.TipoCambioEuro;

                domain.TotalFabase = viewModel.TotalFa;
                domain.TotalFadolar = domain.TotalFabase / domain.TipoCambioDolar;
                domain.TotalFaeuro = domain.TotalFabase / domain.TipoCambioEuro;

                domain.TotalBase = viewModel.Total;
                domain.TotalDolar = domain.TotalBase / domain.TipoCambioDolar;
                domain.TotalEuro = domain.TotalBase / domain.TipoCambioEuro;

                domain.TotalDescuentoBase = viewModel.TotalDescuento;
                domain.TotalDescuentoDolar = domain.TotalDescuentoBase / domain.TipoCambioDolar;
                domain.TotalDescuentoEuro = domain.TotalDescuentoBase / domain.TipoCambioEuro;

            }
            else if (viewModel.IdMoneda == 2)
            {
                domain.SubTotalExcentoBase = viewModel.SubTotalExcento * domain.TipoCambioDolar;
                domain.SubTotalExcentoDolar = viewModel.SubTotalExcento;
                domain.SubTotalExcentoEuro = domain.SubTotalExcentoBase / domain.TipoCambioEuro;

                domain.SubTotalExcentoNetoBase = viewModel.SubTotalExcentoNeto * domain.TipoCambioDolar;
                domain.SubTotalExcentoNetoDolar = viewModel.SubTotalExcentoNeto;
                domain.SubTotalExcentoNetoEuro = domain.SubTotalExcentoNetoBase / domain.TipoCambioEuro;

                domain.SubTotalGravadoBase = viewModel.SubTotalGravado * domain.TipoCambioDolar;
                domain.SubTotalGravadoDolar = viewModel.SubTotalGravado;
                domain.SubTotalGravadoEuro = domain.SubTotalGravadoBase / domain.TipoCambioEuro;

                domain.SubTotalGravadoNetoBase = viewModel.SubTotalGravadoNeto * domain.TipoCambioDolar;
                domain.SubTotalGravadoNetoDolar = viewModel.SubTotalGravadoNeto;
                domain.SubTotalGravadoNetoEuro = domain.SubTotalGravadoNetoBase / domain.TipoCambioEuro;


                domain.TotalIvabase = viewModel.TotalIva * domain.TipoCambioDolar;
                domain.TotalIvadolar = viewModel.TotalIva;
                domain.TotalIvaeuro = domain.TotalIvabase / domain.TipoCambioEuro;

                domain.TotalFabase = viewModel.TotalFa * domain.TipoCambioDolar;
                domain.TotalFadolar = viewModel.TotalFa;
                domain.TotalFaeuro = domain.TotalFabase / domain.TipoCambioEuro;

                domain.TotalBase = viewModel.Total * domain.TipoCambioDolar;
                domain.TotalDolar = viewModel.Total;
                domain.TotalEuro = domain.TotalBase / domain.TipoCambioEuro;

                domain.TotalDescuentoBase = viewModel.TotalDescuento * domain.TipoCambioDolar;
                domain.TotalDescuentoDolar = viewModel.TotalDescuento;
                domain.TotalDescuentoEuro = domain.TotalDescuentoBase / domain.TipoCambioEuro;
            }
            else if (viewModel.IdMoneda == 3)
            {

                domain.SubTotalExcentoBase = viewModel.SubTotalExcento * domain.TipoCambioEuro;
                domain.SubTotalExcentoDolar = domain.SubTotalExcentoBase / domain.TipoCambioDolar;
                domain.SubTotalExcentoEuro = viewModel.SubTotalExcento;

                domain.SubTotalExcentoNetoBase = viewModel.SubTotalExcentoNeto * domain.TipoCambioEuro;
                domain.SubTotalExcentoNetoDolar = domain.SubTotalExcentoNetoBase / domain.TipoCambioDolar;
                domain.SubTotalExcentoNetoEuro = viewModel.SubTotalExcentoNeto;

                domain.SubTotalGravadoBase = viewModel.SubTotalGravado * domain.TipoCambioEuro;
                domain.SubTotalGravadoDolar = domain.SubTotalGravadoBase / domain.TipoCambioDolar;
                domain.SubTotalGravadoEuro = viewModel.SubTotalGravado;

                domain.SubTotalGravadoNetoBase = viewModel.SubTotalGravadoNeto * domain.TipoCambioEuro;
                domain.SubTotalGravadoNetoDolar = domain.SubTotalGravadoNetoBase / domain.TipoCambioDolar;
                domain.SubTotalGravadoNetoEuro = viewModel.SubTotalGravadoNeto;


                domain.TotalIvabase = viewModel.TotalIva * domain.TipoCambioEuro;
                domain.TotalIvadolar = domain.TotalIvabase / domain.TipoCambioDolar;
                domain.TotalIvaeuro = viewModel.TotalIva;

                domain.TotalFabase = viewModel.TotalFa * domain.TipoCambioEuro;
                domain.TotalFadolar = domain.TotalFabase / domain.TipoCambioDolar;
                domain.TotalFaeuro = viewModel.TotalFa;

                domain.TotalBase = viewModel.Total * domain.TipoCambioEuro;
                domain.TotalDolar = domain.TotalBase / domain.TipoCambioDolar;
                domain.TotalEuro = viewModel.Total;

                domain.TotalDescuentoBase = viewModel.TotalDescuento * domain.TipoCambioEuro;
                domain.TotalDescuentoDolar = domain.TotalDescuentoBase / domain.TipoCambioDolar;
                domain.TotalDescuentoEuro = viewModel.TotalDescuento;
            }
            return domain;

        }

        public void UpdateTotalesGastos(TbPrCompra compra)
        {
            var detallesServicios = new List<TbCpComprasDetalleServicio>();
            var dolar = compra.TipoCambioDolar;
            var euro = compra.TipoCambioEuro;

            foreach (var domain in compra.TbCpComprasDetalleServicio)
            {


                domain.SubTotalExcentoDolar = domain.SubTotalExcentoBase / dolar;
                domain.SubTotalExcentoEuro = domain.SubTotalExcentoBase / euro;

                domain.SubTotalExcentoNetoDolar = domain.SubTotalExcentoNetoBase / dolar;
                domain.SubTotalExcentoNetoEuro = domain.SubTotalExcentoNetoBase / euro;

                domain.SubTotalGravadoDolar = domain.SubTotalGravadoBase / dolar;
                domain.SubTotalGravadoEuro = domain.SubTotalGravadoBase / euro;

                domain.SubTotalGravadoNetoDolar = domain.SubTotalGravadoNetoBase / dolar;
                domain.SubTotalGravadoNetoEuro = domain.SubTotalGravadoNetoBase / euro;

                domain.TotalIvadolar = domain.TotalIvabase / dolar;
                domain.TotalIvaeuro = domain.TotalIvabase / euro;

                domain.TotalDolar = domain.TotalBase / dolar;
                domain.TotalEuro = domain.TotalBase / euro;

                domain.TotalIsdolar = domain.TotalIsbase / dolar;
                domain.TotalIseuro = domain.TotalIsbase / euro;

                domain.TotalDescuentoDolar = domain.TotalDescuentoBase / dolar;
                domain.TotalDescuentoEuro = domain.TotalDescuentoBase / euro;
                detallesServicios.Add(domain);
            }
            service.UpdateComprasDetalleServicio(detallesServicios);
        }
        public void UpdateTotales(TbPrCompra compra)
        {
            var detalles = new List<TbPrCompraDetalle>();
            var dolar = compra.TipoCambioDolar;
            var euro = compra.TipoCambioEuro;

            foreach (var domain in compra.TbPrCompraDetalle)
            {
                domain.PrecioUnitarioDolar = domain.PrecioUnitarioBase / dolar;
                domain.PrecioUnitarioEuro = domain.PrecioUnitarioBase / euro;

                domain.SubTotalExcentoDolar = domain.SubTotalExcentoBase / dolar;
                domain.SubTotalExcentoEuro = domain.SubTotalExcentoBase / euro;

                domain.SubTotalExcentoNetoDolar = domain.SubTotalExcentoNetoBase / dolar;
                domain.SubTotalExcentoNetoEuro = domain.SubTotalExcentoNetoBase / euro;

                domain.SubTotalGravadoDolar = domain.SubTotalGravadoBase / dolar;
                domain.SubTotalGravadoEuro = domain.SubTotalGravadoBase / euro;

                domain.SubTotalGravadoNetoDolar = domain.SubTotalGravadoNetoBase / dolar;
                domain.SubTotalGravadoNetoEuro = domain.SubTotalGravadoNetoBase / euro;

                domain.TotalIvadolar = domain.TotalIvabase / dolar;
                domain.TotalIvaeuro = domain.TotalIvabase / euro;

                domain.TotalDolar = domain.TotalBase / dolar;
                domain.TotalEuro = domain.TotalBase / euro;

                domain.TotalFadolar = domain.TotalFabase / dolar;
                domain.TotalFaeuro = domain.TotalFabase / euro;

                domain.TotalDescuentoDolar = domain.TotalDescuentoBase / dolar;
                domain.TotalDescuentoEuro = domain.TotalDescuentoBase / euro;
                //if (compra.IdMoneda == 1)
                //{

                //    domain.PrecioUnitarioDolar = domain.PrecioUnitarioBase / dolar;
                //    domain.PrecioUnitarioEuro = domain.PrecioUnitarioBase / euro;

                //    domain.SubTotalExcentoDolar = domain.SubTotalExcentoBase / dolar;
                //    domain.SubTotalExcentoEuro = domain.SubTotalExcentoBase / euro;

                //    domain.SubTotalExcentoNetoDolar = domain.SubTotalExcentoNetoBase / dolar;
                //    domain.SubTotalExcentoNetoEuro = domain.SubTotalExcentoNetoBase / euro;

                //    domain.SubTotalGravadoDolar = domain.SubTotalGravadoBase / dolar;
                //    domain.SubTotalGravadoEuro = domain.SubTotalGravadoBase / euro;

                //    domain.SubTotalGravadoNetoDolar = domain.SubTotalGravadoNetoBase / dolar;
                //    domain.SubTotalGravadoNetoEuro = domain.SubTotalGravadoNetoBase / euro;

                //    domain.TotalIvadolar = domain.TotalIvabase / dolar;
                //    domain.TotalIvaeuro = domain.TotalIvabase / euro;

                //    domain.TotalDolar = domain.TotalBase / dolar;
                //    domain.TotalEuro = domain.TotalBase / euro;

                //    domain.TotalFadolar = domain.TotalFabase / dolar;
                //    domain.TotalFaeuro = domain.TotalFabase / euro;

                //    domain.TotalDescuentoDolar = domain.TotalDescuentoBase / dolar;
                //    domain.TotalDescuentoEuro = domain.TotalDescuentoBase / euro;


                //}
                //else if (compra.IdMoneda == 2)
                //{

                //    domain.PrecioUnitarioBase = domain.PrecioUnitarioBase * dolar;
                //    domain.PrecioUnitarioEuro = domain.PrecioUnitarioBase / euro;

                //    domain.SubTotalExcentoBase = domain.SubTotalExcentoBase * dolar;
                //    domain.SubTotalExcentoEuro = domain.SubTotalExcentoBase / euro;

                //    domain.SubTotalExcentoNetoBase = domain.SubTotalExcentoNetoBase * dolar;
                //    domain.SubTotalExcentoNetoEuro = domain.SubTotalExcentoNetoBase / euro;

                //    domain.SubTotalGravadoBase = domain.SubTotalGravadoBase * dolar;
                //    domain.SubTotalGravadoEuro = domain.SubTotalGravadoBase / euro;

                //    domain.SubTotalGravadoNetoBase = domain.SubTotalGravadoNetoBase * dolar;
                //    domain.SubTotalGravadoNetoEuro = domain.SubTotalGravadoNetoBase / euro;


                //    domain.TotalIvabase = domain.TotalIvabase * dolar;
                //    domain.TotalIvaeuro = domain.TotalIvabase / euro;

                //    domain.TotalFabase = domain.TotalFabase * dolar;
                //    domain.TotalFaeuro = domain.TotalFabase / euro;

                //    domain.TotalBase = domain.TotalFabase * dolar;
                //    domain.TotalEuro = domain.TotalBase / euro;


                //    domain.TotalDescuentoBase = domain.TotalDescuentoBase * dolar;
                //    domain.TotalDescuentoEuro = domain.TotalDescuentoBase / euro;
                //}
                //else if (compra.IdMoneda == 3)
                //{

                //    domain.PrecioUnitarioBase = domain.PrecioUnitarioBase * euro;
                //    domain.PrecioUnitarioDolar = domain.PrecioUnitarioBase / euro;

                //    domain.SubTotalExcentoBase = domain.SubTotalExcentoBase * euro;
                //    domain.SubTotalExcentoDolar = domain.SubTotalExcentoBase / dolar;

                //    domain.SubTotalExcentoNetoBase = domain.SubTotalExcentoNetoBase * euro;
                //    domain.SubTotalExcentoNetoDolar = domain.SubTotalExcentoNetoBase / dolar;

                //    domain.SubTotalGravadoBase = domain.SubTotalGravadoBase * euro;
                //    domain.SubTotalGravadoDolar = domain.SubTotalGravadoBase / dolar;

                //    domain.SubTotalGravadoNetoBase = domain.SubTotalGravadoNetoBase * euro;
                //    domain.SubTotalGravadoNetoDolar = domain.SubTotalGravadoNetoBase / dolar;


                //    domain.TotalIvabase = domain.TotalIvabase * euro;
                //    domain.TotalIvadolar = domain.TotalIvabase / dolar;


                //    domain.TotalFabase = domain.TotalFabase * euro;
                //    domain.TotalFadolar = domain.TotalFabase / dolar;

                //    domain.TotalBase = domain.TotalBase * euro;
                //    domain.TotalDolar = domain.TotalBase / dolar;

                //    domain.TotalDescuentoBase = domain.TotalDescuentoBase * euro;
                //    domain.TotalDescuentoDolar = domain.TotalDescuentoBase / dolar;
                //}

                detalles.Add(domain);
            }


            service.UpdateCompraDetalle(detalles);

            

        }
    

        public IList<TbPrCompraDetalle> ViewModelToDomainCD(CompraViewModel viewModel)
        {
            var domain = new List<TbPrCompraDetalle>();
            foreach (var item in viewModel.CompraDetalle)
            {
                domain.Add(ViewModelToDomainSingleCD(item, viewModel));
            }

            return domain;
        }
        public IList<TbCpComprasDetalleServicio> ViewModelToDomainCDS(CompraViewModel viewModel)
        {
            var domain = new List<TbCpComprasDetalleServicio>();
            foreach (var item in viewModel.ComprasDetalleServicio)
            {
                domain.Add(ViewModelToDomainSingleCDS(item, viewModel));
            }

            return domain;
        }

        public TbCpComprasDetalleServicio ViewModelToDomainSingleCDS(ComprasDetalleServicioViewModel viewModel, CompraViewModel compra)
        {
            var domain = new TbCpComprasDetalleServicio
            {
                IdCompraDetalle = viewModel.IdCompraDetalle,
                IdCompra = viewModel.IdCompra,
                Articulo = viewModel.Articulo,
                PrecioUnidad = viewModel.PrecioUnidad,
                PorcDescuento = viewModel.PorcDescuento
            };
            float dolar = (float)compra.TipoCambioDolar;
            float euro = (float)compra.TipoCambioEuro;
            if (viewModel.IdMonedaCDS == 1)
            {
               domain.SubTotalExcentoBase = viewModel.SubTotalExcento;
                domain.SubTotalExcentoDolar = domain.SubTotalExcentoBase / dolar;
                domain.SubTotalExcentoEuro = domain.SubTotalExcentoBase / euro;

                domain.SubTotalExcentoNetoBase = viewModel.SubTotalExcentoNeto;
                domain.SubTotalExcentoNetoDolar = domain.SubTotalExcentoNetoBase / dolar;
                domain.SubTotalExcentoNetoEuro = domain.SubTotalExcentoNetoBase / euro;

                domain.SubTotalGravadoBase = viewModel.SubTotalGravado;
                domain.SubTotalGravadoDolar = domain.SubTotalGravadoBase / dolar;
                domain.SubTotalGravadoEuro = domain.SubTotalGravadoBase / euro;

                domain.SubTotalGravadoNetoBase = viewModel.SubTotalGravadoNeto;
                domain.SubTotalGravadoNetoDolar = domain.SubTotalGravadoNetoBase / dolar;
                domain.SubTotalGravadoNetoEuro = domain.SubTotalGravadoNetoBase / euro;

                domain.TotalIvabase = viewModel.TotalIva;
                domain.TotalIvadolar = domain.TotalIvabase / dolar;
                domain.TotalIvaeuro = domain.TotalIvabase / euro;


                domain.TotalBase = viewModel.Total;
                domain.TotalDolar = domain.TotalBase / dolar;
                domain.TotalEuro = domain.TotalBase / euro;

                domain.TotalIsbase = viewModel.TotalIs;
                domain.TotalIsdolar = domain.TotalIsbase / dolar;
                domain.TotalIseuro = domain.TotalIsbase / euro;


                domain.TotalDescuentoBase = viewModel.TotalDescuento;
                domain.TotalDescuentoDolar = viewModel.TotalDescuento / dolar;
                domain.TotalDescuentoEuro = viewModel.TotalDescuento / euro;


            }
            else if (viewModel.IdMonedaCDS == 2)
            {
                domain.SubTotalExcentoBase = viewModel.SubTotalExcento * dolar;
                domain.SubTotalExcentoDolar = viewModel.SubTotalExcento;
                domain.SubTotalExcentoEuro = domain.SubTotalExcentoBase / euro;

                domain.SubTotalExcentoNetoBase = viewModel.SubTotalExcentoNeto * dolar;
                domain.SubTotalExcentoNetoDolar = viewModel.SubTotalExcentoNeto;
                domain.SubTotalExcentoNetoEuro = domain.SubTotalExcentoNetoBase / euro;

                domain.SubTotalGravadoBase = viewModel.SubTotalGravado * dolar;
                domain.SubTotalGravadoDolar = viewModel.SubTotalGravado;
                domain.SubTotalGravadoEuro = domain.SubTotalGravadoBase / euro;

                domain.SubTotalGravadoNetoBase = viewModel.SubTotalGravadoNeto * dolar;
                domain.SubTotalGravadoNetoDolar = viewModel.SubTotalGravadoNeto;
                domain.SubTotalGravadoNetoEuro = domain.SubTotalGravadoNetoBase / euro;


                domain.TotalIvabase = viewModel.TotalIva * dolar;
                domain.TotalIvadolar = viewModel.TotalIva;
                domain.TotalIvaeuro = domain.TotalIvabase / euro;

                domain.TotalIsbase = viewModel.TotalIs * dolar;
                domain.TotalIsdolar = viewModel.TotalIs;
                domain.TotalIseuro = domain.TotalIsbase / euro;

                domain.TotalBase = viewModel.Total * dolar;
                domain.TotalDolar = viewModel.Total;
                domain.TotalEuro = domain.TotalBase / euro;


                domain.TotalDescuentoBase = viewModel.TotalDescuento * dolar;
                domain.TotalDescuentoDolar = viewModel.TotalDescuento;
                domain.TotalDescuentoEuro = domain.TotalDescuentoBase / euro;
            }
            else if (viewModel.IdMonedaCDS == 3)
            {
                domain.SubTotalExcentoBase = viewModel.SubTotalExcento * euro;
                domain.SubTotalExcentoDolar = domain.SubTotalExcentoBase / dolar;
                domain.SubTotalExcentoEuro = viewModel.SubTotalExcento;

                domain.SubTotalExcentoNetoBase = viewModel.SubTotalExcentoNeto * euro;
                domain.SubTotalExcentoNetoDolar = domain.SubTotalExcentoNetoBase / dolar;
                domain.SubTotalExcentoNetoEuro = viewModel.SubTotalExcentoNeto;

                domain.SubTotalGravadoBase = viewModel.SubTotalGravado * euro;
                domain.SubTotalGravadoDolar = domain.SubTotalGravadoBase / dolar;
                domain.SubTotalGravadoEuro = viewModel.SubTotalGravado;

                domain.SubTotalGravadoNetoBase = viewModel.SubTotalGravadoNeto * euro;
                domain.SubTotalGravadoNetoDolar = domain.SubTotalGravadoNetoBase / dolar;
                domain.SubTotalGravadoNetoEuro = viewModel.SubTotalGravadoNeto;


                domain.TotalIvabase = viewModel.TotalIva * euro;
                domain.TotalIvadolar = domain.TotalIvabase / dolar;
                domain.TotalIvaeuro = viewModel.TotalIva;


                domain.TotalIsbase = viewModel.TotalIs * euro;
                domain.TotalIsdolar = domain.TotalIsbase / dolar;
                domain.TotalIseuro = viewModel.TotalIs;

                domain.TotalBase = viewModel.Total * euro;
                domain.TotalDolar = domain.TotalBase / dolar;
                domain.TotalEuro = viewModel.Total;

                domain.TotalDescuentoBase = viewModel.TotalDescuento * euro;
                domain.TotalDescuentoDolar = domain.TotalDescuentoBase / dolar;
                domain.TotalDescuentoEuro = viewModel.TotalDescuento;
            }
            return domain;
        }

        public TbPrCompraDetalle ViewModelToDomainSingleCD(CompraDetalleViewModel viewModel, CompraViewModel compra)
        {
            var domain = new TbPrCompraDetalle
            {
                Cantidad = viewModel.Cantidad,
                Id = viewModel.Id,
                IdInventario = viewModel.IdInventario,
                IdCompra = viewModel.IdCompra,
                PorcFa = viewModel.PorcFa,
                PorcDescuento = viewModel.PorcDescuento,
                IdBodega = viewModel.IdBodega,               
                PorcIva = viewModel.PorcIva
                
            };

            float dolar = (float)compra.TipoCambioDolar;
            float euro = (float)compra.TipoCambioEuro;

            if (viewModel.IdMonedaCD == 1)
            {


                domain.PrecioUnitarioBase = viewModel.PrecioUnitario;
                domain.PrecioUnitarioDolar = domain.PrecioUnitarioBase / dolar;
                domain.PrecioUnitarioEuro = domain.PrecioUnitarioBase / euro;

                domain.SubTotalExcentoBase = viewModel.SubTotalExcento;
                domain.SubTotalExcentoDolar = domain.SubTotalExcentoBase / dolar;
                domain.SubTotalExcentoEuro = domain.SubTotalExcentoBase / euro;

                domain.SubTotalExcentoNetoBase = viewModel.SubTotalExcentoNeto;
                domain.SubTotalExcentoNetoDolar = domain.SubTotalExcentoNetoBase / dolar;
                domain.SubTotalExcentoNetoEuro = domain.SubTotalExcentoNetoBase / euro;

                domain.SubTotalGravadoBase = viewModel.SubTotalGravado;
                domain.SubTotalGravadoDolar = domain.SubTotalGravadoBase / dolar;
                domain.SubTotalGravadoEuro = domain.SubTotalGravadoBase / euro;

                domain.SubTotalGravadoNetoBase = viewModel.SubTotalGravadoNeto;
                domain.SubTotalGravadoNetoDolar = domain.SubTotalGravadoNetoBase / dolar;
                domain.SubTotalGravadoNetoEuro = domain.SubTotalGravadoNetoBase / euro;

                domain.TotalIvabase = viewModel.TotalIva;
                domain.TotalIvadolar = domain.TotalIvabase / dolar;
                domain.TotalIvaeuro = domain.TotalIvabase / euro;


                domain.TotalBase = viewModel.Total;
                domain.TotalDolar = domain.TotalBase / dolar;
                domain.TotalEuro = domain.TotalBase / euro;

                domain.TotalFabase = viewModel.TotalFa;
                domain.TotalFadolar = domain.TotalFabase / dolar;
                domain.TotalFaeuro = domain.TotalFabase / euro;


                domain.TotalDescuentoBase = viewModel.TotalDescuento;
                domain.TotalDescuentoDolar = viewModel.TotalDescuento / dolar;
                domain.TotalDescuentoEuro = viewModel.TotalDescuento / euro;


            }
            else if (viewModel.IdMonedaCD == 2)
            {

                domain.PrecioUnitarioBase = viewModel.PrecioUnitario * dolar;
                domain.PrecioUnitarioDolar = viewModel.PrecioUnitario;
                domain.PrecioUnitarioEuro = domain.PrecioUnitarioBase / euro;

                domain.SubTotalExcentoBase = viewModel.SubTotalExcento * dolar;
                domain.SubTotalExcentoDolar = viewModel.SubTotalExcento;
                domain.SubTotalExcentoEuro = domain.SubTotalExcentoBase / euro;

                domain.SubTotalExcentoNetoBase = viewModel.SubTotalExcentoNeto * dolar;
                domain.SubTotalExcentoNetoDolar = viewModel.SubTotalExcentoNeto;
                domain.SubTotalExcentoNetoEuro = domain.SubTotalExcentoNetoBase / euro;

                domain.SubTotalGravadoBase = viewModel.SubTotalGravado * dolar;
                domain.SubTotalGravadoDolar = viewModel.SubTotalGravado;
                domain.SubTotalGravadoEuro = domain.SubTotalGravadoBase / euro;

                domain.SubTotalGravadoNetoBase = viewModel.SubTotalGravadoNeto * dolar;
                domain.SubTotalGravadoNetoDolar = viewModel.SubTotalGravadoNeto;
                domain.SubTotalGravadoNetoEuro = domain.SubTotalGravadoNetoBase / euro;


                domain.TotalIvabase = viewModel.TotalIva * dolar;
                domain.TotalIvadolar = viewModel.TotalIva;
                domain.TotalIvaeuro = domain.TotalIvabase / euro;

                domain.TotalFabase = viewModel.TotalFa * dolar;
                domain.TotalFadolar = viewModel.TotalFa;
                domain.TotalFaeuro = domain.TotalFabase / euro;

                domain.TotalBase = viewModel.Total * dolar;
                domain.TotalDolar = viewModel.Total;
                domain.TotalEuro = domain.TotalBase / euro;


                domain.TotalDescuentoBase = viewModel.TotalDescuento * dolar;
                domain.TotalDescuentoDolar = viewModel.TotalDescuento;
                domain.TotalDescuentoEuro = domain.TotalDescuentoBase / euro;
            }
            else if (viewModel.IdMonedaCD == 3)
            {

                domain.PrecioUnitarioBase = viewModel.PrecioUnitario * euro;
                domain.PrecioUnitarioDolar = domain.PrecioUnitarioBase / dolar;
                domain.PrecioUnitarioEuro = viewModel.PrecioUnitario;

                domain.SubTotalExcentoBase = viewModel.SubTotalExcento * euro;
                domain.SubTotalExcentoDolar = domain.SubTotalExcentoBase / dolar;
                domain.SubTotalExcentoEuro = viewModel.SubTotalExcento;

                domain.SubTotalExcentoNetoBase = viewModel.SubTotalExcentoNeto * euro;
                domain.SubTotalExcentoNetoDolar = domain.SubTotalExcentoNetoBase / dolar;
                domain.SubTotalExcentoNetoEuro = viewModel.SubTotalExcentoNeto;

                domain.SubTotalGravadoBase = viewModel.SubTotalGravado * euro;
                domain.SubTotalGravadoDolar = domain.SubTotalGravadoBase / dolar;
                domain.SubTotalGravadoEuro = viewModel.SubTotalGravado;

                domain.SubTotalGravadoNetoBase = viewModel.SubTotalGravadoNeto * euro;
                domain.SubTotalGravadoNetoDolar = domain.SubTotalGravadoNetoBase / dolar;
                domain.SubTotalGravadoNetoEuro = viewModel.SubTotalGravadoNeto;


                domain.TotalIvabase = viewModel.TotalIva * euro;
                domain.TotalIvadolar = domain.TotalIvabase / dolar;
                domain.TotalIvaeuro = viewModel.TotalIva;


                domain.TotalFabase = viewModel.TotalFa * euro;
                domain.TotalFadolar = domain.TotalFabase / dolar;
                domain.TotalFaeuro = viewModel.TotalFa;

                domain.TotalBase = viewModel.Total * euro;
                domain.TotalDolar = domain.TotalBase / dolar;
                domain.TotalEuro = viewModel.Total;

                domain.TotalDescuentoBase = viewModel.TotalDescuento * euro;
                domain.TotalDescuentoDolar = domain.TotalDescuentoBase / dolar;
                domain.TotalDescuentoEuro = viewModel.TotalDescuento;
            }

            return domain;
        }
    }
}
