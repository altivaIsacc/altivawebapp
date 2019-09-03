using AltivaWebApp.Context;
using AltivaWebApp.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public class TrasladoRepository : BaseRepository<TbPrTraslado>, ITrasladoRepository
    {

        public TrasladoRepository(EmpresasContext context) : base(context)
        {

        }

        
        public IList<TbPrTraslado> GetAllTraslado()
        {
            return context.TbPrTraslado.Include(a => a.IdBodegaDestinoNavigation).Include(a => a.IdBodegaOrigenNavigation).ToList();
        }

        public TbPrTraslado GetTrasladoById(long id)
        {          
                return context.TbPrTraslado.AsNoTracking().FirstOrDefault(d => d.IdTraslado == id);// AsNoTracking()       
        }

      
        public bool SaveTrasladoInventario(IList<TbPrTrasladoInventario> domain)
        {
            try
            {
                context.TbPrTrasladoInventario.AddRange(domain);
                context.SaveChanges();
                return true;


            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }
        }


        public IList<TbPrTrasladoInventario> SaveOrUpdateTrasladoInventario(IList<TbPrTrasladoInventario> domain)
        {
            try
            {
                var actualizar = new List<TbPrTrasladoInventario>();
                var crear = new List<TbPrTrasladoInventario>();

                foreach (var item in domain)
                {
                    if (item.Id != 0)
                        actualizar.Add(item);
                    else
                        crear.Add(item);
                }
                context.TbPrTrasladoInventario.AddRange(crear);
                context.TbPrTrasladoInventario.UpdateRange(actualizar);

                context.SaveChanges();
                return domain;
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }

        }

        public void DeleteTrasladoInventario(IList<long> domain)
        {
            try
            {
                context.TbPrTrasladoInventario.RemoveRange(context.TbPrTrasladoInventario.Where(r => domain.Any(id => id == r.Id)));
                context.SaveChanges();

            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }
        }


        public IList<TbPrTraslado> GetTrasladosSinAnular()
        {
            return context.TbPrTraslado.Where(d => d.Anulado == false).ToList();
        }



        public TbPrTraslado GetTrasladoForKardex(int id, IList<long> idDetalles)
        {
            try
            {
                return context.TbPrTraslado.Select(a => new TbPrTraslado
                    {
                        IdUsuario = a.IdUsuario,
                        IdBodegaOrigen = a.IdBodegaOrigen,
                        IdBodegaDestino = a.IdBodegaDestino,
                        Fecha = a.Fecha,
                        FechaCreacion = a.FechaCreacion,
                        Anulado = a.Anulado,
                        CostoTraslado = a.CostoTraslado,
                        Comentario = a.Comentario,
                            TbPrTrasladoInventario = a.TbPrTrasladoInventario.Select(d => new TbPrTrasladoInventario
                            {
                                Id = d.Id,
                                IdTraslado = d.IdTraslado,
                                IdInventario = d.IdInventario,
                                CodigoArticulo = d.CodigoArticulo,
                                Descripcion = d.Descripcion,
                                Cantidad = d.Cantidad,
                                PrecioUnitario = d.PrecioUnitario,
                                CostoTotal = d.CostoTotal,
                                                                                    
                                IdInventarioNavigation = new TbPrInventario
                                {
                                    IdInventario = d.IdInventarioNavigation.IdInventario,
                                    TbPrInventarioBodega = d.IdInventarioNavigation.TbPrInventarioBodega,
                                    ExistenciaGeneral = d.IdInventarioNavigation.ExistenciaGeneral,
                                    CostoPromedioGeneral = d.IdInventarioNavigation.CostoPromedioGeneral,
                                    UltimoPrecioCompra = d.IdInventarioNavigation.UltimoPrecioCompra
                                }
                              
                            }).Where(d => idDetalles.Any(idD => idD == d.Id)).ToList()
                           
                }).AsNoTracking().FirstOrDefault(a => a.IdTraslado == id);
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }


        }









    }
}
