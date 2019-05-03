using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
namespace AltivaWebApp.Repositories
{
   
public interface IContactoRepository
    {
        IList<TbCrContacto> GetAll();
        IList<TbCrContacto> GetAllPersonas();
        ContactoViewModel GetByEdit(int id);
        IList<TbCrContacto> GetAllEmpresas();
        TbCrContacto Save(TbCrContacto domain);
        ContactoViemModelDetalle getById(int id);
        TbCrContacto Update(TbCrContacto domain);
        IList<TbCeProvincias> GetProvincias();
        IList<TbCeCanton> GetCantones(int idProvincia);
        TbCrContacto GetByIdContacto(long id);
        TbCrContacto GetByEmailContacto(string correo);
        TbCrContacto GetByCedulaContacto(string cedula);
        IList<ContactoRelacionGETViewModel> GetContactosRelacion(int id);
        IList<TbCrContacto> GetAllProveedores();
        IList<TbCeDistrito> GetDistrito(int idCanton,int idProvincia);
    }
}
