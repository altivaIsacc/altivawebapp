using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public interface IKardexMap
    {
        bool CreateKardexAM(TbPrAjuste ajuste, int idAjuste);
        bool CreateKardexDeletedAM(TbPrAjuste domain);
        bool CreateKardexCD(int idCompra);
        bool CreateKardexEliminarCD(TbPrCompra domain);
        bool CreateKardexCDSingle(int idCD);
        bool CreateKardexEliminarCDSingle(int idCD);
        bool CreateKardexRD(IList<TbPrRequisicionDetalle> rq, bool isDeteled);
    }
}
