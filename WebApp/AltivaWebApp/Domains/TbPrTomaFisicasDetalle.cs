using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbPrTomaFisicasDetalle
    {
        public long Id { get; set; }
        public long IdTomaFisica { get; set; }
        public long IdInventario { get; set; }
        public double Cantidad { get; set; }
        public double ExistenciaEnBodega { get; set; }
    }
}
