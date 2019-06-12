using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
using AltivaWebApp.Services;
using AltivaWebApp.GEDomain;

namespace AltivaWebApp.Mappers
{
    public class MonedaMap : IMonedaMap
    {
        private IMonedaService service;

        public MonedaMap(IMonedaService pMonedaService)
        {
            service = pMonedaService;
        }

        public IList<TbSeMoneda> Create()
        {
            var monedas = new List<TbSeMoneda>();

            var mBase = new TbSeMoneda
            {
                Activa = true,
                Codigo = 1,
                Nombre = "Colón",
                Simbolo = "CRC",
                ValorCompra = 1,
                ValorVenta = 1
            };

            monedas.Add(mBase);

            var dolar = new TbSeMoneda
            {
                Activa = true,
                Codigo = 2,
                Nombre = "Dolar",
                Simbolo = "USD",
                ValorCompra = 1,
                ValorVenta = 1
            };

            monedas.Add(dolar);

            var euro = new TbSeMoneda
            {
                Activa = true,
                Codigo = 3,
                Nombre = "Euro",
                Simbolo = "EUR",
                ValorCompra = 1,
                ValorVenta = 1
            };

            monedas.Add(euro);

            return service.SaveMoneda(monedas);

        }

        public IList<TbSeHistorialMoneda> CreateHM(IList<TbSeMoneda> domain, int idUsuario)
        {
            var hm = new List<TbSeHistorialMoneda>();
            foreach (var item in domain)
            {
                var model = new TbSeHistorialMoneda
                {
                    CodigoMoneda = item.Codigo,
                    Fecha = DateTime.Now,
                    IdUsuario = idUsuario,
                    ValorCompra = item.ValorCompra,
                    ValorVenta = item.ValorVenta
                };

                hm.Add(model);
            }

            return service.CrearHistorialMoneda(hm);
        }


        //public TbSeMoneda ViewModelToDomain(MonedaViewModel monedaViewModel)
        //{
        //    var domain = monedaService.GetMonedaById(monedaViewModel.Codigo);         
        //    domain.Nombre = monedaViewModel.Nombre;
        //    domain.Simbolo = monedaViewModel.Simbolo;
        //    //domain.Codigo = monedaViewModel.Codigo;
        //    domain.Activa = monedaViewModel.Activa;
        //    domain.ValorCompra = monedaViewModel.ValorCompra;
        //    domain.ValorVenta = monedaViewModel.ValorVenta;

        //    return domain;
        //}




    }
}
