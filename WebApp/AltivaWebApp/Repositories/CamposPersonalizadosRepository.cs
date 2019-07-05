using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Context;
using AltivaWebApp.Domains;
using Microsoft.EntityFrameworkCore;

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
            return context.TbCrCamposPersonalizados.Include(c => c.TbCrListaDesplegables).Where(c => c.Estado == "Activo").ToList();
        }
      
    }
}
