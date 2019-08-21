using AltivaWebApp.Domains;
using AltivaWebApp.GEDomain;
using AltivaWebApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Services
{
    public class DescuentoUsuarioClaveService: IDescuentoUsuarioClaveService
    {
        readonly IDescuentoUsuarioClaveRepository repository;
        readonly IUserRepository repositoryUser;
        public DescuentoUsuarioClaveService(IDescuentoUsuarioClaveRepository repository, IUserRepository repositoryUser)
        {
            this.repository = repository;
            this.repositoryUser = repositoryUser;
        }

        //public IList<TbFaDescuentoUsuario> Save(IList<TbFaDescuentoUsuario> domain)
        //{
        //    return repository.Save(domain);
        //}

        public bool Save(IList<TbFaDescuentoUsuarioClave> domain)
        {
            return repository.SaveDescUserClave(domain);
        }

        public IList<TbFaDescuentoUsuarioClave> GetAll()

        {

            return repository.GetAll();

        }

        public TbFaDescuentoUsuarioClave GetDescuentoUsuarioClaveById(int id)
        {
            return repository.GetDescuentoUsuarioClaveById(id);
        }

        public bool Delete(TbFaDescuentoUsuarioClave domain)
        {
            return repository.Delete(domain);
        }

        public IList<TbSeUsuario> GetUsuarioSInDescClave(int idEmpresa)
        {

            var usuarios = repositoryUser.GetAllByIdEmpresa(idEmpresa);
            var desc = repository.GetAll();
            var usuariosDesc = new List<TbSeUsuario>();

            foreach (var item in usuarios)
            {
                if (!desc.Any(u => u.IdUsuario == item.Id))
                {
                    usuariosDesc.Add(item);
                }
            }

            return usuariosDesc;

        }
    }
}
