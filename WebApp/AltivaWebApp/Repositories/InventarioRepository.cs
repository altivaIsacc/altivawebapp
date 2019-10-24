using AltivaWebApp.Context;
using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public class InventarioRepository : BaseRepository<TbPrInventario>, IInventarioRepository
    {
        
        public InventarioRepository(EmpresasContext context) : base(context)
        {

        }
        public IList<ListarInventarioViewModel> GetListarInventario(int valor, int tipo, bool estado, int bodega, bool clave)
        {        
            if (estado && clave)
            {
                
                    if (tipo == 1)
                    {
                        if (valor == 1)
                            return context.ListarInventario.FromSql($"Select *from vs_Pr_ListarIventario where ExistenciaGeneral < ExistenciaMinima").ToList();
                        if (valor == 2)
                            return context.ListarInventario.FromSql($"Select *from vs_Pr_ListarIventario where ExistenciaGeneral = ExistenciaMinima").ToList();

                        if (valor == 3)
                            return context.ListarInventario.FromSql($"Select *from vs_Pr_ListarIventario where ExistenciaGeneral > ExistenciaMinima").ToList();

                        if (valor == 4)
                            return context.ListarInventario.FromSql($"Select *from vs_Pr_ListarIventario where ExistenciaGeneral <= ExistenciaMinima").ToList();

                        if (valor == 5)
                            return context.ListarInventario.FromSql($"Select *from vs_Pr_ListarIventario where ExistenciaGeneral >= ExistenciaMinima").ToList();
                        if(valor ==6)
                            return context.ListarInventario.FromSql($"Select *from vs_Pr_ListarIventario where ExistenciaGeneral <> ExistenciaMinima").ToList();
                    }
                    if (tipo == 2)
                    {
                        if (valor == 1)
                            return context.ListarInventario.FromSql($"Select *from vs_Pr_ListarIventario where ExistenciaGeneral < ExistenciaMedia").ToList();
                        if (valor == 2)
                            return context.ListarInventario.FromSql($"Select *from vs_Pr_ListarIventario where ExistenciaGeneral = ExistenciaMedia").ToList();

                        if (valor == 3)
                            return context.ListarInventario.FromSql($"Select *from vs_Pr_ListarIventario where ExistenciaGeneral > ExistenciaMedia").ToList();

                        if (valor == 4)
                            return context.ListarInventario.FromSql($"Select *from vs_Pr_ListarIventario where ExistenciaGeneral <= ExistenciaMedia").ToList();

                        if (valor == 5)
                            return context.ListarInventario.FromSql($"Select *from vs_Pr_ListarIventario where ExistenciaGeneral >= ExistenciaMedia").ToList();
                        if(valor ==6)
                            return context.ListarInventario.FromSql($"Select *from vs_Pr_ListarIventario where ExistenciaGeneral <> ExistenciaMedia").ToList();
                    }
                    if (tipo == 3)
                    {
                        if (valor == 1)
                            return context.ListarInventario.FromSql($"Select *from vs_Pr_ListarIventario where ExistenciaGeneral < ExistenciaMaxima").ToList();
                        if (valor == 2)
                            return context.ListarInventario.FromSql($"Select *from vs_Pr_ListarIventario where ExistenciaGeneral = ExistenciaMaxima").ToList();

                        if (valor == 3)
                            return context.ListarInventario.FromSql($"Select *from vs_Pr_ListarIventario where ExistenciaGeneral > ExistenciaMaxima").ToList();

                        if (valor == 4)
                            return context.ListarInventario.FromSql($"Select *from vs_Pr_ListarIventario where ExistenciaGeneral <= ExistenciaMaxima").ToList();

                        if (valor == 5)
                            return context.ListarInventario.FromSql($"Select *from vs_Pr_ListarIventario where ExistenciaGeneral >= ExistenciaMaxima").ToList();
                        if(valor ==6)
                          return context.ListarInventario.FromSql($"Select *from vs_Pr_ListarIventario where ExistenciaGeneral <> ExistenciaMaxima").ToList();


                }
            }
            else if (estado && !clave)
            {
                
                    if (tipo == 1)
                    {
                        if (valor == 1)
                            return context.ListarInventario.FromSql($"Select *from vs_Pr_ListarIventarioPorBodega where ExistenciaGeneral < ExistenciaMinima and IdBodega = {bodega}").ToList();
                        if (valor == 2)
                            return context.ListarInventario.FromSql($"Select *from vs_Pr_ListarIventarioPorBodega where ExistenciaGeneral = ExistenciaMinima and IdBodega = {bodega}").ToList();

                        if (valor == 3)
                            return context.ListarInventario.FromSql($"Select *from vs_Pr_ListarIventarioPorBodega where ExistenciaGeneral > ExistenciaMinima and IdBodega = {bodega}").ToList();

                        if (valor == 4)
                            return context.ListarInventario.FromSql($"Select *from vs_Pr_ListarIventarioPorBodega where ExistenciaGeneral <= ExistenciaMinima and IdBodega = {bodega}").ToList();

                        if (valor == 5)
                            return context.ListarInventario.FromSql($"Select *from vs_Pr_ListarIventarioPorBodega where ExistenciaGeneral >= ExistenciaMinima and IdBodega = {bodega}").ToList();
                        if(valor ==6)
                            return context.ListarInventario.FromSql($"Select *from vs_Pr_ListarIventarioPorBodega where ExistenciaGeneral <> ExistenciaMinima and IdBodega = {bodega}").ToList();
                    }
                    if (tipo == 2)
                    {
                        if (valor == 1)
                            return context.ListarInventario.FromSql($"Select *from vs_Pr_ListarIventarioPorBodega where ExistenciaGeneral < ExistenciaMedia and IdBodega = {bodega}").ToList();
                        if (valor == 2)
                            return context.ListarInventario.FromSql($"Select *from vs_Pr_ListarIventarioPorBodega where ExistenciaGeneral = ExistenciaMedia and IdBodega = {bodega}").ToList();

                        if (valor == 3)
                            return context.ListarInventario.FromSql($"Select *from vs_Pr_ListarIventarioPorBodega where ExistenciaGeneral > ExistenciaMedia and IdBodega = {bodega}").ToList();

                        if (valor == 4)
                            return context.ListarInventario.FromSql($"Select *from vs_Pr_ListarIventarioPorBodega where ExistenciaGeneral <= ExistenciaMedia and IdBodega = {bodega}").ToList();

                        if (valor == 5)
                            return context.ListarInventario.FromSql($"Select *from vs_Pr_ListarIventarioPorBodega where ExistenciaGeneral >= ExistenciaMedia and IdBodega = {bodega}").ToList();
                        if (valor == 6)
                        return context.ListarInventario.FromSql($"Select *from vs_Pr_ListarIventarioPorBodega where ExistenciaGeneral <> ExistenciaMedia and IdBodega = {bodega}").ToList();
                    }
                    if (tipo == 3)
                    {
                        if (valor == 1)
                            return context.ListarInventario.FromSql($"Select *from vs_Pr_ListarIventarioPorBodega where ExistenciaGeneral < ExistenciaMaxima and IdBodega = {bodega}").ToList();
                        if (valor == 2)
                            return context.ListarInventario.FromSql($"Select *from vs_Pr_ListarIventarioPorBodega where ExistenciaGeneral = ExistenciaMaxima and IdBodega = {bodega}").ToList();

                        if (valor == 3)
                            return context.ListarInventario.FromSql($"Select *from vs_Pr_ListarIventarioPorBodega where ExistenciaGeneral > ExistenciaMaxima and IdBodega = {bodega}").ToList();

                        if (valor == 4)
                            return context.ListarInventario.FromSql($"Select *from vs_Pr_ListarIventarioPorBodega where ExistenciaGeneral <= ExistenciaMaxima and IdBodega = {bodega}").ToList();

                        if (valor == 5)
                            return context.ListarInventario.FromSql($"Select *from vs_Pr_ListarIventarioPorBodega where ExistenciaGeneral >= ExistenciaMaxima and IdBodega = {bodega}").ToList();
                         if (valor == 6)
                            return context.ListarInventario.FromSql($"Select *from vs_Pr_ListarIventarioPorBodega where ExistenciaGeneral <> ExistenciaMaxima and IdBodega = {bodega}").ToList();
 
                    }
               



            }

            if(!estado)
            {          
               return context.ListarInventario.FromSql($"Select * from vs_Pr_ListarIventario").ToList();
            }
            else
            {
                return context.ListarInventario.FromSql($"Select * from vs_Pr_ListarIventario").ToList();
            }

        }
        public IList<TbPrInventario> GetAllByCoincidence(string word)
        {
            return (from i in context.TbPrInventario where 
                    EF.Functions.Like(i.IdInventario.ToString(), $"%{word}%") || 
                    EF.Functions.Like(i.Descripcion, $"%{word}%") ||
                    EF.Functions.Like(i.Codigo, $"%{word}%") && i.HabilitarVentaDirecta
                    select i
                    ).ToList(); //context.TbPrInventario.Where(i => i.IdInventario like word);
        }

        public TbPrInventario GetInventarioById(int id)
        {
            return context.TbPrInventario.Include(i => i.IdUnidadMedidaNavigation).FirstOrDefault(i => i.IdInventario == id);
        }
      
        public TbPrInventarioBodega UpdateIBodega(TbPrInventarioBodega domain)
        {
            try
            {
                context.TbPrInventarioBodega.Update(domain);
                context.SaveChanges();
                return domain;
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }
        }
        public TbPrInventarioBodega GetInventarioBodegaById(int id)
        {
            return context.TbPrInventarioBodega.FirstOrDefault(i => i.Id == id);
        }

        public IList<TbPrInventario> GetInventarioFacturable()
        {
            return context.TbPrInventario.Include(i => i.TbPrPrecioCatalogo).Where(i => i.HabilitarVentaDirecta == true).ToList();
        }

        public IList<TbPrImagenInventario> GetInventarioImagenByCodigo(int id)
        {
            return context.TbPrImagenInventario.Where(i => i.IdInventario == id).ToList();
        }
        public IList<TbPrInventarioCaracteristica> GetInventarioCaracteristicaByCodigo(int id)
        {
            return context.TbPrInventarioCaracteristica.Where(i => i.IdInventario == id).ToList();
        }

        public TbPrInventario GetInventarioByCodigo(string codigo)
        {
            return context.TbPrInventario.FirstOrDefault(i => i.Codigo == codigo);
        }
        
        public long? ExisteInventarioCodigo(string codigo)
        {
            var idInventario = context.TbPrInventario.Select(i => new TbPrInventario { IdInventario = i.IdInventario, Codigo = i.Codigo }).FirstOrDefault(i => i.Codigo == codigo);
            if (idInventario == null)
                return 0;
            else
                return idInventario.IdInventario;
            
        }

        public bool ExisteCaracteristica(long idInventario, string caracteristica )
        {
            return context.TbPrInventarioCaracteristica.Any(i => i.IdInventario == idInventario && i.Caracteristicas == caracteristica);
        }

        public IList<TbPrInventario> GetAllInventario()
        {
            return context.TbPrInventario
                .Include(i => i.IdSubFamiliaNavigation)
                    .ThenInclude(f => f.IdFamiliaNavigation)
                .Include(i => i.IdUnidadMedidaNavigation)
                .Include(i => i.TbPrInventarioBodega)
                .Select(i => new TbPrInventario {
                    AbreviacionFacturas = i.AbreviacionFacturas,
                    HabilitarVentaDirecta = i.HabilitarVentaDirecta,
                    Codigo = i.Codigo,
                    Descripcion = i.Descripcion,
                    CantidadUnidad = i.CantidadUnidad,
                    CodigoMoneda = i.CodigoMoneda,
                    CodigoMonedaVenta = i.CodigoMonedaVenta,
                    CostoPromedioGeneral = i.CostoPromedioGeneral,
                    DescripcionVenta = i.DescripcionVenta,
                    ExistenciaGeneral = i.ExistenciaGeneral,
                    FactorAprovechamiento = i.FactorAprovechamiento,
                    FechaCreacion = i.FechaCreacion,
                    HabilitarVentaOnline = i.HabilitarVentaOnline,
                    IdFamiliaOnline = i.IdFamiliaOnline,
                    IdInventario = i.IdInventario,
                    IdMonedaVentaOnline = i.IdMonedaVentaOnline,
                    IdSubFamilia = i.IdSubFamilia,
                    IdSubFamiliaNavigation = i.IdSubFamiliaNavigation,
                    IdUnidadMedida = i.IdUnidadMedida,
                    IdUnidadMedidaNavigation = new TbPrUnidadMedida
                    {
                        Abreviatura = i.IdUnidadMedidaNavigation.Abreviatura,
                        Id = i.IdUnidadMedidaNavigation.Id,
                        Nombre = i.IdUnidadMedidaNavigation.Nombre,
                    },
                    IdUsuario = i.IdUsuario,
                    ImpuestoVenta = i.ImpuestoVenta,
                    Inactiva = i.Inactiva,
                    NombreCarrito = i.NombreCarrito,
                    Notas = i.Notas,
                    PrecioCredito = i.PrecioCredito,
                    PrecioCreditoFinal = i.PrecioCreditoFinal,
                    PrecioTemporal = i.PrecioTemporal,
                    PrecioTemporalFinal = i.PrecioTemporalFinal,
                    PrecioVenta = i.PrecioVenta,
                    PrecioVentaFinal = i.PrecioVentaFinal,
                    PrecioVentaOnline = i.PrecioVentaOnline,
                    SkuOnline = i.SkuOnline,
                    UltimoPrecioCompra = i.UltimoPrecioCompra,
                    UtilidadCredito = i.UtilidadCredito,
                    UtilidadDeseada = i.UtilidadDeseada,
                    UtilidadTemporal = i.UtilidadTemporal,
                    TbPrInventarioBodega = i.TbPrInventarioBodega.Select(ib => new TbPrInventarioBodega {
                        CostoPromedioBodega = ib.CostoPromedioBodega,
                        Id = ib.Id,
                        ExistenciaBodega = ib.ExistenciaBodega,
                        ExistenciaMaxima = ib.ExistenciaMaxima,
                        ExistenciaMedia = ib.ExistenciaMedia,
                        ExistenciaMinima = ib.ExistenciaMinima,
                        IdBodega = ib.IdBodega,
                        IdBodegaNavigation = new TbPrBodega
                        {
                            Id = ib.IdBodegaNavigation.Id,
                            Nombre = ib.IdBodegaNavigation.Nombre
                        },
                        SaldoBodega = ib.SaldoBodega,
                        UltimoCostoBodega = ib.UltimoCostoBodega

                    }).ToList()
                    

                }).ToList();
        }

        public IList<TbPrInventarioBodega> GetAllBodegasPorInventario(int id)
        {
            return context.TbPrInventarioBodega.Include(i => i.IdBodegaNavigation).Where(ib => ib.IdInventario == id).ToList();
        }

        public void SaveInventarioBodega(IList<TbPrInventarioBodega> domain)
        {
            try
            {
                context.TbPrInventarioBodega.AddRange(domain);
                context.SaveChanges();

            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }
        }

        public void SaveImagenInventario(IList<TbPrImagenInventario> domain)
        {

            try
            {
                context.TbPrImagenInventario.AddRange(domain);
                context.SaveChanges();
                
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
               
                throw;
            }
        }

        public void SaveCaracteristicaInventario(TbPrInventarioCaracteristica domain)
        {

            try
            {
                context.TbPrInventarioCaracteristica.Add(domain);
                context.SaveChanges();

            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }
        }

        public bool EliminarInventarioBodega(int id)
        {
            try
            {
                var ib = context.TbPrInventarioBodega.FirstOrDefault(i => i.Id == id);
                if (ib.ExistenciaBodega > 0)
                    return false;
                context.TbPrInventarioBodega.Remove(ib);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }
        }

        public void CrearRelacionInventarioBodega(int idInventario, int idBodega)
        {
            try
            {
                var ib = new TbPrInventarioBodega
                {
                    ExistenciaBodega = 0,
                    CostoPromedioBodega = 0,
                    IdBodega = idBodega,
                    IdInventario = idInventario,
                    ExistenciaMaxima = 3,
                    ExistenciaMedia = 2,
                    ExistenciaMinima = 1,
                    SaldoBodega = 0,
                    UltimoCostoBodega = 0

                };
                context.TbPrInventarioBodega.Add(ib);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");

                throw;
            }
        }

        public bool ExisteEquivalencia(TbPrEquivalencia domain)
        {
            return context.TbPrEquivalencia.Any(e => e.IdEquivalencia == domain.IdEquivalencia && e.IdInventario == domain.IdInventario);
        }

        public IList<TbPrEquivalencia> GetEquivalenciasPorInventario(int idInventario)
        {
            try
            {
                return context.TbPrEquivalencia.Include(i => i.IdEquivalenciaNavigation).Where(e => e.IdInventario == idInventario || e.IdEquivalencia == idInventario).ToList();
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }
        }

        public bool SaveEquivalencia(TbPrEquivalencia domain)
        {
            try
            {
                context.TbPrEquivalencia.Add(domain);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }
            
        }
        public bool DeleteEquivalencia(int id)
        {
            try
            {
                var domain = context.TbPrEquivalencia.FirstOrDefault(e => e.Id == id);
                context.TbPrEquivalencia.Remove(domain);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }

        }

        public bool DeleteCaracteristica(int id)
        {
            try
            {
                var domain = context.TbPrInventarioCaracteristica.FirstOrDefault(e => e.IdCaracteristicas == id);
                context.TbPrInventarioCaracteristica.Remove(domain);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }

        }

        public bool DeleteImagen(int id)
        {
            try
            {
                var domain = context.TbPrImagenInventario.FirstOrDefault(e => e.IdImagen == id);
                context.TbPrImagenInventario.Remove(domain);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }

        }
    }
}

