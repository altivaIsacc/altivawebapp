using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.ViewModels
{
    public class CotizacionDetalleViewModels
    {
        public long IdCotizacionDetalle { get; set; }
        public long? IdInventario { get; set; }
        public double? PrecioBase { get; set; }
        public double? PrecioDolar { get; set; }
        public double? PrecioEuro { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public long? IdUsuarioCreador { get; set; }
        public double? SubTotalBase { get; set; }
        public double? SubTotalDolar { get; set; }
        public double? SubTotalEuro { get; set; }
        public double? SubTotalGravadoBase { get; set; }
        public double? SubTotalGravadoDolar { get; set; }
        public double? SubTotalGravadoEuro { get; set; }
        public double? SubTotalExcentoBase { get; set; }
        public double? SubTotalExcentoDolar { get; set; }
        public double? SubTotalExcentoEuro { get; set; }
        public double? PorcDescuento { get; set; }
        public double? TotalDescuentoBase { get; set; }
        public double? TotalDescuentoDolar { get; set; }
        public double? TotalDescuentoEuro { get; set; }
        public double? SubTotalGravadoNetoBase { get; set; }
        public double? SubTotalGravadoNetoDolar { get; set; }
        public double? SubTotalGravadoNetoEuro { get; set; }
        public double? SubTotalExcentoNetoBase { get; set; }
        public double? SubTotalExcentoNetoDolar { get; set; }
        public double? SubTotalExcentoNetoEuro { get; set; }
        public double MontoIvabase { get; set; }
        public double? MontoIvadolar { get; set; }
        public double? MontoIvaEuro { get; set; }
        public double? TotalBase { get; set; }
        public double? TotalDolar { get; set; }
        public double? TotalEuro { get; set; }
        public long? IdCotizacion { get; set; }
        public double? Cantidad { get; set; }

    }
}
