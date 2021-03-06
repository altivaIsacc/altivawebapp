﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
namespace AltivaWebApp.Services
{
   public interface ICamposPersonalizadosService
    {
        IList<TbCrCamposPersonalizados> GetCamposContacto(int idContacto);
        IList<TbCrCamposPersonalizados> GetCampos();
        TbCrCamposPersonalizados getById(int id);
        TbCrCamposPersonalizados Save(TbCrCamposPersonalizados domain);
        IList<TbCrCamposPersonalizados> GetAll();
        TbCrCamposPersonalizados Edit(TbCrCamposPersonalizados domain);
   
        void CrearCamposPersonalizados(IList<TbCrCamposPersonalizados> domain);
        TbCrCamposPersonalizados GetCPPorNombre(string nombre);
    }
}
