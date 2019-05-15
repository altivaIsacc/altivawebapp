using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbPrCompra
    {
        public TbPrCompra()
        {
            TbPrCompraDetalle = new HashSet<TbPrCompraDetalle>();
        }

        public long Id { get; set; }
        public DateTime FechaDocumento { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public long IdProveedor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int IdUsuario { get; set; }
        public int IdMoneda { get; set; }
        public double SubTotalGrabadoBase { get; set; }
        public double SubTotalGrabadoDolar { get; set; }
        public double SubTotalGrabadoEuro { get; set; }
        public double SubTotalExcentoBase { get; set; }
        public double SubTotalExcentoDolar { get; set; }
        public double SubTotalExcentoEuro { get; set; }
        public double SubTotalGrabadoNetoBase { get; set; }
        public double SubTotalGrabadoNetoDolar { get; set; }
        public double SubTotalGrabadoNetoEuro { get; set; }
        public double SubTotalExcentoNetoBase { get; set; }
        public double SubTotalExcentoNetoDolar { get; set; }
        public double SubTotalExcentoNetoEuro { get; set; }
        public double TotalDescuentoBase { get; set; }
        public double TotalDescuentoDolar { get; set; }
        public double TotalDescuentoEuro { get; set; }
        public double TotalIvabase { get; set; }
        public double TotalIvadolar { get; set; }
        public double TotalIvaeuro { get; set; }
        public double TotalFabase { get; set; }
        public double TotalFadolar { get; set; }
        public double TotalFaeuro { get; set; }
        public double TotalBase { get; set; }
        public double TotalDolar { get; set; }
        public double TotalEuro { get; set; }
        public bool Anulado { get; set; }
        public bool Borrador { get; set; }
        public double TipoCambioDolar { get; set; }
        public double TipoCambioEuro { get; set; }
        public virtual TbCrContacto IdContactoNavigation { get; set; }
        public virtual ICollection<TbPrCompraDetalle> TbPrCompraDetalle { get; set; }
    }
}
