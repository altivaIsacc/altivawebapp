using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
using AltivaWebApp.Services;
namespace AltivaWebApp.Mappers
{
    public class TipoClienteMapper : ITipoClienteMapper
    {
        //variable que instacia al servicio del tipo del cliente
        public ITipoClienteService ItipoCliente;
        //contructor
        public TipoClienteMapper(ITipoClienteService ItipoCliente)
        {
            this.ItipoCliente = ItipoCliente;
        }

        public TbFdTipoCliente Save(TipoClienteViewModel domain)
        {
            return this.ItipoCliente.Save(ViewModelToSave(domain));
        }

        public TbFdTipoCliente Update(TipoClienteViewModel domain)
        {
            return this.ItipoCliente.Updtae(ViewModelToUpdate(domain));
        }

        public TbFdTipoCliente ViewModelToSave(TipoClienteViewModel domain)
        {
            TbFdTipoCliente Tc = new TbFdTipoCliente();
            Tc.IdPadre = domain.IdPadre;
            Tc.Nombre = domain.Nombre;
            Tc.Inactivo = domain.Inactivo;
            Tc.FechaCreacion = DateTime.Now;

            return Tc;
        }

        public TbFdTipoCliente ViewModelToUpdate(TipoClienteViewModel domain)
        {
            TbFdTipoCliente Tc = new TbFdTipoCliente();
            Tc = this.ItipoCliente.GetById(Convert.ToInt32(domain.Id));
          
            Tc.Nombre = domain.Nombre;
            Tc.Inactivo = domain.Inactivo;


            return Tc;
        }
    }
}
