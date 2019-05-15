using AltivaWebApp.Domains;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;


namespace AltivaWebApp.Mappers
{
    public class CompraMap: ICompraMap
    {
        private readonly ICompraService service;

        public CompraMap(ICompraService service)
        {
            this.service = service;
        }

        public TbPrCompra Create(CompraViewModel viewModel)
        {
            return service.Save(ViewModelToDomain(viewModel));
        }

        public TbPrCompra Update(CompraViewModel viewModel)
        {
            return service.Update(ViewModelToDomainEdit(viewModel));
        }

        public bool CreateCD(CompraViewModel viewModel)
        {
            return service.SaveCompraDetalle(ViewModelToDomainCD(viewModel));
        }

        public bool UpdateCD(CompraViewModel viewModel)
        {
            return service.UpdateCompraDetalle(ViewModelToDomainCD(viewModel));
        }

        public CompraViewModel DomainToViewModel(TbPrCompra domain)
        {
            var viewModel = new CompraViewModel
            {
                Anulado = domain.Anulado,
                FechaDocumento = domain.FechaDocumento,
                Id = domain.Id,
                IdMoneda = domain.IdMoneda,
                IdProveedor = domain.IdProveedor,
                IdUsuario = domain.IdUsuario,
                TipoCambioDolar = domain.TipoCambioDolar,
                TipoCambioEuro = domain.TipoCambioEuro,
                Borrador = domain.Borrador,
                NumeroDocumento = domain.NumeroDocumento,
                FechaCreacion = domain.FechaCreacion,
                TipoDocumento = domain.TipoDocumento
                
            };

            if (domain.IdMoneda == 1)
            {
                viewModel.SubTotalExcento = domain.SubTotalExcentoBase;
                viewModel.SubTotalGrabado = domain.SubTotalGrabadoBase;
                viewModel.Total = domain.TotalBase;
                viewModel.TotalIva = domain.TotalIvabase;
                viewModel.TotalDescuento = domain.TotalDescuentoBase;
                viewModel.SubTotalExcentoNeto = domain.SubTotalExcentoNetoBase;
                viewModel.SubTotalGrabadoNeto = domain.SubTotalGrabadoNetoBase;
                viewModel.TotalFa = domain.TotalFabase;
            }
            else if (domain.IdMoneda == 2)
            {
                viewModel.SubTotalExcento = domain.SubTotalExcentoDolar;
                viewModel.SubTotalGrabado = domain.SubTotalGrabadoDolar;
                viewModel.Total = domain.TotalDolar;
                viewModel.TotalIva = domain.TotalIvadolar;
                viewModel.TotalDescuento = domain.TotalDescuentoDolar;
                viewModel.SubTotalExcentoNeto = domain.SubTotalExcentoNetoDolar;
                viewModel.SubTotalGrabadoNeto = domain.SubTotalGrabadoNetoDolar;
                viewModel.TotalFa = domain.TotalFadolar;
            }
            else if (domain.IdMoneda == 3)
            {
                viewModel.SubTotalExcento = domain.SubTotalExcentoEuro;
                viewModel.SubTotalGrabado = domain.SubTotalGrabadoEuro;
                viewModel.Total = domain.TotalEuro;
                viewModel.TotalIva = domain.TotalIvaeuro;
                viewModel.TotalDescuento = domain.TotalDescuentoEuro;
                viewModel.SubTotalExcentoNeto = domain.SubTotalExcentoNetoEuro;
                viewModel.SubTotalGrabadoNeto = domain.SubTotalGrabadoNetoEuro;
                viewModel.TotalFa = domain.TotalFaeuro;
            }


            return viewModel;
        }

