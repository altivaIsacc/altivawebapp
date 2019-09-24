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
    public class MovimientoMap: IMovimientoMap
    {
        private readonly IMovimientoService service;
        private readonly IMonedaService monedaService;

        public MovimientoMap(IMovimientoService service, IMonedaService monedaService)
        {
            this.service = service;
            this.monedaService = monedaService;
        }

        public TbFaMovimiento Create(MovimientoViewModel viewModel)
        {
            return service.Save(ViewModelToDomain(viewModel));
        }

        public TbFaMovimiento Update(MovimientoViewModel viewModel)
        {
            return service.Update(ViewModelToDomainEdit(viewModel));
        }

        public bool CreateMJ(MovimientoViewModel viewModel)
        {
            return service.SaveMovimientoJustificante(ViewModelToDomainMJ(viewModel));
        }

        public bool UpdateMJ(MovimientoViewModel viewModel)
        {
            return service.UpdateMovimientoJustificante(ViewModelToDomainMJ(viewModel));
        }
        public TbFaMovimiento ViewModelToDomain(MovimientoViewModel viewModel)
        {

            var domain = new TbFaMovimiento();

            domain.IdMovimiento = viewModel.IdMovimiento;
            domain.IdContacto = viewModel.IdContacto;
            domain.IdDocumento = viewModel.IdDocumento;
            domain.IdTipoDocumento = viewModel.IdTipoDocumento;
            domain.IdUsuario = viewModel.IdUsuario;
            domain.Cxp = viewModel.Cxp;
            domain.Cxc = viewModel.Cxc;
            domain.IdMoneda = viewModel.IdMoneda;         
            domain.DisponibleBase = viewModel.DisponibleBase;
            domain.DisponibleDolar = viewModel.DisponibleDolar;
            domain.DisponibleEuro = viewModel.DisponibleEuro;
            domain.AplicadoBase = viewModel.AplicadoBase;
            domain.AplicadoDolar = viewModel.AplicadoDolar;
            domain.AplicadoEuro = viewModel.AplicadoEuro;
            domain.SaldoBase = viewModel.SaldoBase;
            domain.SaldoDolar = viewModel.SaldoDolar;
            domain.SaldoEuro = viewModel.SaldoEuro;
            domain.FechaCreacion = viewModel.FechaCreacion;
            domain.TbFaMovimientoJustificante = ViewModelToDomainMJ(viewModel);

            double montoBase = 0;
            double montoDolar = 0;
            double montoEuro = 0;

            foreach (var item in domain.TbFaMovimientoJustificante)
            {
                 montoBase = item.MontoBase + montoBase;
                 montoDolar = item.MontoDolar + montoDolar;
                 montoEuro = item.MontoEuro + montoEuro;

            }           
                domain.MontoBase = montoBase;
                domain.MontoDolar = montoDolar;
                domain.MontoEuro = montoEuro;
         

            return domain;
        }
        public double RecuperarTipos(MovimientoViewModel viewModel, int tipo)
        {
            var domain = new List<TbFaMovimientoJustificante>();
            foreach (var item in viewModel.movimientoJustificante)
            {
                if (tipo == 1)
                    return item.CompraDolarTc;
                if (tipo == 2)
                    return item.CompraEuroTc;
            }
            return 0;
        }
        public IList<TbFaMovimientoJustificante> ViewModelToDomainMJ(MovimientoViewModel viewModel)
        {
            var domain = new List<TbFaMovimientoJustificante>();
            foreach (var item in viewModel.movimientoJustificante)
            {
                domain.Add(ViewModelToDomainSingleMj(item, viewModel));
            }

            return domain;
        }
        public TbFaMovimientoJustificante ViewModelToDomainSingleMj(MovimientoJustificanteViewModel viewModel, MovimientoViewModel movimiento)
        {
            var domain = new TbFaMovimientoJustificante
            {
                IdMovimientoJustificante = viewModel.IdMovimientoJustificante,
                IdMovimiento = viewModel.IdMovimiento,
                IdTipoJustificante = viewModel.IdTipoJustificante,
                IdUsuario = viewModel.IdUsuario,
                Estado = viewModel.Estado,
                IdMoneda = viewModel.IdMoneda,
                CompraDolarTc = viewModel.CompraDolarTc,
                CompraEuroTc = viewModel.CompraEuroTc,
                VentaDolatTc = viewModel.VentaDolatTc,
                VentaEuroTc = viewModel.VentaEuroTc,
                Descripcion = viewModel.Descripcion,


            };

            float dolar = (float)viewModel.CompraDolarTc;
            float euro = (float)viewModel.CompraEuroTc;

            if (viewModel.IdMoneda == 1)
            {
                domain.MontoBase = viewModel.Monto;
                domain.MontoDolar = domain.MontoBase / dolar;
                domain.MontoEuro= domain.MontoBase / euro;
            }
            else if (viewModel.IdMoneda == 2)
            {
                domain.MontoBase = viewModel.Monto * dolar;
                domain.MontoDolar = viewModel.Monto;
                domain.MontoEuro = domain.MontoBase / euro;                        
            }
            else if (viewModel.IdMoneda == 3)
            {
                domain.MontoBase = viewModel.Monto * euro;
                domain.MontoDolar = domain.MontoBase / dolar;
                domain.MontoEuro = viewModel.Monto;              
            }

            return domain;
        }
        public TbFaMovimiento ViewModelToDomainEdit(MovimientoViewModel viewModel)
        {
            var domain = service.GetMovimientoById(viewModel.IdMovimiento);
            domain.IdMovimiento = viewModel.IdMovimiento;
            domain.IdContacto = viewModel.IdContacto;
            domain.IdDocumento = viewModel.IdDocumento;
            domain.IdTipoDocumento = viewModel.IdTipoDocumento;
            domain.IdUsuario = viewModel.IdUsuario;
            domain.Cxp = viewModel.Cxp;
            domain.Cxc = viewModel.Cxc;
            domain.IdMoneda = viewModel.IdMoneda;         
            domain.DisponibleBase = viewModel.DisponibleBase;
            domain.DisponibleDolar = viewModel.DisponibleDolar;
            domain.DisponibleEuro = viewModel.DisponibleEuro;
            domain.AplicadoBase = viewModel.AplicadoBase;
            domain.AplicadoDolar = viewModel.AplicadoDolar;
            domain.AplicadoEuro = viewModel.AplicadoEuro;
            domain.SaldoBase = viewModel.SaldoBase;
            domain.SaldoDolar = viewModel.SaldoDolar;
            domain.SaldoEuro = viewModel.SaldoEuro;
            domain.FechaCreacion = viewModel.FechaCreacion;

            double montoBase = 0;
            double montoDolar = 0;
            double montoEuro = 0;

            foreach (var item in service.GetJustificantesByMovimientoId(viewModel.IdMovimiento))
            {
                montoBase = item.MontoBase + montoBase;
                montoDolar = item.MontoDolar + montoDolar;
                montoEuro = item.MontoEuro + montoEuro;

            }
            domain.MontoBase = montoBase;
            domain.MontoDolar = montoDolar;
            domain.MontoEuro = montoEuro;

            return domain;
        }

       public MovimientoViewModel DomainToViewModel(TbFaMovimiento domain)
       {
         var viewModel = new MovimientoViewModel
         {
             IdMovimiento = domain.IdMovimiento,
            IdContacto = domain.IdContacto,
            IdDocumento = domain.IdDocumento,
            IdTipoDocumento = domain.IdTipoDocumento,
            IdUsuario = domain.IdUsuario,
            Cxp = domain.Cxp,
            Cxc = domain.Cxc,
            IdMoneda = domain.IdMoneda,            
            DisponibleBase = domain.DisponibleBase,
            DisponibleDolar = domain.DisponibleDolar,
            DisponibleEuro = domain.DisponibleEuro,
            AplicadoBase = domain.AplicadoBase,
            AplicadoDolar = domain.AplicadoDolar,
            AplicadoEuro = domain.AplicadoEuro,
            SaldoBase = domain.SaldoBase,
            SaldoDolar = domain.SaldoDolar,
            SaldoEuro = domain.SaldoEuro,
            FechaCreacion = domain.FechaCreacion
         };
            if (viewModel.IdMoneda == 1)
            {
                viewModel.Monto = domain.MontoBase;           
            }
            else if (viewModel.IdMoneda == 2)
            {
                viewModel.Monto = domain.MontoDolar;
            }
            else if (viewModel.IdMoneda == 3)
            {
                viewModel.Monto = domain.MontoEuro;
            }
            return viewModel;
       }
    }
}
