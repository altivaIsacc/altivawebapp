﻿using AltivaWebApp.Domains;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public class CajaMap:ICajaMap
    {
        private readonly ICajaService _Service;

        public CajaMap(ICajaService service)
        {
            _Service = service;

        }

        public TbFaCajaAperturaDenominacion CreateCD(CajaViewModel viewModel)
        {
            return _Service.SaveCajaAperturaDenominacion(ViewModelToDomainCD(viewModel)[0]);

        }


        public TbFaCaja Update(CajaViewModel viewModel)
        {
            return _Service.Update(ViewModelToDomainEdit(viewModel));
        }

        public bool UpdateCD(CajaViewModel viewModel)
        {
            return _Service.UpdateCajaAperturaDenominacion(ViewModelToDomainCD(viewModel));
        }

        public bool UpdateArqueo(CajaViewModel viewModel)
        {
            return _Service.UpdateCajaArqueo(ViewModelToDomainArqueo(viewModel));
        }

        public bool UpdateCierre(CajaViewModel viewModel)
        {
            return _Service.UpdateCajaCierre(ViewModelToDomainCierre(viewModel));
        }

        public bool UpdateAr(CajaViewModel viewModel)
        {
            return _Service.UpdateCajaArqueoDenominacion(ViewModelToDomainAr(viewModel));
        }


        public TbFaCaja ViewModelToDomainEdit(CajaViewModel viewModel)
        {

            var domain = _Service.GetCajaById((int)viewModel.IdCaja);

            domain.IdCaja = viewModel.IdCaja;
            domain.FechaCreacion = viewModel.FechaCreacion;
            domain.IdUsuario = viewModel.IdUsuario;
            domain.Estado = viewModel.Estado;
            domain.FechaModificacion = DateTime.Now;
            domain.IdPuntoVenta = viewModel.IdPuntoVenta;

            return domain;

        }


        public CajaViewModel DomainToViewModel(TbFaCaja domain)
        {
            var viewModel = new CajaViewModel
            {
                IdCaja = domain.IdCaja,
                FechaCreacion = Convert.ToDateTime(domain.FechaCreacion),
                IdUsuario = Convert.ToInt32(domain.IdUsuario),
                Estado = Convert.ToInt32(domain.Estado),
                FechaModificacion = domain.FechaModificacion,
                IdPuntoVenta = domain.IdPuntoVenta
            };

            return viewModel;
        }

        public TbFaCaja Create(CajaViewModel viewModel)
        {
            try
            {
                var caja = _Service.Save(ViewModelToDomain(viewModel));
                return caja;
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }

        }


        public TbFaCaja ViewModelToDomain(CajaViewModel viewModel)
        {
            var domain = new TbFaCaja { };
            var fecha = new DateTime();

            if (viewModel.IdCaja != 0)
            {
                fecha = viewModel.FechaCreacion;
        
            }
            else
            {
                fecha = DateTime.Now;
            }
            try
            {
                domain = new TbFaCaja
                {
                    IdCaja = viewModel.IdCaja,
                    FechaCreacion = fecha,
                    IdUsuario = viewModel.IdUsuario,
                    Estado = viewModel.Estado,
                    FechaModificacion=DateTime.Now,
                    IdPuntoVenta = viewModel.IdPuntoVenta,
                    TbFaCajaAperturaDenominacion = ViewModelToDomainCD(viewModel),
                    TbFaCajaArqueoDenominacion= ViewModelToDomainAr(viewModel)

                };

                return domain;
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Advertencia");
                var msj = ex.Message;
                return domain;
            }


        }


        public IList<TbFaCajaAperturaDenominacion> ViewModelToDomainCD(CajaViewModel viewModel)
        {
            var domain = new List<TbFaCajaAperturaDenominacion>();
            foreach (var item in viewModel.TbFaCajaAperturaDenominacion)
            {
                domain.Add(ViewModelToDomainSingleCD(item, viewModel));
            }

            return domain;
        }


        public IList<TbFaCajaArqueo> ViewModelToDomainArqueo(CajaViewModel viewModel)
        {
            var domain = new List<TbFaCajaArqueo>();
            foreach (var item in viewModel.TbFaCajaArqueo)
            {
                domain.Add(ViewModelToDomainSingleArqueo(item, viewModel));
            }

            return domain;
        }

        public IList<TbFaCajaCierre> ViewModelToDomainCierre(CajaViewModel viewModel)
        {
            var domain = new List<TbFaCajaCierre>();
            foreach (var item in viewModel.TbFaCajaCierre)
            {
                domain.Add(ViewModelToDomainSingleCierre(item, viewModel));
            }

            return domain;
        }

        public IList<TbFaCajaArqueoDenominacion> ViewModelToDomainAr(CajaViewModel viewModel)
        {
            var domain = new List<TbFaCajaArqueoDenominacion>();
            foreach (var item in viewModel.TbFaCajaArqueoDenominacion)
            {
                domain.Add(ViewModelToDomainSingleAr(item, viewModel));
            }

            return domain;
        }




        public TbFaCajaAperturaDenominacion ViewModelToDomainSingleCD(CajaAperturaDenominacionViewModel viewModel, CajaViewModel compra)
        {
            DateTime fecha = new DateTime();
            if (compra.IdCaja != 0)
            {
        
                fecha = viewModel.FechaCreacion;
            }
            else
            {
                fecha = DateTime.Now;
            }

            var domain = new TbFaCajaAperturaDenominacion
            {
                IdCajaApertura = viewModel.IdCajaApertura,
                IdCaja=viewModel.IdCaja,
                FechaCreacion =fecha,
                IdUsuario = viewModel.IdUsuario,
                IdDenominacion = viewModel.IdDenominacion,
                Cantidad=viewModel.Cantidad,
                Monto=viewModel.Monto,
            };

            return domain;
        }

        public TbFaCajaArqueoDenominacion ViewModelToDomainSingleAr(CajaArqueoDenominacionViewModel viewModel, CajaViewModel compra)
        {
            DateTime fecha = new DateTime();
            if (compra.IdCaja != 0)
            {
            
                fecha = viewModel.FechaCreacion;
            }
            else
            {
                fecha = DateTime.Now;
            }

            var domain = new TbFaCajaArqueoDenominacion
            {
                IdCajaArqueoDenominacion = viewModel.IdCajaArqueoDenominacion,
                IdCaja = viewModel.IdCaja,
                FechaCreacion =fecha,
                IdUsuario = viewModel.IdUsuario,
                IdDenominacion = viewModel.IdDenominacion,
                Cantidad = viewModel.Cantidad,
                Monto = viewModel.Monto,
            };

            return domain;
        }

        public TbFaCajaArqueo ViewModelToDomainSingleArqueo(CajaArqueoViewModel viewModel, CajaViewModel compra)
        {
            DateTime fechaCreacion = new DateTime();

            if (viewModel.FechaCreacion!=null)
            {
                fechaCreacion = Convert.ToDateTime(viewModel.FechaCreacion);
        
            }
            else
            {
                fechaCreacion = DateTime.Now;

            }
            var domain = new TbFaCajaArqueo
            {
                IdCajaArqueo = viewModel.IdCajaArqueo,
                IdCaja = (long)viewModel.IdCaja,
                FechaCreacion = fechaCreacion,
                IdUsuario = (long)viewModel.IdUsuario,
                IdMoneda = (int)viewModel.IdMoneda,
                EfectivoReal = (double)viewModel.EfectivoReal,
                TarjetaReal = (double)viewModel.TarjetaReal,
                BancoReal = (double)viewModel.BancoReal,
            };

            return domain;
        }

        public TbFaCajaCierre ViewModelToDomainSingleCierre(CajaCierreViewModel viewModel, CajaViewModel compra)
        {
            DateTime fechaCreacion = new DateTime();
            if (viewModel.FechaCreacion!=null)
            {
                fechaCreacion =Convert.ToDateTime( viewModel.FechaCreacion);

            }
            else
            {
                fechaCreacion = DateTime.Now;
            }
            var domain = new TbFaCajaCierre
            {
                IdCajaCierre = viewModel.IdCajaCierre,
                IdCaja = viewModel.IdCaja,
                FechaCreacion = fechaCreacion,
                IdUsuario = viewModel.IdUsuario,
                IdMoneda = viewModel.IdMoneda,
                Efectivo=viewModel.Efectivo,
                EfectivoReal = viewModel.EfectivoReal,
                Tarjeta=viewModel.Tarjeta,
                TarjetaReal = viewModel.TarjetaReal,
                Bancos=viewModel.Bancos,
                BancoReal = viewModel.BancoReal,
                Entradas=viewModel.Entradas,
                Salidas=viewModel.Salidas,
            };

            return domain;
        }


    }
}
