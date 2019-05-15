using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.ViewModels
{
    public class CompraDetalleViewModel
    {
        public long Id { get; set; }
        public long IdCompra { get; set; }
        public long IdInventario { get; set; }
        public double Cantidad { get; set; }
        public double PrecioUnitario { get; set; }
        public double PorcDescuento { get; set; }
        public double SubTotalGrabado { get; set; }
        public double SubTotalExcento { get; set; }
        public double SubTotalGrabadoNeto { get; set; }
        public double SubTotalExcentoNeto { get; set; }
        public double TotalDescuento { get; set; }
        public double TotalIva { get; set; }
        public double TotalIs { get; set; }
        public double Total { get; set; }
        public double PorcFa { get; set; }
        public double TotalFa { get; set; }
        public long IdBodega { get; set; }
        public int IdMonedaCD { get; set; }



    }
}
