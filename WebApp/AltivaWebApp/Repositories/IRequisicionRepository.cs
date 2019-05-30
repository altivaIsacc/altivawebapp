using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public interface IRequisicionRepository
    {
        TbPrRequisicion Save(TbPrRequisicion domain);
        TbPrRequisicion Update(TbPrRequisicion domain);
        TbPrRequisicion GetReqById(int id);
        TbPrRequisicion GetRequisicionWithDetails(int id);
        IList<TbPrRequisicionDetalle> GetAllRDByRequisicionId(int id);
        IList<TbPrRequisicionDetalle> SaveRD(IList<TbPrRequisicionDetalle> domain);
        void UpdateRD(IList<TbPrRequisicionDetalle> domain);
        bool DeleteRD(IList<TbPrRequisicionDetalle> domain);
        IList<TbPrRequisicion> GetAllWithDetails();
        IList<TbPrRequisicionDetalle> GetAllReqDetalleById(IList<int> domain);

    }
}
