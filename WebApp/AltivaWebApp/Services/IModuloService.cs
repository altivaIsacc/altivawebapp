using AltivaWebApp.Domains;
using AltivaWebApp.GEDomain;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Services
{
    public interface IModuloService
    {
        TbSeModulo Create(TbSeModulo domain);
        TbSeModulo Update(TbSeModulo domain);
        IList<TbSeModulo> GetAll();
        TbSeModulo GetModuloById(int id);



    }
}
