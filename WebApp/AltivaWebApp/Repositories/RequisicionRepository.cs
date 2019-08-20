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

        public TbPrRequisicion GetReqById(int id)
        {
            return context.TbPrRequisicion.FirstOrDefault(r => r.Id == id);//.Include(r => r.TbPrRequisicionDetalle)
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

        public IList<TbPrRequisicionDetalle> SaveRD(IList<TbPrRequisicionDetalle> domain)
        {
            try
            {
                context.TbPrRequisicionDetalle.AddRange(domain);
                context.SaveChanges();

                return domain;
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }
        }

        public void UpdateRD(IList<TbPrRequisicionDetalle> domain)
        {
            try
            {
                context.TbPrRequisicionDetalle.UpdateRange(domain);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");

                throw;
            }
        }

        public IList<TbPrRequisicionDetalle> GetAllReqDetalleById(IList<int> domain)
        {
            return context.TbPrRequisicionDetalle.Where(r => domain.Any(id => id == r.Id)).ToList();
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
