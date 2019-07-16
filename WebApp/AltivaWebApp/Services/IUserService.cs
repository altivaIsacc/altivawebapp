using System.Collections.Generic;
using System.Threading.Tasks;
using AltivaWebApp.GEDomain;
using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;

namespace AltivaWebApp.Services
{
    public interface IUserService
    {
        IList<TbSeUsuario> GetAllById(int id);
        TbSeUsuario GetUsuarioConPerfilesById(int id);
        TbSeUsuario Create(TbSeUsuario domain);
        TbSeUsuario UpdateUsuario(TbSeUsuario domain);
        void Delete(TbSeUsuario domain);
        IList<TbSeUsuario> GetAll();
        TbSeUsuario GetSingleUser(int id);
        TbSeUsuario GetUsuarioConPerfiles(string usuario);
        TbSeUsuario GetUsuarioConEmpresas(string usuario);
        IEnumerable<TbSePerfil> GetPerfiles(int id);
        bool CreatePerfilUsuario(IList<TbSePerfilUsuario> domain);
        bool DeletePU(TbSePerfilUsuario model);
        TbSePerfilUsuario GetPerfilUsuario(PerfilUsuarioViewModel model);
        TbSeUsuarioConfiguraion CreateOrUpdateConfiguracion(TbSeUsuarioConfiguraion domain);
        TbSeEmpresaUsuario CreateEmpresaUsuarioRel(TbSeEmpresaUsuario domain);
        IList<TbSeUsuario> GetAllByIdEmpresa(int idEmpresa);
        bool ExisteUsuarioPorCodigo(string codigo);
        bool ExisteUsuarioPorCorreo(string correo);
        IList<TbSeUsuario> GetAllConEmpresas();
    }
}
