using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Context;
using AltivaWebApp.Domains;
namespace AltivaWebApp.Repositories
{
    public class CamposPersonalizadosRepository : BaseRepository<TbCrCamposPersonalizados>, ICamposPersonalizadosRepository
    {
        public CamposPersonalizadosRepository(EmpresasContext context) : base(context)
        {
        }

        public void CrearCamposPersonalizados(IList<TbCrCamposPersonalizados> domain)
        {

            context.TbCrCamposPersonalizados.AddRange(domain);
            context.SaveChanges();
        }

        public TbCrCamposPersonalizados getById(int id)
        {
            return context.TbCrCamposPersonalizados.Where(u => u.Id == id).FirstOrDefault();
        }

        public IList<TbCrCamposPersonalizados> GetCampos()
        {
            var model = (from us in context.TbCrCamposPersonalizados
                         where us.Estado != "Eliminado"
                         orderby us.Nombre descending
                         select new TbCrCamposPersonalizados
                         {

                             Id = us.Id,
                             Nombre =us.Nombre,
                             Tipo = us.Tipo

                         }

       ).ToList();

            return model;
        }
      
    }
}
