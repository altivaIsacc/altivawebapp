using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Context;
using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;

namespace AltivaWebApp.Repositories
{
    public class ListaDesplegableRepository : BaseRepository<TbCrListaDesplegables>, IListaDespegableRepository
    {
        public ListaDesplegableRepository(EmpresasContext context) : base(context)
        {

        }

        public IList<ListaDesplegableGETViewModel> GetAllLista()
        {

            var model = (from con in context.TbCrListaDesplegables
                         join a in context.TbCrCamposPersonalizados
                         on con.IdCamposPersonalizados equals a.Id
                         select new ListaDesplegableGETViewModel
                         {
                             IdCampoPersonalizado = Convert.ToInt32(a.Id),
                             Nombre = a.Nombre,
                             IdListaDesplegable = Convert.ToInt32(con.Id),
                             Tipo = a.Tipo


                         }

     ).ToList();

            return model;
        }

        public TbCrListaDesplegables GetById(int idLista)
        {
            return context.TbCrListaDesplegables.Where(u => u.Id == idLista).FirstOrDefault();

        }

        public IList<TbCrListaDesplegables> GetListaByIdCampo(int idCampo)
        {
            return context.TbCrListaDesplegables.Where(u => u.IdCamposPersonalizados == idCampo).ToList();
        }

        public IList<ListaDesplegableGETViewModel> GetCampos(int id)
        {

            var model = (from con in context.TbCrListaDesplegables
                         join a in context.TbCrCamposPersonalizados
                         on con.IdCamposPersonalizados equals a.Id
                         where con.IdCamposPersonalizados == id
                         select new ListaDesplegableGETViewModel
                         {
                             IdCampoPersonalizado = Convert.ToInt32(con.Id),
                             IdListaDesplegable = Convert.ToInt32(a.Id),
                             Tipo = a.Tipo,
                             Nombre = a.Nombre,
                             Valor = con.Valor

                         }

     ).ToList();

            return model;
        }

        public void SaveRange(IList<TbCrListaDesplegables> domain)
        {
            context.TbCrListaDesplegables.AddRange(domain);
            context.SaveChanges();
        }

        public void UpdateRange(IList<TbCrListaDesplegables> domain)
        {
            context.TbCrListaDesplegables.UpdateRange(domain);
            context.SaveChanges();
        }

        public void DeleteRange(IList<long> domain)
        {
            context.TbCrListaDesplegables.RemoveRange(context.TbCrListaDesplegables.Where(l => domain.Contains(l.Id)));
            context.SaveChanges();
        }
    }
}
