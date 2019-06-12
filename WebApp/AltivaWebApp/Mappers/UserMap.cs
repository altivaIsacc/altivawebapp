
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;
using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
using AltivaWebApp.Services;
using AltivaWebApp.GEDomain;
using Microsoft.AspNetCore.Hosting;

namespace AltivaWebApp.Mappers
{
    public class UserMap : IUserMap

    {

        IUserService userService;
        private readonly IHostingEnvironment hostingEnvironment;

        public UserMap(IUserService service, IHostingEnvironment hostingEnvironment)

        {

            userService = service;
            this.hostingEnvironment = hostingEnvironment;
        }

        public UsuarioViewModel Create(UsuarioViewModel viewModel)
        {

            var user = ViewModelToDomainNuevo(viewModel);

            return DomainToViewModelSingle(userService.Create(user));

        }

        public bool CreatePU(IList<PerfilUsuarioViewModel> model)
        {            
            return userService.CreatePerfilUsuario(ViewModelToDomainPU(model));
        }

        public TbSeUsuario Update(UsuarioViewModel viewModel)

        {
 
            var user = ViewModelToDomainEditar(viewModel);

            return userService.UpdateUsuario(user);


        }

        public void Delete(TbSeUsuario domain)

        {

            userService.Delete(domain);

        }

        public IList<UsuarioViewModel> GetAll()

        {

            return DomainToViewModel(userService.GetAll());

        }

        public UsuarioViewModel DomainToViewModelSingle(TbSeUsuario domain)

        {
            
            UsuarioViewModel model = new UsuarioViewModel
            {
                id =(int) domain.Id,         
                codigo = domain.Codigo,
                nombre = domain.Nombre,
                estado = domain.Estado,
                iniciales = domain.Iniciales,
                contrasena = domain.Contrasena,
                correo = domain.Correo,
                avatar = domain.Avatar
            };

            return model;

        }

        public IList<UsuarioViewModel> DomainToViewModel(IList<TbSeUsuario> domain)

        {

            IList<UsuarioViewModel> model = new List<UsuarioViewModel>();

            foreach (TbSeUsuario of in domain)

            {
                model.Add(DomainToViewModelSingle(of));
            }

            return model;

        }

        public TbSeUsuario ViewModelToDomainEditar(UsuarioViewModel officeViewModel)
        {

            var domain = userService.GetSingleUser(officeViewModel.id);
            domain.Codigo = officeViewModel.codigo;
            domain.Nombre = officeViewModel.nombre;
            domain.Estado = officeViewModel.estado;
            domain.Iniciales = officeViewModel.iniciales;
            if(officeViewModel.contrasena != null || officeViewModel.contrasena != "")
                domain.Contrasena = officeViewModel.contrasena;
            domain.Correo = officeViewModel.correo;
        


            if (officeViewModel.Foto != null && domain.Avatar != null)
            {
                var savePath = System.IO.Path.Combine(hostingEnvironment.WebRootPath, "uploads");

                domain.Avatar = FotosService.SubirFotoUsuarios1(officeViewModel.Foto, savePath);
            }

            return domain;

        }

        public IList<TbSePerfilUsuario> ViewModelToDomainPU(IList<PerfilUsuarioViewModel> model)
        {
            var domainList = new List<TbSePerfilUsuario>();

            foreach (var item in model)
            {
                var domain = new TbSePerfilUsuario
                {
                    IdPerfil = item.IdPerfil,
                    IdUsuario = item.IdUsuario
                };

                domainList.Add(domain);
            }


            return domainList;
        }

        public TbSeUsuario ViewModelToDomainNuevo(UsuarioViewModel officeViewModel)

        {

            //var domain = userService.GetUsuarioConPerfiles(officeViewModel.codigo);

            //if (domain != null)
            //{
            //    return null;
            //}
            var savePath = System.IO.Path.Combine(hostingEnvironment.WebRootPath, "uploads");

            var nuevoDomain = new TbSeUsuario
            {
                Nombre = officeViewModel.nombre,
                Codigo = officeViewModel.codigo,
                Correo = officeViewModel.correo,
                Contrasena = officeViewModel.contrasena,
                Estado = officeViewModel.estado,
                Iniciales = officeViewModel.iniciales,
                FechaMod = DateTime.Now,
                IdUsuario = officeViewModel.Id_Usuario,
                Avatar = FotosService.SubirFotoUsuarios1(officeViewModel.Foto, savePath)
            };

            
            return nuevoDomain;

        }


    }
}
