using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbPrRequisicionInventario
    {
        public long IdRequisicionInventario { get; set; }
        public long IdRequisicion { get; set; }
        public int IdBodega { get; set; }
        public long IdInventario { get; set; }
        public string CodigoArticulo { get; set; }
        public string Descripcion { get; set; }
        public double Cantidad { get; set; }
        public double CostoUnitario { get; set; }
        public double CostoTotal { get; set; }

        public virtual TbPrRequisiciones IdRequisicionNavigation { get; set; }
    }
}
