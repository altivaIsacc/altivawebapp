using System;
using System.Collections.Generic;

namespace AltivaWebApp.Modelos
{
    public partial class TbFdCuentaDetalleServicioTarifa
    {
        public long Id { get; set; }
        public long IdCuentaEnCasa { get; set; }
        public long IdCuentaEnCasaDetalle { get; set; }
        public long IdServicio { get; set; }
        public double Tarifa { get; set; }
        public DateTime Fecha { get; set; }

        public virtual TbFdCuentaEnCasaDetalle IdCuentaEnCasaDetalleNavigation { get; set; }
        public virtual TbFdCuentaEnCasa IdCuentaEnCasaNavigation { get; set; }
        public virtual TbFdServicio IdServicioNavigation { get; set; }
    }
}
