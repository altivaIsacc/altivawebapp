using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Services
{
    public interface ICategoriaGastoService
    {
        TbCpCategoriaGasto Save(TbCpCategoriaGasto domain);
        TbCpCategoriaGasto Update(TbCpCategoriaGasto domain);
        IList<TbCpCategoriaGasto> GetAll();
        TbCpCategoriaGasto GetCGById(int id);
        TbCpCategoriaGasto GetCGByNombre(string nombre);
    }
}
