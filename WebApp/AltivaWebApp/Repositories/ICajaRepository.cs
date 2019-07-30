﻿using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
   public interface ICajaRepository
    {
        IList<TbFaCaja> GetInfoCaja();
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
