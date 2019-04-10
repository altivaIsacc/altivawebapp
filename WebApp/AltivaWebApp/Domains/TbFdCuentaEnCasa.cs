using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbFdCuentaEnCasa
    {
        public TbFdCuentaEnCasa()
        {
            TbFdCuentaDetalleServicioTarifa = new HashSet<TbFdCuentaDetalleServicioTarifa>();
            TbFdCuentaEnCasaDetalle = new HashSet<TbFdCuentaEnCasaDetalle>();
            TbFdCuentaEnCasaPagoCliente = new HashSet<TbFdCuentaEnCasaPagoCliente>();
            TbFdCuentaEnCasaPuntoDeVenta = new HashSet<TbFdCuentaEnCasaPuntoDeVenta>();
            TbFdFacturacion = new HashSet<TbFdFacturacion>();
        }

        public long Id { get; set; }
        public long IdReserva { get; set; }
        public long IdCliente { get; set; }
        public long IdHuesped { get; set; }
        public bool Facturada { get; set; }
        public bool Abierta { get; set; }
        public bool ClientePrincipal { get; set; }
        public string Placa { get; set; }
        public string Nota { get; set; }
        public long IdHabitacion { get; set; }
        public string HoraEntrada { get; set; }
        public string HoraSalida { get; set; }
        public long IdCuentaMadre { get; set; }
        public DateTime FechaCreacion { get; set; }

        public virtual TbFdCliente IdClienteNavigation { get; set; }
        public virtual TbFdHabitacion IdHabitacionNavigation { get; set; }
        public virtual TbFdReservacion IdReservaNavigation { get; set; }
        public virtual ICollection<TbFdCuentaDetalleServicioTarifa> TbFdCuentaDetalleServicioTarifa { get; set; }
        public virtual ICollection<TbFdCuentaEnCasaDetalle> TbFdCuentaEnCasaDetalle { get; set; }
        public virtual ICollection<TbFdCuentaEnCasaPagoCliente> TbFdCuentaEnCasaPagoCliente { get; set; }
        public virtual ICollection<TbFdCuentaEnCasaPuntoDeVenta> TbFdCuentaEnCasaPuntoDeVenta { get; set; }
        public virtual ICollection<TbFdFacturacion> TbFdFacturacion { get; set; }
    }
}