        public TbPrCompra ViewModelToDomain(CompraViewModel viewModel)
        {

            var domain = new TbPrCompra();

            domain.Id = viewModel.Id;
            domain.IdMoneda = viewModel.IdMoneda;
            domain.IdProveedor = viewModel.IdProveedor;
            domain.IdUsuario = viewModel.IdUsuario;
            domain.Anulado = false;
            domain.FechaCreacion = DateTime.Now;
            domain.FechaDocumento = viewModel.FechaDocumento;
            domain.NumeroDocumento = viewModel.NumeroDocumento;


            domain.TipoCambioDolar = viewModel.TipoCambioDolar; 
            domain.TipoCambioEuro = viewModel.TipoCambioEuro;

            domain.TbPrCompraDetalle = ViewModelToDomainCD(viewModel);

            if (viewModel.IdMoneda == 1)
            {
                domain.SubTotalExcentoBase = viewModel.SubTotalExcento;
                domain.SubTotalExcentoDolar = domain.SubTotalExcentoBase / domain.TipoCambioDolar;
                domain.SubTotalExcentoEuro = domain.SubTotalExcentoBase / domain.TipoCambioEuro;

                domain.SubTotalExcentoNetoBase = viewModel.SubTotalExcentoNeto;
                domain.SubTotalExcentoNetoDolar = domain.SubTotalExcentoNetoBase / domain.TipoCambioDolar;
                domain.SubTotalExcentoNetoEuro = domain.SubTotalExcentoNetoBase / domain.TipoCambioEuro;

                domain.SubTotalGrabadoBase = viewModel.SubTotalGrabado;
                domain.SubTotalGrabadoDolar = domain.SubTotalGrabadoBase / domain.TipoCambioDolar;
                domain.SubTotalGrabadoEuro = domain.SubTotalGrabadoBase / domain.TipoCambioEuro;

                domain.SubTotalGrabadoNetoBase = viewModel.SubTotalGrabadoNeto;
                domain.SubTotalGrabadoNetoDolar = domain.SubTotalGrabadoNetoBase / domain.TipoCambioDolar;
                domain.SubTotalGrabadoNetoEuro = domain.SubTotalGrabadoNetoBase / domain.TipoCambioEuro;


                domain.TotalIvabase = viewModel.TotalIva;
                domain.TotalIvadolar = domain.TotalIvabase / domain.TipoCambioDolar;
                domain.TotalIvaeuro = domain.TotalIvaeuro / domain.TipoCambioEuro;

                domain.TotalFabase = viewModel.TotalFa;
                domain.TotalFadolar = domain.TotalFabase / domain.TipoCambioDolar;
                domain.TotalFaeuro = domain.TotalFaeuro / domain.TipoCambioEuro;

                domain.TotalBase = viewModel.Total;
                domain.TotalDolar = domain.TotalBase / domain.TipoCambioDolar;
                domain.TotalEuro = domain.TotalEuro / domain.TipoCambioEuro;

                domain.TotalDescuentoBase = viewModel.TotalDescuento;
                domain.TotalDescuentoDolar = domain.TotalDescuentoBase / domain.TipoCambioDolar;
                domain.TotalDescuentoEuro = domain.TotalDescuentoEuro / domain.TipoCambioEuro;

            }
            else if (viewModel.IdMoneda == 2)
            {
                domain.SubTotalExcentoBase = viewModel.SubTotalExcento * domain.TipoCambioDolar;
                domain.SubTotalExcentoDolar = viewModel.SubTotalExcento;
                domain.SubTotalExcentoEuro = domain.SubTotalExcentoBase / domain.TipoCambioEuro;

                domain.SubTotalExcentoNetoBase = viewModel.SubTotalExcentoNeto * domain.TipoCambioDolar;
                domain.SubTotalExcentoNetoDolar = viewModel.SubTotalExcentoNeto;
                domain.SubTotalExcentoNetoEuro = domain.SubTotalExcentoNetoBase / domain.TipoCambioEuro;

                domain.SubTotalGrabadoBase = viewModel.SubTotalGrabado * domain.TipoCambioDolar;
                domain.SubTotalGrabadoDolar = viewModel.SubTotalGrabado;
                domain.SubTotalGrabadoEuro = domain.SubTotalGrabadoBase / domain.TipoCambioEuro;

                domain.SubTotalGrabadoNetoBase = viewModel.SubTotalGrabadoNeto * domain.TipoCambioDolar;
                domain.SubTotalGrabadoNetoDolar = viewModel.SubTotalGrabadoNeto;
                domain.SubTotalGrabadoNetoEuro = domain.SubTotalGrabadoNetoBase / domain.TipoCambioEuro;


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

                domain.SubTotalGrabadoBase = viewModel.SubTotalGrabado * domain.TipoCambioEuro;
                domain.SubTotalGrabadoDolar = domain.SubTotalGrabadoBase / domain.TipoCambioDolar;
                domain.SubTotalGrabadoEuro = viewModel.SubTotalGrabado;

                domain.SubTotalGrabadoNetoBase = viewModel.SubTotalGrabadoNeto * domain.TipoCambioEuro;
                domain.SubTotalGrabadoNetoDolar = domain.SubTotalGrabadoNetoBase / domain.TipoCambioDolar;
                domain.SubTotalGrabadoNetoEuro = viewModel.SubTotalGrabadoNeto;


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
                domain.TotalEuro = viewModel.TotalDescuento;
            }

            return domain;

        }

