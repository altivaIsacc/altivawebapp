using AltivaWebApp.Domains;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public class DescuentoUsuarioMap: IDescuentoUsuarioMap
    {
        readonly IDescuentoUsuarioService service;

        public DescuentoUsuarioMap(IDescuentoUsuarioService service)
        {
            this.service = service;
        }

        public bool SaveDescuentoUsuario(IList<DescuentoUsuarioViewModel> model)
        {
            return service.Save((ViewModelToDomainDescuentoUsuario(model)));
        }

        public IList<TbFaDescuentoUsuario> ViewModelToDomainDescuentoUsuario(IList<DescuentoUsuarioViewModel> viewModel)
        {

            var domainList = new List<TbFaDescuentoUsuario>();
            foreach (var item in viewModel)
            {
                var domain = new TbFaDescuentoUsuario
                {

                    IdDescuentoUsuario = item.IdDescuentoUsuario,
                    IdRebajaConfig = item.IdRebajaConfig,
                    IdUsuario = item.IdUsuario,
                    MaxDescuento = item.MaxDescuento,
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
