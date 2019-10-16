using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Services
{
    public interface IRequisicionService
    {
        TbPrRequisicion Save(TbPrRequisicion domain);
        TbPrRequisicion Update(TbPrRequisicion domain);
        TbPrRequisicion GetReqById(long id); // este
        TbPrRequisicion GetRequisicionWithDetails(int id);
        IList<TbPrRequisicionDetalle> GetAllRDByRequisicionId(int id);
        IList<TbPrRequisicionDetalle> SaveOrUpdateRD(IList<TbPrRequisicionDetalle> domain);
        bool DeleteRD(IList<TbPrRequisicionDetalle> domain);
        IList<TbPrRequisicion> GetAllWithDetails();
        IList<TbPrRequisicionDetalle> GetAllReqDetalleById(IList<int> domain);
    }
}
