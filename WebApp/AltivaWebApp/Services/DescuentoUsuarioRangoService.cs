using AltivaWebApp.Domains;
using AltivaWebApp.GEDomain;
using AltivaWebApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Services
{
    public class DescuentoUsuarioRangoService: IDescuentoUsuarioRangoService
    {
        readonly IDescuentoUsuarioRangoRepository repository;
        readonly IUserRepository repositoryUser;

        public DescuentoUsuarioRangoService(IDescuentoUsuarioRangoRepository repository, IUserRepository repositoryUser)
        {
            this.repository = repository;
            this.repositoryUser = repositoryUser;
        }

        public bool Save(IList<TbFaDescuentoUsuarioRango> domain)
        {
            return repository.SaveDescUserRango(domain);
        }

        public IList<TbFaDescuentoUsuarioRango> GetAll()

        {

            return repository.GetAll();

        }

        public TbFaDescuentoUsuarioRango GetDescuentoUsuarioRangoById(int id)
        {
            return repository.GetDescuentoUsuarioRangoById(id);
        }

        public bool Delete(TbFaDescuentoUsuarioRango domain)
        {
            return repository.Delete(domain);
        }

        public IList<TbSeUsuario> GetUsuarioSInDescRango(int idEmpresa)
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
