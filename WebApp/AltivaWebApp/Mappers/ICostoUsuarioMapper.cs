using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.ViewModels;
using AltivaWebApp.GEDomain;
namespace AltivaWebApp.Mappers
{
    public interface ICostoUsuarioMapper
    {
        TbFdUsuarioCosto Save(CentroCostosViewModel domain);
        TbFdUsuarioCosto viewToModelSave(CentroCostosViewModel domain);
        TbFdUsuarioCosto Update(CentroCostosViewModel domain);
        TbFdUsuarioCosto viewToModelUpdate(CentroCostosViewModel domain);
    }
}
