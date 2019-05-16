using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Context;
using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace AltivaWebApp.Repositories
{
    public class ContactoCamposRepository : BaseRepository<TbCrContactosCamposPersonalizados>, IContactoCamposRepository
    {
        public ContactoCamposRepository(EmpresasContext context) : base(context)
        {
        }

        public void Agregar(IList<TbCrContactosCamposPersonalizados> domain)
        {
            context.TbCrContactosCamposPersonalizados.AddRange(domain);
            context.SaveChanges();
        }

        public TbCrContactosCamposPersonalizados GetById(long id)
        {
            return context.TbCrContactosCamposPersonalizados.Where(u => u.Id == id).FirstOrDefault();
        }

        public IList<ContactoViewModel> GetCamposEdit(int id)
        {
            var model = (from us in context.TbCrContacto
                         join c in context.TbCrContactosCamposPersonalizados on us.IdContacto equals c.IdContacto
                         join cp in context.TbCrCamposPersonalizados on c.IdCampoPersonalizados equals cp.Id
                         where c.IdContacto == id
                         select new ContactoViewModel
                         {

                             Tipo = cp.Tipo,
                             Valor = c.Valor,
                             IdCampoPersonalizados = c.Id,
                             NombreCampo = cp.Nombre,
                             Id = cp.Id


                         }

     ).ToList();

            return model;
        }

        public void Update(IList<TbCrContactosCamposPersonalizados> domain)
        {
            try
            {
                context.TbCrContactosCamposPersonalizados.UpdateRange(domain);
                context.SaveChanges();

            }
            catch
            {
                throw;
            }
        }
    }
}
