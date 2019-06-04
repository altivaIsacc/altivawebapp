using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbFaCotizacionDetalle
    {
        public long IdCotizacionDetalle { get; set; }
        public long? IdInventario { get; set; }
        public double? PrecioColon { get; set; }
        public double? PrecioDolar { get; set; }
        public double? PrecioEuro { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public long? IdUsuarioCreador { get; set; }
        public double? SubTotalColon { get; set; }
        public double? SubTotalDolar { get; set; }
        public double? SubTotalEuro { get; set; }
        public double? SubTotalGravadoColon { get; set; }
        public double? SubTotalGravadoDolar { get; set; }
        public double? SubTotalGravadoEuro { get; set; }
        public double? SubTotalExcentoColon { get; set; }
        public double? SubTotalExcentoDolar { get; set; }
        public double? SubTotalExcentoEuro { get; set; }
        public double? PorcDescuento { get; set; }
        public double? TotalDescuentoColon { get; set; }
        public double? TotalDescuentoDolar { get; set; }
        public double? TotalDescuentoEuro { get; set; }
        public double? SubTotalGravadoNetoColon { get; set; }
        public double? SubTotalGravadoNetoDolar { get; set; }
        public double? SubTotalGravadoNetoEuro { get; set; }
        public double? SubTotalExcentoNetoColon { get; set; }
        public double? SubTotalExcentoNetoDolar { get; set; }
        public double? SubTotalExcentoNetoEuro { get; set; }
        public double? MontoIvacolon { get; set; }
        public double? MontoIvadolar { get; set; }
        public double? TotalColon { get; set; }
        public double? TotalDolar { get; set; }
        public double? TotalEuro { get; set; }
    }
}
