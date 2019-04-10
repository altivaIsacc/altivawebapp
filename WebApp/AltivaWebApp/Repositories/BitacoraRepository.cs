using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Context;
using AltivaWebApp.GEDomain;
using AltivaWebApp.ViewModels;
namespace AltivaWebApp.Repositories
{
    public class BitacoraRepository : BaseRepositoryGE<TbSeBitacora>, IBitacoraRepository
    {
        public BitacoraRepository(GrupoEmpresarialContext context) : base(context)
        {
        }

        public List<BitacoraViewModel> Get()
        {
            var model = (from us in context.TbSeUsuario
                         join bi in context.TbSeBitacora on us.Id equals bi.IdUsuario
                      
                         select new BitacoraViewModel
                         {
                             Fecha = bi.Fecha,
                            nombreUsuario  = us.Nombre,
                             Descripcion = bi.Descripcion,
                             TipoReferencia= bi.TipoReferencia
                             
                         }

            ).ToList();


            return model;
        }

        public List<BitacoraViewModel> GetByDate(DateTime date1, DateTime date2)
        {
            var model = (from us in context.TbSeUsuario
                         join bi in context.TbSeBitacora on us.Id equals bi.IdUsuario
                         where bi.Fecha >= date1 && bi.Fecha <= date2
                         select new BitacoraViewModel
                         {
                             Fecha = bi.Fecha,
                             nombre = us.Nombre,
                             Descripcion = bi.Descripcion,
                             nombreUsuario = us.Nombre,
                             TipoReferencia = bi.TipoReferencia
                             
                         }

             ).ToList();


            return model;

        }

        public List<BitacoraViewModel> GetByName(int id)
        {
            var model = (from us in context.TbSeUsuario
                         join bi in context.TbSeBitacora on us.Id equals bi.IdUsuario
                         where bi.IdUsuario == id
                         select new BitacoraViewModel
                         {
                             IdUsuario = bi.IdUsuario,
                             nombre = us.Nombre,
                             Fecha = bi.Fecha,
                             Descripcion = bi.Descripcion,
                             nombreUsuario = us.Nombre,
                             TipoReferencia = bi.TipoReferencia

                         }

 ).ToList();

            return model;

        }
    }
}
