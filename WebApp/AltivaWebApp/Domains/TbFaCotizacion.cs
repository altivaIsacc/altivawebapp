using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbFaCotizacion
    {
        public TbFaCotizacion()
        {
            TbFaCotizacionDetalle = new HashSet<TbFaCotizacionDetalle>();
        }

        public long IdCotizacion { get; set; }
        public DateTime? FechaCotizacion { get; set; }
        public long? IdCliente { get; set; }
        public string Estado { get; set; }
        public int? IdMoneda { get; set; }
        public long? IdVendedor { get; set; }
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
        public double? PorcDescuentoBase { get; set; }
        public double? TotalDescuentoBase { get; set; }
        public double? TotalDescuentoDolar { get; set; }
        public double? TotalDescuentoEuro { get; set; }
        public double? SubTotalGravadoNetoBase { get; set; }
        public double? SubTotalGravadoNetoDolar { get; set; }
        public double? SubTotalGravadoNetoEuro { get; set; }
        public double? SubTotalExcentoNetoBase { get; set; }
        public double? SubTotalExcentoNetoDolar { get; set; }
        public double? SubTotalExcentoNetoEuro { get; set; }
        public double? MontoIvabase { get; set; }
        public double? MontoIvadolar { get; set; }
        public double? MontoIvaeuro { get; set; }
        public double? TotalBase { get; set; }
        public double? TotalDolar { get; set; }
        public double? TotalEuro { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public double? TipoCambioDolar { get; set; }
        public double? TipoCambioEuro { get; set; }

        public virtual TbCrContacto IdClienteNavigation { get; set; }
        public virtual ICollection<TbFaCotizacionDetalle> TbFaCotizacionDetalle { get; set; }
    }
}
