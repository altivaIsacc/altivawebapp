using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbSeConfiguracion
    {
        public long IdConfiguracion { get; set; }
        public string NombreEmpresa { get; set; }
        public string PersonaJuridica { get; set; }
        public string CedulaJuridica { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public string Fax1 { get; set; }
        public string Fax2 { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string Web { get; set; }
        public byte[] Logo { get; set; }
        public double ImpuestoVenta { get; set; }
        public double ImpuestoServicio { get; set; }
        public bool SinContabilidad { get; set; }
        public int CodigoMonedaTarifas { get; set; }
        public bool AsignarHabitacionObligatorio { get; set; }
        public bool PreguntaAsignarHabitacion { get; set; }
        public string ReservaTentativa { get; set; }
        public string ReservaConfirmada { get; set; }
        public string ReservaEnCasa { get; set; }
        public string ReservaFacturada { get; set; }
        public string Alottemets { get; set; }
        public string EnMantenimiento { get; set; }
        public int DiasConfirmarReservar { get; set; }
        public string Direccion { get; set; }
        public int IdLlamadaInternacional { get; set; }
        public int IdLlamadaNacional { get; set; }
        public int IdLlamadaCelular { get; set; }
        public string RutaLlamada { get; set; }
        public string CodigoPostal { get; set; }
        public bool JustificaPagosParciales { get; set; }
        public int CodigoMonedaFactura { get; set; }
        public string Version { get; set; }
        public string NumeroScript { get; set; }
        public long CodigoNoShow { get; set; }
        public long IdBodegaDescarga { get; set; }
        public bool UtilizaTipoCompra { get; set; }
    }
}
