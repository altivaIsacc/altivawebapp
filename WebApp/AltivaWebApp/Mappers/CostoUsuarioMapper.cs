using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.GEDomain;
using AltivaWebApp.ViewModels;
using AltivaWebApp.Services;
namespace AltivaWebApp.Mappers
{
    public class CostoUsuarioMapper :ICostoUsuarioMapper
    {
        //variable service costo 
        public ICentroCostosService ICentroCostos;
        //constructor
        public CostoUsuarioMapper(ICentroCostosService pICentroCostos)
        {
            this.ICentroCostos = pICentroCostos;
        }

        public TbFdUsuarioCosto Save(CentroCostosViewModel domain)
        {
            return this.ICentroCostos.Save(viewToModelSave(domain));
        }

        public TbFdUsuarioCosto Update(CentroCostosViewModel domain)
        {
            return this.ICentroCostos.Update(viewToModelUpdate(domain));
        }

        public TbFdUsuarioCosto viewToModelSave(CentroCostosViewModel domain)
        {

            TbFdUsuarioCosto usuarioCosto = new TbFdUsuarioCosto();
            usuarioCosto.IdUsuario = domain.IdUsuario;
            usuarioCosto.Costo = domain.Costo;
            return usuarioCosto;
        }

        public TbFdUsuarioCosto viewToModelUpdate(CentroCostosViewModel domain)
        {

            TbFdUsuarioCosto usuarioCosto = new TbFdUsuarioCosto();
            usuarioCosto.Id = domain.Id;
            usuarioCosto.IdUsuario = domain.IdUsuario;
            usuarioCosto.Costo = domain.Costo;

            return usuarioCosto;
        }
    }
}
