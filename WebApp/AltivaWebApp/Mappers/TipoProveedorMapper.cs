using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
using AltivaWebApp.Services;
namespace AltivaWebApp.Mappers
{
    public class TipoProveedorMapper :ITipoProveedorMapper
    {
        //variable 
        public ITipoProveedorService ITipoProveedor;
        //constructor
        public TipoProveedorMapper(ITipoProveedorService ITipoProveedor)
        {
            this.ITipoProveedor = ITipoProveedor;
        }

        public TbFdTipoProveedor Save(TipoClienteViewModel domain)
        {
            return this.ITipoProveedor.Save(ViewModelToSave(domain));
        }

        public TbFdTipoProveedor Update(TipoClienteViewModel domain)
        {
            return this.ITipoProveedor.Updtae(ViewModelToUpdate(domain));
        }

        public TbFdTipoProveedor ViewModelToSave(TipoClienteViewModel domain)
        {
            TbFdTipoProveedor tp = new TbFdTipoProveedor();
            tp.Nombre = domain.Nombre;
            tp.Inactivo = domain.Inactivo;
            tp.FechaCreacion = DateTime.Now;

            return tp;
        }

        public TbFdTipoProveedor ViewModelToUpdate(TipoClienteViewModel domain)
        {
            TbFdTipoProveedor tp = new TbFdTipoProveedor();

            tp = this.ITipoProveedor.GetById(Convert.ToInt32(domain.Id));
            tp.Nombre = domain.Nombre;
            tp.Inactivo = domain.Inactivo;
          

            return tp;
        }
    }
}
