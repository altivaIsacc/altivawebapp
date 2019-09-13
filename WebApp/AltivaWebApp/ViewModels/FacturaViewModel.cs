using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.ViewModels
{
    public class FacturaViewModel
    {
        public long Id { get; set; }
        public byte Tipo { get; set; }
        public long Consecutivo { get; set; }
        public DateTime FechaFactura { get; set; }
        public long IdCliente { get; set; }
        public long IdPuntoVenta { get; set; }
        public string Estado { get; set; }
        public byte IdMoneda { get; set; }
        public long IdVendedor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public long IdUsuarioCreador { get; set; }
        public double SubTotal { get; set; }
        public double SubTotalGravado { get; set; }
        public double SubTotalExcento { get; set; }
        public double PorcDescuento { get; set; }
        public double TotalDescuento { get; set; }
        public double SubTotalGravadoNeto { get; set; }
        public double SubTotalExcentoNeto { get; set; }
        public double MontoIva { get; set; }
        public double MontoExoneracion { get; set; }
        public double Total { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public double TipoCambioDolar { get; set; }
        public double TipoCambioEuro { get; set; }
        public bool EnCola { get; set; }

        public IList<FacturaDetalleViewModel> FacturaDetalle;
    }
}
