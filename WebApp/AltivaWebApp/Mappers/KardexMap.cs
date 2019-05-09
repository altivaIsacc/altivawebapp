using AltivaWebApp.Domains;
using AltivaWebApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public class KardexMap: IKardexMap
    {
        private readonly IKardexService service;
        private readonly IAjusteService ajusteService;
        public KardexMap(IKardexService service, IAjusteService ajusteService)
        {
            this.service = service;
            this.ajusteService = ajusteService;
        }

        public void CreateKardexAM(int idAjuste)
        {
            var domain = ajusteService.GetAjusteById(idAjuste);
            var kardex = new List<TbPrKardex>();

            foreach (var item in domain.TbPrAjusteInventario)
            {

                double existencia = 0;
                double existenciaB = 0;
                if (item.Movimiento)
                {
                    existencia = item.IdInventarioNavigation.ExistenciaGeneral + domain.TbPrAjusteInventario.FirstOrDefault(i => i.Movimiento == true && i.IdInventario == item.IdInventario).Cantidad;
                    existenciaB = item.IdInventarioNavigation.TbPrInventarioBodega.FirstOrDefault(i => i.IdBodega == domain.IdBodega).ExistenciaBodega + domain.TbPrAjusteInventario.FirstOrDefault(i => i.Movimiento == true && i.IdInventario == item.IdInventario).Cantidad;
                }
                else
                {
                    existencia = item.IdInventarioNavigation.ExistenciaGeneral - domain.TbPrAjusteInventario.FirstOrDefault(i => i.Movimiento == false && i.IdInventario == item.IdInventario).Cantidad;
                    existenciaB = item.IdInventarioNavigation.TbPrInventarioBodega.FirstOrDefault(i => i.IdBodega == domain.IdBodega).ExistenciaBodega - domain.TbPrAjusteInventario.FirstOrDefault(i => i.Movimiento == false && i.IdInventario == item.IdInventario).Cantidad;
                }

                var k = new TbPrKardex
                {
                    CantidadMov = item.Cantidad,
                    CostoMov = item.TotalMovimiento,
                    CostoPromedio = item.CostoPromedio,
                    ExistAct = existencia,
                    ExistActBod = existenciaB,
                    ExistAnt = item.IdInventarioNavigation.ExistenciaGeneral,
                    ExistAntBod = item.IdInventarioNavigation.TbPrInventarioBodega.FirstOrDefault(i => i.IdBodega == domain.IdBodega).ExistenciaBodega,
                    Fecha = DateTime.Now,
                    IdBodegaDestino = domain.IdBodega,
                    IdBodegaOrigen = domain.IdBodega,
                    IdDocumento = domain.Id,
                    IdInventario = item.IdInventario,
                    IdMoneda = 1,
                    IdUsuario = domain.IdUsuario,
                    Observaciones = domain.Descripcion,
                    PrecioPromedio = 0,
                    PrecioUnit = item.IdInventarioNavigation.UltimoPrecioCompra,
                    SaldoFinal = item.CostoPromedio * existenciaB,
                    TipoDocumento = "AM"
                };

                kardex.Add(k);
            }

            var res = service.SaveAll(kardex);

        }
    }
}
