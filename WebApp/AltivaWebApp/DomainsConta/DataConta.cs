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
    [Table("vs_SE_AsientosAnalitico")]
    public class AsientosAnalitico
    {
        [Key]
        public long IdDetalleAsientoContable { get; set; }
        public long IdAsientoContable { get; set; }
        public long IdPeriodoTrabajo { get; set; }
        public long IdCuentaContable { get; set; }
        public string CuentaContable { get; set; }
        public string Descripcion { get; set; }
        public string Asiento { get; set; }
        public int Estado { get; set; }
        public string TipoDocumento { get; set; }
        public string NumDocumento { get; set; }       
        public string Nota { get; set; }
        public bool Debe { get; set; }
        public bool Haber { get; set; }
        public double MontoColones { get; set; }
        public double MontoDolares { get; set; }
        public double MontoEuro { get; set; }
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
        public string CuentaContable { get; set; }
        public string Descripcion { get; set; }
        public short Nivel { get; set; }
        public string Notas { get; set; }
        public short IdTipoCuentaContable { get; set; }
        public long IdCuentaContablePadre { get; set; }
        public bool Movimiento { get; set; }
        public bool Inactivo { get; set; }
        public float DebitoBase { get; set; }
        public float CreditoBase { get; set; }
        public float SaldoBase { get; set; }
        public float DebitoDolar { get; set; }
        public float CreditoDolar { get; set; }
        public float SaldoDolar { get; set; }
        public float DebitoEuro { get; set; }
        public float CreditoEuro { get; set; }
        public float SaldoEuro { get; set; }
        public long IdPeriodoTrabajo { get; set; }
        public long IdPeriodoTrabajoResultado { get; set; }
        public long IdCuentaContable { get; set; }
    }

}
