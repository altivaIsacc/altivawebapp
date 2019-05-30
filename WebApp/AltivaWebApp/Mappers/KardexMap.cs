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
        private readonly ICompraService compraService;
        private readonly IRequisicionService reqService;
        public KardexMap(IRequisicionService reqService, ICompraService compraService, IKardexService service, IAjusteService ajusteService)
        {
            this.service = service;
            this.ajusteService = ajusteService;
            this.compraService = compraService;
            this.reqService = reqService;
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

        ///////////////////////////Compras
        ///
        public bool CreateKardexCD(int idCompra)
        {
            var domain = compraService.GetCompraById(idCompra);
            var kardex = new List<TbPrKardex>();
            var cd = new List<TbPrCompraDetalle>();




            foreach (var item in domain.TbPrCompraDetalle)
            {
                var k = new TbPrKardex
                {
                    CantidadMov = item.Cantidad,
                    CostoPromedio = 0,
                    CostoMov = item.SubTotalExcentoBase + item.SubTotalGravadoBase,
                    Fecha = DateTime.Now,
                    ExistAct = item.IdInventarioNavigation.ExistenciaGeneral + item.Cantidad,
                    ExistAnt = item.IdInventarioNavigation.ExistenciaGeneral,
                    ExistActBod = 0,
                    ExistAntBod = 0,
                    IdBodegaDestino = item.IdBodega,
                    IdBodegaOrigen = item.IdBodega,
                    IdDocumento = domain.Id,
                    IdUsuario = domain.IdUsuario,
                    IdMoneda = domain.IdMoneda,
                    Observaciones = "N/A",
                    PrecioPromedio = 0,
                    PrecioUnit = item.PrecioUnitario,
                    IdInventario = item.IdInventario,
                    TipoDocumento = "CD",
                    SaldoFinal = 0
                };

                kardex.Add(k);

            }



            try
            {
                service.SaveAll(kardex);
                return true;
            }
            catch (Exception)
            {
                return true;
                throw;
            }

        }

        public bool CreateKardexCDSingle(int idCD)
        {
            var item = compraService.GetCompraDetalleById(idCD);


            var k = new TbPrKardex
            {
                CantidadMov = item.Cantidad,
                CostoPromedio = 0,
                CostoMov = item.SubTotalExcentoBase + item.SubTotalGravadoBase,
                Fecha = DateTime.Now,
                ExistAct = 0,
                ExistAnt = 0,
                ExistActBod = 0,
                ExistAntBod = 0,
                IdBodegaDestino = item.IdBodega,
                IdBodegaOrigen = item.IdBodega,
                IdDocumento = item.IdCompraNavigation.Id,
                IdUsuario = item.IdCompraNavigation.IdUsuario,
                IdMoneda = item.IdCompraNavigation.IdMoneda,
                Observaciones = "N/A",
                PrecioPromedio = 0,
                PrecioUnit = item.PrecioUnitario,
                IdInventario = item.IdInventario,
                TipoDocumento = "CD",
                SaldoFinal = 0
            };




            try
            {
                service.Save(k);
                return true;
            }
            catch (Exception)
            {
                return true;
                throw;
            }

        }


        public bool CreateKardexEliminarCD(TbPrCompra domain)
        {
            //var domain = compraService.GetCompraById(idCompra);
            var kardex = new List<TbPrKardex>();


            foreach (var item in domain.TbPrCompraDetalle)
            {

                var k = new TbPrKardex
                {
                    CantidadMov = item.Cantidad * -1,
                    CostoPromedio = 0,
                    CostoMov = item.SubTotalExcentoBase + item.SubTotalGravadoBase,
                    Fecha = DateTime.Now,
                    ExistAct = 0,
                    ExistAnt = 0,
                    ExistActBod = 0,
                    ExistAntBod = 0,
                    IdBodegaDestino = item.IdBodega,
                    IdBodegaOrigen = item.IdBodega,
                    IdDocumento = domain.Id,
                    IdUsuario = domain.IdUsuario,
                    IdMoneda = domain.IdMoneda,
                    Observaciones = "N/A",
                    PrecioPromedio = 0,
                    PrecioUnit = item.PrecioUnitario,
                    IdInventario = item.IdInventario,
                    TipoDocumento = "CD",
                    SaldoFinal = 0
                };

                kardex.Add(k);


            }

            try
            {
                service.SaveAll(kardex);
                return true;
            }
            catch (Exception)
            {
                return true;
                throw;
            }




        }


        public bool CreateKardexEliminarCDSingle(int idCD)
        {
            var item = compraService.GetCompraDetalleById(idCD);
            var kardex = new List<TbPrKardex>();


            var k = new TbPrKardex
            {
                CantidadMov = item.Cantidad * -1,
                CostoPromedio = 0,
                CostoMov = item.SubTotalExcentoBase + item.SubTotalGravadoBase,
                Fecha = DateTime.Now,
                ExistAct = 0,
                ExistAnt = 0,
                ExistActBod = 0,
                ExistAntBod = 0,
                IdBodegaDestino = item.IdBodega,
                IdBodegaOrigen = item.IdBodega,
                IdDocumento = item.IdCompraNavigation.Id,
                IdUsuario = item.IdCompraNavigation.IdUsuario,
                IdMoneda = item.IdCompraNavigation.IdMoneda,
                Observaciones = "N/A",
                PrecioPromedio = 0,
                PrecioUnit = item.PrecioUnitario,
                IdInventario = item.IdInventario,
                TipoDocumento = "CD",
                SaldoFinal = 0
            };

            try
            {
                service.Save(k);
                return true;
            }
            catch (Exception)
            {
                return true;
                throw;
            }




        }


        ///////////////////////////requisiciones
        ///
        public bool CreateKardexRD(IList<TbPrRequisicionDetalle> rq, bool isDeteled)
        {
            var domain = reqService.GetReqById((int)rq.First().IdRequisicion);
            var kardex = new List<TbPrKardex>();
            var cd = new List<TbPrCompraDetalle>();

            double cantidad = 0;
            var tipoDoc = "REQ";

            if (domain.Anulado)
                tipoDoc = "REA";





            foreach (var item in rq)
            {
                cantidad = 0;
                if (isDeteled)              
                    cantidad = item.Cantidad;                   
                else
                    cantidad = item.Cantidad * -1;

                    

                var k = new TbPrKardex
                {
                    CantidadMov = cantidad,
                    CostoPromedio = 0,
                    CostoMov = item.Total,
                    Fecha = DateTime.Now,
                    ExistAct = 0,
                    ExistAnt = 0,
                    ExistActBod = 0,
                    ExistAntBod = 0,
                    IdBodegaDestino = domain.IdBodega,
                    IdBodegaOrigen = domain.IdBodega,
                    IdDocumento = domain.Id,
                    IdUsuario = domain.IdUsuario,
                    IdMoneda = 1,
                    Observaciones = "N/A",
                    PrecioPromedio = 0,
                    PrecioUnit = item.PrecioUnitario,
                    IdInventario = item.IdInventario,
                    TipoDocumento = tipoDoc,
                    SaldoFinal = 0
                };

                kardex.Add(k);

            }



            try
            {
                service.SaveAll(kardex);
                return true;
            }
            catch (Exception)
            {
                return true;
                throw;
            }

        }





    }
}
