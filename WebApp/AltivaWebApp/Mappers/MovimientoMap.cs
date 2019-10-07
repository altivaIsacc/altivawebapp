using AltivaWebApp.Domains;
using AltivaWebApp.Services;
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

        public IList<TbFaMovimientoDetalle> CreateMovmientoDetalle(long idDocumento)
        {
            var moneda = monedaService.GetAll();
            var movimientos = service.GetMovimientosByIdDocumento(idDocumento);

            var movimientoDesde = movimientos.First();
            var movimientoHasta = movimientos.Last();
            ///insertar el detalle rel mov de la fact y el pago
            ///
            IList<TbFaMovimientoDetalle> movDetalle = new List<TbFaMovimientoDetalle>();

            movDetalle.Add(new TbFaMovimientoDetalle
            {
                AplicadoBase = movimientoHasta.MontoBase,
                AplicadoDolar = movimientoHasta.MontoDolar,
                AplicadoEuro = movimientoHasta.MontoEuro,
                CompraDolarTc = moneda[1].ValorCompra,
                CompraEuroTc = moneda[2].ValorCompra,
                Fecha = DateTime.Now,
                VentaDolarTc = moneda[1].ValorVenta,
                VentaEuroTc = moneda[2].ValorVenta,
                IdMovimientoDesde = movimientoDesde.IdMovimiento,
                IdMovimientoHasta = movimientoHasta.IdMovimiento
                
            });


            return service.SaveMovDetalle(movDetalle);
        }

        public void CrearEnlance(long idUltMovimiento, double montoPrepago)
        {
            TbFaMovimiento ultMov = service.GetMovimientoById(idUltMovimiento);
            IList<TbFaMovimiento> movList = service.GetSaldoContacto(ultMov.IdContacto);

            IList<TbFaMovimientoDetalle> movDetlist = new List<TbFaMovimientoDetalle>();

            double monto = 0;

            //foreach (var item in movList)
            //{
            //    switch (ultMov)
            //    {
            //        default:
            //            break;
            //    }
            //}


        }

    }
}
