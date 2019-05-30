using System;
using System.Collections.Generic;

namespace AltivaWebApp.Modelos
{
    public partial class TbReCategoriaMenu
    {
        public TbReCategoriaMenu()
        {
            TbReComplementoCategoriaMenu = new HashSet<TbReComplementoCategoriaMenu>();
        }

        public int IdCategoriaMenu { get; set; }
        public int IdUsuarioCreador { get; set; }
        public int IdUsuarioModificador { get; set; }
        public string Nombre { get; set; }
        public string Observacion { get; set; }
        public string Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public double PosicionX { get; set; }
        public double PosicionY { get; set; }
        public byte[] Imagen { get; set; }
        public string Color { get; set; }

        public virtual ICollection<TbReComplementoCategoriaMenu> TbReComplementoCategoriaMenu { get; set; }
    }
}
