using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.ViewModels
{
    public class FacturaDetalleViewModel
    {
        public long Id { get; set; }
        public long IdFactura { get; set; }
        public long IdInventario { get; set; }
        public int IdMonedaFD { get; set; }
        public double Cantidad { get; set; }
        public double Precio { get; set; }
        public double PorcIva { get; set; }
        public double PorcDescuento { get; set; }
        public DateTime FechaCreacion { get; set; }
        public long IdUsuarioCreador { get; set; }
        public double SubTotal { get; set; }
        public double SubTotalGravado { get; set; }
        public double SubTotalExcento { get; set; }
        public double SubTotalGravadoNeto { get; set; }
        public double SubTotalExcentoNeto { get; set; }
        public double MontoDescuento { get; set; }
        public double MontoIva { get; set; }
        public double Total { get; set; }
        public DateTime FechaVencimiento { get; set; }
    }
}
