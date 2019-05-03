using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.Repositories;
namespace AltivaWebApp.Services
{
    public class TipoProveedorService : ITipoProveedorService
    {
        //variable que instacia al repositorio de tipos de proveedores'
        public ITipoProveedorRepository ITipoProveedor;
        //constructor
        public TipoProveedorService(ITipoProveedorRepository ITipoProveedor)
        {
            this.ITipoProveedor = ITipoProveedor;
        }

        public bool Delete(TbFdTipoProveedor domain)
        {
            return this.ITipoProveedor.Delete(domain);
        }

        public IList<TbFdTipoProveedor> GetAll()
        {
            throw new NotImplementedException();
        }

        public TbFdTipoProveedor GetById(int IdTipoCliente)
        {
            return this.ITipoProveedor.GetById(IdTipoCliente);
        }

        public IList<TbFdTipoProveedor> GetFamiliaTipoProveedor(int IdTipoProveedor)
        {
            return this.ITipoProveedor.GetFamiliaTipoProveedor(IdTipoProveedor);
        }

        public IList<TbFdTipoProveedor> GetSubFamiliaProveedor(int IdTipoProveedor)
        {
            return this.ITipoProveedor.GetSubFamiliaProveedor(IdTipoProveedor);
                }

        public IList<TbFdTipoProveedor> GetTipoProveedor()
        {
            return this.ITipoProveedor.GetTipoProveedor();
                }

        public TbFdTipoProveedor Save(TbFdTipoProveedor domain)
        {
            return this.ITipoProveedor.Save(domain);
        }

        public TbFdTipoProveedor Updtae(TbFdTipoProveedor domain)
        {
            return this.ITipoProveedor.Update(domain);
        }
    }
}
