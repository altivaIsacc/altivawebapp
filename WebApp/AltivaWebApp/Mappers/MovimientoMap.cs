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
                        IdMovimientoDesde = idMovDoc,
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

    }
}
