using AltivaWebApp.Domains;
using AltivaWebApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public class KardexMap : IKardexMap
    {
        private readonly IKardexService service;
        private readonly IAjusteService ajusteService;
        public KardexMap(IKardexService service, IAjusteService ajusteService)
        {
            this.service = service;
            this.ajusteService = ajusteService;
        }

        public bool CreateKardexAM(TbPrAjuste ajuste, int idAjuste)
        {
            var flag = true;
            var domain = ajusteService.GetAjusteById(idAjuste);
            var kardex = new List<TbPrKardex>();

            /////averiguar que hacer si se eliminar una linea, restar si es entrada y sumar si es salida
            ///debe procesar la linea eliminada y despues guardar el kardex


            foreach (var item in domain.TbPrAjusteInventario)
            {
                if (!ExisteAjusteInventario(ajuste, (int)item.Id))
                {
                    var k = new TbPrKardex();
                    double existencia = 0;
                    double existenciaB = 0;

                    if (domain.Anulada)
                        if (item.Movimiento)
                            item.Movimiento = false;
                        else
                            item.Movimiento = true;

                    if (item.Movimiento)
                    {
                        existencia = item.IdInventarioNavigation.ExistenciaGeneral + domain.TbPrAjusteInventario.FirstOrDefault(i => i.Movimiento == true && i.IdInventario == item.IdInventario).Cantidad;
                        existenciaB = item.IdInventarioNavigation.TbPrInventarioBodega.FirstOrDefault(i => i.IdBodega == domain.IdBodega).ExistenciaBodega + domain.TbPrAjusteInventario.FirstOrDefault(i => i.Movimiento == true && i.IdInventario == item.IdInventario).Cantidad;
                        k.CantidadMov = item.Cantidad;
                    }
                    else
                    {
                        existencia = item.IdInventarioNavigation.ExistenciaGeneral - domain.TbPrAjusteInventario.FirstOrDefault(i => i.Movimiento == false && i.IdInventario == item.IdInventario).Cantidad;
                        existenciaB = item.IdInventarioNavigation.TbPrInventarioBodega.FirstOrDefault(i => i.IdBodega == domain.IdBodega).ExistenciaBodega - domain.TbPrAjusteInventario.FirstOrDefault(i => i.Movimiento == false && i.IdInventario == item.IdInventario).Cantidad;
                        k.CantidadMov = item.Cantidad * -1;
                    }

                    if (existencia < 0 || existenciaB < 0)
                    {
                        flag = false;
                        break;
                    }
                        

                    k.CostoMov = item.TotalMovimiento;
                    k.CostoPromedio = 0;//item.CostoPromedio;
                    k.ExistAct = existencia;
                    k.ExistActBod = existenciaB;
                    k.ExistAnt = item.IdInventarioNavigation.ExistenciaGeneral;
                    k.ExistAntBod = item.IdInventarioNavigation.TbPrInventarioBodega.FirstOrDefault(i => i.IdBodega == domain.IdBodega).ExistenciaBodega;
                    k.Fecha = DateTime.Now;
                    k.IdBodegaDestino = domain.IdBodega;
                    k.IdBodegaOrigen = domain.IdBodega;
                    k.IdDocumento = domain.Id;
                    k.IdInventario = item.IdInventario;
                    k.IdMoneda = 1;
                    k.IdUsuario = domain.IdUsuario;
                    k.Observaciones = domain.Descripcion;
                    k.PrecioPromedio = 0;
                    k.PrecioUnit = item.IdInventarioNavigation.UltimoPrecioCompra;
                    k.SaldoFinal = 0;//item.CostoPromedio * existenciaB,
                    k.TipoDocumento = "AM";


                    kardex.Add(k);
                }


            }

            if (flag)
                service.SaveAll(kardex);

            return flag;
            
        }

        public bool CreateKardexDeletedAM(TbPrAjuste domain)
        {
            var flag = true;
            var kardex = new List<TbPrKardex>();

            foreach (var item in domain.TbPrAjusteInventario)
            {
                var k = new TbPrKardex();
                double existencia = 0;
                double existenciaB = 0;

                if (item.Movimiento)
                {
                    existencia = item.IdInventarioNavigation.ExistenciaGeneral - domain.TbPrAjusteInventario.FirstOrDefault(i => i.Movimiento == true && i.IdInventario == item.IdInventario).Cantidad;
                    existenciaB = item.IdInventarioNavigation.TbPrInventarioBodega.FirstOrDefault(i => i.IdBodega == domain.IdBodega).ExistenciaBodega - domain.TbPrAjusteInventario.FirstOrDefault(i => i.Movimiento == true && i.IdInventario == item.IdInventario).Cantidad;
                    k.CantidadMov = item.Cantidad * -1;
                }
                else
                {
                    existencia = item.IdInventarioNavigation.ExistenciaGeneral + domain.TbPrAjusteInventario.FirstOrDefault(i => i.Movimiento == false && i.IdInventario == item.IdInventario).Cantidad;
                    existenciaB = item.IdInventarioNavigation.TbPrInventarioBodega.FirstOrDefault(i => i.IdBodega == domain.IdBodega).ExistenciaBodega + domain.TbPrAjusteInventario.FirstOrDefault(i => i.Movimiento == false && i.IdInventario == item.IdInventario).Cantidad;
                    k.CantidadMov = item.Cantidad;

                }

                if (existencia < 0 || existenciaB < 0)
                {
                    flag = false;
                    break;
                }

                k.CostoMov = item.TotalMovimiento;
                k.CostoPromedio = 0;//item.CostoPromedio;
                k.ExistAct = existencia;
                k.ExistActBod = existenciaB;
                k.ExistAnt = item.IdInventarioNavigation.ExistenciaGeneral;
                k.ExistAntBod = item.IdInventarioNavigation.TbPrInventarioBodega.FirstOrDefault(i => i.IdBodega == domain.IdBodega).ExistenciaBodega;
                k.Fecha = DateTime.Now;
                k.IdBodegaDestino = domain.IdBodega;
                k.IdBodegaOrigen = domain.IdBodega;
                k.IdDocumento = domain.Id;
                k.IdInventario = item.IdInventario;
                k.IdMoneda = 1;
                k.IdUsuario = domain.IdUsuario;
                k.Observaciones = domain.Descripcion;
                k.PrecioPromedio = 0;
                k.PrecioUnit = item.IdInventarioNavigation.UltimoPrecioCompra;
                k.SaldoFinal = 0;//item.CostoPromedio * existenciaB,
                k.TipoDocumento = "AM";


                kardex.Add(k);
            }




            if (flag)
                service.SaveAll(kardex);

            return flag;
        }

        private bool ExisteAjusteInventario(TbPrAjuste ajuste, int aiId)
        {
            if (ajuste != null)
            {
                var flag = false;
                foreach (var item in ajuste.TbPrAjusteInventario)
                {
                    if (item.Id == aiId)
                    {
                        flag = true;
                        break;
                    }

                }
                return flag;
            }
            else
                return false;
        }


    }
}
