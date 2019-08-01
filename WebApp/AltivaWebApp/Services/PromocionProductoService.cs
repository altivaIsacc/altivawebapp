using AltivaWebApp.Domains;
using AltivaWebApp.GEDomain;
using AltivaWebApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Services
{
    public class PromocionProductoService : IPromocionProductoService
    {
        readonly IPromocionProductoRepository repository;
        readonly IUserRepository repositoryUser;
        public PromocionProductoService(IUserRepository repositoryUser, IPromocionProductoRepository repository)
        {
            this.repository = repository;
            this.repositoryUser = repositoryUser;
        }

        //public IList<TbSeUsuario> GetUsuarioSInDesc(int idEmpresa)
        //{

        //    var usuarios = repositoryUser.GetAllByIdEmpresa(idEmpresa);
        //    var desc = repository.GetAll();
        //    var usuariosDesc = new List<TbSeUsuario>();

        //    foreach (var item in usuarios)
        //    {
        //        if (!desc.Any(u => u.IdUsuario == item.Id))
        //        {
        //            usuariosDesc.Add(item);
        //        }
        //    }

        //    return usuariosDesc;

        //}

        //public IList<TbSeUsuario> GetUsuarioConDesc(int idEmpresa)
        //{

        //    var usuarios = repositoryUser.GetAllByIdEmpresa(idEmpresa);
        //    var desc = repository.GetAll();
        //    var usuariosDesc = new List<TbSeUsuario>();

        //    foreach (var item in usuarios)
        //    {
        //        if (desc.Any(u => u.IdUsuario == item.Id))
        //        {
        //            usuariosDesc.Add(item);
        //        }
        //    }

        //    return usuariosDesc;

        //}

        public bool Save(IList<TbFaPromocionProducto> domain)
        {
            return repository.SavePromocion(domain);
        }

        public IList<TbFaPromocionProducto> GetAll()

        {

            return repository.GetAll();

        }

        public TbFaPromocionProducto GetPromocionById(int id)
        {
            return repository.GetPromocionById(id);
        }

        public bool Delete(TbFaPromocionProducto domain)
        {
            return repository.Delete(domain);
        }
    }
}
