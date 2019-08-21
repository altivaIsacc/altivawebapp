using AltivaWebApp.Context;
using AltivaWebApp.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public class AjusteRepository : BaseRepository<TbPrAjuste>, IAjusteRepository
    {
        public AjusteRepository(EmpresasContext context)
            : base(context)
        {

        }

        public IList<TbPrAjuste> GetAllAjustes()
        {
            return context.TbPrAjuste.Include(a => a.TbPrAjusteInventario).ThenInclude(a => a.IdInventarioNavigation).ToList();
        }

        public IList<TbCoCuentaContable> GetAllCC()
        {
            return context.TbCoCuentaContable.ToList();
        }

        public IList<TbCoCentrosDeGastos> GetAllCG()
        {
            return context.TbCoCentrosDeGastos.ToList();
        }

        public TbPrAjuste GetAjusteById(int id)
        {
            try
            {
                return context.TbPrAjuste
                                .Include(a => a.IdBodegaNavigation)
                                .Include(a => a.TbPrAjusteInventario)
                                .ThenInclude(a => a.IdCentroGastosNavigation)
                                .Include(a => a.TbPrAjusteInventario)
                                .ThenInclude(a => a.IdInventarioNavigation)
                                .ThenInclude(b => b.TbPrInventarioBodega)
                                .Include(a => a.TbPrAjusteInventario)
                                .ThenInclude(a => a.IdCuentaContableNavigation).AsNoTracking()
                                .FirstOrDefault(a => a.Id == id);
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }
        }

        public TbPrAjuste GetAjusteForKardex(int id, IList<long> idDetalles)
        {
            try
            {
                //return context.TbPrAjuste
                //                .Include(a => a.TbPrAjusteInventario)
                //                .ThenInclude(a => a.IdInventarioNavigation)
                //                .ThenInclude(b => b.TbPrInventarioBodega)
                //                .FirstOrDefault(a => a.Id == id && a.TbPrAjusteInventario.Any(d => idDetalles.Any(idD => idD == a.Id)));

                return context.TbPrAjuste
                    .Select(a => new TbPrAjuste
                    {
                        Anulada = a.Anulada,
                        Descripcion = a.Descripcion,
                        FechaCreacion = a.FechaCreacion,
                        FechaDocumento = a.FechaDocumento,
                        Id = a.Id,
                        IdBodega = a.IdBodega,
                        IdUsuario = a.IdUsuario,
                        SaldoAjuste = a.SaldoAjuste,
                        TbPrAjusteInventario = a.TbPrAjusteInventario.Select(d => new TbPrAjusteInventario
                        {
                            Cantidad = d.Cantidad,
                            CostoPromedio = d.CostoPromedio,
                            Descripcion = d.Descripcion,
                            Id = d.Id,
                            IdAjuste = d.IdAjuste,
                            IdInventario = d.IdInventario,
                            IdInventarioNavigation = new TbPrInventario
                            {
                                IdInventario = d.IdInventarioNavigation.IdInventario,
                                TbPrInventarioBodega = d.IdInventarioNavigation.TbPrInventarioBodega,
                                ExistenciaGeneral = d.IdInventarioNavigation.ExistenciaGeneral,
                                CostoPromedioGeneral = d.IdInventarioNavigation.CostoPromedioGeneral,
                                UltimoPrecioCompra = d.IdInventarioNavigation.UltimoPrecioCompra
                            },
                            Movimiento = d.Movimiento

                        }).Where(d => idDetalles.Any(idD => idD == d.Id)).ToList(),
                        TotalEntrada = a.TotalEntrada,
                        TotalSalida = a.TotalSalida

                    }).AsNoTracking().FirstOrDefault(a => a.Id == id);

            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }
        }


        public IList<TbPrAjusteInventario> SaveOrUpdateAjusteInventario(IList<TbPrAjusteInventario> domain)
        {
            try
            {

                var actualizar = new List<TbPrAjusteInventario>();
                var crear = new List<TbPrAjusteInventario>();

                foreach (var item in domain)
                {
                    if (item.Id != 0)
                        actualizar.Add(item);
                    else
                        crear.Add(item);
                }

                context.TbPrAjusteInventario.AddRange(crear);
                context.TbPrAjusteInventario.UpdateRange(actualizar);

                context.SaveChanges();
                return domain;
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }
        }


        public void DeleteAjusteInventario(IList<long> domain)
        {
            try
            {
                context.TbPrAjusteInventario.RemoveRange(context.TbPrAjusteInventario.Where(d => domain.Contains(d.Id)));
                context.SaveChanges();

            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }
        }

    }
}
