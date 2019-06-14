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
            //condiciones de pago
            services.AddScoped<ICondicionesDePagoRepository,CondicionesDePagoRepository>();
            //cuentas Bancarias
            services.AddScoped<ICuentasBancariasRepository, CuentasBancariasRepository>();

            //tipos de proveedores
            services.AddScoped<ITipoProveedorMapper, TipoProveedorMapper>();
            services.AddScoped<ITipoProveedorRepository, TipoProveedorRepository>();
            services.AddScoped<ITipoProveedorService, TipoProveedorService>();
            //tipos de clientes
            services.AddScoped<ITipoClienteMapper, TipoClienteMapper>();
            services.AddScoped<ITipoClienteRepository, TipoClienteRepository>();
            services.AddScoped<ITipoClienteService, TipoClienteService>();
            //configuracion de filtros
            services.AddScoped<IConfiguracionFiltrosRepository, ConfiguracionFiltrosRepository>();
            services.AddScoped<IConfiguracionFiltrosService, ConfiguracionFiltrosServices>();

            //estados
            services.AddScoped<IEstadoTareaService, EstadoTareaService>();
            services.AddScoped<IEstadoTareaRepository, EstadoTareaRepository>();
            services.AddScoped<IEstadoTareaMapper, EstadoTareaMapper>();
            //tipos
            services.AddScoped<ITipoTareaService, TipoTareaService>();
            services.AddScoped<ITipoTareaRepository,    TipoTareaRepository>();
            services.AddScoped<ITipoTareaMapper,    TipoTareaMapper>();
            //costos
            services.AddScoped<ICentroCostosRepository, CentroCostosRepository>();
            services.AddScoped<ICentroCostosService, CentroCostosService>();
            services.AddScoped<ICostoUsuarioMapper, CostoUsuarioMapper>();

            //tareas.
            services.AddScoped<ITareaMapper, TareaMapper>();
            services.AddScoped<ITareaService, TareaService>();
            services.AddScoped<ITareaRepository, TareaRepository>();



            //Lista desplegable
            services.AddScoped<IListaDesplegableMapper, ListaDesplegableMapper>();
            services.AddScoped<IListaDesplegableService, ListaDesplegableService>();
            services.AddScoped<IListaDespegableRepository, ListaDesplegableRepository>();
            
         
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

            //familiasOnline
            services.AddScoped<IFamiliaOnlineRepository, FamiliaOnlineRepository>();
            services.AddScoped<IFamiliaOnlineService, FamiliaOnlineService>();
            services.AddScoped<IFamiliaOnlineMap, FamiliaOnlineMap>();

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


            //Kardex

            services.AddScoped<IKardexRepository, KardexRepository>();
            services.AddScoped<IKardexService, KardexService>();
            services.AddScoped<IKardexMap, KardexMap>();

            //Compra

            services.AddScoped<ICompraRepository, CompraRepository>();
            services.AddScoped<ICompraService, CompraService>();
            services.AddScoped<ICompraMap, CompraMap>();

            //Departamento

            services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();
            services.AddScoped<IDepartamentoService, DepartamentoService>();
            services.AddScoped<IDepartamentoMap, DepartamentoMap>();


            /// todo lo que tiene que ver con comprobantes electronicos ///hacienda
            services.AddScoped<IColaAprobacionRepository, ColaAprobacionRepository>();
            services.AddScoped<IHaciendaService, HaciendaService>();
            services.AddScoped<IHaciendaMap, HaciendaMap>();


            /// Requisicion
            services.AddScoped<IRequisicionRepository, RequisicionRepository>();
            services.AddScoped<IRequisicionService, RequisicionService>();
            services.AddScoped<IRequisicionMap, RequisicionMap>();

            //RebajaConfig
            services.AddScoped<IDescuentoPromocionRepository, DescuentoPromocionRepository>();
            services.AddScoped<IDescuentoPromocionService, DescuentoPromocionService>();
            services.AddScoped<IDescuentoPromocionMap, DescuentoPromocionMap>();

            //DescuentoUSuario
            services.AddScoped<IDescuentoUsuarioRepository, DescuentoUsuarioRepository>();
            services.AddScoped<IDescuentoUsuarioService, DescuentoUsuarioService>();
            services.AddScoped<IDescuentoUsuarioMap, DescuentoUsuarioMap>();


            //DescuentoUSuarioRango
            services.AddScoped<IDescuentoUsuarioRangoRepository, DescuentoUsuarioRangoRepository>();
            services.AddScoped<IDescuentoUsuarioRangoService, DescuentoUsuarioRangoService>();
            services.AddScoped<IDescuentoUsuarioRangoMap, DescuentoUsuarioRangoMap>();

            //DescuentoUSuarioClave
            services.AddScoped<IDescuentoUsuarioClaveRepository, DescuentoUsuarioClaveRepository>();
            services.AddScoped<IDescuentoUsuarioClaveService, DescuentoUsuarioClaveService>();
            services.AddScoped<IDescuentoUsuarioClaveMap, DescuentoUsuarioClaveMap>();

            //PromocionProducto
            services.AddScoped<IPromocionProductoRepository, PromocionProductoRepositoy>();
            services.AddScoped<IPromocionProductoService, PromocionProductoService>();
            services.AddScoped<IPromocionProductoMap, PromocionProductoMap>();

        }
    }
}
