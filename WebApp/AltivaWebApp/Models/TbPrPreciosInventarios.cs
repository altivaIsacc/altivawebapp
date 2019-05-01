using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbPrPreciosInventarios
    {
        public long Id { get; set; }
        public string Observacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public DateTime Fecha { get; set; }
        public long IdUsuarioCreador { get; set; }
        public long IdUsuarioModifica { get; set; }
        public string Tipo { get; set; }
        public bool Anulado { get; set; }
        public bool Aplicado { get; set; }
    }
}
