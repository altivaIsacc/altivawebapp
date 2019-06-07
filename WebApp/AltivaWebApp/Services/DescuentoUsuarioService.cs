using AltivaWebApp.Domains;
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
        public DescuentoUsuarioService(IDescuentoUsuarioRepository repository)
        {
            this.repository = repository;
        }

        //public IList<TbFaDescuentoUsuario> Save(IList<TbFaDescuentoUsuario> domain)
        //{
        //    return repository.Save(domain);
        //}

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
