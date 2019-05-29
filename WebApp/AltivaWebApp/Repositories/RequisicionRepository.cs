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

        public IList<TbPrRequisicionDetalle> GetAllRDByRequisicionId(int id)
        {
            try
            {
                return context.TbPrRequisicionDetalle.Where(r => r.IdRequisicionNavigation.Id == id).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void SaveRD(IList<TbPrRequisicionDetalle> domain)
        {
            try
            {
                context.TbPrRequisicionDetalle.AddRange(domain);
                context.SaveChanges(); 
            }
            catch (Exception)
            {               
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
            catch (Exception)
            {

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
            catch (Exception)
            {

                throw;
            }
        }




    }
}
