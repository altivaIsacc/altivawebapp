using AltivaWebApp.Context;
using AltivaWebApp.Mappers;
using AltivaWebApp.Domains;
using AltivaWebApp.Repositories;
using AltivaWebApp.Services;
using Microsoft.Extensions.DependencyInjection;


namespace AltivaWebApp.App_Start
{
    public class DependencyInjectionConfig
    {


        public static void AddScope(IServiceCollection services)

        {
            services.AddScoped<IListaDesplegableMapper, ListaDesplegableMapper>();
            services.AddScoped<IListaDesplegableService, ListaDesplegableService>();
            services.AddScoped<IListaDespegableRepository, ListaDesplegableRepository>();
            //
           // services.AddScoped<FotosService>();
            services.AddScoped<FotosService>();
            //
            services.AddScoped< IcontactoCamposMap, ContactosCamposMap>();
            //

            services.AddScoped<IContactoRelacionRepository, ContactoRelacionRepository>();
            services.AddScoped<IContactoCamposService, ContactoCamposService>();
            services.AddScoped<IContactoCamposRepository, ContactoCamposRepository>();
            //campos personalizados
            services.AddScoped<ICamposPersonalizadosService, CamposPersonalizadosServices>();
            services.AddScoped<ICamposPersonalizadosRepository, CamposPersonalizadosRepository>();
            //
            services.AddScoped<IContactoMap, ContactoMapper>();
            //
            services.AddScoped<IContactoService, ContactoService>();
            services.AddScoped<IContactoRepository, ContactoRepository>();
            //
            services.AddScoped<IBitacoraMapper, BitacoraMapper>();
            services.AddScoped<IBitacoraService, BitacoraService>();
            services.AddScoped<IBitacoraRepository, BitacoraRepository>();
            //
            services.AddScoped<IMensajeReceptorService, MensajeReceptorService>();
            services.AddScoped<IAdjuntoService, AdjuntoService>();
            services.AddScoped<EmailSender>();
            services.AddScoped<IMensajeReceptor, MensajerReceptorMap>();
            services.AddScoped<IMensajeReceptorRepository, MensajeReceptorRepository>();
            //
       
            //
            services.AddScoped<IMensajeMap, MensajeMap>();
            services.AddScoped<IAdjuntoMap, AdjuntoMap>();
            services.AddScoped<IMensajeService, MensajeService>();
            services.AddScoped<IAdjuntoMap, AdjuntoMap>();
            services.AddScoped<IAdjuntoRepository, AdjuntoRepository>();
         
            services.AddScoped<IMensajeRepository, MensajeRepository>();
            //
            services.AddScoped<IMonedaMap, MonedaMap>();

            services.AddScoped<IMonedaService, MonedaService>();

            services.AddScoped<IMonedaRepository, MonedaRepository>();

            services.AddScoped<IModuloService, ModuloService>();
            services.AddScoped<IPaisService, PaisService>();

            services.AddScoped<IPaisRepository, PaisRepository>();

            services.AddScoped<IPaisMap, PaisMap>();
            services.AddScoped<EmpresasContext, EmpresasContext>();

            services.AddScoped<IUserMap, UserMap>();

            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IPerfilMap, PerfilMap>();

            services.AddScoped<IPerfilService, PerfilService>();

            services.AddScoped<IPerfilRepository, PerfilRepository>();

            services.AddScoped<IModuloService, ModuloService>();
            services.AddScoped<IModuloRepository, ModuloRepository>();
            services.AddScoped<IModuloMap, ModuloMap>();

            ///HistorialMoneda
            services.AddScoped<IHistorialMonedaService, HistorialMonedaService>();
            services.AddScoped<IHistorialMonedaMap, HistorialMonedaMap>();
            services.AddScoped<IHistorialMonedaRepository, HistorialMonedaRepository>();

            //ModuloPerfil
            services.AddScoped<IModuloPerfilMap, ModuloPerfilMap>();
            services.AddScoped<IModuloPerfilService, ModuloPerfilService>();
            services.AddScoped<IModuloPerfilRepository, ModuloPerfilRepository>();

            ///grupo empresa
            services.AddScoped<IGERepository, GERepository>();
            services.AddScoped<IGEService, GEService>();
            services.AddScoped<IGEMap, GEMap>();


            ///bodega
            services.AddScoped<IBodegaRepository, BodegaRepository>();
            services.AddScoped<IBodegaService, BodegaService>();
            services.AddScoped<IBodegaMap, BodegaMap>();

            //unidades
            services.AddScoped<IUnidadRepository, UnidadRepository>();
            services.AddScoped<IUnidadService, UnidadService>();
            services.AddScoped<IUnidadMap, UnidadMap>();

            //Conversiones
            services.AddScoped<IConversionRepository, ConversionRepository>();
            services.AddScoped<IConversionService, ConversionService>();
            services.AddScoped<IConversionMap, ConversionMap>();


            //familias
            services.AddScoped<IFamiliaRepository, FamiliaRepository>();
            services.AddScoped<IFamiliaService, FamiliaService>();
            services.AddScoped<IFamiliaMap, FamiliaMap>();

            //inventario

            services.AddScoped<IInventarioRepository, InventarioRepository>();
            services.AddScoped<IInventarioService, InventarioService>();
            services.AddScoped<IInventarioMap, InventarioMap>();

            //ajuste

            services.AddScoped<IAjusteRepository, AjusteRepository>();
            services.AddScoped<IAjusteService, AjusteService>();
            services.AddScoped<IAjusteMap, AjusteMap>();

            //orden

            services.AddScoped<IOrdenRepository, OrdenRepository>();
            services.AddScoped<IOrdenService, OrdenService>();
            services.AddScoped<IOrdenMap, OrdenMap>();



        }
    }
}
