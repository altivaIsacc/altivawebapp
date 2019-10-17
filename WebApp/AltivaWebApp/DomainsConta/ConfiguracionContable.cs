using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AltivaWebApp.DomainsConta
{
    [Table("tb_CO_Configuracion")]
    public class ConfiguracionContable
    {
        [Key]
        public short IdConfiguracion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public long IdUsuario { get; set; }
        public long TamanoCuenta  { get; set; }
        public short Nivel1 { get; set; }
        public short Nivel2 { get; set; }
        public short Nivel3 { get; set; }
        public short Nivel4 { get; set; }
        public short Nivel5 { get; set; }
        public short Nivel6 { get; set; }
        public short Nivel7 { get; set; }
        public short Nivel8 { get; set; }
        public string Ejemplo { get; set; }
    }
}