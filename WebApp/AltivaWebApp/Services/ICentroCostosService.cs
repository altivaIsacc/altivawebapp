using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.GEDomain;
using AltivaWebApp.ViewModels;
namespace AltivaWebApp.Services
{
    public interface ICentroCostosService
    {
        IList<TbSeUsuario> GetAll();
        TbFdUsuarioCosto Save(TbFdUsuarioCosto domain);
        TbFdUsuarioCosto Update(TbFdUsuarioCosto domain);
        TbFdUsuarioCosto Delete(TbFdUsuarioCosto domain);
        TbFdUsuarioCosto GetById(int idUsuarioCostos);

    }
}
