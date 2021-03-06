﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.GEDomain;
using AltivaWebApp.ViewModels;

namespace AltivaWebApp.Services
{
   public interface ICajaService
    {
        IList<TbFaCaja> GetInfoCaja(FiltroFechaViewModel _filtroFecha, long _filtroNum, long _filtroPV);
        TbFaCaja Save(TbFaCaja domain);
        TbFaCaja Update(TbFaCaja domain);
        IList<TbFaCaja> GetAllCajas();
        TbFaCaja GetCajaById(int id);
        IList<TbFaCajaArqueo> GetAllById(int id);
        bool UpdateCajaAperturaDenominacion(IList<TbFaCajaAperturaDenominacion> domain);
        bool UpdateCajaArqueoDenominacion(IList<TbFaCajaArqueoDenominacion> domain);
        bool UpdateCajaArqueo(IList<TbFaCajaArqueo> domain);
        bool UpdateCajaCierre(IList<TbFaCajaCierre> domain);
        TbFaCajaAperturaDenominacion SaveCajaAperturaDenominacion(TbFaCajaAperturaDenominacion domain);
        IList<TbFaCajaAperturaDenominacion> GetAllCajaAperturaDenominacionByIdCaja(int id);
        IList<TbFaCajaArqueoDenominacion> GetAllCajaArqueoDenominacionByIdCaja(int id);
        IList<TbFaCajaArqueo> GetAllCajaArqueoByIdCaja(int id);
        IList<TbFaCajaCierre> GetAllCajaCierreByIdCaja(int id);

    }
}
