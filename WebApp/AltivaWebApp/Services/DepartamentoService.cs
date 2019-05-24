using AltivaWebApp.Domains;
using AltivaWebApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Services
{
    public class DepartamentoService: IDepartamentoService
    {
        private readonly IDepartamentoRepository reposistory;

        public DepartamentoService(IDepartamentoRepository reposistory)
        {
            this.reposistory = reposistory;
        }

        public IList<TbPrDepartamento> GetAll()
        {
            return reposistory.GetAll(); ;
        }

        public TbPrDepartamento GetDepartamentoByDesc(string desc)
        {
            return reposistory.GetDepartamentoByDesc(desc);
        }

        public TbPrDepartamento GetDepartamentoById(int id)
        {
            return reposistory.GetDepartamentoById(id);
        }

        public IList<TbPrDepartamento> GetDepartamentosSinAnular()
        {
            return reposistory.GetDepartamentosSinAnular();
        }

        public TbPrDepartamento Save(TbPrDepartamento domain)
        {
            return reposistory.Save(domain);
        }
        public TbPrDepartamento Update(TbPrDepartamento domain)
        {
            return reposistory.Update(domain);
        }

    }
}
