using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbPrInventarioBodega
    {
        public long Id { get; set; }
        public long IdInventario { get; set; }
        public long IdBodega { get; set; }
        public double ExistenciaMinima { get; set; }
        public double ExistenciaMaxima { get; set; }
        public double ExistenciaBodega { get; set; }
        public double CostoPromedioBodega { get; set; }
        public double SaldoBodega { get; set; }
        public double UltimoCostoBodega { get; set; }
        public double ExistenciaMedia { get; set; }

        public virtual TbPrBodega IdBodegaNavigation { get; set; }
        public virtual TbPrInventario IdInventarioNavigation { get; set; }
    }
}
