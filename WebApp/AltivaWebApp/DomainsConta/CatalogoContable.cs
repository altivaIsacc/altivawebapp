using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AltivaWebApp.DomainsConta
{
    [Table("tb_CO_CuentaContable")]
    public class CatalogoContable
    {
        [Key]
        public long id { get; set; }
        public string CuentaContable { get; set; }
        public string Descripcion { get; set; }
        public short Nivel { get; set; }
        public string Tipo { get; set; }
        public int PARENTID { get; set; }
        public string CuentaMadre { get; set; }
        public string DescCuentaMadre { get; set; }
        public bool Movimiento { get; set; }
        public bool Evaluacion { get; set; }
        public bool Inactivo { get; set; }
        public string Notas { get; set; } 

    }
}

