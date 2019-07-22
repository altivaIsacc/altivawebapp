using AltivaWebApp.Domains;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public class FacturaMap: IFacturaMap
    {
        private readonly IFacturaService service;
        public FacturaMap(IFacturaService service)
        {
            this.service = service;
        }

        public TbFdFactura Create(FacturaViewModel viewModel)
        {
            return service.Save(ViewModelToDomain(viewModel));
        }

        public TbFdFactura Update(FacturaViewModel viewModel)
        {
            return service.Update(ViewModelToDomain(viewModel));
        }

        public IList<TbFdFacturaDetalle> CreateFD(FacturaViewModel viewModel)
        {
            return service.SaveFacturaDetalle(ViewModelToDomainFD(viewModel));
        }

        public IList<TbFdFacturaDetalle> UpdateFD(FacturaViewModel viewModel)
        {
            return service.UpdateFacturaDetalle(ViewModelToDomainFD(viewModel));
        }

        public IList<TbFdFacturaDetalle> CreateOrUpdateFD(FacturaViewModel viewModel)
        {
            if(viewModel.FacturaDetalle[0].Id != 0)
                return service.UpdateFacturaDetalle(ViewModelToDomainFD(viewModel));
            else
                return service.SaveFacturaDetalle(ViewModelToDomainFD(viewModel));
        }

        public TbFdFactura ViewModelToDomain(FacturaViewModel viewModel)
        {

            var domain = new TbFdFactura
            {
                Id = viewModel.Id,
                IdMoneda = viewModel.IdMoneda,
                IdCliente = viewModel.IdCliente,
                IdUsuarioCreador = viewModel.IdUsuarioCreador,
                Estado = viewModel.Estado,
                FechaCreacion = viewModel.FechaCreacion,
                FechaVencimiento = viewModel.FechaVencimiento,
                TipoCambioDolar = viewModel.TipoCambioDolar,
                TipoCambioEuro = viewModel.TipoCambioEuro,
                FechaFactura = viewModel.FechaFactura,
                IdVendedor = viewModel.IdVendedor,
                PorcDescuento = viewModel.PorcDescuento,
                Tipo = viewModel.Tipo,
                
                TbFdFacturaDetalle = ViewModelToDomainFD(viewModel)
            };

            if (viewModel.IdMoneda == 1)
            {
                domain.SubTotalBase = viewModel.SubTotal;
                domain.SubTotalDolar = domain.SubTotalBase / domain.TipoCambioDolar;
                domain.SubTotalEuro = domain.SubTotalBase / domain.TipoCambioEuro;

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


                domain.MontoIvabase = viewModel.MontoIva;
                domain.MontoIvadolar = domain.MontoIvabase / domain.TipoCambioDolar;
                domain.MontoIvaeuro = domain.MontoIvabase / domain.TipoCambioEuro;

                domain.TotalBase = viewModel.Total;
                domain.TotalDolar = domain.TotalBase / domain.TipoCambioDolar;
                domain.TotalEuro = domain.TotalBase / domain.TipoCambioEuro;

                domain.TotalDescuentoBase = viewModel.TotalDescuento;
                domain.TotalDescuentoDolar = domain.TotalDescuentoBase / domain.TipoCambioDolar;
                domain.TotalDescuentoEuro = domain.TotalDescuentoBase / domain.TipoCambioEuro;

            }
            else if (viewModel.IdMoneda == 2)
            {
                domain.SubTotalBase = viewModel.SubTotal * domain.TipoCambioDolar;
                domain.SubTotalDolar = viewModel.SubTotal;
                domain.SubTotalEuro = domain.SubTotalBase / domain.TipoCambioEuro;

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


                domain.MontoIvabase = viewModel.MontoIva * domain.TipoCambioDolar;
                domain.MontoIvadolar = viewModel.MontoIva;
                domain.MontoIvaeuro = domain.MontoIvabase / domain.TipoCambioEuro;

                domain.TotalBase = viewModel.Total * domain.TipoCambioDolar;
                domain.TotalDolar = viewModel.Total;
                domain.TotalEuro = domain.TotalBase / domain.TipoCambioEuro;

                domain.TotalDescuentoBase = viewModel.TotalDescuento * domain.TipoCambioDolar;
                domain.TotalDescuentoDolar = viewModel.TotalDescuento;
                domain.TotalDescuentoEuro = domain.TotalDescuentoBase / domain.TipoCambioEuro;
            }
            else if (viewModel.IdMoneda == 3)
            {

                domain.SubTotalBase = viewModel.SubTotal * domain.TipoCambioEuro;
                domain.SubTotalDolar = domain.SubTotalBase / domain.TipoCambioDolar;
                domain.SubTotalEuro = viewModel.SubTotal;

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


                domain.MontoIvabase = viewModel.MontoIva * domain.TipoCambioEuro;
                domain.MontoIvadolar = domain.MontoIvabase / domain.TipoCambioDolar;
                domain.MontoIvaeuro = viewModel.MontoIva;

                domain.TotalBase = viewModel.Total * domain.TipoCambioEuro;
                domain.TotalDolar = domain.TotalBase / domain.TipoCambioDolar;
                domain.TotalEuro = viewModel.Total;

                domain.TotalDescuentoBase = viewModel.TotalDescuento * domain.TipoCambioEuro;
                domain.TotalDescuentoDolar = domain.TotalDescuentoBase / domain.TipoCambioDolar;
                domain.TotalDescuentoEuro = viewModel.TotalDescuento;
            }

            return domain;

        }





        public IList<TbFdFacturaDetalle> ViewModelToDomainFD(FacturaViewModel viewModel)
        {
            var domain = new List<TbFdFacturaDetalle>();
            foreach (var item in viewModel.FacturaDetalle)
            {
                domain.Add(ViewModelToDomainSingleFD(item, viewModel));
            }

            return domain;
        }

        public TbFdFacturaDetalle ViewModelToDomainSingleFD(FacturaDetalleViewModel viewModel, FacturaViewModel factura)
        {
            var domain = new TbFdFacturaDetalle
            {
                FechaCreacion = viewModel.FechaCreacion,
                FechaVencimiento = viewModel.FechaVencimiento,
                Id = viewModel.Id,
                IdFactura = viewModel.IdFactura,
                IdInventario = viewModel.IdInventario,
                IdUsuarioCreador = viewModel.IdUsuarioCreador,
                Cantidad = viewModel.Cantidad,
                PorcDescuento = viewModel.PorcDescuento,
                PorcIva = viewModel.PorcIva
            };


            float dolar = (float)factura.TipoCambioDolar;
            float euro = (float)factura.TipoCambioEuro;

            if (viewModel.IdMonedaFD == 1)
            {


                domain.PrecioBase = viewModel.Precio;
                domain.PrecioDolar = domain.PrecioBase / dolar;
                domain.PrecioEuro = domain.PrecioBase / euro;

                domain.SubTotalBase = viewModel.SubTotal;
                domain.SubTotalDolar = domain.SubTotalBase / dolar;
                domain.SubTotalEuro = domain.SubTotalBase / euro;

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

                domain.MontoIvabase = viewModel.MontoIva;
                domain.MontoIvadolar = domain.MontoIvabase / dolar;
                domain.MontoIvaeuro = domain.MontoIvabase / euro;


                domain.TotalBase = viewModel.Total;
                domain.TotalDolar = domain.TotalBase / dolar;
                domain.TotalEuro = domain.TotalBase / euro;

                domain.MontoDescuentoBase = viewModel.MontoDescuento;
                domain.MontoDescuentoDolar = viewModel.MontoDescuento / dolar;
                domain.MontoDescuentoEuro = viewModel.MontoDescuento / euro;

            }
            else if (viewModel.IdMonedaFD == 2)
            {

                domain.PrecioBase = viewModel.Precio * dolar;
                domain.PrecioDolar = viewModel.Precio;
                domain.PrecioEuro = domain.PrecioBase / euro;

                domain.SubTotalBase = viewModel.SubTotal * dolar;
                domain.SubTotalDolar = viewModel.SubTotal;
                domain.SubTotalEuro = domain.SubTotalBase / euro;

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


                domain.MontoIvabase = viewModel.MontoIva * dolar;
                domain.MontoIvadolar = viewModel.MontoIva;
                domain.MontoIvaeuro = domain.MontoIvabase / euro;

                domain.TotalBase = viewModel.Total * dolar;
                domain.TotalDolar = viewModel.Total;
                domain.TotalEuro = domain.TotalBase / euro;

                domain.MontoDescuentoBase = viewModel.MontoDescuento * dolar;
                domain.MontoDescuentoDolar = viewModel.MontoDescuento;
                domain.MontoDescuentoEuro = domain.MontoDescuentoBase / euro;


            }
            else if (viewModel.IdMonedaFD == 3)
            {

                domain.PrecioBase = viewModel.Precio * euro;
                domain.PrecioDolar = domain.PrecioBase / dolar;
                domain.PrecioEuro = viewModel.Precio;

                domain.SubTotalBase = viewModel.SubTotal * euro;
                domain.SubTotalDolar = domain.SubTotalBase / dolar;
                domain.SubTotalEuro = viewModel.SubTotal;

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


                domain.MontoIvabase = viewModel.MontoIva * euro;
                domain.MontoIvadolar = domain.MontoIvabase / dolar;
                domain.MontoIvaeuro = viewModel.MontoIva;


                domain.TotalBase = viewModel.Total * euro;
                domain.TotalDolar = domain.TotalBase / dolar;
                domain.TotalEuro = viewModel.Total;

                domain.MontoDescuentoBase = viewModel.MontoDescuento * euro;
                domain.MontoDescuentoDolar = domain.MontoDescuentoBase / dolar;
                domain.MontoDescuentoEuro = viewModel.MontoDescuento;
            }

            return domain;



        }

    }
}
