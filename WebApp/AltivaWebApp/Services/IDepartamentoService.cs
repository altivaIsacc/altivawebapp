using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Services
{
    public interface IDepartamentoService
    {
        TbPrDepartamento Save(TbPrDepartamento domain);
        TbPrDepartamento Update(TbPrDepartamento domain);
        IList<TbPrDepartamento> GetAll();
        TbPrDepartamento GetDepartamentoById(int id);
        IList<TbPrDepartamento> GetDepartamentosSinAnular();
        TbPrDepartamento GetDepartamentoByDesc(string desc);
    }
}
