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
        IList<TbCrContacto> GetAllClientes();
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
        IList<TbFdTarea> GetTareas(int idContacto);
        IList<TbFdCondicionesDePago> CreateOrUpdateCondicionPago(IList<TbFdCondicionesDePago> domain);
        TbFdCondicionesDePago EditarCondicion(TbFdCondicionesDePago domain);
        TbFdCuentasBancarias AgregarCuentasBancarias(TbFdCuentasBancarias domain);
        IList<TbFdCondicionesDePago> GetCondicionesByIdContacto(int idContacto);
        TbFdCuentasBancarias EditarCuentasBancarias(TbFdCuentasBancarias domain);
        IList<TbFdCuentasBancarias> GetByContacto(int idContacto);
        TbFdCuentasBancarias GetCuentaById(int id);
        IList<TbFdCuentasBancarias> GetCuentasByContacto(int id);
        bool DeleteCuentasBancarias(TbFdCuentasBancarias domain);
        IList<TbCrContacto> GetAllProveedores();
        bool EliminarRelacion(int idRelacion);
        TbCrContactoRelacion GetRelacionById(int id);
        TbCrContactoRelacion GetByIdPadreAndIdHijo(int idPadre, int idHijo);
        bool EsPorDefectoPV(int id);
        IList<DocContacto> GetAllDocs(long id);

    }
}
