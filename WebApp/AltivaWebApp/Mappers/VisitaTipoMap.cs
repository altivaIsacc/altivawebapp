using AltivaWebApp.Domains;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public class VisitaTipoMap : IVisitaTipoMap
    {

        IVisitaTipoService service;
        public VisitaTipoMap(IVisitaTipoService service)
        {
            this.service = service;
        }







        public TbCrVisitaTipo Create(VisitaTipoViewModel viewModel)
        {
            return service.Save(ViewModelToDomainNuevo(viewModel));
        }


        public TbCrVisitaTipo Update(VisitaTipoViewModel viewModel, int id)
        {
            return service.Update(ViewModelToDomainEditar(viewModel, id));
        }






        public TbCrVisitaTipo ViewModelToDomainNuevo(VisitaTipoViewModel viewModel)
        {
            var domain = new TbCrVisitaTipo
            {
                IdVisitaTipo = viewModel.IdVisitaTipo,            
                IdUsuarioCreacion = viewModel.IdUsuarioCreacion,
                IdUsuarioModificacion = viewModel.IdUsuarioModificacion,            
                FechaCreacion = viewModel.FechaCreacion,
                FechaModificacion = viewModel.FechaModificacion,
                Nombre = viewModel.Nombre,
                Observacion = viewModel.Observacion,
                Estado = viewModel.Estado
            };
            return domain;
        }


        public TbCrVisitaTipo ViewModelToDomainEditar(VisitaTipoViewModel viewModel, int id)
        {
            var visitaTipo = service.GetVisitaTipoById((int)viewModel.IdVisitaTipo);
          //var domain = service.GetVisitaTipoById(id);

                //visitaTipo.IdVisitaTipo = viewModel.IdVisitaTipo;
                //visitaTipo.IdUsuarioCreacion = viewModel.IdUsuarioCreacion;
            visitaTipo.IdUsuarioModificacion = viewModel.IdUsuarioModificacion;
                //visitaTipo.FechaCreacion = viewModel.FechaCreacion;
            visitaTipo.FechaModificacion= viewModel.FechaModificacion;
            visitaTipo.Nombre = viewModel.Nombre;
            visitaTipo.Observacion = viewModel.Observacion;
               //visitaTipo.Estado = viewModel.Estado;
            return visitaTipo;
        }


        public VisitaTipoViewModel DomainToViewModel(TbCrVisitaTipo domain)
        {
            return new VisitaTipoViewModel
            {           
                IdVisitaTipo = domain.IdVisitaTipo,
                IdUsuarioCreacion = domain.IdUsuarioCreacion,
                IdUsuarioModificacion = domain.IdUsuarioModificacion,
                FechaCreacion = domain.FechaCreacion,
                FechaModificacion = domain.FechaModificacion,
                Nombre = domain.Nombre,
                Estado = domain.Estado
              
            };
        }



    }
}
