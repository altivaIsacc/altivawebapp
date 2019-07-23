using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbCpComprasDetalleServicio
    {
        public long IdCompraDetalle { get; set; }
        public long IdCompra { get; set; }
        public string Articulo { get; set; }
        public double Cantidad { get; set; }

        public long PrecioUnidad { get; set; }
        public double PorcDescuento { get; set; }
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
        public double TotalIsbase { get; set; }
        public double TotalIsdolar { get; set; }
        public double TotalIseuro { get; set; }
        public double TotalBase { get; set; }
        public double TotalDolar { get; set; }
        public double TotalEuro { get; set; }
        public int IdCategoriaGasto { get; set; }

        public virtual TbCpCategoriaGasto IdCategoriaGastoNavigation { get; set; }
        public virtual TbPrCompra IdCompraNavigation { get; set; }
        
    }
}
