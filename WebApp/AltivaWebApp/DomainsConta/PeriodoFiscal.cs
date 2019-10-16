using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AltivaWebApp.DomainsConta
{
    [Table("tb_CO_PeriodoFiscal")]
    public class PeriodoFiscal
    {
        [Key]
        public long IdPeriodoFiscal { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public string Estado { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Nombre { get; set; }
    }
}
