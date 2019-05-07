using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbPrOrdenDetalle
    {
        public long Id { get; set; }
        public long IdOrden { get; set; }
        public long IdInventario { get; set; }
        public string NombreInventario { get; set; }
        public double Cantidad { get; set; }
        public double PrecioBase { get; set; }
        public double PrecioDolar { get; set; }
        public double PrecioEuro { get; set; }
        public double SubTotalGrabadoBase { get; set; }
        public double SubTotalGrabadoDolar { get; set; }
        public double SubTotalGrabadoEuro { get; set; }
        public double SubTotalExcentoBase { get; set; }
        public double SubTotalExcentoDolar { get; set; }
        public double SubTotalExcentoEuro { get; set; }
        public double SubTotalNetoBase { get; set; }
        public double SubTotalNetoDolar { get; set; }
        public double SubTotalNetoEuro { get; set; }
        public double PorcIva { get; set; }
        public double PorcIs { get; set; }
        public double TotalIvabase { get; set; }
        public double TotalIvadolar { get; set; }
        public double TotalIvaeuro { get; set; }
        public double TotalIsbase { get; set; }
        public double TotalIsdolar { get; set; }
        public double TotalIseuro { get; set; }
        public double TotalBase { get; set; }
        public double TotalDolar { get; set; }
        public double TotalEuro { get; set; }
        public double PorcDesc { get; set; }
        public double TotalDescuentoBase { get; set; }
        public double TotalDescuentoDolar { get; set; }
        public double TotalDescuentoEuro { get; set; }

        public virtual TbPrInventario IdInventarioNavigation { get; set; }
        public virtual TbPrOrden IdOrdenNavigation { get; set; }
    }
}
