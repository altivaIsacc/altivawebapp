using AltivaWebApp.GEDomain;
using System;
using System.Collections.Generic;


namespace AltivaWebApp.Services
{
    public interface IPerfilService
    {
        TbSePerfil Create(TbSePerfil domain);
        TbSePerfil Update(TbSePerfil domain);
        IList<TbSePerfil> GetAll();
        bool Delete(TbSePerfil domain);
        TbSePerfil GetSinglePerfil(int id);
        IList<TbSePerfil> GetPerfilByUsuario(int id);
        IList<TbSePerfil> GetPerfilSinAsignarByUsuario(int id);
        bool GetPerfilTieneUsuarios(int idPerfil);


    }
}
