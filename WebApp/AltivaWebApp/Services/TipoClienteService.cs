using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.Repositories;
namespace AltivaWebApp.Services
{
    public class TipoClienteService : ITipoClienteService
    {

        //variable que instacia al reposiroty
        public ITipoClienteRepository ITipoCliente;

        //constructor
        public TipoClienteService(ITipoClienteRepository ITipoCliente)
        {
            this.ITipoCliente = ITipoCliente;
        }

        public bool Delete(TbFdTipoCliente domain)
        {
            return this.ITipoCliente.Delete(domain);
        }

        public IList<TbFdTipoCliente> GetAll()
        {
            throw new NotImplementedException();
        }

        public TbFdTipoCliente GetById(int IdTipoCliente)
        {
            return this.ITipoCliente.GetById(IdTipoCliente);
        }

        public IList<TbFdTipoCliente> GetFamiliaTipoCliente(int IdTipoCLiente)
        {
            return this.ITipoCliente.GetFamiliaTipoCliente(IdTipoCLiente);
        }

        public IList<TbFdTipoCliente> GetSubFamilia(int IdTipoCliente)
        {
            return this.ITipoCliente.GetSubFamilia(IdTipoCliente);
        }

        public IList<TbFdTipoCliente> GetTipoCliente()
        {
            return ITipoCliente.GetTipoCliente();
        }

        public TbFdTipoCliente Save(TbFdTipoCliente domain)
        {
            return this.ITipoCliente.Save(domain);
        }

        public TbFdTipoCliente Updtae(TbFdTipoCliente domain)
        {
            return this.ITipoCliente.Update(domain);
        }
    }
}