        public TbPrCompra ViewModelToDomainEdit(CompraViewModel viewModel)
        {

            var domain = service.GetCompraById((int)viewModel.Id);

            
            domain.IdMoneda = viewModel.IdMoneda;
            domain.IdProveedor = viewModel.IdProveedor;
            domain.IdUsuario = viewModel.IdUsuario;
            domain.Anulado = false;
            domain.FechaCreacion = DateTime.Now;
            domain.FechaDocumento = viewModel.FechaDocumento;
            //domain.NumeroDocumento = viewModel.NumeroDocumento;


            //domain.TbPrCompraDetalle = ViewModelToDomainCD(viewModel);

            if (viewModel.IdMoneda == 1)
            {
                domain.SubTotalExcentoBase = viewModel.SubTotalExcento;
                domain.SubTotalExcentoDolar = domain.SubTotalExcentoBase / domain.TipoCambioDolar;
                domain.SubTotalExcentoEuro = domain.SubTotalExcentoBase / domain.TipoCambioEuro;

                domain.SubTotalExcentoNetoBase = viewModel.SubTotalExcentoNeto;
                domain.SubTotalExcentoNetoDolar = domain.SubTotalExcentoNetoBase / domain.TipoCambioDolar;
                domain.SubTotalExcentoNetoEuro = domain.SubTotalExcentoNetoBase / domain.TipoCambioEuro;

                domain.SubTotalGrabadoBase = viewModel.SubTotalGrabado;
                domain.SubTotalGrabadoDolar = domain.SubTotalGrabadoBase / domain.TipoCambioDolar;
                domain.SubTotalGrabadoEuro = domain.SubTotalGrabadoBase / domain.TipoCambioEuro;

                domain.SubTotalGrabadoNetoBase = viewModel.SubTotalGrabadoNeto;
                domain.SubTotalGrabadoNetoDolar = domain.SubTotalGrabadoNetoBase / domain.TipoCambioDolar;
                domain.SubTotalGrabadoNetoEuro = domain.SubTotalGrabadoNetoBase / domain.TipoCambioEuro;


                domain.TotalIvabase = viewModel.TotalIva;
                domain.TotalIvadolar = domain.TotalIvabase / domain.TipoCambioDolar;
                domain.TotalIvaeuro = domain.TotalIvaeuro / domain.TipoCambioEuro;

                domain.TotalFabase = viewModel.TotalFa;
                domain.TotalFadolar = domain.TotalFabase / domain.TipoCambioDolar;
                domain.TotalFaeuro = domain.TotalFaeuro / domain.TipoCambioEuro;

                domain.TotalBase = viewModel.Total;
                domain.TotalDolar = domain.TotalBase / domain.TipoCambioDolar;
                domain.TotalEuro = domain.TotalEuro / domain.TipoCambioEuro;

                domain.TotalDescuentoBase = viewModel.TotalDescuento;
                domain.TotalDescuentoDolar = domain.TotalDescuentoBase / domain.TipoCambioDolar;
                domain.TotalDescuentoEuro = domain.TotalDescuentoEuro / domain.TipoCambioEuro;

            }
            else if (viewModel.IdMoneda == 2)
            {
                domain.SubTotalExcentoBase = viewModel.SubTotalExcento * domain.TipoCambioDolar;
                domain.SubTotalExcentoDolar = viewModel.SubTotalExcento;
                domain.SubTotalExcentoEuro = domain.SubTotalExcentoBase / domain.TipoCambioEuro;

                domain.SubTotalExcentoNetoBase = viewModel.SubTotalExcentoNeto * domain.TipoCambioDolar;
                domain.SubTotalExcentoNetoDolar = viewModel.SubTotalExcentoNeto;
                domain.SubTotalExcentoNetoEuro = domain.SubTotalExcentoNetoBase / domain.TipoCambioEuro;

                domain.SubTotalGrabadoBase = viewModel.SubTotalGrabado * domain.TipoCambioDolar;
                domain.SubTotalGrabadoDolar = viewModel.SubTotalGrabado;
                domain.SubTotalGrabadoEuro = domain.SubTotalGrabadoBase / domain.TipoCambioEuro;

                domain.SubTotalGrabadoNetoBase = viewModel.SubTotalGrabadoNeto * domain.TipoCambioDolar;
                domain.SubTotalGrabadoNetoDolar = viewModel.SubTotalGrabadoNeto;
                domain.SubTotalGrabadoNetoEuro = domain.SubTotalGrabadoNetoBase / domain.TipoCambioEuro;


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

                domain.SubTotalGrabadoBase = viewModel.SubTotalGrabado * domain.TipoCambioEuro;
                domain.SubTotalGrabadoDolar = domain.SubTotalGrabadoBase / domain.TipoCambioDolar;
                domain.SubTotalGrabadoEuro = viewModel.SubTotalGrabado;

                domain.SubTotalGrabadoNetoBase = viewModel.SubTotalGrabadoNeto * domain.TipoCambioEuro;
                domain.SubTotalGrabadoNetoDolar = domain.SubTotalGrabadoNetoBase / domain.TipoCambioDolar;
                domain.SubTotalGrabadoNetoEuro = viewModel.SubTotalGrabadoNeto;


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
                domain.TotalEuro = viewModel.TotalDescuento;
            }

            return domain;

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
                PrecioUnitario = viewModel.PrecioUnitario            
                
            };

