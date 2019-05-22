using System;
using System.Collections.Generic;

namespace AltivaWebApp.Modelos
{
    public partial class TbSeAuditoriaInterna
    {
        public long Id { get; set; }
        public string TipoRegistro { get; set; }
        public long IdRegistro { get; set; }
        public string DescripcionCambio { get; set; }
        public DateTime Fecha { get; set; }
        public long IdUsuario { get; set; }
        public string EstacionTrabajo { get; set; }
    }
}
