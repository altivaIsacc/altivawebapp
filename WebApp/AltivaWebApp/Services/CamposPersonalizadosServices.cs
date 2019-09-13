using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.Repositories;
using AltivaWebApp.ViewModels;

namespace AltivaWebApp.Services
{
    public class CamposPersonalizadosServices : ICamposPersonalizadosService
    {
        public ICamposPersonalizadosRepository pIcamposPersonalizados;
        public CamposPersonalizadosServices(ICamposPersonalizadosRepository pIcamposPersonalizados)
        {
            this.pIcamposPersonalizados = pIcamposPersonalizados;
        }

        public void CrearCamposPersonalizados(IList<TbCrCamposPersonalizados> domain)
        {
             this.pIcamposPersonalizados.CrearCamposPersonalizados(domain);
        }

        public TbCrCamposPersonalizados Edit(TbCrCamposPersonalizados domain)
        {
            return this.pIcamposPersonalizados.Update(domain);
        }

        public IList<TbCrCamposPersonalizados> GetCamposContacto(int idContacto)
        {
            return this.pIcamposPersonalizados.GetCampos(idContacto);
        }

        public IList<TbCrCamposPersonalizados> GetAll()
        {
            return this.pIcamposPersonalizados.GetAll();
        }

        public TbCrCamposPersonalizados getById(int id)
        {
            return this.pIcamposPersonalizados.getById(id);
        }

        public TbCrCamposPersonalizados GetCPPorNombre(string nombre)
        {
            return pIcamposPersonalizados.GetCPPorNombre(nombre);
        }

        public IList<TbCrCamposPersonalizados> GetCampos()
        {
            return this.pIcamposPersonalizados.GetCampos(0);
        }

        public TbCrCamposPersonalizados Save(TbCrCamposPersonalizados domain)
        {
            return this.pIcamposPersonalizados.Save(domain);
        }
    }
}
