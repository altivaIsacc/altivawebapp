using AltivaWebApp.GEDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public interface IGERepository
    {        
        TbGeEmpresa Save(TbGeEmpresa domain);
        TbGeEmpresa Update(TbGeEmpresa domain);
        bool EliminarEmpresa(TbGeEmpresa domain);
        IList<TbGeEmpresa> GetAllByUsuario(int id);
        bool CrearBD(string nombre);
        TbGeEmpresa GetByCedula(string cedula);
        TbGeGrupoEmpresarial GetGE();
        TbGeEmpresa GetEmpresaById(int id);
        TbGeEmpresa GetEmpresaByNombre(string nombre);
        bool AgregarUsuarios(int idEmpresa);
    }
}
