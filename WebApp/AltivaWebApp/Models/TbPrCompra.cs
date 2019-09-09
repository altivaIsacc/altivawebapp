using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbPrCompra
    {
        public TbPrCompra()
        {
            TbCpComprasDetalleServicio = new HashSet<TbCpComprasDetalleServicio>();
            TbPrCompraDetalle = new HashSet<TbPrCompraDetalle>();
        }

        public long Id { get; set; }
        public DateTime FechaDocumento { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public long IdContacto { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int IdUsuario { get; set; }
        public int IdMoneda { get; set; }
        public double SubTotalGravadoBase { get; set; }
        public double SubTotalGravadoDolar { get; set; }
        public double SubTotalGravadoEuro { get; set; }
        public double SubTotalExcentoBase { get; set; }
        public double SubTotalExcentoDolar { get; set; }
        public double SubTotalExcentoEuro { get; set; }
        public double SubTotalGravadoNetoBase { get; set; }
        public double SubTotalGravadoNetoDolar { get; set; }
        public double SubTotalGravadoNetoEuro { get; set; }
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
        public bool EnCola { get; set; }

        public virtual TbCrContacto IdContactoNavigation { get; set; }
        public virtual ICollection<TbCpComprasDetalleServicio> TbCpComprasDetalleServicio { get; set; }
        public virtual ICollection<TbPrCompraDetalle> TbPrCompraDetalle { get; set; }
    }
}
