using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbReDescargaDetalle
    {
        public int IdDetalle { get; set; }
        public int IdDescarga { get; set; }
        public int IdBodega { get; set; }
        public int IdReferencia { get; set; }
        public int IdUnidadMedida { get; set; }
        public double Cantidad { get; set; }
        public double CostoTotal { get; set; }
        public double CostoUnitario { get; set; }
        public double Factor { get; set; }
        public string TipoReferencia { get; set; }

        public virtual TbReDescarga IdDescargaNavigation { get; set; }
    }
}
