using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbPrTomaFisicas
    {
        public long Id { get; set; }
        public string Observacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public DateTime Fecha { get; set; }
        public bool Anulada { get; set; }
        public bool Aplicada { get; set; }
        public long IdUsuarioCreador { get; set; }
        public long IdUsuarioModificador { get; set; }
        public long IdBodega { get; set; }
    }
}
