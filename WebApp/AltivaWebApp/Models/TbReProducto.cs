using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbReProducto
    {
        public int IdProducto { get; set; }
        public int? IdDescarga { get; set; }
        public int IdCategoriaMenu { get; set; }
        public int IdUsuarioCreador { get; set; }
        public int IdUsuarioModificador { get; set; }
        public bool EsServicio { get; set; }
        public string TipoPrecio { get; set; }
        public string Nombre { get; set; }
        public string Estado { get; set; }
        public double PrecioUnitarioVenta { get; set; }
        public double PrecioUnitarioVentaConImpuesto { get; set; }
        public bool TieneIs { get; set; }
        public bool TieneIv { get; set; }
        public double PosicionX { get; set; }
        public double PosicionY { get; set; }
        public bool Imprime { get; set; }
        public string Impresora { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string Color { get; set; }
        public byte[] Imagen { get; set; }
        public bool EligeMod { get; set; }
        public bool EligeAcom { get; set; }
        public int MaxAcom { get; set; }
        public bool PermiteMedio { get; set; }
        public bool PorPeso { get; set; }
    }
}
