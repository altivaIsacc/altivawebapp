using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbPrPreciosInventariosAutomaticos
    {
        public long Id { get; set; }
        public long IdUsuarioCreador { get; set; }
        public long IdUsuarioActualiza { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public string Tipo { get; set; }
        public bool Anulado { get; set; }
        public bool Aplicado { get; set; }
    }
}
