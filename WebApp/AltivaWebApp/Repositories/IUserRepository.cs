﻿using AltivaWebApp.GEDomain;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace AltivaWebApp.Repositories
{
    public interface IUserRepository
    {
        TbSeUsuario Save(TbSeUsuario domain);
        TbSeUsuario Update(TbSeUsuario domain);
        bool Delete(TbSeUsuario damain);
        IList<TbSeUsuario> GetAll();
        IList<TbSeUsuario> GetAllByIdUsuario(int id);
        TbSeUsuario GetUsuarioById(int id);

        TbSeUsuario GetUsuarioConConfig(string usuario);

        TbSeUsuario GetUsuarioConEmpresas(string usuario);
        TbSeUsuario GetUsuarioConPerfiles(string usuario);
        IEnumerable<TbSePerfil> GetPerfiles(int id);
        TbSeUsuario GetUsuarioConPerfilesById(int id);
        bool CreatePerfilUsuario(IList<TbSePerfilUsuario> domain);
        bool DeletePU(TbSePerfilUsuario model);
        TbSePerfilUsuario GetPerfilUsuario(PerfilUsuarioViewModel model);
        TbSeUsuarioConfiguraion CreateOrUpdateConfiguracion(TbSeUsuarioConfiguraion domain);
        TbSeEmpresaUsuario CreateEmpresaUsuarioRel(TbSeEmpresaUsuario domain);
        IList<TbSeUsuario> GetAllByIdEmpresa(int idEmpresa);
        IList<TbSeUsuario> GetAllByIdEmpresaConPerfiles(int idEmpresa);

        bool ExisteUsuarioPorCodigo(string codigo);
        bool ExisteUsuarioPorCorreo(string correo);
        IList<TbSeUsuario> GetAllConEmpresas();
        bool CrearRelEmpresaUsuario(IList<TbSeEmpresaUsuario> domain);
        bool DesactivarRelEmpresaUsuario(IList<TbSeEmpresaUsuario> domain);
        IList<TbGeEmpresa> GetEmpresasPorUsuario(int idUsuario);
         IList<TbSePerfilModulo> GetAllPerfilModulo();
        IList<TbSePerfilUsuario> GetAllPerfilUsuario();

    }
}
