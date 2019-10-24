using AltivaWebApp.Context;
using AltivaWebApp.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public class RequisicionRepository: BaseRepository<TbPrRequisicion>, IRequisicionRepository
    {
        public RequisicionRepository(EmpresasContext context) : base(context)
        {
            
        }

        public IList<TbPrRequisicion> GetAllWithDetails()
        {
            return context.TbPrRequisicion.Include(r => r.IdDepartamentoNavigation).ToList();
        }

        public TbPrRequisicion GetReqById(long id)
        {
            TbPrRequisicion resul;

            if (id == 0)
            {

                resul = context.TbPrRequisicion.AsNoTracking().FirstOrDefault(r => r.Id == id);
            }
            else {

                resul = context.TbPrRequisicion.AsNoTracking().FirstOrDefault(r => r.Id == id);
                resul.TbPrRequisicionDetalle = context.TbPrRequisicionDetalle.AsNoTracking().Where(r => r.IdRequisicion == id).ToList();

            }

            return resul;

          
        }

        public TbPrRequisicion GetRequisicionWithDetails(int id)
        {
            return context.TbPrRequisicion.Include(r => r.TbPrRequisicionDetalle).FirstOrDefault(r => r.Id == id);
        }

        public IList<TbPrRequisicionDetalle> GetAllRDByRequisicionId(int id)
        {
            try
            {
                return context.TbPrRequisicionDetalle.Where(r => r.IdRequisicionNavigation.Id == id).ToList();
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");

                throw;
            }
        }

        public IList<TbPrRequisicionDetalle> SaveOrUpdateRD(IList<TbPrRequisicionDetalle> domain)
        {
            try
            {

                var actualizar = new List<TbPrRequisicionDetalle>();
                var crear = new List<TbPrRequisicionDetalle>();

                foreach (var item in domain)
                {
                    if (item.Id != 0)
                        actualizar.Add(item);
                    else
                        crear.Add(item);
                }

                context.TbPrRequisicionDetalle.AddRange(crear);
                context.TbPrRequisicionDetalle.UpdateRange(actualizar);

                context.SaveChanges();

                return domain;
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }
        }


        public IList<TbPrRequisicionDetalle> GetAllReqDetalleById(IList<int> domain)
        {
            return context.TbPrRequisicionDetalle.Where(r => domain.Any(id => id == r.Id)).AsNoTracking().ToList();
        }

        public bool DeleteRD(IList<TbPrRequisicionDetalle> domain)
        {
            try
            {
                

                context.TbPrRequisicionDetalle.RemoveRange(domain);
                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");

                throw;
            }
        }




    }
}
