using AltivaWebApp.Domains;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public class ContactoVisitaMap : IContactoVisitaMap
    {


        IContactoVisitaService service;
        public ContactoVisitaMap(IContactoVisitaService service)
        {
            this.service = service;
        }






        public TbCrContactoVisita Create(ContactoVisitaViewModel viewModel)
        {
            return service.Save(ViewModelToDomainNuevo(viewModel));
        }

        public TbCrContactoVisita Update(ContactoVisitaViewModel viewModel, long id)
        {
            return service.Update(ViewModelToDomainEditar(viewModel, id));
        }
       






        public TbCrContactoVisita ViewModelToDomainNuevo(ContactoVisitaViewModel viewModel)
        {
            var domain = new TbCrContactoVisita
            {
                IdContactoVisita = viewModel.IdContactoVisita,
                IdContacto = viewModel.IdContacto,
                IdUsuarioCreacion = viewModel.IdUsuarioCreacion,
                IdUsuarioModificacion = viewModel.IdUsuarioModificacion,
                IdVisitaTipo = viewModel.IdVisitaTipo, //relacion
                FechaCreacion = viewModel.FechaCreacion,
                FechaModificacion = viewModel.FechaModificacion,
                Observacion = viewModel.Observacion,
                Foto = viewModel.Foto,
                Estado = viewModel.Estado
            };
            return domain;
        }




        public TbCrContactoVisita ViewModelToDomainEditar(ContactoVisitaViewModel viewModel, long id)
        {
            var ContactoVisita = service.GetContactoVisitaById((long)viewModel.IdContactoVisita);
          //var domain = service.GetContactoVisitaById(id);

            ContactoVisita.IdContacto = viewModel.IdContacto;
            // ContactoVisita.IdUsuarioCreacion = viewModel.IdUsuarioCreacion;
            ContactoVisita.IdUsuarioModificacion = viewModel.IdUsuarioModificacion;
            // ContactoVisita.FechaCreacion = viewModel.FechaCreacion;
            ContactoVisita.FechaModificacion = viewModel.FechaModificacion;
            ContactoVisita.Observacion = viewModel.Observacion;
            ContactoVisita.Foto = viewModel.Foto;
            // ContactoVisita.Estado = viewModel.Estado;

            return ContactoVisita;
        }




        public ContactoVisitaViewModel DomainToViewModel(TbCrContactoVisita domain)
        {
            return new ContactoVisitaViewModel
            {
                //VisitaTipoDetalle = AIDomainToViewModel(domain.TbCrVisitaTipo),
                IdContactoVisita = domain.IdContactoVisita,
                IdContacto = domain.IdContacto,
                IdUsuarioCreacion = domain.IdUsuarioCreacion,
                IdUsuarioModificacion = domain.IdUsuarioModificacion,
                FechaCreacion = domain.FechaCreacion,
                FechaModificacion = domain.FechaModificacion,
                Observacion = domain.Observacion,
                Foto = domain.Foto,
                Estado = domain.Estado
            };

        }





    }
}
