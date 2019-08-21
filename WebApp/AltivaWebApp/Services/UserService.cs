
using System.Collections.Generic;
using System.Threading.Tasks;
using AltivaWebApp.GEDomain;
using AltivaWebApp.ViewModels;
using AltivaWebApp.Repositories;

namespace AltivaWebApp.Services
{
    public class UserService : IUserService

    {

        private IUserRepository repository;

        public UserService(IUserRepository userRepository)

        {

            repository = userRepository;

        }
        public IList<TbSeUsuario> GetAllById(int id)
        {
            return this.repository.GetAllByIdUsuario(id);
        }
       

        public bool ExisteUsuarioPorCodigo(string codigo)
        {
            return repository.ExisteUsuarioPorCodigo(codigo);
        }
        public bool ExisteUsuarioPorCorreo(string correo)
        {
            return repository.ExisteUsuarioPorCorreo(correo);
        }

        public TbSeUsuario Create(TbSeUsuario domain)

        {

            return repository.Save(domain);

        }

        public TbSeUsuario GetUsuarioConConfig(string usuario)
        {
            return repository.GetUsuarioConConfig(usuario);
        }

        public IList<TbSePerfilModulo> GetAllPerfilModulo()
        {
            return repository.GetAllPerfilModulo();
        }

        public IList<TbSePerfilUsuario> GetAllPerfilUsuario()
        {
            return repository.GetAllPerfilUsuario();
        }


        public TbSeEmpresaUsuario CreateEmpresaUsuarioRel(TbSeEmpresaUsuario domain)
        {
            return repository.CreateEmpresaUsuarioRel(domain);
        }

        public TbSeUsuario UpdateUsuario(TbSeUsuario domain)

        {
            return repository.Update(domain);
        }

        public void Delete(TbSeUsuario domain)

        {

            repository.Delete(domain);

        }

        public TbSeUsuarioConfiguraion CreateOrUpdateConfiguracion(TbSeUsuarioConfiguraion domain)
        {
            return repository.CreateOrUpdateConfiguracion(domain);
        }


        public TbSePerfilUsuario GetPerfilUsuario(PerfilUsuarioViewModel model)
        {
            return repository.GetPerfilUsuario(model);
        }
        public bool DeletePU(TbSePerfilUsuario model)
        {
            return repository.DeletePU(model);
        }

            public IList<TbSeUsuario> GetAll()

        {

            return repository.GetAll();

        }

        


        public TbSeUsuario GetSingleUser(int id)
        {
            return repository.GetUsuarioById(id);
        }

        public TbSeUsuario GetUsuarioConPerfiles(string usuario)
        {
            return repository.GetUsuarioConPerfiles(usuario);
        }

        public TbSeUsuario GetUsuarioConPerfilesById(int usuario)
        {
            return repository.GetUsuarioConPerfilesById(usuario);
        }

        public TbSeUsuario GetUsuarioConEmpresas(string usuario)
        {
            return repository.GetUsuarioConEmpresas(usuario);
        }
       
        public IEnumerable<TbSePerfil> GetPerfiles(int id)
        {
            return repository.GetPerfiles(id);
        }

        public bool CreatePerfilUsuario(IList<TbSePerfilUsuario> domain)
        {
            return repository.CreatePerfilUsuario(domain);
        }

        public IList<TbSeUsuario> GetAllByIdEmpresa(int idEmpresa)
        {
            return repository.GetAllByIdEmpresa(idEmpresa);
        }
        public IList<TbSeUsuario> GetAllConEmpresas()
        {
            return repository.GetAllConEmpresas();
        }
        public IList<TbGeEmpresa> GetEmpresasPorUsuario(int idUsuario)
        {
            return repository.GetEmpresasPorUsuario(idUsuario);
        }
        public bool CrearRelEmpresaUsuario(IList<TbSeEmpresaUsuario> domain)
        {
            return repository.CrearRelEmpresaUsuario(domain);
        }

        public bool DesactivarRelEmpresaUsuario(IList<TbSeEmpresaUsuario> domain)
        {
            return repository.DesactivarRelEmpresaUsuario(domain);
        }
        public IList<TbSeUsuario> GetAllByIdEmpresaConPerfiles(int idEmpresa)
        {
            return repository.GetAllByIdEmpresaConPerfiles(idEmpresa);
        }
    }
}
