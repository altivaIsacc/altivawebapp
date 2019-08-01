using AltivaWebApp.Domains;
using AltivaWebApp.GEDomain;
using AltivaWebApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Services
{
    public class DescuentoUsuarioService: IDescuentoUsuarioService
    {
        readonly IDescuentoUsuarioRepository repository;
        readonly IUserRepository repositoryUser;
        public DescuentoUsuarioService(IUserRepository repositoryUser, IDescuentoUsuarioRepository repository)
        {
            this.repository = repository;
            this.repositoryUser = repositoryUser;
        }

        //public IList<TbFaDescuentoUsuario> Save(IList<TbFaDescuentoUsuario> domain)
        //{
        //    return repository.Save(domain);
        //}
        public IList<TbSeUsuario> GetUsuarioSInDesc(int idEmpresa)
        {

            var usuarios = repositoryUser.GetAllByIdEmpresa(idEmpresa);
            var desc = repository.GetAll();
            var usuariosDesc = new List<TbSeUsuario>();

            foreach (var item in usuarios)
            {
                if(!desc.Any(u => u.IdUsuario == item.Id))
                {
                    usuariosDesc.Add(item);
                }
            }

            return usuariosDesc;

        }

        public IList<TbSeUsuario> GetUsuarioConDesc(int idEmpresa)
        {

            var usuarios = repositoryUser.GetAllByIdEmpresa(idEmpresa);
            var desc = repository.GetAll();
            var usuariosDesc = new List<TbSeUsuario>();

            foreach (var item in usuarios)
            {
                if (desc.Any(u => u.IdUsuario == item.Id))
                {
                    usuariosDesc.Add(item);
                }
            }

            return usuariosDesc;

        }

        public bool Save(IList<TbFaDescuentoUsuario> domain)
        {
            return repository.SaveDescUser(domain);
        }

        public IList<TbFaDescuentoUsuario> GetAll()

        {

            return repository.GetAll();

        }

        public TbFaDescuentoUsuario GetDescuentoUsuarioById(int id)
        {
            return repository.GetDescuentoUsuarioById(id);
        }

        public bool Delete(TbFaDescuentoUsuario domain)
        {
            return repository.Delete(domain);
        }
    }
}
