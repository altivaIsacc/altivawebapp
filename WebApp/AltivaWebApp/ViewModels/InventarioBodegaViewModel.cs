using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.ViewModels
{
    public class InventarioBodegaViewModel
    {
        
        public long IdInventario { get; set; }
        public long IdBodega { get; set; }
        public double ExistenciaMinima { get; set; }
        public double ExistenciaMaxima { get; set; }
        public double ExistenciaBodega { get; set; }
        public double CostoPromedioBodega { get; set; }
        public double SaldoBodega { get; set; }
        public double UltimoCostoBodega { get; set; }
        public double ExistenciaMedia { get; set; }
    }
}
