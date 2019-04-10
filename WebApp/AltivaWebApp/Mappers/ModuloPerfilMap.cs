using AltivaWebApp.Domains;
using AltivaWebApp.GEDomain;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public class ModuloPerfilMap : IModuloPerfilMap
    {
        IModuloPerfilService mpService;

        public ModuloPerfilMap(IModuloPerfilService mpService)
        {
            this.mpService = mpService;
        }


        public IList<TbSePerfilModulo> Create(IList<MPNuevoViewModel> viewModel)
        {
            var domain = new List<TbSePerfilModulo>();

            foreach (var item in viewModel)
            {
                domain.Add(ViewToDomain(item));
            }
            return mpService.Create(domain);
        }

        public TbSePerfilModulo Update(MPEditarViewModel viewModel)
        {
            var pm = mpService.GetById(viewModel.Id);

            /*var model = new TbSePerfilModulo
            {
                Id = pm.Id,
                IdPerfil = pm.IdPerfil,
                IdModulo = pm.IdModulo
            };*/

            switch (viewModel.Accion)
            {
                case "ejecutar":
                    pm.Ejecutar = viewModel.Estado;
                    break;
                case "actualizar":
                    pm.Actualizar = viewModel.Estado;
                    break;
                case "imprimir":
                    pm.Imprimir = viewModel.Estado;
                    break;
                case "insertar":
                    pm.Insertar = viewModel.Estado;
                    break;
                case "eliminar":
                    pm.Eliminar = viewModel.Estado;
                    break;
                case "opcion1":
                    pm.Opcion1 = viewModel.Estado;
                    break;
                case "opcion2":
                    pm.Opcion2 = viewModel.Estado;
                    break;
                default:
                    break;
            }

            return mpService.Update(pm);
        }

        public bool Delete(IList<int> id)
        {

            var mps = mpService.GetAll();
            var mpToDelete = new List<TbSePerfilModulo>();

            foreach (var item in mps)
            {
                for (int i = 0; i < id.Count(); i++)
                {
                    if(item.Id == id[i])
                    {
                        mpToDelete.Add(item);
                    }
                }
                
            }
            //var pm = mpService.GetById(mpToDelete);
            return mpService.Delete(mpToDelete);

           

        }

        public TbSePerfilModulo ViewToDomain(MPNuevoViewModel viewModel)
        {
            var domain = new TbSePerfilModulo
            {
                IdModulo = viewModel.IdModulo,
                IdPerfil = viewModel.IdPerfil,
                Actualizar = true,
                Ejecutar = true,
                Eliminar = true,
                Imprimir = true,
                Insertar = true,
                Opcion1 = true,
                Opcion2 = true
            };

            return domain;
        }

    }
}
