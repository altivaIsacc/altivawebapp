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
    public class MovimientoMap : IMovimientoMap
    {
        private readonly IMovimientoService service;
        private readonly IMonedaService monedaService;

        public MovimientoMap(IMovimientoService service, IMonedaService monedaService)
        {
            this.service = service;
            this.monedaService = monedaService;
        }

        public TbFaMovimiento CreateMovimientoPago(long idDoc, IList<CajaMovimientoViewModel> formasPago, double montoPrepago)
        {

            var movDoc = service.GetMovimientoByIdDocumento(idDoc);

            double montoFPBase = formasPago.Sum(fp => fp.MontoBase);
            double montoFPDolar = formasPago.Sum(fp => fp.MontoDolar);
            double montoFPEuro = formasPago.Sum(fp => fp.MontoEuro);

            var movPago = new TbFaMovimiento
            {
                IdMovimiento = 0,
                IdContacto = movDoc.IdContacto,
                IdDocumento = 0,
                IdTipoDocumento = 2,
                IdUsuario = movDoc.IdUsuario,
                Cxp = movDoc.Cxp,
                Cxc = movDoc.Cxc,
                IdMoneda = movDoc.IdMoneda,
                MontoBase = montoFPBase, //suma de fp base
                MontoDolar = montoFPDolar,//suma de fp dolar
                MontoEuro = montoFPEuro,//suma de fp euro
                DisponibleBase = montoFPBase,//suma de fp base
                DisponibleDolar = montoFPDolar,//suma de fp dolar
                DisponibleEuro = montoFPEuro,//suma de fp euro
                AplicadoBase = 0,
                AplicadoDolar = 0,
                AplicadoEuro = 0,
                SaldoBase = 0,
                SaldoDolar = 0,
                SaldoEuro = 0,
                FechaCreacion = DateTime.Now

            };

            TbFaMovimiento newMov = null;

            if (formasPago.Count() > 0)
            {
                newMov = service.Save(movPago);
                CreateMovmientoDetalle(movDoc, newMov);
            }

            if (montoPrepago > 0)
                AplicarSaldo(movDoc.IdMovimiento, montoPrepago, idDoc);

            return newMov;
        }

        public IList<TbFaMovimientoDetalle> CreateMovmientoDetalle(TbFaMovimiento movDesde, TbFaMovimiento movHasta)
        {
            var moneda = monedaService.GetAll();
            IList<TbFaMovimientoDetalle> movDetalle = new List<TbFaMovimientoDetalle>();

            movDetalle.Add(new TbFaMovimientoDetalle
            {
                AplicadoBase = movHasta.MontoBase,
                AplicadoDolar = movHasta.MontoDolar,
                AplicadoEuro = movHasta.MontoEuro,
                CompraDolarTc = moneda[1].ValorCompra,
                CompraEuroTc = moneda[2].ValorCompra,
                Fecha = DateTime.Now,
                VentaDolarTc = moneda[1].ValorVenta,
                VentaEuroTc = moneda[2].ValorVenta,
                IdMovimientoDesde = movDesde.IdMovimiento,
                IdMovimientoHasta = movHasta.IdMovimiento

            });


            return service.SaveMovDetalle(movDetalle);
        }

        public void AplicarSaldo(long idMovDoc, double montoPrepago, long idDocumento)
        {
            IList<TbSeMoneda> monedas = monedaService.GetAll();
            TbFaMovimiento movDoc = idMovDoc != 0 ? service.GetMovimientoById(idMovDoc) : service.GetMovimientoByIdDocumento(idDocumento);


            //saldos aplicados
            IList<TbFaMovimientoDetalle> docAplicado = service.GetMovimientoByIdDocConPagos(idDocumento).Where(m => (bool)!m.IdMovimientoHastaNavigation.IdTipoDocumentoNavigation.EsDebito && m.IdMovimientoHastaNavigation.IdTipoDocumentoNavigation.Cxc && m.IdMovimientoHastaNavigation.IdTipoDocumento != 2).ToList();

            double saldoAplicado = docAplicado.Sum(m => movDoc.IdMoneda == 1 ? m.AplicadoBase : movDoc.IdMoneda == 2 ? m.AplicadoDolar : m.AplicadoEuro);

            if (saldoAplicado == montoPrepago)
                return;

            if (docAplicado.Count() > 0 && saldoAplicado != montoPrepago)
            {
                //tiene prepagos o saldo, se borran todas las relaciones
                service.DeleteMovimientoDetalle(docAplicado);
            }


            IList<TbFaMovimiento> movList = service.GetSaldoContacto(movDoc.IdContacto).OrderBy(m => m.FechaCreacion).ToList();

            IList<TbFaMovimientoDetalle> movDetlist = new List<TbFaMovimientoDetalle>();

            double aplicadoB = 0;
            double aplicadoD = 0;
            double aplicadoE = 0;

            double saldoB = retornaPrepagoAlCambio(movDoc.IdMoneda, 1, montoPrepago, monedas);
            double saldoD = retornaPrepagoAlCambio(movDoc.IdMoneda, 2, montoPrepago, monedas);
            double saldoE = retornaPrepagoAlCambio(movDoc.IdMoneda, 3, montoPrepago, monedas);

            foreach (var item in movList)
            {
                saldoB = saldoB - aplicadoB;
                saldoD = saldoD - aplicadoD;
                saldoE = saldoE - aplicadoE;

                if (saldoB > 0)
                {
                    if (item.DisponibleBase <= saldoB)
                    {
                        aplicadoB = item.DisponibleBase;
                        aplicadoD = item.DisponibleDolar;
                        aplicadoE = item.DisponibleEuro;
                    }
                    else
                    {
                        aplicadoB = saldoB;
                        aplicadoD = saldoD;
                        aplicadoE = saldoE;
                    }


                    movDetlist.Add(new TbFaMovimientoDetalle
                    {
                        AplicadoBase = aplicadoB,
                        AplicadoDolar = aplicadoD,
                        AplicadoEuro = aplicadoE,
                        CompraDolarTc = monedas[1].ValorCompra,
                        CompraEuroTc = monedas[2].ValorCompra,
                        Fecha = DateTime.Now,
                        IdMovimientoDesde = movDoc.IdMovimiento,
                        IdMovimientoHasta = item.IdMovimiento,
                        IdMovimientoDetalle = 0,
                        VentaDolarTc = monedas[1].ValorVenta,
                        VentaEuroTc = monedas[2].ValorVenta
                    });

                }
                else
                    break;
            }

            service.SaveMovDetalle(movDetlist);


        }


        private double retornaPrepagoAlCambio(int monedaIn, int monedaOut, double prepago, IList<TbSeMoneda> monedas)
        {
            double monto = 0;
            switch (monedaIn)
            {
                case 1:
                    switch (monedaOut)
                    {
                        case 1:
                            monto = prepago;
                            break;
                        case 2:
                            monto = prepago / monedas[1].ValorCompra;
                            break;
                        case 3:
                            monto = prepago / monedas[2].ValorCompra;
                            break;
                    }
                    break;
                case 2:
                    switch (monedaOut)
                    {
                        case 1:
                            monto = prepago * monedas[1].ValorCompra;
                            break;
                        case 2:
                            monto = prepago;
                            break;
                        case 3:
                            monto = (prepago * monedas[1].ValorCompra) / monedas[2].ValorCompra;
                            break;
                    }
                    break;
                case 3:
                    switch (monedaOut)
                    {
                        case 1:
                            monto = prepago * monedas[2].ValorCompra;
                            break;
                        case 2:
                            monto = (prepago * monedas[2].ValorCompra) / monedas[1].ValorCompra;
                            break;
                        case 3:
                            monto = prepago;
                            break;
                    }
                    break;
            }

            return monto;

        }
        //francisco
        public TbFaMovimiento Create(MovimientoViewModel viewModel)
        {
            return service.Save(ViewModelToDomain(viewModel));
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
            domain.DisponibleBase = montoBase;
            domain.DisponibleDolar = montoDolar;
            domain.DisponibleEuro = montoEuro;


            return domain;
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
                viewModel.DisponibleBase = domain.DisponibleBase;
            }
            else if (viewModel.IdMoneda == 2)
            {
                viewModel.Monto = domain.MontoDolar;
                viewModel.DisponibleDolar = domain.DisponibleDolar;
            }
            else if (viewModel.IdMoneda == 3)
            {
                viewModel.Monto = domain.MontoEuro;
                viewModel.DisponibleEuro = domain.DisponibleEuro;
            }
            return viewModel;
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
                Estado = viewModel.Estado,
                IdUsuario = viewModel.IdUsuario,
                IdMoneda = viewModel.IdMoneda,
                CompraDolarTc = viewModel.CompraDolarTc,
                CompraEuroTc = viewModel.CompraEuroTc,
                VentaDolatTc = viewModel.VentaDolatTc,
                VentaEuroTc = viewModel.VentaEuroTc,
                Descripcion = viewModel.Descripcion,


            };

            float dolar = (float)viewModel.VentaDolatTc;
            float euro = (float)viewModel.VentaEuroTc;

            if (viewModel.IdMoneda == 1)
            {
                domain.MontoBase = viewModel.Monto;
                domain.MontoDolar = domain.MontoBase / dolar;
                domain.MontoEuro = domain.MontoBase / euro;
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
        public bool CreateMD(IList<MovimientoDetalleViewModel> viewModel)
        {
            return service.SaveMD(ViewModelToDomainMD(viewModel));
        }
        public bool UpdateMD(IList<MovimientoDetalleViewModel> viewModel)
        {
            return service.UpdateMD(ViewModelToDomainMDEdit(viewModel));
        }
        public TbFaMovimiento ViewModelToDomainEdit(MovimientoViewModel viewModel)
        {
            var domain = service.GetMovimientoById(viewModel.IdMovimiento);
            domain.IdMoneda = viewModel.IdMoneda;
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
            domain.DisponibleBase = montoBase - domain.AplicadoBase;
            domain.DisponibleDolar = montoDolar - domain.DisponibleDolar;
            domain.DisponibleEuro = montoEuro - domain.DisponibleEuro;


            return domain;
        }
        public IList<TbFaMovimientoDetalle> ViewModelToDomainMDEdit(IList<MovimientoDetalleViewModel> viewModel)
        {
            var domain = new List<TbFaMovimientoDetalle>();
            foreach (var item in viewModel)
            {
                domain.Add(ViewModelToDomainSingleMDEdit(item));
            }

            return domain;
        }
        public TbFaMovimientoDetalle ViewModelToDomainSingleMDEdit(MovimientoDetalleViewModel viewModel)
        {
            var domain = service.GetMovimientoDetalleByIdMovimiento(viewModel.IdMovimientoHasta);


            domain.CompraDolarTc = viewModel.CompraDolarTc;
            domain.VentaDolarTc = viewModel.VentaDolarTc;
            domain.CompraEuroTc = viewModel.CompraEuroTc;
            domain.VentaEuroTc = viewModel.VentaEuroTc;
            domain.Fecha = DateTime.Now;




            float dolar = (float)viewModel.VentaDolarTc;
            float euro = (float)viewModel.VentaEuroTc;

            if (viewModel.IdMoneda == 1)
            {
                domain.AplicadoBase = viewModel.Aplicado;
                domain.AplicadoDolar = domain.AplicadoBase / dolar;
                domain.AplicadoEuro = domain.AplicadoBase / euro;
            }
            else if (viewModel.IdMoneda == 2)
            {
                domain.AplicadoBase = viewModel.Aplicado * dolar;
                domain.AplicadoDolar = viewModel.Aplicado;
                domain.AplicadoEuro = domain.AplicadoBase / euro;
            }
            else if (viewModel.IdMoneda == 3)
            {
                domain.AplicadoBase = viewModel.Aplicado * euro;
                domain.AplicadoDolar = domain.AplicadoBase / dolar;
                domain.AplicadoEuro = viewModel.Aplicado;
            }

            return domain;
        }
        public IList<TbFaMovimientoDetalle> ViewModelToDomainMD(IList<MovimientoDetalleViewModel> viewModel)
        {
            var domain = new List<TbFaMovimientoDetalle>();
            foreach (var item in viewModel)
            {
                domain.Add(ViewModelToDomainSingleMD(item));
            }

            return domain;
        }
        public TbFaMovimientoDetalle ViewModelToDomainSingleMD(MovimientoDetalleViewModel viewModel)
        {
            var domain = new TbFaMovimientoDetalle
            {
                IdMovimientoDetalle = viewModel.IdMovimientoDetalle,
                IdMovimientoDesde = viewModel.IdMovimientoDesde,
                IdMovimientoHasta = viewModel.IdMovimientoHasta,
                CompraDolarTc = viewModel.CompraDolarTc,
                VentaDolarTc = viewModel.VentaDolarTc,
                CompraEuroTc = viewModel.CompraEuroTc,
                VentaEuroTc = viewModel.VentaEuroTc,
                Fecha = DateTime.Now


            };

            float dolar = (float)viewModel.VentaDolarTc;
            float euro = (float)viewModel.VentaEuroTc;

            if (viewModel.IdMoneda == 1)
            {
                domain.AplicadoBase = viewModel.Aplicado;
                domain.AplicadoDolar = domain.AplicadoBase / dolar;
                domain.AplicadoEuro = domain.AplicadoBase / euro;
            }
            else if (viewModel.IdMoneda == 2)
            {
                domain.AplicadoBase = viewModel.Aplicado * dolar;
                domain.AplicadoDolar = viewModel.Aplicado;
                domain.AplicadoEuro = domain.AplicadoBase / euro;
            }
            else if (viewModel.IdMoneda == 3)
            {
                domain.AplicadoBase = viewModel.Aplicado * euro;
                domain.AplicadoDolar = domain.AplicadoBase / dolar;
                domain.AplicadoEuro = viewModel.Aplicado;
            }

            return domain;
        }
        //francisco

    }
}
