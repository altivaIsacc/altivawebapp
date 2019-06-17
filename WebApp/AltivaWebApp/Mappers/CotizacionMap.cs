using AltivaWebApp.Domains;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public class CotizacionMap:ICotizacionMap
    {
        private readonly ICotizacionService _Service;

        public CotizacionMap(ICotizacionService service)
        {
            _Service = service;
           
        }

        public CotizacionViewModel DomainToViewModel(TbFaCotizacion domain)
        {
            var viewModel = new CotizacionViewModel
            {
                IdCotizacion=domain.IdCotizacion,
                FechaCotizacion = domain.FechaCotizacion,
                IdCliente = domain.IdCliente,
                Estado = domain.Estado,
                IdMoneda = domain.IdMoneda,
                IdVendedor = domain.IdVendedor,
                IdUsuarioCreador = domain.IdUsuarioCreador,
                FechaVencimiento = domain.FechaVencimiento,
                TipoCambioDolar = domain.TipoCambioDolar,
                TipoCambioEuro = domain.TipoCambioEuro,
                FechaCreacion=domain.FechaCreacion

            };

            if (domain.IdMoneda == 1)
            {
                viewModel.SubTotalBase = domain.SubTotalBase;
                viewModel.SubTotalDolar = domain.SubTotalGravadoDolar;
                viewModel.SubTotalEuro = domain.SubTotalEuro;
                viewModel.SubTotalGravadoBase = domain.SubTotalGravadoBase;
                viewModel.SubTotalGravadoDolar = domain.SubTotalGravadoDolar;
                viewModel.SubTotalGravadoEuro = domain.SubTotalGravadoEuro;
                viewModel.SubTotalExcentoBase = domain.SubTotalExcentoBase;
                viewModel.SubTotalExcentoDolar = domain.SubTotalExcentoDolar;
                viewModel.SubTotalExcentoEuro = domain.SubTotalExcentoEuro;
                viewModel.PorcDescuentoBase = domain.PorcDescuentoBase;
                viewModel.TotalDescuentoBase = domain.TotalDescuentoBase;
                viewModel.TotalDescuentoDolar = domain.TotalDescuentoDolar;
                viewModel.TotalDescuentoEuro = domain.TotalDescuentoEuro;
                viewModel.SubTotalGravadoNetoBase = domain.SubTotalGravadoNetoBase;
                viewModel.SubTotalGravadoNetoDolar = domain.SubTotalGravadoNetoDolar;
                viewModel.SubTotalGravadoNetoEuro = domain.SubTotalGravadoNetoEuro;
                viewModel.SubTotalExcentoNetoBase = domain.SubTotalExcentoNetoBase;
                viewModel.SubTotalExcentoNetoDolar = domain.SubTotalExcentoNetoDolar;
                viewModel.SubTotalExcentoNetoEuro = domain.SubTotalExcentoNetoEuro;
                viewModel.MontoIvabase = domain.MontoIvabase;
                viewModel.MontoIvadolar = domain.MontoIvadolar;
                viewModel.MontoIvaeuro = domain.MontoIvaeuro;
                viewModel.TotalBase = domain.TotalBase;
                viewModel.TotalDolar = domain.TotalDolar;
                viewModel.TotalEuro = domain.TotalEuro;

            }
            else if (domain.IdMoneda == 2)
            {
                viewModel.SubTotalBase = domain.SubTotalBase;
                viewModel.SubTotalDolar = domain.SubTotalGravadoDolar;
                viewModel.SubTotalEuro = domain.SubTotalEuro;
                viewModel.SubTotalGravadoBase = domain.SubTotalGravadoBase;
                viewModel.SubTotalGravadoDolar = domain.SubTotalGravadoDolar;
                viewModel.SubTotalGravadoEuro = domain.SubTotalGravadoEuro;
                viewModel.SubTotalExcentoBase = domain.SubTotalExcentoBase;
                viewModel.SubTotalExcentoDolar = domain.SubTotalExcentoDolar;
                viewModel.SubTotalExcentoEuro = domain.SubTotalExcentoEuro;
                viewModel.PorcDescuentoBase = domain.PorcDescuentoBase;
                viewModel.TotalDescuentoBase = domain.TotalDescuentoBase;
                viewModel.TotalDescuentoDolar = domain.TotalDescuentoDolar;
                viewModel.TotalDescuentoEuro = domain.TotalDescuentoEuro;
                viewModel.SubTotalGravadoNetoBase = domain.SubTotalGravadoNetoBase;
                viewModel.SubTotalGravadoNetoDolar = domain.SubTotalGravadoNetoDolar;
                viewModel.SubTotalGravadoNetoEuro = domain.SubTotalGravadoNetoEuro;
                viewModel.SubTotalExcentoNetoBase = domain.SubTotalExcentoNetoBase;
                viewModel.SubTotalExcentoNetoDolar = domain.SubTotalExcentoNetoDolar;
                viewModel.SubTotalExcentoNetoEuro = domain.SubTotalExcentoNetoEuro;
                viewModel.MontoIvabase = domain.MontoIvabase;
                viewModel.MontoIvadolar = domain.MontoIvadolar;
                viewModel.MontoIvaeuro = domain.MontoIvaeuro;
                viewModel.TotalBase = domain.TotalBase;
                viewModel.TotalDolar = domain.TotalDolar;
                viewModel.TotalEuro = domain.TotalEuro;
            }
            else if (domain.IdMoneda == 3)
            {
                viewModel.SubTotalBase = domain.SubTotalBase;
                viewModel.SubTotalDolar = domain.SubTotalGravadoDolar;
                viewModel.SubTotalEuro = domain.SubTotalEuro;
                viewModel.SubTotalGravadoBase = domain.SubTotalGravadoBase;
                viewModel.SubTotalGravadoDolar = domain.SubTotalGravadoDolar;
                viewModel.SubTotalGravadoEuro = domain.SubTotalGravadoEuro;
                viewModel.SubTotalExcentoBase = domain.SubTotalExcentoBase;
                viewModel.SubTotalExcentoDolar = domain.SubTotalExcentoDolar;
                viewModel.SubTotalExcentoEuro = domain.SubTotalExcentoEuro;
                viewModel.PorcDescuentoBase = domain.PorcDescuentoBase;
                viewModel.TotalDescuentoBase = domain.TotalDescuentoBase;
                viewModel.TotalDescuentoDolar = domain.TotalDescuentoDolar;
                viewModel.TotalDescuentoEuro = domain.TotalDescuentoEuro;
                viewModel.SubTotalGravadoNetoBase = domain.SubTotalGravadoNetoBase;
                viewModel.SubTotalGravadoNetoDolar = domain.SubTotalGravadoNetoDolar;
                viewModel.SubTotalGravadoNetoEuro = domain.SubTotalGravadoNetoEuro;
                viewModel.SubTotalExcentoNetoBase = domain.SubTotalExcentoNetoBase;
                viewModel.SubTotalExcentoNetoDolar = domain.SubTotalExcentoNetoDolar;
                viewModel.SubTotalExcentoNetoEuro = domain.SubTotalExcentoNetoEuro;
                viewModel.MontoIvabase = domain.MontoIvabase;
                viewModel.MontoIvadolar = domain.MontoIvadolar;
                viewModel.MontoIvaeuro = domain.MontoIvaeuro;
                viewModel.TotalBase = domain.TotalBase;
                viewModel.TotalDolar = domain.TotalDolar;
                viewModel.TotalEuro = domain.TotalEuro;
            }


            return viewModel;
        }


        public TbFaCotizacion Create(CotizacionViewModel viewModel)
        {
            try
            {
                var cotizacion = _Service.Save(ViewModelToDomain(viewModel));
                var cd = cotizacion.TbFaCotizacionDetalle.First();


                return cotizacion;
            }
            catch
            {
                throw;
            }

        }

        public TbFaCotizacion Update(CotizacionViewModel viewModel)
        {
            return _Service.Update(ViewModelToDomainEdit(viewModel));
        }

        public TbFaCotizacionDetalle CreateCD(CotizacionViewModel viewModel)
        {
            return _Service.SaveCotizacionDetalle(ViewModelToDomainCD(viewModel)[0]);

        }

        public bool UpdateCD(CotizacionViewModel viewModel)
        {
            return _Service.UpdateCotizacionDetalle(ViewModelToDomainCD(viewModel));
        }

        public CotizacionViewModel DomainToViewModel(CotizacionViewModel domain)
        {
            var viewModel = new CotizacionViewModel
            {
                IdCotizacion = domain.IdCotizacion,
                FechaCotizacion = domain.FechaCotizacion,
                IdCliente = domain.IdCliente,
                Estado = domain.Estado,
                IdMoneda = domain.IdMoneda,
                IdVendedor = domain.IdVendedor,
                IdUsuarioCreador = domain.IdUsuarioCreador,
                FechaVencimiento = domain.FechaVencimiento,
                FechaCreacion=domain.FechaCreacion,
                TipoCambioDolar = domain.TipoCambioDolar,
                TipoCambioEuro = domain.TipoCambioEuro,

            };

            if (domain.IdMoneda == 1)
            {
                viewModel.SubTotalBase = domain.SubTotalBase;
                viewModel.SubTotalDolar = domain.SubTotalGravadoDolar;
                viewModel.SubTotalEuro = domain.SubTotalEuro;
                viewModel.SubTotalGravadoBase = domain.SubTotalGravadoBase;
                viewModel.SubTotalGravadoDolar = domain.SubTotalGravadoDolar;
                viewModel.SubTotalGravadoEuro = domain.SubTotalGravadoEuro;
                viewModel.SubTotalExcentoBase = domain.SubTotalExcentoBase;
                viewModel.SubTotalExcentoDolar = domain.SubTotalExcentoDolar;
                viewModel.SubTotalExcentoEuro = domain.SubTotalExcentoEuro;
                viewModel.PorcDescuentoBase = domain.PorcDescuentoBase;
                viewModel.TotalDescuentoBase = domain.TotalDescuentoBase;
                viewModel.TotalDescuentoDolar = domain.TotalDescuentoDolar;
                viewModel.TotalDescuentoEuro = domain.TotalDescuentoEuro;
                viewModel.SubTotalGravadoNetoBase = domain.SubTotalGravadoNetoBase;
                viewModel.SubTotalGravadoNetoDolar = domain.SubTotalGravadoNetoDolar;
                viewModel.SubTotalGravadoNetoEuro = domain.SubTotalGravadoNetoEuro;
                viewModel.SubTotalExcentoNetoBase = domain.SubTotalExcentoNetoBase;
                viewModel.SubTotalExcentoNetoDolar = domain.SubTotalExcentoNetoDolar;
                viewModel.SubTotalExcentoNetoEuro = domain.SubTotalExcentoNetoEuro;
                viewModel.MontoIvabase = domain.MontoIvabase;
                viewModel.MontoIvadolar = domain.MontoIvadolar;
                viewModel.MontoIvaeuro = domain.MontoIvaeuro;
                viewModel.TotalBase = domain.TotalBase;
                viewModel.TotalDolar = domain.TotalDolar;
                viewModel.TotalEuro = domain.TotalEuro;
            }
            else if (domain.IdMoneda == 2)
            {
                viewModel.SubTotalBase = domain.SubTotalBase;
                viewModel.SubTotalDolar = domain.SubTotalGravadoDolar;
                viewModel.SubTotalEuro = domain.SubTotalEuro;
                viewModel.SubTotalGravadoBase = domain.SubTotalGravadoBase;
                viewModel.SubTotalGravadoDolar = domain.SubTotalGravadoDolar;
                viewModel.SubTotalGravadoEuro = domain.SubTotalGravadoEuro;
                viewModel.SubTotalExcentoBase = domain.SubTotalExcentoBase;
                viewModel.SubTotalExcentoDolar = domain.SubTotalExcentoDolar;
                viewModel.SubTotalExcentoEuro = domain.SubTotalExcentoEuro;
                viewModel.PorcDescuentoBase = domain.PorcDescuentoBase;
                viewModel.TotalDescuentoBase = domain.TotalDescuentoBase;
                viewModel.TotalDescuentoDolar = domain.TotalDescuentoDolar;
                viewModel.TotalDescuentoEuro = domain.TotalDescuentoEuro;
                viewModel.SubTotalGravadoNetoBase = domain.SubTotalGravadoNetoBase;
                viewModel.SubTotalGravadoNetoDolar = domain.SubTotalGravadoNetoDolar;
                viewModel.SubTotalGravadoNetoEuro = domain.SubTotalGravadoNetoEuro;
                viewModel.SubTotalExcentoNetoBase = domain.SubTotalExcentoNetoBase;
                viewModel.SubTotalExcentoNetoDolar = domain.SubTotalExcentoNetoDolar;
                viewModel.SubTotalExcentoNetoEuro = domain.SubTotalExcentoNetoEuro;
                viewModel.MontoIvabase = domain.MontoIvabase;
                viewModel.MontoIvadolar = domain.MontoIvadolar;
                viewModel.MontoIvaeuro = domain.MontoIvaeuro;
                viewModel.TotalBase = domain.TotalBase;
                viewModel.TotalDolar = domain.TotalDolar;
                viewModel.TotalEuro = domain.TotalEuro;
            }
            else if (domain.IdMoneda == 3)
            {
                viewModel.SubTotalBase = domain.SubTotalBase;
                viewModel.SubTotalDolar = domain.SubTotalGravadoDolar;
                viewModel.SubTotalEuro = domain.SubTotalEuro;
                viewModel.SubTotalGravadoBase = domain.SubTotalGravadoBase;
                viewModel.SubTotalGravadoDolar = domain.SubTotalGravadoDolar;
                viewModel.SubTotalGravadoEuro = domain.SubTotalGravadoEuro;
                viewModel.SubTotalExcentoBase = domain.SubTotalExcentoBase;
                viewModel.SubTotalExcentoDolar = domain.SubTotalExcentoDolar;
                viewModel.SubTotalExcentoEuro = domain.SubTotalExcentoEuro;
                viewModel.PorcDescuentoBase = domain.PorcDescuentoBase;
                viewModel.TotalDescuentoBase = domain.TotalDescuentoBase;
                viewModel.TotalDescuentoDolar = domain.TotalDescuentoDolar;
                viewModel.TotalDescuentoEuro = domain.TotalDescuentoEuro;
                viewModel.SubTotalGravadoNetoBase = domain.SubTotalGravadoNetoBase;
                viewModel.SubTotalGravadoNetoDolar = domain.SubTotalGravadoNetoDolar;
                viewModel.SubTotalGravadoNetoEuro = domain.SubTotalGravadoNetoEuro;
                viewModel.SubTotalExcentoNetoBase = domain.SubTotalExcentoNetoBase;
                viewModel.SubTotalExcentoNetoDolar = domain.SubTotalExcentoNetoDolar;
                viewModel.SubTotalExcentoNetoEuro = domain.SubTotalExcentoNetoEuro;
                viewModel.MontoIvabase = domain.MontoIvabase;
                viewModel.MontoIvadolar = domain.MontoIvadolar;
                viewModel.MontoIvaeuro = domain.MontoIvaeuro;
                viewModel.TotalBase = domain.TotalBase;
                viewModel.TotalDolar = domain.TotalDolar;
                viewModel.TotalEuro = domain.TotalEuro;
            }


            return viewModel;
        }

        public TbFaCotizacion ViewModelToDomain(CotizacionViewModel viewModel)
        {
            var domain = new TbFaCotizacion { };
            try
            {
                 domain = new TbFaCotizacion
                {
                    IdCotizacion = viewModel.IdCotizacion,
                    FechaCotizacion = viewModel.FechaCotizacion,
                    IdCliente = viewModel.IdCliente,
                    Estado = viewModel.Estado,
                    IdMoneda = viewModel.IdMoneda,
                    IdVendedor = viewModel.IdVendedor,
                    IdUsuarioCreador = viewModel.IdUsuarioCreador,
                    FechaVencimiento = viewModel.FechaVencimiento,
                    TipoCambioDolar = viewModel.TipoCambioDolar,
                    TipoCambioEuro = viewModel.TipoCambioEuro,
                    FechaCreacion=viewModel.FechaCreacion,
                    

                    TbFaCotizacionDetalle = ViewModelToDomainCD(viewModel)
                };

                if (viewModel.IdMoneda == 1)
                {

                    domain.SubTotalBase = viewModel.SubTotalBase;
                    domain.SubTotalDolar = domain.SubTotalBase * domain.TipoCambioDolar;
                    domain.SubTotalEuro = domain.SubTotalBase * domain.TipoCambioEuro;

                    domain.SubTotalGravadoBase = viewModel.SubTotalGravadoBase;
                    domain.SubTotalGravadoDolar = domain.SubTotalGravadoBase / domain.TipoCambioDolar;
                    domain.SubTotalGravadoEuro = domain.SubTotalGravadoBase / domain.TipoCambioEuro;

                    domain.SubTotalExcentoBase = viewModel.SubTotalExcentoBase;
                    domain.SubTotalExcentoDolar = domain.SubTotalExcentoBase / domain.TipoCambioDolar;
                    domain.SubTotalExcentoEuro = domain.SubTotalExcentoBase / domain.TipoCambioEuro;

                    domain.PorcDescuentoBase = viewModel.PorcDescuentoBase;

                    domain.TotalDescuentoBase = viewModel.TotalDescuentoBase;
                    domain.TotalDescuentoDolar = domain.TotalDescuentoBase / domain.TipoCambioDolar;
                    domain.TotalDescuentoEuro = domain.TotalDescuentoBase / domain.TipoCambioEuro;

                    domain.SubTotalGravadoNetoBase = viewModel.SubTotalGravadoNetoBase;
                    domain.SubTotalGravadoNetoDolar = domain.SubTotalGravadoNetoBase / domain.TipoCambioDolar;
                    domain.SubTotalGravadoNetoEuro = domain.SubTotalGravadoNetoBase / domain.TipoCambioEuro;

                    domain.SubTotalExcentoNetoBase = viewModel.SubTotalExcentoNetoBase;
                    domain.SubTotalExcentoNetoDolar = domain.SubTotalExcentoNetoBase / domain.TipoCambioDolar;
                    domain.SubTotalExcentoNetoEuro = domain.SubTotalExcentoNetoBase / domain.TipoCambioEuro;

                    domain.MontoIvabase = viewModel.MontoIvabase;
                    domain.MontoIvadolar = domain.MontoIvabase / domain.TipoCambioDolar;
                    domain.MontoIvaeuro = domain.MontoIvabase / domain.TipoCambioEuro;

                    domain.TotalBase = viewModel.TotalBase;
                    domain.TotalDolar = domain.TotalBase / domain.TipoCambioDolar;
                    domain.TotalEuro = domain.TotalBase / domain.TipoCambioEuro;


                }
                else if (viewModel.IdMoneda == 2)
                {

                    domain.SubTotalBase = viewModel.SubTotalBase * domain.TipoCambioDolar;
                    domain.SubTotalDolar = domain.SubTotalDolar;
                    domain.SubTotalEuro = domain.SubTotalBase / domain.TipoCambioDolar;

                    domain.SubTotalGravadoBase = viewModel.SubTotalGravadoBase * domain.TipoCambioDolar;
                    domain.SubTotalGravadoDolar = domain.SubTotalGravadoDolar;
                    domain.SubTotalGravadoEuro = domain.SubTotalGravadoBase / domain.TipoCambioEuro;

                    domain.SubTotalExcentoBase = viewModel.SubTotalExcentoBase * domain.TipoCambioDolar;
                    domain.SubTotalExcentoDolar = domain.SubTotalExcentoDolar;
                    domain.SubTotalExcentoEuro = domain.SubTotalExcentoBase / domain.TipoCambioEuro;

                    domain.PorcDescuentoBase = viewModel.PorcDescuentoBase;

                    domain.TotalDescuentoBase = viewModel.TotalDescuentoBase * domain.TipoCambioDolar;
                    domain.TotalDescuentoDolar = domain.TotalDescuentoDolar;
                    domain.TotalDescuentoEuro = domain.TotalDescuentoBase / domain.TipoCambioEuro;

                    domain.SubTotalGravadoNetoBase = viewModel.SubTotalGravadoNetoBase * domain.TipoCambioDolar;
                    domain.SubTotalGravadoNetoDolar = domain.SubTotalGravadoNetoDolar;
                    domain.SubTotalGravadoNetoEuro = domain.SubTotalGravadoNetoBase / domain.TipoCambioEuro;

                    domain.SubTotalExcentoNetoBase = viewModel.SubTotalExcentoNetoBase * domain.TipoCambioDolar;
                    domain.SubTotalExcentoNetoDolar = domain.SubTotalExcentoNetoDolar;
                    domain.SubTotalExcentoNetoEuro = domain.SubTotalExcentoNetoBase / domain.TipoCambioEuro;

                    domain.MontoIvabase = viewModel.MontoIvabase * domain.TipoCambioDolar;
                    domain.MontoIvadolar = domain.MontoIvadolar;
                    domain.MontoIvaeuro = domain.MontoIvabase / domain.TipoCambioEuro;

                    domain.TotalBase = viewModel.TotalBase * domain.TipoCambioDolar;
                    domain.TotalDolar = domain.TotalDolar;
                    domain.TotalEuro = domain.TotalBase / domain.TipoCambioEuro;
                }
                else if (viewModel.IdMoneda == 3)
                {

                    domain.SubTotalBase = viewModel.SubTotalBase * domain.TipoCambioEuro;
                    domain.SubTotalDolar = domain.SubTotalBase * domain.TipoCambioDolar;
                    domain.SubTotalEuro = domain.SubTotalEuro;

                    domain.SubTotalGravadoBase = viewModel.SubTotalGravadoBase * domain.TipoCambioEuro;
                    domain.SubTotalGravadoDolar = domain.SubTotalGravadoBase * domain.TipoCambioDolar;
                    domain.SubTotalGravadoEuro = domain.SubTotalGravadoEuro;

                    domain.SubTotalExcentoBase = viewModel.SubTotalExcentoBase * domain.TipoCambioEuro;
                    domain.SubTotalExcentoDolar = domain.SubTotalExcentoBase * domain.TipoCambioDolar;
                    domain.SubTotalExcentoEuro = domain.SubTotalExcentoEuro;

                    domain.PorcDescuentoBase = viewModel.PorcDescuentoBase;

                    domain.TotalDescuentoBase = viewModel.TotalDescuentoBase * domain.TipoCambioEuro;
                    domain.TotalDescuentoDolar = domain.TotalDescuentoBase * domain.TipoCambioDolar;
                    domain.TotalDescuentoEuro = domain.TotalDescuentoEuro;

                    domain.SubTotalGravadoNetoBase = viewModel.SubTotalGravadoNetoBase * domain.TipoCambioEuro;
                    domain.SubTotalGravadoNetoDolar = domain.SubTotalGravadoNetoBase * domain.TipoCambioDolar;
                    domain.SubTotalGravadoNetoEuro = domain.SubTotalGravadoNetoEuro;

                    domain.SubTotalExcentoNetoBase = viewModel.SubTotalExcentoNetoBase * domain.TipoCambioEuro;
                    domain.SubTotalExcentoNetoDolar = domain.SubTotalExcentoNetoBase * domain.TipoCambioDolar;
                    domain.SubTotalExcentoNetoEuro = domain.SubTotalExcentoNetoEuro;

                    domain.MontoIvabase = viewModel.MontoIvabase * domain.TipoCambioEuro;
                    domain.MontoIvadolar = domain.MontoIvabase * domain.TipoCambioDolar;
                    domain.MontoIvaeuro = domain.MontoIvaeuro;

                    domain.TotalBase = viewModel.TotalBase * domain.TipoCambioEuro;
                    domain.TotalDolar = domain.TotalBase * domain.TipoCambioDolar;
                    domain.TotalEuro = domain.TotalEuro;

                   
                }
                return domain;
            }
            catch(Exception ex)
            {
                var msj = ex.Message;
                return domain;
            }


        }


        public TbFaCotizacion ViewModelToDomainEdit(CotizacionViewModel viewModel)
        {

            var domain = _Service.GetCotizacionById((int)viewModel.IdCotizacion);

            domain.IdCotizacion = viewModel.IdCotizacion;
            domain.FechaCotizacion = viewModel.FechaCotizacion;
            domain.IdCliente = viewModel.IdCliente;
            domain.Estado = viewModel.Estado;
            domain.IdMoneda = viewModel.IdMoneda;
            domain.IdVendedor = viewModel.IdVendedor;
            domain.IdUsuarioCreador = viewModel.IdUsuarioCreador;
            domain.FechaVencimiento = viewModel.FechaVencimiento;
            domain.TipoCambioDolar = viewModel.TipoCambioDolar;
            domain.TipoCambioEuro = viewModel.TipoCambioEuro;
            domain.FechaCreacion = viewModel.FechaCreacion;

            if (domain.TipoCambioDolar != viewModel.TipoCambioDolar || domain.TipoCambioEuro != viewModel.TipoCambioEuro)
            {
                domain.TipoCambioDolar = viewModel.TipoCambioDolar;
                domain.TipoCambioEuro = viewModel.TipoCambioEuro;
                UpdateTotales(domain);

            }

            if (viewModel.IdMoneda == 1)
            {
                domain.SubTotalBase = viewModel.SubTotalBase;
                domain.SubTotalDolar = domain.SubTotalBase / domain.TipoCambioDolar;
                domain.SubTotalEuro = domain.SubTotalBase/domain.TipoCambioEuro;

                domain.SubTotalGravadoBase = viewModel.SubTotalGravadoBase;
                domain.SubTotalGravadoDolar = domain.SubTotalGravadoBase / domain.TipoCambioDolar;
                domain.SubTotalGravadoEuro = domain.SubTotalGravadoBase/domain.TipoCambioEuro;

                domain.SubTotalExcentoBase = viewModel.SubTotalExcentoBase;
                domain.SubTotalExcentoDolar = domain.SubTotalExcentoBase/ domain.TipoCambioDolar;
                domain.SubTotalExcentoEuro = domain.SubTotalExcentoBase/domain.TipoCambioEuro;

                domain.PorcDescuentoBase = viewModel.PorcDescuentoBase;

                domain.TotalDescuentoBase = viewModel.TotalDescuentoBase;
                domain.TotalDescuentoDolar = domain.TotalDescuentoBase / domain.TipoCambioDolar;
                domain.TotalDescuentoEuro = domain.TotalDescuentoBase/domain.TipoCambioEuro;

                domain.SubTotalGravadoNetoBase = viewModel.SubTotalGravadoNetoBase;
                domain.SubTotalGravadoNetoDolar = domain.SubTotalGravadoNetoBase / domain.TipoCambioDolar;
                domain.SubTotalGravadoNetoEuro = domain.SubTotalGravadoNetoBase/domain.TipoCambioEuro;

                domain.SubTotalExcentoNetoBase = viewModel.SubTotalExcentoNetoBase;
                domain.SubTotalExcentoNetoDolar = domain.SubTotalExcentoNetoBase / domain.TipoCambioDolar;
                domain.SubTotalExcentoNetoEuro = domain.SubTotalExcentoNetoBase/domain.TipoCambioEuro;

                domain.MontoIvabase = viewModel.MontoIvabase;
                domain.MontoIvadolar = domain.MontoIvabase / domain.TipoCambioDolar;
                domain.MontoIvaeuro = domain.MontoIvabase / domain.TipoCambioEuro;

                domain.TotalBase = viewModel.TotalBase;
                domain.TotalDolar = domain.TotalBase / domain.TipoCambioDolar;
                domain.TotalEuro = domain.TotalBase/domain.TipoCambioEuro;

            }
            else if (viewModel.IdMoneda == 2)
            {
                domain.SubTotalBase = viewModel.SubTotalBase*domain.TipoCambioDolar;
                domain.SubTotalDolar = viewModel.SubTotalBase;
                domain.SubTotalEuro = domain.SubTotalBase / domain.TipoCambioEuro;

                domain.SubTotalGravadoBase = viewModel.SubTotalGravadoBase*domain.TipoCambioDolar;
                domain.SubTotalGravadoDolar = viewModel.SubTotalGravadoBase;
                domain.SubTotalGravadoEuro = domain.SubTotalGravadoBase / domain.TipoCambioEuro;

                domain.SubTotalExcentoBase = viewModel.SubTotalExcentoBase*domain.TipoCambioDolar;
                domain.SubTotalExcentoDolar = viewModel.SubTotalExcentoBase;
                domain.SubTotalExcentoEuro = domain.SubTotalExcentoBase / domain.TipoCambioEuro;

                domain.PorcDescuentoBase = viewModel.PorcDescuentoBase;

                domain.TotalDescuentoBase = viewModel.TotalDescuentoBase*domain.TipoCambioDolar;
                domain.TotalDescuentoDolar = viewModel.TotalDescuentoBase;
                domain.TotalDescuentoEuro = domain.TotalDescuentoBase / domain.TipoCambioEuro;

                domain.SubTotalGravadoNetoBase = viewModel.SubTotalGravadoNetoBase*domain.TipoCambioDolar;
                domain.SubTotalGravadoNetoDolar = viewModel.SubTotalGravadoNetoBase ;
                domain.SubTotalGravadoNetoEuro = domain.SubTotalGravadoNetoBase / domain.TipoCambioEuro;

                domain.SubTotalExcentoNetoBase = viewModel.SubTotalExcentoNetoBase*domain.TipoCambioDolar;
                domain.SubTotalExcentoNetoDolar = viewModel.SubTotalExcentoNetoBase;
                domain.SubTotalExcentoNetoEuro = domain.SubTotalExcentoNetoBase / domain.TipoCambioEuro;

                domain.MontoIvabase = viewModel.MontoIvabase*domain.TipoCambioDolar;
                domain.MontoIvadolar = viewModel.MontoIvabase ;
                domain.MontoIvaeuro = domain.MontoIvabase / domain.TipoCambioEuro;

                domain.TotalBase = viewModel.TotalBase*domain.TipoCambioDolar;
                domain.TotalDolar = viewModel.TotalBase;
                domain.TotalEuro = domain.TotalBase / domain.TipoCambioEuro;
            }
            else if (viewModel.IdMoneda == 3)
            {

                domain.SubTotalBase = viewModel.SubTotalBase*domain.TipoCambioEuro;
                domain.SubTotalDolar = domain.SubTotalBase / domain.TipoCambioDolar;
                domain.SubTotalEuro = viewModel.SubTotalBase;

                domain.SubTotalGravadoBase = viewModel.SubTotalGravadoBase*domain.TipoCambioEuro;
                domain.SubTotalGravadoDolar = domain.SubTotalGravadoBase / domain.TipoCambioDolar;
                domain.SubTotalGravadoEuro = viewModel.SubTotalGravadoBase;

                domain.SubTotalExcentoBase = viewModel.SubTotalExcentoBase*domain.TipoCambioEuro;
                domain.SubTotalExcentoDolar = domain.SubTotalExcentoBase / domain.TipoCambioDolar;
                domain.SubTotalExcentoEuro = viewModel.SubTotalExcentoBase / domain.TipoCambioEuro;

                domain.PorcDescuentoBase = viewModel.PorcDescuentoBase;

                domain.TotalDescuentoBase = viewModel.TotalDescuentoBase*domain.TipoCambioEuro;
                domain.TotalDescuentoDolar = domain.TotalDescuentoBase / domain.TipoCambioDolar;
                domain.TotalDescuentoEuro = viewModel.TotalDescuentoBase;

                domain.SubTotalGravadoNetoBase = viewModel.SubTotalGravadoNetoBase*domain.TipoCambioEuro;
                domain.SubTotalGravadoNetoDolar = domain.SubTotalGravadoNetoBase / domain.TipoCambioDolar;
                domain.SubTotalGravadoNetoEuro = viewModel.SubTotalGravadoNetoBase;

                domain.SubTotalExcentoNetoBase = viewModel.SubTotalExcentoNetoBase*domain.TipoCambioEuro;
                domain.SubTotalExcentoNetoDolar = domain.SubTotalExcentoNetoBase / domain.TipoCambioDolar;
                domain.SubTotalExcentoNetoEuro = viewModel.SubTotalExcentoNetoBase;

                domain.MontoIvabase = viewModel.MontoIvabase*domain.TipoCambioEuro;
                domain.MontoIvadolar = domain.MontoIvabase / domain.TipoCambioDolar;
                domain.MontoIvaeuro = viewModel.MontoIvabase;

                domain.TotalBase = viewModel.TotalBase*domain.TipoCambioEuro;
                domain.TotalDolar = domain.TotalBase / domain.TipoCambioDolar;
                domain.TotalEuro = viewModel.TotalBase;
            }
            return domain;

        }

        public void UpdateTotales(TbFaCotizacion compra)
        {
            var detalles = new List<TbFaCotizacionDetalle>();
            var dolar = compra.TipoCambioDolar;
            var euro = compra.TipoCambioEuro;

            foreach (var domain in compra.TbFaCotizacionDetalle)
            {
                if (compra.IdMoneda == 1)
                {
                    domain.SubTotalExcentoDolar = domain.SubTotalExcentoBase / dolar;
                    domain.SubTotalExcentoEuro = domain.SubTotalExcentoBase / euro;

                    domain.SubTotalExcentoNetoDolar = domain.SubTotalExcentoNetoBase / dolar;
                    domain.SubTotalExcentoNetoEuro = domain.SubTotalExcentoNetoBase / euro;

                    domain.SubTotalGravadoDolar = domain.SubTotalGravadoBase / dolar;
                    domain.SubTotalGravadoEuro = domain.SubTotalGravadoBase / euro;

                    domain.SubTotalGravadoNetoDolar = domain.SubTotalGravadoNetoBase / dolar;
                    domain.SubTotalGravadoNetoEuro = domain.SubTotalGravadoNetoBase / euro;

                    domain.MontoIvaDolar = domain.MontoIvaBase / dolar;
                    domain.MontoIvaEuro = domain.MontoIvaBase / euro;

                    domain.TotalDolar = domain.TotalBase / dolar;
                    domain.TotalEuro = domain.TotalBase / euro;

                    domain.TotalDescuentoDolar = domain.TotalDescuentoBase / dolar;
                    domain.TotalDescuentoEuro = domain.TotalDescuentoBase / euro;


                }
                else if (compra.IdMoneda == 2)
                {
                    domain.SubTotalExcentoBase = domain.SubTotalExcentoBase * dolar;
                    domain.SubTotalExcentoEuro = domain.SubTotalExcentoBase / euro;

                    domain.SubTotalExcentoNetoBase = domain.SubTotalExcentoNetoBase * dolar;
                    domain.SubTotalExcentoNetoEuro = domain.SubTotalExcentoNetoBase / euro;

                    domain.SubTotalGravadoBase = domain.SubTotalGravadoBase * dolar;
                    domain.SubTotalGravadoEuro = domain.SubTotalGravadoBase / euro;

                    domain.SubTotalGravadoNetoBase = domain.SubTotalGravadoNetoBase * dolar;
                    domain.SubTotalGravadoNetoEuro = domain.SubTotalGravadoNetoBase / euro;


                    domain.MontoIvaBase = domain.MontoIvaBase *Convert.ToDouble( dolar);
                    domain.MontoIvaEuro = domain.MontoIvaBase / euro;


                    domain.TotalBase = domain.TotalBase * dolar;
                    domain.TotalEuro = domain.TotalBase / euro;


                    domain.TotalDescuentoBase = domain.TotalDescuentoBase * dolar;
                    domain.TotalDescuentoEuro = domain.TotalDescuentoBase / euro;
                }
                else if (compra.IdMoneda == 3)
                {

                    domain.SubTotalExcentoBase = domain.SubTotalExcentoBase * euro;
                    domain.SubTotalExcentoDolar = domain.SubTotalExcentoBase / dolar;

                    domain.SubTotalExcentoNetoBase = domain.SubTotalExcentoNetoBase * euro;
                    domain.SubTotalExcentoNetoDolar = domain.SubTotalExcentoNetoBase / dolar;

                    domain.SubTotalGravadoBase = domain.SubTotalGravadoBase * euro;
                    domain.SubTotalGravadoDolar = domain.SubTotalGravadoBase / dolar;

                    domain.SubTotalGravadoNetoBase = domain.SubTotalGravadoNetoBase * euro;
                    domain.SubTotalGravadoNetoDolar = domain.SubTotalGravadoNetoBase / dolar;


                    domain.MontoIvaBase = domain.MontoIvaBase *Convert.ToDouble( euro);
                    domain.MontoIvaDolar = domain.MontoIvaBase / dolar;

                    domain.TotalBase = domain.TotalBase * euro;
                    domain.TotalDolar = domain.TotalBase / dolar;

                    domain.TotalDescuentoBase = domain.TotalDescuentoBase * euro;
                    domain.TotalDescuentoDolar = domain.TotalDescuentoBase / dolar;
                }

                detalles.Add(domain);
            }


            _Service.UpdateCotizacionDetalle(detalles);



        }


        public IList<TbFaCotizacionDetalle> ViewModelToDomainCD(CotizacionViewModel viewModel)
        {
            var domain = new List<TbFaCotizacionDetalle>();
            foreach (var item in viewModel.CotizacionDetalle)
            {
                domain.Add(ViewModelToDomainSingleCD(item, viewModel));
            }

            return domain;
        }

        public TbFaCotizacionDetalle ViewModelToDomainSingleCD(CotizacionDetalleViewModels viewModel, CotizacionViewModel compra)
        {
            var domain = new TbFaCotizacionDetalle
            {
                IdCotizacionDetalle = viewModel.IdCotizacionDetalle,
                IdInventario  = viewModel.IdInventario,
                FechaCreacion= viewModel.FechaCreacion,
                IdUsuarioCreador = viewModel.IdUsuarioCreador,
                IdCotizacion= viewModel.IdCotizacion,
                Cantidad=viewModel.Cantidad
           
         
        };

            float dolar = (float)compra.TipoCambioDolar;
            float euro = (float)compra.TipoCambioEuro;

            if (compra.IdMoneda == 1)
            {
                domain.PrecioBase = viewModel.PrecioBase;
                domain.PrecioDolar = domain.PrecioBase * dolar;
                domain.PrecioEuro = domain.PrecioBase * euro;

                domain.SubTotalBase = viewModel.SubTotalBase;
                domain.SubTotalDolar = domain.SubTotalBase / dolar;
                domain.SubTotalEuro = domain.SubTotalBase / euro;

                domain.SubTotalGravadoBase = viewModel.SubTotalGravadoBase;
                domain.SubTotalGravadoDolar = domain.SubTotalGravadoBase / dolar;
                domain.SubTotalGravadoEuro = domain.SubTotalGravadoBase / euro;

                domain.SubTotalExcentoBase = viewModel.SubTotalExcentoBase;
                domain.SubTotalExcentoDolar = domain.SubTotalExcentoBase / dolar;
                domain.SubTotalExcentoEuro = domain.SubTotalExcentoBase / euro;

                domain.PorcDescuento = viewModel.PorcDescuento;

                domain.TotalDescuentoBase = viewModel.TotalDescuentoBase;
                domain.TotalDescuentoDolar = domain.TotalDescuentoBase / dolar;
                domain.TotalDescuentoEuro = domain.TotalDescuentoBase / euro;

                domain.SubTotalGravadoNetoBase = viewModel.SubTotalGravadoNetoBase;
                domain.SubTotalGravadoNetoDolar = domain.SubTotalGravadoNetoBase / dolar;
                domain.SubTotalGravadoNetoEuro = domain.SubTotalGravadoNetoBase / euro;

                domain.SubTotalExcentoNetoBase = viewModel.SubTotalExcentoNetoBase;
                domain.SubTotalExcentoNetoDolar = domain.SubTotalExcentoNetoBase / dolar;
                domain.SubTotalExcentoNetoEuro = domain.SubTotalExcentoNetoBase / euro;

                domain.MontoIvaBase = viewModel.MontoIvaBase;
                domain.MontoIvaDolar = domain.MontoIvaBase / dolar;
                domain.MontoIvaEuro = domain.MontoIvaBase / euro;

                domain.TotalBase = viewModel.TotalBase;
                domain.TotalDolar = domain.TotalBase / dolar;
                domain.TotalEuro = domain.TotalBase / euro;

            }
            else if (compra.IdMoneda == 2)
            {

                domain.PrecioBase = viewModel.PrecioBase*dolar;
                domain.PrecioDolar = viewModel.PrecioBase ;
                domain.PrecioEuro = domain.PrecioBase / euro;

                domain.SubTotalBase = viewModel.SubTotalBase*dolar;
                domain.SubTotalDolar = viewModel.SubTotalBase ;
                domain.SubTotalEuro = domain.SubTotalBase / euro;

                domain.SubTotalGravadoBase = viewModel.SubTotalGravadoBase*dolar;
                domain.SubTotalGravadoDolar = viewModel.SubTotalGravadoBase;
                domain.SubTotalGravadoEuro = domain.SubTotalGravadoBase / euro;

                domain.SubTotalExcentoBase = viewModel.SubTotalExcentoBase*dolar;
                domain.SubTotalExcentoDolar = viewModel.SubTotalExcentoBase;
                domain.SubTotalExcentoEuro = domain.SubTotalExcentoBase / euro;

                domain.PorcDescuento = viewModel.PorcDescuento;

                domain.TotalDescuentoBase = viewModel.TotalDescuentoBase*dolar;
                domain.TotalDescuentoDolar = viewModel.TotalDescuentoBase;
                domain.TotalDescuentoEuro = domain.TotalDescuentoBase / euro;

                domain.SubTotalGravadoNetoBase = viewModel.SubTotalGravadoNetoBase*dolar;
                domain.SubTotalGravadoNetoDolar = viewModel.SubTotalGravadoNetoBase;
                domain.SubTotalGravadoNetoEuro = domain.SubTotalGravadoNetoBase / euro;

                domain.SubTotalExcentoNetoBase = viewModel.SubTotalExcentoNetoBase*dolar;
                domain.SubTotalExcentoNetoDolar = viewModel.SubTotalExcentoNetoBase;
                domain.SubTotalExcentoNetoEuro = domain.SubTotalExcentoNetoBase / euro;

                domain.MontoIvaBase = viewModel.MontoIvaBase*dolar;
                domain.MontoIvaDolar = viewModel.MontoIvaBase ;
                domain.MontoIvaEuro = domain.MontoIvaBase / euro;

                domain.TotalBase = viewModel.TotalBase*dolar;
                domain.TotalDolar = viewModel.TotalBase;
                domain.TotalEuro = domain.TotalBase / euro;

            }
            else if (compra.IdMoneda == 3)
            {

                domain.PrecioBase = viewModel.PrecioBase*euro;
                domain.PrecioDolar = domain.PrecioBase / dolar;
                domain.PrecioEuro = viewModel.PrecioBase;

                domain.SubTotalBase = viewModel.SubTotalBase*euro;
                domain.SubTotalDolar = domain.SubTotalBase/dolar;
                domain.SubTotalEuro = viewModel.SubTotalBase;

                domain.SubTotalGravadoBase = viewModel.SubTotalGravadoBase*euro;
                domain.SubTotalGravadoDolar = domain.SubTotalGravadoBase / dolar;
                domain.SubTotalGravadoEuro = viewModel.SubTotalGravadoBase;

                domain.SubTotalExcentoBase = viewModel.SubTotalExcentoBase*euro;
                domain.SubTotalExcentoDolar = domain.SubTotalExcentoBase / dolar;
                domain.SubTotalExcentoEuro = viewModel.SubTotalExcentoBase;

                domain.PorcDescuento = viewModel.PorcDescuento;

                domain.TotalDescuentoBase = viewModel.TotalDescuentoBase*euro;
                domain.TotalDescuentoDolar = domain.TotalDescuentoBase / dolar;
                domain.TotalDescuentoEuro = viewModel.TotalDescuentoBase;

                domain.SubTotalGravadoNetoBase = viewModel.SubTotalGravadoNetoBase*euro;
                domain.SubTotalGravadoNetoDolar = domain.SubTotalGravadoNetoBase / dolar;
                domain.SubTotalGravadoNetoEuro = viewModel.SubTotalGravadoNetoBase ;

                domain.SubTotalExcentoNetoBase = viewModel.SubTotalExcentoNetoBase*euro;
                domain.SubTotalExcentoNetoDolar = domain.SubTotalExcentoNetoBase / dolar;
                domain.SubTotalExcentoNetoEuro = viewModel.SubTotalExcentoNetoBase;

                domain.MontoIvaBase = viewModel.MontoIvaBase*euro;
                domain.MontoIvaDolar = domain.MontoIvaBase / dolar;
                domain.MontoIvaEuro = viewModel.MontoIvaBase ;

                domain.TotalBase = viewModel.TotalBase*euro;
                domain.TotalDolar = domain.TotalBase / dolar;
                domain.TotalEuro = viewModel.TotalBase;

            }

            return domain;
        }

    }
}
