﻿using System;
using System.Collections.Generic;

namespace AltivaWebApp.Modelos
{
    public partial class TbPrBodega
    {
        public TbPrBodega()
        {
            TbPrAjuste = new HashSet<TbPrAjuste>();
            TbPrCompraDetalle = new HashSet<TbPrCompraDetalle>();
            TbPrInventarioBodega = new HashSet<TbPrInventarioBodega>();

            TbPrTrasladoIdBodegaDestinoNavigation = new HashSet<TbPrTraslado>();
            TbPrTrasladoIdBodegaOrigenNavigation = new HashSet<TbPrTraslado>();
        }

        public long Id { get; set; }
        public string Nombre { get; set; }
        public bool? Produccion { get; set; }
        public bool? Almacenamiento { get; set; }
        public bool? Consignacion { get; set; }
        public bool? SuministrosInternos { get; set; }
        public bool? Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public long UsuarioEncargado { get; set; }
        public string Observaciones { get; set; }

        public virtual ICollection<TbPrAjuste> TbPrAjuste { get; set; }
        public virtual ICollection<TbPrCompraDetalle> TbPrCompraDetalle { get; set; }
        public virtual ICollection<TbPrInventarioBodega> TbPrInventarioBodega { get; set; }
        public virtual ICollection<TbPrTraslado> TbPrTrasladoIdBodegaDestinoNavigation { get; set; }
        public virtual ICollection<TbPrTraslado> TbPrTrasladoIdBodegaOrigenNavigation { get; set; }
    }
}
