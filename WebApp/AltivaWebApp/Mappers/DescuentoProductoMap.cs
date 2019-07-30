using AltivaWebApp.Domains;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public class DescuentoProductoMap
    {

        readonly IDescuentoProductoService service;

        public DescuentoProductoMap(IDescuentoProductoService service)
        {
            this.service = service;
        }

        public bool SaveDescuentoUsuario(IList<DescuentoProductoViewModel> model)
        {
            return service.Save((ViewModelToDomainDescuentoUsuario(model)));
        }

        public IList<TbFaDescuentoProducto> ViewModelToDomainDescuentoUsuario(IList<DescuentoProductoViewModel> viewModel)
        {

            var domainList = new List<TbFaDescuentoProducto>();
            foreach (var item in viewModel)
            {
                var domain = new TbFaDescuentoProducto
                {

                   IdDescuentoProducto = item.IdDescuentoProducto,
                   IdProducto = item.IdProducto,
                   Porcentaje = item.Porcentaje,
                   Tipo = item.Tipo
                };
                domainList.Add(domain);
            }
            return domainList;

        }
    }
}
