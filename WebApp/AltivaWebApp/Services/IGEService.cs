using AltivaWebApp.GEDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Services
{
    public interface IGEService
    {
        TbGeEmpresa Save(TbGeEmpresa domain);
        bool EliminarEmpresa(TbGeEmpresa domain);
        TbGeEmpresa Update(TbGeEmpresa domain);
        IList<TbGeEmpresa> GetAllByUsuario(int id);
        bool CrearBD(string nombre);
        TbGeEmpresa GetByCedula(string cedula);
        TbGeGrupoEmpresarial GetGE();
        TbGeEmpresa GetEmpresaById(int id);
        TbGeEmpresa GetEmpresaByNombre(string nombre);
    }
}
