using AltivaWebApp.Context;
using AltivaWebApp.Domains;
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
        public IList<TbPrInventario> GetAllByCoincidence(string word)
        {
            return (from i in context.TbPrInventario
                    where
                      EF.Functions.Like(i.IdInventario.ToString(), $"%{word}%") ||
                      EF.Functions.Like(i.Descripcion, $"%{word}%") ||
                      EF.Functions.Like(i.Codigo, $"%{word}%") && i.HabilitarVentaDirecta
                    select i
                    ).ToList(); //context.TbPrInventario.Where(i => i.IdInventario like word);
        }
        public TbPrInventario GetInventarioById(int id)
        {
            return context.TbPrInventario.FirstOrDefault(i => i.IdInventario == id);
        }
        public IList<TbPrInventario> GetInventarioFacturable()
        {
            return context.TbPrInventario.Where(i => i.HabilitarVentaDirecta == true).ToList();
        }
        public TbPrInventarioBodega UpdateIBodega(TbPrInventarioBodega domain)
        {
            try
            {
                context.TbPrInventarioBodega.Update(domain);
                context.SaveChanges();
                return domain;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public TbPrInventarioBodega GetInventarioBodegaById(int id)
        {
            return context.TbPrInventarioBodega.FirstOrDefault(i => i.Id == id);
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

        public IList<TbPrInventario> GetAllInventario()
        {
            return context.TbPrInventario
                .Include(i => i.IdSubFamiliaNavigation)
                    .ThenInclude(f => f.IdFamiliaNavigation)
                .Include(i => i.IdUnidadMedidaNavigation)
                .Include(i => i.TbPrInventarioBodega).ToList();
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
            catch (Exception)
            {
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
            catch (Exception)
            {
                //return false;
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
            catch (Exception)
            {
                //return false;
                throw;
            }
        }

        public bool EliminarInventarioBodega(int id)
        {
            try
            {
                var ib = context.TbPrInventarioBodega.FirstOrDefault(i => i.Id == id);
                context.TbPrInventarioBodega.Remove(ib);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
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
            catch (Exception)
            {

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
            catch (Exception)
            {
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
            catch (Exception)
            {
                //return false;
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
            catch (Exception)
            {
                //return false;
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
            catch (Exception)
            {
                //return false;
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
            catch (Exception)
            {
                //return false;
                throw;
            }

        }
    }
}

