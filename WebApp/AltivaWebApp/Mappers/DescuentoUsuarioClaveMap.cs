using AltivaWebApp.Domains;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public class DescuentoUsuarioClaveMap: IDescuentoUsuarioClaveMap
    {
        readonly IDescuentoUsuarioClaveService service;

        public DescuentoUsuarioClaveMap(IDescuentoUsuarioClaveService service)
        {
            this.service = service;
        }

        
        public bool SaveDescuentoUsuarioClave(IList<DescuentoUsuarioClaveViewModel> model)
        {
            return service.Save((ViewModelToDomainDescuentoUsuarioClave(model)));
        }

        public IList<TbFaDescuentoUsuarioClave> ViewModelToDomainDescuentoUsuarioClave(IList<DescuentoUsuarioClaveViewModel> viewModel)
        {

            var domainList = new List<TbFaDescuentoUsuarioClave>();
            foreach (var item in viewModel)
            {
                var domain = new TbFaDescuentoUsuarioClave
                {

                    IdDescuentoUsuario = item.IdDescuentoUsuario,
                    IdRebajaConfig = item.IdRebajaConfig,
                    IdUsuario = item.IdUsuario,
                    MaxDescuento = item.MaxDescuento,
                    Clave = item.Clave,
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
