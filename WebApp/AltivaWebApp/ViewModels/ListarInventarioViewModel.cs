using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.ViewModels
{
    public class ListarInventarioViewModel
    {
        public long IdInventario { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public double CantidadUnidad { get; set; }
        public double ExistenciaGeneral { get; set; }
        public bool Inactiva { get; set; }
        public long IdSubFamilia { get; set; }
        public string Abreviatura { get; set; }
        public double PrecioVentaFinal { get; set; }
        public string Simbolo { get; set; }
        public double ExistenciaMinima { get; set; }
        public double ExistenciaMaxima { get; set; }
        public double ExistenciaMedia { get; set; }
        public long IdBodega { get; set; }
        public long IdFamilia { get; set; }

    }

}
