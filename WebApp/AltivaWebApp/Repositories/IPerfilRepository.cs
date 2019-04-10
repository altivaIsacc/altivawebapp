using AltivaWebApp.GEDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public interface IPerfilRepository
    {
        TbSePerfil Save(TbSePerfil domain);
        TbSePerfil GetSinglePerfil(int id);
        TbSePerfil Update(TbSePerfil domain);
        bool Delete(TbSePerfil domain);
        IList<TbSePerfil> GetAll();
        IList<TbSePerfil> GetPerfilSinAsignarByUsuario(int id);
        IList<TbSePerfil> GetPerfilesByUsuario(int id);
        bool GetPerfilTieneUsuarios(int idPerfil);

    }
}
