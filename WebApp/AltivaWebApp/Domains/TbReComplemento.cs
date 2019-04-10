using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbReComplemento
    {
        public TbReComplemento()
        {
            TbReComplementoCategoriaMenu = new HashSet<TbReComplementoCategoriaMenu>();
        }

        public int IdComplemento { get; set; }
        public string Tipo { get; set; }
        public int IdUsuarioCreador { get; set; }
        public int IdUsuarioModificador { get; set; }
        public int IdDescarga { get; set; }
        public string Nombre { get; set; }
        public string Observacion { get; set; }
        public string Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public double PosicionX { get; set; }
        public double PosicionY { get; set; }
        public byte[] Imagen { get; set; }
        public string Color { get; set; }
        public bool Gratis { get; set; }
        public double PrecioUnitarioVenta { get; set; }
        public double PrecioUnitarioVentaConImpuesto { get; set; }
        public bool TieneIs { get; set; }
        public bool TieneIv { get; set; }

        public virtual ICollection<TbReComplementoCategoriaMenu> TbReComplementoCategoriaMenu { get; set; }
    }
}
