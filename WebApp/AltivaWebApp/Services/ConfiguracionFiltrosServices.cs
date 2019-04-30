using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.Repositories;
namespace AltivaWebApp.Services
{
    public class ConfiguracionFiltrosServices : IConfiguracionFiltrosService
    {
        //variable para acceso a datos
        public IConfiguracionFiltrosRepository IConfigRepository;
        //contructor
        public ConfiguracionFiltrosServices(IConfiguracionFiltrosRepository IConfigRepository)
        {
            this.IConfigRepository = IConfigRepository;
        }

        public bool Delete(TbFdConfiguracionFiltros domain)
        {
            return this.IConfigRepository.Delete(domain);
        }

        public void DeleteRange(IList<TbFdConfiguracionFiltros> domain)
        {
            this.IConfigRepository.DeleteRange(domain);
        }

        public TbFdConfiguracionFiltros GetFiltro()
        {
            return this.IConfigRepository.GetFiltro();
        }

        public TbFdConfiguracionFiltros Save(TbFdConfiguracionFiltros domain)
        {
            
            return this.IConfigRepository.Save(domain);
        }
    }
}