            float dolar = (float)compra.TipoCambioDolar;
            float euro = (float)compra.TipoCambioEuro;

            if (viewModel.IdMonedaCD == 1)
            {
                domain.SubTotalExcentoBase = viewModel.SubTotalExcento;
                domain.SubTotalExcentoDolar = domain.SubTotalExcentoBase / dolar;
                domain.SubTotalExcentoEuro = domain.SubTotalExcentoBase / euro;

                domain.SubTotalExcentoNetoBase = viewModel.SubTotalExcentoNeto;
                domain.SubTotalExcentoNetoDolar = domain.SubTotalExcentoNetoBase / dolar;
                domain.SubTotalExcentoNetoEuro = domain.SubTotalExcentoNetoBase / euro;

                domain.SubTotalGrabadoBase = viewModel.SubTotalGrabado;
                domain.SubTotalGrabadoDolar = domain.SubTotalGrabadoBase / dolar;
                domain.SubTotalGrabadoEuro = domain.SubTotalGrabadoBase / euro;

                domain.SubTotalGrabadoNetoBase = viewModel.SubTotalGrabadoNeto;
                domain.SubTotalGrabadoNetoDolar = domain.SubTotalGrabadoNetoBase / dolar;
                domain.SubTotalGrabadoNetoEuro = domain.SubTotalGrabadoNetoBase / euro;

                domain.TotalIvabase = viewModel.TotalIva;
                domain.TotalIvadolar = domain.TotalIvabase / dolar;
                domain.TotalIvaeuro = domain.TotalIvabase / euro;

                domain.TotalIsbase = viewModel.TotalIs;
                domain.TotalIsdolar = domain.TotalIsbase / dolar;
                domain.TotalIseuro = domain.TotalIsbase / euro;


                domain.TotalBase = viewModel.Total;
                domain.TotalDolar = domain.TotalBase / dolar;
                domain.TotalEuro = domain.TotalEuro / euro;

                domain.TotalFabase = viewModel.TotalFa;
                domain.TotalFadolar = domain.TotalFabase / dolar;
                domain.TotalFaeuro = domain.TotalFabase / euro;


                domain.TotalDescuentoBase = viewModel.TotalDescuento;
                domain.TotalDescuentoDolar = viewModel.TotalDescuento / dolar;
                domain.TotalDescuentoEuro = viewModel.TotalDescuento / euro;


            }
            else if (viewModel.IdMonedaCD == 2)
            {
                domain.SubTotalExcentoBase = viewModel.SubTotalExcento * dolar;
                domain.SubTotalExcentoDolar = viewModel.SubTotalExcento;
                domain.SubTotalExcentoEuro = domain.SubTotalExcentoBase / euro;

                domain.SubTotalExcentoNetoBase = viewModel.SubTotalExcentoNeto * dolar;
                domain.SubTotalExcentoNetoDolar = viewModel.SubTotalExcentoNeto;
                domain.SubTotalExcentoNetoEuro = domain.SubTotalExcentoNetoBase / euro;

                domain.SubTotalGrabadoBase = viewModel.SubTotalGrabado * dolar;
                domain.SubTotalGrabadoDolar = viewModel.SubTotalGrabado;
                domain.SubTotalGrabadoEuro = domain.SubTotalGrabadoBase / euro;

                domain.SubTotalGrabadoNetoBase = viewModel.SubTotalGrabadoNeto * dolar;
                domain.SubTotalGrabadoNetoDolar = viewModel.SubTotalGrabadoNeto;
                domain.SubTotalGrabadoNetoEuro = domain.SubTotalGrabadoNetoBase / euro;


                domain.TotalIvabase = viewModel.TotalIva * dolar;
                domain.TotalIvadolar = viewModel.TotalIva;
                domain.TotalIvaeuro = domain.TotalIvabase / euro;

                domain.TotalIsbase = viewModel.TotalIs * dolar;
                domain.TotalIsdolar = viewModel.TotalIs;
                domain.TotalIseuro = domain.TotalIsbase / euro;

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

                domain.SubTotalExcentoBase = viewModel.SubTotalExcento * euro;
                domain.SubTotalExcentoDolar = domain.SubTotalExcentoBase / dolar;
                domain.SubTotalExcentoEuro = viewModel.SubTotalExcento;

                domain.SubTotalExcentoNetoBase = viewModel.SubTotalExcentoNeto * euro;
                domain.SubTotalExcentoNetoDolar = domain.SubTotalExcentoNetoBase / dolar;
                domain.SubTotalExcentoNetoEuro = viewModel.SubTotalExcentoNeto;

                domain.SubTotalGrabadoBase = viewModel.SubTotalGrabado * euro;
                domain.SubTotalGrabadoDolar = domain.SubTotalGrabadoBase / dolar;
                domain.SubTotalGrabadoEuro = viewModel.SubTotalGrabado;

                domain.SubTotalGrabadoNetoBase = viewModel.SubTotalGrabadoNeto * euro;
                domain.SubTotalGrabadoNetoDolar = domain.SubTotalGrabadoNetoBase / dolar;
                domain.SubTotalGrabadoNetoEuro = viewModel.SubTotalGrabadoNeto;


                domain.TotalIvabase = viewModel.TotalIva * euro;
                domain.TotalIvadolar = domain.TotalIvabase / dolar;
                domain.TotalIvaeuro = viewModel.TotalIva;

                domain.TotalIsbase = viewModel.TotalIs * euro;
                domain.TotalIsdolar = domain.TotalIsbase / dolar;
                domain.TotalIseuro = viewModel.TotalIs;

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
