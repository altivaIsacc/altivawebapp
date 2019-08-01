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

        public IList<TbCrCamposPersonalizados> GetCampos(int id)
        {
            return context.TbCrCamposPersonalizados.Where(c => c.Estado == "Activo")
            .Select(c => new TbCrCamposPersonalizados {
                Estado = c.Estado,
                Id = c.Id,
                Nombre = c.Nombre,
                Tipo = c.Tipo,
                TbCrListaDesplegables = c.TbCrListaDesplegables,
                TbCrContactosCamposPersonalizados = c.TbCrContactosCamposPersonalizados.Where(cc => cc.IdContacto == id).ToList()
            }).ToList();
        }

      
    }
}
