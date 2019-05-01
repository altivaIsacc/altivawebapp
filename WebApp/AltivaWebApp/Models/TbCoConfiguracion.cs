using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbCoConfiguracion
    {
        public short IdConfiguracion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public long IdUsuario { get; set; }
        public long TamanoCuenta { get; set; }
        public short Nivel1 { get; set; }
        public short Nivel2 { get; set; }
        public short? Nivel3 { get; set; }
        public short? Nivel4 { get; set; }
        public short? Nivel5 { get; set; }
        public short? Nivel6 { get; set; }
        public short? Nivel8 { get; set; }
        public string Ejemplo { get; set; }
        public short? Nivel7 { get; set; }
        public string FechaDesde { get; set; }
        public string FechaHasta { get; set; }
    }
}
