using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbFdReservacion
    {
        public TbFdReservacion()
        {
            TbFdArchivosAdjuntos = new HashSet<TbFdArchivosAdjuntos>();
            TbFdCuentaEnCasa = new HashSet<TbFdCuentaEnCasa>();
            TbFdDesgloceReservaNotas = new HashSet<TbFdDesgloceReservaNotas>();
            TbFdDocumentos = new HashSet<TbFdDocumentos>();
            TbFdReservacionHospedaje = new HashSet<TbFdReservacionHospedaje>();
            TbFdReservacionServicio = new HashSet<TbFdReservacionServicio>();
        }

        public long Id { get; set; }
        public DateTime FechaInclusion { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaSalida { get; set; }
        public string HoraEntrada { get; set; }
        public string HoraSalida { get; set; }
        public long Tipo { get; set; }
        public long IdOrigenReserva { get; set; }
        public long IdClientePrincipal { get; set; }
        public long IdClienteFactura { get; set; }
        public string Estado { get; set; }
        public string NombreCliente { get; set; }
        public bool Bloquear { get; set; }
        public bool Facturada { get; set; }
        public long IdUsuario { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string Nota { get; set; }
        public long IdPagoComision { get; set; }
        public double MontoComision { get; set; }
        public bool ComisionPagada { get; set; }
        public bool FacturaEmpresa { get; set; }
        public bool? EsAllotment { get; set; }
        public int DiasCorte { get; set; }
        public long IdTipoHabitacion { get; set; }
        public int CantidadHabitaciones { get; set; }
        public bool? EnMantenimiento { get; set; }
        public string NotaInterna { get; set; }

        public virtual TbFdCliente IdClienteFacturaNavigation { get; set; }
        public virtual TbFdOrigenReserva IdOrigenReservaNavigation { get; set; }
        public virtual TbFdPagoComision IdPagoComisionNavigation { get; set; }
        public virtual ICollection<TbFdArchivosAdjuntos> TbFdArchivosAdjuntos { get; set; }
        public virtual ICollection<TbFdCuentaEnCasa> TbFdCuentaEnCasa { get; set; }
        public virtual ICollection<TbFdDesgloceReservaNotas> TbFdDesgloceReservaNotas { get; set; }
        public virtual ICollection<TbFdDocumentos> TbFdDocumentos { get; set; }
        public virtual ICollection<TbFdReservacionHospedaje> TbFdReservacionHospedaje { get; set; }
        public virtual ICollection<TbFdReservacionServicio> TbFdReservacionServicio { get; set; }
    }
}
