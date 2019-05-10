using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.GEDomain;
using AltivaWebApp.ViewModels;
namespace AltivaWebApp.Repositories
{
  public  interface ICentroCostosRepository
    {

        TbFdUsuarioCosto Save(TbFdUsuarioCosto domain);
        TbFdUsuarioCosto Update(TbFdUsuarioCosto domain);
        TbFdUsuarioCosto GetById(int idUsuarioCosto);
        bool Delete(TbFdUsuarioCosto domain);
        IList<TbSeUsuario> GetUsuarioConCosto();
    }
}
