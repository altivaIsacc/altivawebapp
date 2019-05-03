using AltivaWebApp.Domains;
using AltivaWebApp.GEDomain;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public class OrdenMap : IOrdenMap
    {
        private readonly IOrdenService service;
        private readonly IMonedaService monedaService;
        public OrdenMap(IOrdenService service, IMonedaService monedaService)
        {
            this.service = service;
            this.monedaService = monedaService;
        }


        public TbPrOrden Create(OrdenViewModel viewModel)
        {
            return service.Save(ViewModelToDomain(viewModel));
        }
        public TbPrOrden Update(OrdenViewModel viewModel)
        {
            return service.Update(ViewModelToDomainEdit(viewModel));
        }

        public bool CreateOD(OrdenViewModel viewModel)
        {
            return service.SaveOrdenDetalle(ViewModelToDomainOD(viewModel));
        }

        public OrdenViewModel DomainToViewModel(TbPrOrden domain)
        {
            var viewModel = new OrdenViewModel
            {
                Anulado = domain.Anulado,
                Fecha = domain.Fecha,
                Id = domain.Id,
                IdMoneda = domain.IdMoneda,
                IdProveedor = domain.IdProveedor,
                IdUsuario = domain.IdUsuario,
                Observacion = domain.Observacion,
                TipoCambioDolar = domain.TipoCambioDolar,
                TipoCambioEuro = domain.TipoCambioEuro
            };

            if(domain.IdMoneda == 1)
            {
                viewModel.SubTotalExcento = domain.SubTotalExcentoBase;
                viewModel.SubTotalGrabado = domain.SubTotalGrabadoBase;
                viewModel.Total = domain.TotalBase;
                viewModel.TotalIva = domain.TotalIvabase;
            }
            else if(domain.IdMoneda == 2)
            {
                viewModel.SubTotalExcento = domain.SubTotalExcentoDolar;
                viewModel.SubTotalGrabado = domain.SubTotalGrabadoDolar;
                viewModel.Total = domain.TotalDolar;
                viewModel.TotalIva = domain.TotalIvadolar;
            }
            else if(domain.IdMoneda == 3)
            {
                viewModel.SubTotalExcento = domain.SubTotalExcentoEuro;
                viewModel.SubTotalGrabado = domain.SubTotalGrabadoEuro;
                viewModel.Total = domain.TotalEuro;
                viewModel.TotalIva = domain.TotalIvaeuro;
            }

            
            return viewModel;
        }

        public TbPrOrden ViewModelToDomain(OrdenViewModel viewModel)
        {

            var moneda = monedaService.GetAll();
            var domain = new TbPrOrden();

            domain.Id = viewModel.Id;
            domain.IdMoneda = viewModel.IdMoneda;
            domain.IdProveedor = viewModel.IdProveedor;
            domain.IdUsuario = viewModel.IdUsuario;
            domain.Observacion = viewModel.Observacion;
            domain.Anulado = false;
            domain.FechaCreacion = DateTime.Now;


            domain.TipoCambioDolar = viewModel.TipoCambioDolar; //moneda.FirstOrDefault(m => m.Codigo == 2).ValorCompra;
            domain.TipoCambioEuro = viewModel.TipoCambioEuro;//moneda.FirstOrDefault(m => m.Codigo == 3).ValorCompra;

            domain.TbPrOrdenDetalle = ViewModelToDomainOD(viewModel);

            if (viewModel.IdMoneda == 1)
            {
                domain.SubTotalExcentoBase = viewModel.SubTotalExcento;
                domain.SubTotalExcentoDolar = domain.SubTotalExcentoBase * domain.TipoCambioDolar;
                domain.SubTotalExcentoEuro = domain.SubTotalExcentoBase * domain.TipoCambioEuro;

                domain.SubTotalGrabadoBase = viewModel.SubTotalGrabado;
                domain.SubTotalGrabadoDolar = domain.SubTotalGrabadoBase * domain.TipoCambioDolar;
                domain.SubTotalGrabadoEuro = domain.SubTotalGrabadoBase * domain.TipoCambioEuro;

                domain.TotalIvabase = viewModel.TotalIva;
                domain.TotalIvadolar = domain.TotalIvabase * domain.TipoCambioDolar;
                domain.TotalIvaeuro = domain.TotalIvaeuro * domain.TipoCambioEuro;

                domain.TotalBase = viewModel.Total;
                domain.TotalDolar = domain.TotalBase * domain.TipoCambioDolar;
                domain.TotalEuro = domain.TotalEuro * domain.TipoCambioEuro;

            }
            else if (viewModel.IdMoneda == 2)
            {
                domain.SubTotalExcentoBase = viewModel.SubTotalExcento / domain.TipoCambioDolar;
                domain.SubTotalExcentoDolar = viewModel.SubTotalExcento;
                domain.SubTotalExcentoEuro = domain.SubTotalExcentoBase * domain.TipoCambioEuro;

                domain.SubTotalGrabadoBase = viewModel.SubTotalGrabado / domain.TipoCambioDolar;
                domain.SubTotalGrabadoDolar = viewModel.SubTotalGrabado;
                domain.SubTotalGrabadoEuro = domain.SubTotalGrabadoBase * domain.TipoCambioEuro;

                domain.TotalIvabase = viewModel.TotalIva / domain.TipoCambioDolar;
                domain.TotalIvadolar = viewModel.TotalIva;
                domain.TotalIvaeuro = domain.TotalIvabase * domain.TipoCambioEuro;

                domain.TotalBase = viewModel.Total / domain.TipoCambioDolar;
                domain.TotalDolar = viewModel.Total;
                domain.TotalEuro = domain.TotalBase * domain.TipoCambioEuro;
            }
            else if (viewModel.IdMoneda == 3)
            {

                domain.SubTotalExcentoBase = viewModel.SubTotalExcento / domain.TipoCambioEuro;
                domain.SubTotalExcentoDolar = domain.SubTotalExcentoBase * domain.TipoCambioDolar;
                domain.SubTotalExcentoEuro = viewModel.SubTotalExcento;

                domain.SubTotalGrabadoBase = viewModel.SubTotalGrabado / domain.TipoCambioEuro;
                domain.SubTotalGrabadoDolar = domain.SubTotalGrabadoBase * domain.TipoCambioDolar;
                domain.SubTotalGrabadoEuro = viewModel.SubTotalGrabado;

                domain.TotalIvabase = viewModel.TotalIva / domain.TipoCambioEuro;
                domain.TotalIvadolar = domain.TotalIvabase * domain.TipoCambioDolar;
                domain.TotalIvaeuro = viewModel.TotalIva;

                domain.TotalBase = viewModel.Total / domain.TipoCambioEuro;
                domain.TotalDolar = domain.TotalBase * domain.TipoCambioDolar;
                domain.TotalEuro = viewModel.Total;
            }

            return domain;

        }

        public TbPrOrden ViewModelToDomainEdit(OrdenViewModel viewModel)
        {
            var domain = service.GetOrdenById((int)viewModel.Id); ;

            domain.IdMoneda = viewModel.IdMoneda;
            domain.IdProveedor = viewModel.IdProveedor;
            domain.IdUsuario = viewModel.IdUsuario;
            domain.Observacion = viewModel.Observacion;
            domain.Anulado = viewModel.Anulado;

            var moneda = monedaService.GetAll();

            if (viewModel.IdMoneda == 1)
            {
                domain.SubTotalExcentoBase = viewModel.SubTotalExcento;
                domain.SubTotalExcentoDolar = domain.SubTotalExcentoBase * domain.TipoCambioDolar;
                domain.SubTotalExcentoEuro = domain.SubTotalExcentoBase * domain.TipoCambioEuro;

                domain.SubTotalGrabadoBase = viewModel.SubTotalGrabado;
                domain.SubTotalGrabadoDolar = domain.SubTotalGrabadoBase * domain.TipoCambioDolar;
                domain.SubTotalGrabadoEuro = domain.SubTotalGrabadoBase * domain.TipoCambioEuro;

                domain.TotalIvabase = viewModel.TotalIva;
                domain.TotalIvadolar = domain.TotalIvabase * domain.TipoCambioDolar;
                domain.TotalIvaeuro = domain.TotalIvaeuro * domain.TipoCambioEuro;

                domain.TotalBase = viewModel.Total;
                domain.TotalDolar = domain.TotalBase * domain.TipoCambioDolar;
                domain.TotalEuro = domain.TotalEuro * domain.TipoCambioEuro;

            }
            else if (viewModel.IdMoneda == 2)
            {
                domain.SubTotalExcentoBase = viewModel.SubTotalExcento / domain.TipoCambioDolar;
                domain.SubTotalExcentoDolar = viewModel.SubTotalExcento;
                domain.SubTotalExcentoEuro = domain.SubTotalExcentoBase * domain.TipoCambioEuro;

                domain.SubTotalGrabadoBase = viewModel.SubTotalGrabado / domain.TipoCambioDolar;
                domain.SubTotalGrabadoDolar = viewModel.SubTotalGrabado;
                domain.SubTotalGrabadoEuro = domain.SubTotalGrabadoBase * domain.TipoCambioEuro;

                domain.TotalIvabase = viewModel.TotalIva / domain.TipoCambioDolar;
                domain.TotalIvadolar = viewModel.TotalIva;
                domain.TotalIvaeuro = domain.TotalIvabase * domain.TipoCambioEuro;

                domain.TotalBase = viewModel.Total / domain.TipoCambioDolar;
                domain.TotalDolar = viewModel.Total;
                domain.TotalEuro = domain.TotalBase * domain.TipoCambioEuro;
            }
            else if (viewModel.IdMoneda == 3)
            {

                domain.SubTotalExcentoBase = viewModel.SubTotalExcento / domain.TipoCambioEuro;
                domain.SubTotalExcentoDolar = domain.SubTotalExcentoBase * domain.TipoCambioDolar;
                domain.SubTotalExcentoEuro = viewModel.SubTotalExcento;

                domain.SubTotalGrabadoBase = viewModel.SubTotalGrabado / domain.TipoCambioEuro;
                domain.SubTotalGrabadoDolar = domain.SubTotalGrabadoBase * domain.TipoCambioDolar;
                domain.SubTotalGrabadoEuro = viewModel.SubTotalGrabado;

                domain.TotalIvabase = viewModel.TotalIva / domain.TipoCambioEuro;
                domain.TotalIvadolar = domain.TotalIvabase * domain.TipoCambioDolar;
                domain.TotalIvaeuro = viewModel.TotalIva;

                domain.TotalBase = viewModel.Total / domain.TipoCambioEuro;
                domain.TotalDolar = domain.TotalBase * domain.TipoCambioDolar;
                domain.TotalEuro = viewModel.Total;
            }

            return domain;

        }

        public IList<TbPrOrdenDetalle> ViewModelToDomainOD(OrdenViewModel viewModel)
        {
            var domain = new List<TbPrOrdenDetalle>();
            foreach (var item in viewModel.OrdenDetalle)
            {
                domain.Add(ViewModelToDomainSingleOD(item, viewModel));
            }

            return domain;
        }

        public TbPrOrdenDetalle ViewModelToDomainSingleOD(OrdenDetalleViewModel viewModel, OrdenViewModel orden)
        {
            var domain = new TbPrOrdenDetalle
            {
                Cantidad = viewModel.Cantidad,
                Id = viewModel.Id,
                IdInventario = viewModel.IdInventario,
                IdOrden = viewModel.IdOrden,
                NombreInventario = viewModel.NombreInventario,
                PorcIs = viewModel.PorcIs,
                PorcIva = viewModel.PorcIva,
            };

            float dolar = (float)orden.TipoCambioDolar;
            float euro = (float)orden.TipoCambioEuro;

            if (viewModel.IdMonedaOD == 1)
            {
                domain.SubTotalExcentoBase = viewModel.SubTotalExcento;
                domain.SubTotalExcentoDolar = domain.SubTotalExcentoBase * dolar;
                domain.SubTotalExcentoEuro = domain.SubTotalExcentoBase * euro;

                domain.SubTotalGrabadoBase = viewModel.SubTotalGrabado;
                domain.SubTotalGrabadoDolar = domain.SubTotalGrabadoBase * dolar;
                domain.SubTotalGrabadoEuro = domain.SubTotalGrabadoBase * euro;

                domain.TotalIvabase = viewModel.TotalIva;
                domain.TotalIvadolar = domain.TotalIvabase * dolar;
                domain.TotalIvaeuro = domain.TotalIvaeuro * euro;

                domain.TotalIsbase = viewModel.TotalIva;
                domain.TotalIsdolar = domain.TotalIsbase * dolar;
                domain.TotalIseuro = domain.TotalIseuro * euro;

                domain.TotalBase = viewModel.Total;
                domain.TotalDolar = domain.TotalBase * dolar;
                domain.TotalEuro = domain.TotalEuro * euro;



                domain.PrecioBase = viewModel.Precio;
                domain.PrecioDolar = viewModel.Precio * dolar;
                domain.PrecioEuro = viewModel.Precio * euro;

            }
            else if (viewModel.IdMonedaOD == 2)
            {
                domain.SubTotalExcentoBase = viewModel.SubTotalExcento / dolar;
                domain.SubTotalExcentoDolar = viewModel.SubTotalExcento;
                domain.SubTotalExcentoEuro = domain.SubTotalExcentoBase * euro;

                domain.SubTotalGrabadoBase = viewModel.SubTotalGrabado / dolar;
                domain.SubTotalGrabadoDolar = viewModel.SubTotalGrabado;
                domain.SubTotalGrabadoEuro = domain.SubTotalGrabadoBase * euro;

                domain.TotalIvabase = viewModel.TotalIva / dolar;
                domain.TotalIvadolar = viewModel.TotalIva;
                domain.TotalIvaeuro = domain.TotalIvabase * euro;

                domain.TotalIsbase = viewModel.TotalIs / dolar;
                domain.TotalIsdolar = viewModel.TotalIs;
                domain.TotalIseuro = domain.TotalIsbase * euro;

                domain.TotalBase = viewModel.Total / dolar;
                domain.TotalDolar = viewModel.Total;
                domain.TotalEuro = domain.TotalBase * euro;

                domain.PrecioBase = viewModel.Precio / dolar;
                domain.PrecioDolar = viewModel.Precio;
                domain.PrecioEuro = domain.PrecioBase * euro;
            }
            else if (viewModel.IdMonedaOD == 3)
            {

                domain.SubTotalExcentoBase = viewModel.SubTotalExcento / euro;
                domain.SubTotalExcentoDolar = domain.SubTotalExcentoBase * dolar;
                domain.SubTotalExcentoEuro = viewModel.SubTotalExcento;

                domain.SubTotalGrabadoBase = viewModel.SubTotalGrabado / euro;
                domain.SubTotalGrabadoDolar = domain.SubTotalGrabadoBase * dolar;
                domain.SubTotalGrabadoEuro = viewModel.SubTotalGrabado;

                domain.TotalIvabase = viewModel.TotalIva / euro;
                domain.TotalIvadolar = domain.TotalIvabase * dolar;
                domain.TotalIvaeuro = viewModel.TotalIva;

                domain.TotalIsbase = viewModel.TotalIs / euro;
                domain.TotalIsdolar = domain.TotalIsbase * dolar;
                domain.TotalIseuro = viewModel.TotalIs;

                domain.TotalBase = viewModel.Total / euro;
                domain.TotalDolar = domain.TotalBase * dolar;
                domain.TotalEuro = viewModel.Total;

                domain.PrecioBase = viewModel.Precio / euro;
                domain.PrecioDolar = domain.PrecioBase * dolar;
                domain.PrecioEuro = viewModel.Precio;
            }

            return domain;
        }



    }
}
