using AltivaWebApp.Domains;
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

            return domain;

        }


        public CajaViewModel DomainToViewModel(TbFaCaja domain)
        {
            var viewModel = new CajaViewModel
            {
                IdCaja = domain.IdCaja,
                FechaCreacion = Convert.ToDateTime( domain.FechaCreacion),
                IdUsuario =Convert.ToInt32( domain.IdUsuario),
                Estado =Convert.ToInt32( domain.Estado),
            };

            return viewModel;
        }

        public TbFaCaja Create(CajaViewModel viewModel)
        {
            try
            {
                var caja = _Service.Save(ViewModelToDomain(viewModel));
                var ac = caja.TbFaCajaAperturaDenominacion.First();

                return caja;
            }
            catch
            {
                throw;
            }

        }


        public TbFaCaja ViewModelToDomain(CajaViewModel viewModel)
        {
            var domain = new TbFaCaja { };
            try
            {
                domain = new TbFaCaja
                {
                    IdCaja = viewModel.IdCaja,
                    FechaCreacion = Convert.ToDateTime(viewModel.FechaCreacion),
                    IdUsuario = viewModel.IdUsuario,
                    Estado = viewModel.Estado,
                    TbFaCajaAperturaDenominacion = ViewModelToDomainCD(viewModel),
                    TbFaCajaArqueoDenominacion= ViewModelToDomainAr(viewModel)

                };

                return domain;
            }
            catch (Exception ex)
            {
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
            var domain = new TbFaCajaAperturaDenominacion
            {
                IdCajaApertura = viewModel.IdCajaApertura,
                IdCaja=viewModel.IdCaja,
                FechaCreacion = Convert.ToDateTime(viewModel.FechaCreacion),
                IdUsuario = viewModel.IdUsuario,
                IdDenominacion = viewModel.IdDenominacion,
                Cantidad=viewModel.Cantidad,
                Monto=viewModel.Monto,
            };

            return domain;
        }

        public TbFaCajaArqueoDenominacion ViewModelToDomainSingleAr(CajaArqueoDenominacionViewModel viewModel, CajaViewModel compra)
        {
            var domain = new TbFaCajaArqueoDenominacion
            {
                IdCajaArqueoDenominacion = viewModel.IdCajaArqueoDenominacion,
                IdCaja = viewModel.IdCaja,
                FechaCreacion = Convert.ToDateTime(viewModel.FechaCreacion),
                IdUsuario = viewModel.IdUsuario,
                IdDenominacion = viewModel.IdDenominacion,
                Cantidad = viewModel.Cantidad,
                Monto = viewModel.Monto,
            };

            return domain;
        }


    }
}
