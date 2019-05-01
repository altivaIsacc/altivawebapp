using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbFdCliente
    {
        public TbFdCliente()
        {
            TbFdAuditoriaIngresos = new HashSet<TbFdAuditoriaIngresos>();
            TbFdAuditoriaRooming = new HashSet<TbFdAuditoriaRooming>();
            TbFdCuentaEnCasa = new HashSet<TbFdCuentaEnCasa>();
            TbFdFacturacion = new HashSet<TbFdFacturacion>();
            TbFdPagoCliente = new HashSet<TbFdPagoCliente>();
            TbFdPagoComision = new HashSet<TbFdPagoComision>();
            TbFdReservacion = new HashSet<TbFdReservacion>();
        }

        public long Id { get; set; }
        public long IdTipoCliente { get; set; }
        public bool EsEmpresa { get; set; }
        public string Nombre { get; set; }
        public string NombreJuridico { get; set; }
        public string Identificacion { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public string Telefono3 { get; set; }
        public string Fax1 { get; set; }
        public string Fax2 { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string Direccion1 { get; set; }
        public string Direccion2 { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Observaciones { get; set; }
        public int IdPais { get; set; }
        public string WebSite1 { get; set; }
        public string WebSite2 { get; set; }
        public string OtroContacto { get; set; }
        public string Contacto { get; set; }
        public string TelefonoContacto { get; set; }
        public string EmailContacto { get; set; }
        public long IdContrato { get; set; }
        public bool TieneCredito { get; set; }
        public double MaximoCredito { get; set; }
        public int PlazoDiasCredito { get; set; }
        public string ReferenciaCrediticia { get; set; }
        public bool OmitirRestriccionCredito { get; set; }
        public string NumTarjetaGarantia { get; set; }
        public string VenceTarjetaGarantia { get; set; }
        public string DigitosTarjetaGarantia { get; set; }
        public bool Inactivo { get; set; }
        public bool ListaNegra { get; set; }
        public long IdReferencia { get; set; }
        public string TipoReferencia { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Exonerado { get; set; }
        public bool Comisionista { get; set; }
        public double PorcentajeCom { get; set; }
        public string TipoId { get; set; }

        public virtual TbFdContrato IdContratoNavigation { get; set; }
        public virtual TbFdTipoCliente IdTipoClienteNavigation { get; set; }
        public virtual ICollection<TbFdAuditoriaIngresos> TbFdAuditoriaIngresos { get; set; }
        public virtual ICollection<TbFdAuditoriaRooming> TbFdAuditoriaRooming { get; set; }
        public virtual ICollection<TbFdCuentaEnCasa> TbFdCuentaEnCasa { get; set; }
        public virtual ICollection<TbFdFacturacion> TbFdFacturacion { get; set; }
        public virtual ICollection<TbFdPagoCliente> TbFdPagoCliente { get; set; }
        public virtual ICollection<TbFdPagoComision> TbFdPagoComision { get; set; }
        public virtual ICollection<TbFdReservacion> TbFdReservacion { get; set; }
    }
}
