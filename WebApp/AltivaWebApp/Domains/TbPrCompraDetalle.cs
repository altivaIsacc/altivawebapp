using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbPrCompraDetalle
    {
        public long Id { get; set; }
        public long IdCompra { get; set; }
        public long IdInventario { get; set; }
        public double Cantidad { get; set; }
        public double PrecioUnitario { get; set; }
        public double PorcIva { get; set; }
        public double PorcDescuento { get; set; }
        public double PorcFa { get; set; }
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
        public double TotalBase { get; set; }
        public double TotalDolar { get; set; }
        public double TotalEuro { get; set; }
        public double TotalFabase { get; set; }
        public double TotalFadolar { get; set; }
        public double TotalFaeuro { get; set; }
        public long IdBodega { get; set; }

        public virtual TbPrBodega IdBodegaNavigation { get; set; }
        public virtual TbPrCompra IdCompraNavigation { get; set; }
        public virtual TbPrInventario IdInventarioNavigation { get; set; }
    }
}
