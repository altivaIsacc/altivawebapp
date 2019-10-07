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
        IList<TbCrContacto> GetAllClientes();
        ContactoViewModel GetByEdit(int id);
        IList<TbCrContacto> GetAllEmpresas();
        TbCrContacto Save(TbCrContacto domain);
        TbCrContacto Update(TbCrContacto domain);
        IList<TbCeProvincias> GetProvincias();
        IList<TbCeCanton> GetCantones(int idProvincia);
        TbCrContacto GetByIdContacto(long id);
        TbCrContacto GetByEmailContacto(string correo);
        TbCrContacto GetByCedulaContacto(string cedula);
        IList<TbFdTarea> GetTareas(int idContacto);
        IList<TbCrContactoRelacion> GetContactosRelacion(int id);
        IList<TbCrContacto> GetAllProveedores();
        IList<TbCeDistrito> GetDistrito(int idCanton,int idProvincia);
        bool EliminarRelacion(int idRelacion);
        bool EsPorDefectoPV(int id);


    }
}
