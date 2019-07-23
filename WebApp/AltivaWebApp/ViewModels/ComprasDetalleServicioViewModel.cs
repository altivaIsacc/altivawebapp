using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.ViewModels
{
    public class ComprasDetalleServicioViewModel
    {
        public long IdCompraDetalle { get; set; }
        public long IdCompra { get; set; }
        public string Articulo { get; set; }
        public double Cantidad { get; set; }

        public long PrecioUnidad { get; set; }
        public double PorcDescuento { get; set; }
        public double SubTotalGravado { get; set; }
        public double SubTotalExcento { get; set; }
        public double SubTotalGravadoNeto { get; set; }
        public double SubTotalExcentoNeto { get; set; }
        public double TotalDescuento { get; set; }
        public double TotalIva { get; set; }
        public double Total { get; set; }
        public double TotalIs{ get; set; }
       public int IdCategoriaGasto { get; set; }
        public int IdMonedaCDS { get; set; }



    }
}
