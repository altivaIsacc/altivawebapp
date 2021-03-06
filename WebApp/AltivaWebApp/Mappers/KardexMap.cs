﻿using AltivaWebApp.Domains;
using AltivaWebApp.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        private readonly ITrasladoService trService;
        public KardexMap(ITrasladoService trService, IRequisicionService reqService, ICompraService compraService, IKardexService service, IAjusteService ajusteService)
        {
            this.service = service;
            this.ajusteService = ajusteService;
            this.compraService = compraService;
            this.reqService = reqService;
            this.trService = trService;
        }

        public bool CreateKardexAM(TbPrAjuste domain, int idAjuste)
        {
            var flag = true;
            //var domain = ajusteService.GetAjusteById(idAjuste);
            var kardex = new List<TbPrKardex>();

            /////averiguar que hacer si se eliminar una linea, restar si es entrada y sumar si es salida
            ///debe procesar la linea eliminada y despues guardar el kardex


            foreach (var item in domain.TbPrAjusteInventario)
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
                    existencia = item.IdInventarioNavigation.ExistenciaGeneral + item.Cantidad; //domain.TbPrAjusteInventario.FirstOrDefault(i => i.Movimiento == true && i.IdInventario == item.IdInventario).Cantidad;
                    existenciaB = item.IdInventarioNavigation.TbPrInventarioBodega.FirstOrDefault(i => i.IdBodega == domain.IdBodega).ExistenciaBodega + item.Cantidad; //domain.TbPrAjusteInventario.FirstOrDefault(i => i.Movimiento == true && i.IdInventario == item.IdInventario).Cantidad;
                    k.CantidadMov = item.Cantidad;
                }
                else
                {
                    existencia = item.IdInventarioNavigation.ExistenciaGeneral - item.Cantidad;//domain.TbPrAjusteInventario.FirstOrDefault(i => i.Movimiento == false && i.IdInventario == item.IdInventario).Cantidad;
                    existenciaB = item.IdInventarioNavigation.TbPrInventarioBodega.FirstOrDefault(i => i.IdBodega == domain.IdBodega).ExistenciaBodega - item.Cantidad;//domain.TbPrAjusteInventario.FirstOrDefault(i => i.Movimiento == false && i.IdInventario == item.IdInventario).Cantidad;
                    k.CantidadMov = item.Cantidad * -1;
                }

                if (existencia < 0 || existenciaB < 0)
                {
                    flag = false;
                    break;
                }


                k.CostoMov = item.TotalMovimiento;
                k.CostoPromedio = item.CostoPromedio;
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
                k.PrecioPromedio = 0;//item.CostoPromedio;
                k.PrecioUnit = item.CostoPromedio;
                k.SaldoFinal = item.CostoPromedio * existenciaB;
                k.TipoDocumento = "AM";


                kardex.Add(k);



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
                k.PrecioUnit = item.CostoPromedio;
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
                    PrecioUnit = item.PrecioUnitarioBase,
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
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
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
                PrecioUnit = item.PrecioUnitarioBase,
                IdInventario = item.IdInventario,
                TipoDocumento = "CD",
                SaldoFinal = 0
            };




            try
            {
                service.Save(k);
                return true;
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
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

                var existAntBod = item.IdInventarioNavigation.TbPrInventarioBodega.FirstOrDefault(i => i.IdBodega == item.IdBodega).ExistenciaBodega;
                var existActBod = existAntBod - item.Cantidad;
                if (existActBod < 0)
                {
                    return false;
                }

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
                    PrecioUnit = item.PrecioUnitarioBase,
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
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                return true;
                throw;
            }




        }


        public bool CreateKardexEliminarCDSingle(int idCD)
        {
            var item = compraService.GetCompraDetalleById(idCD);
            var kardex = new List<TbPrKardex>();

            var existAntBod = item.IdInventarioNavigation.TbPrInventarioBodega.FirstOrDefault(i => i.IdBodega == item.IdBodega).ExistenciaBodega;
            var existActBod = existAntBod - item.Cantidad;
            if (existActBod < 0)
            {
                return false;
            }


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
                PrecioUnit = item.PrecioUnitarioBase,
                IdInventario = item.IdInventario,
                TipoDocumento = "CD",
                SaldoFinal = 0
            };

            try
            {
                service.Save(k);
                return true;
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                return true;
                throw;
            }




        }


        ///////////////////////////requisiciones
        ///
        public bool CreateKardexRD(IList<TbPrRequisicionDetalle> rq, bool isDeteled)
        {
            if (rq.Count() == 0 || rq == null)
                return false;

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
                    Observaciones = domain.Descripcion,
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
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                return true;
                throw;
            }

        }


        ///////////////////////////traslado
       
        public bool CreateKardexTRI(TbPrTraslado cambios, TbPrTraslado original, IList<long> eliminados)
        {
            if (cambios.TbPrTrasladoInventario.Count() == 0 || cambios == null)
                return false;

          
            
            var kardex = new List<TbPrKardex>();

            foreach (var item in cambios.TbPrTrasladoInventario)
            {

                //agrega la entrada
                var kOrigen = new TbPrKardex
                {
                    IdInventario = item.IdInventario,
                    IdDocumento = cambios.IdTraslado,
                    TipoDocumento = "TRE",
                    Fecha = DateTime.Now,
                    ExistAnt = 0,
                    CantidadMov = 0,
                    ExistAct = 0,
                    PrecioUnit = item.PrecioUnitario,
                    CostoMov = 0,
                    IdMoneda = 1,
                    IdBodegaOrigen = cambios.IdBodegaOrigen,
                    IdBodegaDestino = cambios.IdBodegaDestino,
                   
                    ExistAntBod = 0,
                    ExistActBod = 0,
                    Observaciones = cambios.Comentario,
                    CostoPromedio = 0,
                    SaldoFinal = 0,
                    PrecioPromedio = 0,
                    IdUsuario = cambios.IdUsuario
                };
                var kDestino = new TbPrKardex
                {
                    IdInventario = item.IdInventario,
                    IdDocumento = cambios.IdTraslado,
                    TipoDocumento = "TRS",
                    Fecha = DateTime.Now,
                    ExistAnt = 0,
                    CantidadMov = 0,// true d +2
                    ExistAct = 0,
                    PrecioUnit = item.PrecioUnitario,
                    CostoMov = 0,
                    IdMoneda = 1,
                    IdBodegaOrigen = cambios.IdBodegaDestino,
                    IdBodegaDestino = cambios.IdBodegaOrigen,
                    ExistAntBod = 0,
                    ExistActBod = 0,
                    Observaciones = cambios.Comentario,
                    CostoPromedio = 0,
                    SaldoFinal = 0,
                    PrecioPromedio = 0,
                    IdUsuario = cambios.IdUsuario
                };

               
                bool isDeleted = eliminados.Contains(item.Id);
                if (cambios.Anulado == true) { //anulo
                    kOrigen.CantidadMov = item.Cantidad;
                    kDestino.CantidadMov = item.Cantidad * -1;
                    kardex.Add(kDestino);
                    kardex.Add(kOrigen);
                }
                else {

                    if (item.Id <= 0 || original == null) //inserto
                    {
                        kOrigen.CantidadMov = item.Cantidad * -1;
                        kDestino.CantidadMov = item.Cantidad;
                        kardex.Add(kDestino);
                        kardex.Add(kOrigen);
                    }
                    else
                    {
                        if (isDeleted)
                        {
                            kOrigen.CantidadMov = item.Cantidad;
                            kDestino.CantidadMov = item.Cantidad * -1;
                            kardex.Add(kDestino);
                            kardex.Add(kOrigen);
                        }
                        else
                        {
                            var lineaVieja = original.TbPrTrasladoInventario.FirstOrDefault(a => a.Id == item.Id);

                            if (lineaVieja.CostoTotal != item.CostoTotal || lineaVieja.Cantidad != item.Cantidad)
                            {
                                kOrigen.CantidadMov = lineaVieja.Cantidad;
                                kOrigen.PrecioUnit = lineaVieja.PrecioUnitario;
                                kDestino.CantidadMov = lineaVieja.Cantidad * -1;
                                kardex.Add(kDestino);
                                kardex.Add(kOrigen);

                                var kOrigenN = new TbPrKardex
                                {
                                    IdInventario = item.IdInventario,
                                    IdDocumento = cambios.IdTraslado,
                                    TipoDocumento = "TRE",
                                    Fecha = DateTime.Now,
                                    ExistAnt = 0,
                                    CantidadMov = item.Cantidad*-1,
                                    ExistAct = 0,
                                    PrecioUnit = item.PrecioUnitario,
                                    CostoMov = 0,
                                    IdMoneda = 1,
                                    IdBodegaOrigen = cambios.IdBodegaOrigen,
                                    IdBodegaDestino = cambios.IdBodegaDestino,

                                    ExistAntBod = 0,
                                    ExistActBod = 0,
                                    Observaciones = cambios.Comentario,
                                    CostoPromedio = 0,
                                    SaldoFinal = 0,
                                    PrecioPromedio = 0,
                                    IdUsuario = cambios.IdUsuario
                                };
                                var kDestinoN = new TbPrKardex
                                {
                                    IdInventario = item.IdInventario,
                                    IdDocumento = cambios.IdTraslado,
                                    TipoDocumento = "TRS",
                                    Fecha = DateTime.Now,
                                    ExistAnt = 0,
                                    CantidadMov = item.Cantidad,// true d +2
                                    ExistAct = 0,
                                    PrecioUnit = item.PrecioUnitario,
                                    CostoMov = 0,
                                    IdMoneda = 1,
                                    IdBodegaOrigen = cambios.IdBodegaDestino,
                                    IdBodegaDestino = cambios.IdBodegaOrigen,
                                    ExistAntBod = 0,
                                    ExistActBod = 0,
                                    Observaciones = cambios.Comentario,
                                    CostoPromedio = 0,
                                    SaldoFinal = 0,
                                    PrecioPromedio = 0,
                                    IdUsuario = cambios.IdUsuario
                                };
                            
                                kardex.Add(kDestinoN);
                                kardex.Add(kOrigenN);

                            }
                           
                        }
                    }
                }              

            }
            if (original != null) {
                foreach (var item in original.TbPrTrasladoInventario)
                {
                    bool isDeleted = eliminados.Contains(item.Id);
                    if (isDeleted)
                    {


                        //agrega la entrada
                        var kOrigen = new TbPrKardex
                        {
                            IdInventario = item.IdInventario,
                            IdDocumento = cambios.IdTraslado,
                            TipoDocumento = "TRE",
                            Fecha = DateTime.Now,
                            ExistAnt = 0,
                            CantidadMov = 0,
                            ExistAct = 0,
                            PrecioUnit = item.PrecioUnitario,
                            CostoMov = 0,
                            IdMoneda = 1,
                            IdBodegaOrigen = cambios.IdBodegaOrigen,
                            IdBodegaDestino = cambios.IdBodegaDestino,

                            ExistAntBod = 0,
                            ExistActBod = 0,
                            Observaciones = cambios.Comentario,
                            CostoPromedio = 0,
                            SaldoFinal = 0,
                            PrecioPromedio = 0,
                            IdUsuario = cambios.IdUsuario
                        };
                        var kDestino = new TbPrKardex
                        {
                            IdInventario = item.IdInventario,
                            IdDocumento = cambios.IdTraslado,
                            TipoDocumento = "TRS",
                            Fecha = DateTime.Now,
                            ExistAnt = 0,
                            CantidadMov = 0,// true d +2
                            ExistAct = 0,
                            PrecioUnit = item.PrecioUnitario,
                            CostoMov = 0,
                            IdMoneda = 1,
                            IdBodegaOrigen = cambios.IdBodegaDestino,
                            IdBodegaDestino = cambios.IdBodegaOrigen,
                            ExistAntBod = 0,
                            ExistActBod = 0,
                            Observaciones = cambios.Comentario,
                            CostoPromedio = 0,
                            SaldoFinal = 0,
                            PrecioPromedio = 0,
                            IdUsuario = cambios.IdUsuario
                        };
                        kOrigen.CantidadMov = item.Cantidad;
                        kDestino.CantidadMov = item.Cantidad * -1;
                        kardex.Add(kDestino);
                        kardex.Add(kOrigen);
                    }

                }

            }
          

                try
            {
                service.SaveAll(kardex);
                return true;
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
              
                throw;
            }

        }


    }
}
