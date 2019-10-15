using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AltivaWebApp.DomainsConta
{
    [Table("vs_SE_Moneda")]
    public class Moneda
    {
        [Key]
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public bool Activa { get; set; }
        public double ValorCompra { get; set; }
        public double ValorVenta { get; set; }
        public string Simbolo { get; set; }
    }
    [Table("vs_SE_Usuario")]
    public class Usuario
    {
        [Key]
        public long Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Estado { get; set; }
        public string Iniciales { get; set; }
        public string Contrasena { get; set; }
        public DateTime FechaMod { get; set; }
        public long Id_Usuario { get; set; }
        public string Correo { get; set; }
        public string Avatar { get; set; }
    }
    [Table("tb_CO_TiposDocumentos")]
    public class TiposDocumentosConta
    {
        [Key]
        public long IdTipoDocumento { get; set; }
        public string Descripcion { get; set; }
        public string Abreviatura { get; set; }
        public bool Automatico { get; set; }
    }
    [Table("vs_CO_ResultadoPeriodo")]
    public class ResultadoPeriodo
    {
        [Key]
        public long IdTrabajoResultado { get; set; }
                public long IdPeriodoTrabajo { get; set; }
        public long IdCuentaContable { get; set; }
        public float DebitoBase { get; set; }
        public float CreditoBase { get; set; }
        public float SaldoBase { get; set; }
        public float DebitoDolar { get; set; }
        public float CreditoDolar { get; set; }
        public float SaldoDolar { get; set; }
        public float DebitoEuro {get; set;}
        public float CreditoEuro {get; set;}
        public float SaldoEuro {get; set;}
        public string CuentaContable{get; set;}
        public string Descripcion{get;set;}
        public string Nivel {get;set;}
        public string Notas {get;set;}
        public Boolean Movimiento {get;set;}
        public Boolean Inactivo {get;set;}
    }
}
