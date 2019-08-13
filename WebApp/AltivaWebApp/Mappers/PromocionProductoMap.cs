using AltivaWebApp.Domains;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public class PromocionProductoMap: IPromocionProductoMap
    {

        readonly IPromocionProductoService service;

        public PromocionProductoMap(IPromocionProductoService service)
        {
            this.service = service;
        }

        public bool SavePromocionProducto(IList<PromocionProductoViewModel> model)
        {
            return service.Save((ViewModelToDomainPromocionProducto(model)));
        }

        public IList<TbFaPromocionProducto> ViewModelToDomainPromocionProducto(IList<PromocionProductoViewModel> viewModel)
        {

            var domainList = new List<TbFaPromocionProducto>();
            foreach (var item in viewModel)
            {
                var domain = new TbFaPromocionProducto
                {
                    IdPromocionProducto = item.IdPromocionProducto,
                    IdRebajaConfig = item.IdRebajaConfig,
                    ConClaveAutorizacion = item.ConClaveAutorizacion,
                    Clave = item.Clave,
                    VentaCliente = item.VentaCliente,
                    IdCliente = item.IdCliente,
                    EntreFechas = item.EntreFechas,
                    FechaDesde = item.FechaDesde,
                    FechaHasta = item.FechaHasta,
                    Nota = item.Nota,
                    FamiliaCliente = item.FamiliaCliente,
                    IdFamiliaCliente = item.IdFamiliaCliente,
                    EsTipo1 = item.EsTipo1,
                    CantTipo1Ref =item.CantTipo1Ref,
                    IdTipoInventarioRef = item.IdTipoInventarioRef,
                    CantTipo1Promo = item.CantTipo1Promo,
                    IdTipo1InventarioPromo = item.IdTipo1InventarioPromo,
                    PorcTipo1DescuentoPromo = item.PorcTipo1DescuentoPromo,
                    EsTipo2 = item.EsTipo2,
                    CantTipo2Ref = item.CantTipo2Ref,
                    IdTipo2Inventario = item.IdTipo2Inventario,
                    PorcTipo2Descuento = item.PorcTipo2Descuento,
                    FamiliaProveedor = item.FamiliaProveedor,
                    IdProveedor = item.IdProveedor
                    
                };
                domainList.Add(domain);
            }
            return domainList;

        }
    }
}
