using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AltivaWebApp.DomainsConta
{
    [Table("tb_CO_PeriodoTrabajo")]
    public class PeriodoTrabajo
    {
        [Key]
        public long IdPeriodoTrabajo { get; set; }
        public long IdPeriodoFiscal { get; set; }
        public string Estado { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
    }
}
