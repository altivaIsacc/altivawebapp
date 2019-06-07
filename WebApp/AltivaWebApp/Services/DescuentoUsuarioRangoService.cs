using AltivaWebApp.Domains;
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
        public DescuentoUsuarioRangoService(IDescuentoUsuarioRangoRepository repository)
        {
            this.repository = repository;
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
    }
}
