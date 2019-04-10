using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbFdConfiguracionCorreo
    {
        public long Id { get; set; }
        public string InformeEnviar { get; set; }
        public string InformeCopiarA { get; set; }
        public string ServidorSalida { get; set; }
        public string AsuntoTarjetaConfirmar { get; set; }
        public string SaludoTarjetaConfirmar { get; set; }
        public string DespedidaTarjetaConfirmar { get; set; }
        public string TarjetaConfirmarCopiarA { get; set; }
        public string AuditoriaEnviar { get; set; }
        public string AuditoriaCopiarA { get; set; }
        public string AlertasEnviar { get; set; }
        public string AlertasCopiarA { get; set; }
    }
}
