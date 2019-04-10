using AltivaWebApp.GEDomain;
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
        IList<TbSeUsuario> GetAllById(int id);
        IList<TbSeUsuario> GetAllByIdUsuario(int id);
        TbSeUsuario GetUsuarioById(int id);
        TbSeUsuario GetUsuarioConEmpresas(string usuario);
        TbSeUsuario GetUsuarioConPerfiles(string usuario);
        IEnumerable<TbSePerfil> GetPerfiles(int id);
        bool CreatePerfilUsuario(IList<TbSePerfilUsuario> domain);
        bool DeletePU(TbSePerfilUsuario model);
        TbSePerfilUsuario GetPerfilUsuario(PerfilUsuarioViewModel model);
        TbSeUsuarioConfiguraion CreateOrUpdateConfiguracion(TbSeUsuarioConfiguraion domain);
        TbSeEmpresaUsuario CreateEmpresaUsuarioRel(TbSeEmpresaUsuario domain);
        IList<TbSeUsuario> GetAllByIdEmpresa(int idEmpresa);
        bool ExisteUsuarioPorCodigo(string codigo);
        bool ExisteUsuarioPorCorreo(string correo);

    }
}
