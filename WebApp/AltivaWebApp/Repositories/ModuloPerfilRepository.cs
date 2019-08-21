using AltivaWebApp.Context;
using AltivaWebApp.GEDomain;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public class ModuloPerfilRepository: BaseRepositoryGE<TbSePerfilModulo>, IModuloPerfilRepository
    {
        public ModuloPerfilRepository(GrupoEmpresarialContext context)
            : base(context)
        {

        }


        public IList<TbSePerfilModulo> MultipleSave(IList<TbSePerfilModulo> domain)
        {
            try
            {
                context.TbSePerfilModulo.AddRange(domain);
                context.SaveChanges();
                return domain;
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");

                throw;
            }
           
        }

        public bool MultipleDelete(IList<TbSePerfilModulo> domain)
        {
            try
            {
                context.TbSePerfilModulo.RemoveRange(domain);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                return false;
                throw;
            }
        }

        public TbSePerfilModulo GetById(int id)
        {
            return context.TbSePerfilModulo.FirstOrDefault(pm => pm.Id == id);
        }

        public IList<ModuloPerfilViewModel> GetAllByPerfil()
        {

            var modulos = (from pm in context.TbSePerfilModulo
                           join m in context.TbSeModulo on pm.IdModulo equals m.Id
                           join p in context.TbSePerfil on pm.IdPerfil equals p.Id
                           select new ModuloPerfilViewModel
                           {
                               Id = (int)pm.Id,
                               IdModulo = (int)m.Id,
                               IdPerfil = (int)p.Id,
                               Nombre = m.NombreExterno,
                               Descripcion = m.Descripcion,
                               Ejecutar = pm.Ejecutar,
                               Actualizar = pm.Actualizar,
                               Eliminar = pm.Eliminar,
                               Imprimir = pm.Imprimir,
                               Insertar = pm.Insertar,
                               Opcion1 = pm.Opcion1,
                               Opcion2 = pm.Opcion2,
                               Grupo = m.Grupos
                           }).ToList();

            //modulos.RemoveAll(item => item.Id == id);




            return modulos;
        }
    }
}
