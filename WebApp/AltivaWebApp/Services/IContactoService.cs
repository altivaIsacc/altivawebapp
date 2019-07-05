using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
namespace AltivaWebApp.Services
{
    public interface IContactoService
    {
        IList<TbCrContacto> GetAllPersonas();
        IList<TbCrContacto> GetAllEmpresas();
        TbCrContacto GetByIdContacto(long domain);
        TbCrContacto Update(TbCrContacto domain);
        TbCrContacto Save(TbCrContacto domain);
        TbCrContactoRelacion SaveRelacion(TbCrContactoRelacion domain);
        TbCrContactoRelacion UpdateRelacion(TbCrContactoRelacion domain);
        IList<TbCeProvincias> GetProvincias();
        IList<TbCrContacto> GetAll();
        IList<TbCrContactoRelacion> GetContactoRelacion(int id);
        TbCrContacto GetByEmailContacto(string correo);
        TbCrContacto GetByCedulaContacto(string cedula);
        IList<TbCeCanton> GetCantones(int idProvincia);
        IList<TbCeDistrito> GetDistrito(int idCanton, int idProvincia);
        TbCrContacto GetTareas(int idContacto);
        TbFdCondicionesDePago AgregarCondicion(TbFdCondicionesDePago domain);
        TbFdCondicionesDePago EditarCondicion(TbFdCondicionesDePago domain);
        TbFdCuentasBancarias AgregarCuentasBancarias(TbFdCuentasBancarias domain);
        IList<TbFdCondicionesDePago> GetCondiciones(int idContacto);
        TbFdCuentasBancarias AgregarCuentas(TbFdCuentasBancarias domain);
        TbFdCuentasBancarias EditarCuentas(TbFdCuentasBancarias domain);
        IList<TbFdCuentasBancarias> GetByContacto(int idContacto);
        TbFdCuentasBancarias GetCuentasById(int id);
        bool DeleteCuentasBancarias(TbFdCuentasBancarias domain);
        IList<TbCrContacto> GetAllProveedores();
        bool EliminarRelacion(int idRelacion);

    }
}
