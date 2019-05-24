using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public interface IDepartamentoRepository
    {
        TbPrDepartamento Save(TbPrDepartamento domain);
        TbPrDepartamento Update(TbPrDepartamento domain);
        IList<TbPrDepartamento> GetAll();
        TbPrDepartamento GetDepartamentoById(int id);
        IList<TbPrDepartamento> GetDepartamentosSinAnular();
        TbPrDepartamento GetDepartamentoByDesc(string desc);
    }
}
