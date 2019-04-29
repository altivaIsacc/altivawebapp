using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
namespace AltivaWebApp.Services
{
   public  interface IContactoService
    {
        IList<TbCrContacto> GetAllPersonas();
        IList<TbCrContacto> GetAllEmpresas();
        TbCrContacto GetByIdContacto(long domain);
        TbCrContacto Edit(TbCrContacto domain);
        TbCrContacto Save(TbCrContacto domain);
        ContactoViewModel GetByEdit(int id);
       ContactoViemModelDetalle getById(int id);
        TbCrContactoRelacion InsertarRelacion(TbCrContactoRelacion domain);
        IList<ContactoRelacionGETViewModel> GetContactosRelacion(int id);
        IList<TbCeProvincias> GetProvincias();
        IList<TbCrContacto> GetAll();
        TbCrContacto GetByEmailContacto(string correo);
        TbCrContacto GetByCedulaContacto(string cedula);
        IList<TbCeCanton> GetCantones(int idProvincia);
        IList<TbCeDistrito> GetDistrito(int idCanton, int idProvincia);
        TbCrContactoRelacion EditarRelacion(EditarRelacionContactoViewModel domain);
        TbCrContactoRelacion viewModelEditarRelacion(EditarRelacionContactoViewModel domain);
        TbCrContacto GetTareas(int idContacto);

    }
}
