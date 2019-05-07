using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.ViewModels
{
    public class OrdenDetalleViewModel
    {

        public long Id { get; set; }
        public long IdOrden { get; set; }
        public long IdInventario { get; set; }
        public string NombreInventario { get; set; }
        public int IdMonedaOD { get; set; }
        public double Cantidad { get; set; }
        public double Precio { get; set; }
        public double SubTotalGrabado { get; set; }
        public double SubTotalExcento { get; set; }
        public double SubTotalNeto { get; set; }
        public double PorcIva { get; set; }
        public double PorcIs { get; set; }
        public double PorcDesc { get; set; }
        public double TotalIva { get; set; }
        public double TotalIs { get; set; }
        public double TotalDescuento { get; set; }
        public double Total { get; set; }

    }
}
