using AltivaWebApp.Context;
using AltivaWebApp.Domains;
using AltivaWebApp.GEDomain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public class PerfilRepository : BaseRepositoryGE<TbSePerfil>, IPerfilRepository
    {
        public PerfilRepository(GrupoEmpresarialContext context)
             : base(context)
        {

        }

        public TbSePerfil GetSinglePerfil(int id)
        {
            return context.TbSePerfil.Where(u => u.Id == id).FirstOrDefault();
            // return context.TbSeUsuario.
        }

        public bool GetPerfilTieneUsuarios(int idPerfil)
        {
            try
            {
                var model = context.TbSePerfilUsuario.FirstOrDefault(pu => pu.IdPerfil == idPerfil);
                if (model != null)               
                    return true;               
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public IList<TbSePerfil> GetPerfilesByUsuario(int id)
        {

          
            var model = ( from pu in context.TbSePerfilUsuario
                          join p in context.TbSePerfil on pu.IdPerfil equals p.Id
                          join u in context.TbSeUsuario on pu.IdUsuario equals u.Id
                          where u.Id == id
                          select new TbSePerfil
                          {
                              Id = p.Id,
                              Nombre = p.Nombre
                          }
                         
                ).ToList();

            return model;
        }
        
        public IList<TbSePerfil> GetPerfilSinAsignarByUsuario(int id)
        {
            var model = (from pu in context.TbSePerfilUsuario
                         join p in context.TbSePerfil on pu.IdPerfil equals p.Id
                         join u in context.TbSeUsuario on pu.IdUsuario equals u.Id
                         where u.Id != id
                         select new TbSePerfil
                         {
                             Id = p.Id,
                             Nombre = p.Nombre
                         }

               ).ToList();

            return model;
        }


        }
}
