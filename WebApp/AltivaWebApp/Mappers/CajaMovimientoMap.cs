using AltivaWebApp.Domains;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public class CajaMovimientoMap: ICajaMovimientoMap
    {
        private readonly ICajaMovimientoService service;
        private readonly IFlujoCategoriaService flujoService;
        private readonly ICajaService cajaService;
        public CajaMovimientoMap(ICajaMovimientoService service, IFlujoCategoriaService flujoService, ICajaService cajaService)
        {
            this.service = service;
            this.flujoService = flujoService;
            this.cajaService = cajaService;
        }

        public IList<TbFaCajaMovimiento> CreateCajaMovimiento(IList<CajaMovimientoViewModel> viewModel, long idMovimiento)
        {
            int _bancaria = 1;
            int _deposito = 1;

            var cajaMov = new List<TbFaCajaMovimiento>();
            var flujo = new List<TbBaFlujo>();
            foreach (var item in viewModel)
            {
                cajaMov.Add(new TbFaCajaMovimiento {
                    CompraDolarTc = item.CompraDolarTc,
                    CompraEuroTc = item.CompraEuroTc,
                    Estado = item.Estado,
                    FechaCreacion = DateTime.Now,
                    IdCaja = item.IdCaja,
                    IdCategoriaFlujo = item.IdCategoriaFlujo,
                    IdMoneda = item.IdMoneda,
                    IdMovimiento = idMovimiento,
                    IdTipoCajaMovimiento = item.IdTipoCajaMovimiento,
                    MontoBase = item.MontoBase,
                    MontoDolar = item.MontoDolar,
                    MontoEuro = item.MontoEuro,
                    VentaDolarTc = item.VentaDolarTc,
                    VentaEuroTc = item.VentaEuroTc,
                    TbFaCajaMovimientoTarjeta = item.CajaMovTarjeta != null ? ViewModelToDomainTarjeta(item.CajaMovTarjeta) : null,
                    TbFaCajaMovimientoCheque = item.CajaMovCheque != null ? ViewModelToDomainCheque(item.CajaMovCheque,(int) item.IdCategoriaFlujo) : null
                });

                if(item.tipoCategoriaFlujo == _bancaria && item.CajaMovCheque == null)
                {
                    flujo.Add(new TbBaFlujo {
                        Debito = false,
                        Documento = Convert.ToInt64(item.DocumentoTransferencia),
                        Estado = 1,
                        Fecha = item.FechaTransferencia,
                        FechaCreacion = DateTime.Now,
                        FechaUltimaMod = DateTime.Now,
                        IdCategoriaFlujo = item.IdCategoriaFlujo,
                        IdFlujo = 0,
                        IdTipo = _deposito,
                        IdUsuario = (int) cajaService.GetCajaById((int)item.IdCaja).IdUsuario,
                        Monto = item.IdMoneda == 1 ? item.MontoBase : item.IdMoneda == 2 ? item.MontoDolar : item.MontoEuro
                    });
                }
            }

            flujoService.SaveFlujo(flujo);

            return service.SaveRange(cajaMov);
        }

        public IList<TbFaCajaMovimientoTarjeta> ViewModelToDomainTarjeta(CajaMovimientoTarjetaViewModel viewModel)
        {
            IList<TbFaCajaMovimientoTarjeta> movList = new List<TbFaCajaMovimientoTarjeta>();

            movList.Add(new TbFaCajaMovimientoTarjeta
            {
                Autorizacion = viewModel.Autorizacion,
                IdCajaMovimiento = viewModel.IdCajaMovimiento,
                Voucher = viewModel.Voucher,
                IdCajaMovimientoTarjeta = viewModel.IdCajaMovimeintoTarjeta
            });

            return movList;
        }
        public IList<TbFaCajaMovimientoCheque> ViewModelToDomainCheque(CajaMovimientoChequeViewModel viewModel, int idFlujoCat)
        {
            IList<TbFaCajaMovimientoCheque> movList = new List<TbFaCajaMovimientoCheque>();

            movList.Add(new TbFaCajaMovimientoCheque
            {
                IdCajaMovimiento = viewModel.IdCajaMovimiento,
                IdCajaMovimientoCheque = viewModel.IdCajaMovimientoCheque,
                Banco = flujoService.GetFlujoCategoriaById(idFlujoCat).Nombre,
                Fecha = viewModel.Fecha,
                Nota = viewModel.Nota ?? "",
                Numero = viewModel.Numero ,
                Portador = viewModel.Portador ?? ""
            });

            return movList;
        }
    }
}
