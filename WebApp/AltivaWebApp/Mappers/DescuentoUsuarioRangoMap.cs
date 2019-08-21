using AltivaWebApp.Domains;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public class DescuentoUsuarioRangoMap: IDescuentoUsuarioRangoMap
    {
        readonly IDescuentoUsuarioRangoService service;

        public DescuentoUsuarioRangoMap(IDescuentoUsuarioRangoService service)
        {
            this.service = service;
        }

        public bool SaveDescuentoUsuarioRango(IList<DescuentoUsuarioRangoViewModel> model)
        {
            return service.Save((ViewModelToDomainDescuentoUsuarioRango(model)));
        }

        public IList<TbFaDescuentoUsuarioRango> ViewModelToDomainDescuentoUsuarioRango(IList<DescuentoUsuarioRangoViewModel> viewModel)
        {

            var domainList = new List<TbFaDescuentoUsuarioRango>();
            foreach (var item in viewModel)
            {
                var domain = new TbFaDescuentoUsuarioRango
                {

                    IdDescuentoUsuarioRango = item.IdDescuentoUsuarioRango,
                    IdRebajaConfig = item.IdRebajaConfig,
                    IdUsuario = item.IdUsuario,
                    MaxDescuento = item.MaxDescuento,
                    FechaDesde = item.FechaDesde,
                    FechaHasta = item.FechaHasta,
                    FechaCreacion = DateTime.Now,
                    IdUsuarioCreador = item.IdUsuarioCreador,
                    Nota = item.Nota
                };
                domainList.Add(domain);
            }
            return domainList;

        }
    }
}
