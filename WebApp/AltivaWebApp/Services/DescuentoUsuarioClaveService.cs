using AltivaWebApp.Domains;
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
        public DescuentoUsuarioClaveService(IDescuentoUsuarioClaveRepository repository)
        {
            this.repository = repository;
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
    }
}
