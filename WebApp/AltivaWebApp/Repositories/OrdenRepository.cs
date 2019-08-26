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
    public class OrdenRepository: BaseRepository<TbPrOrden>, IOrdenRepository     
    {
        public OrdenRepository(EmpresasContext context) : base(context)
        {

        }
        public IList<TbCrContacto> GetAllProveedores()
        {
            try
            {
                return context.TbCrContacto.Where(c => c.Proveedor == true ).ToList();

               // var newList = provedor.OrderBy(provedor.NombreJuridico).ToList();
                
               /* var prov = (from c in context.TbCrContacto 
                          orderby (c.Nombre ?? c.NombreComercial)
                          where ( c.Proveedor == true )
                          select c).ToList();
                return prov;*/
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");

                throw;
            }
        }
        public IList<TbPrOrden> GetAllOrdenes()
        {
            try
            {
                return context.TbPrOrden.Include(o => o.IdProveedorNavigation).Include(o => o.TbPrOrdenDetalle).ThenInclude(od => od.IdInventarioNavigation).ToList();
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");

                throw;
            }
            
        }

        public TbPrOrden GetOrdenById(int id)
        {
            try
            {
                return context.TbPrOrden.Include(o => o.IdProveedorNavigation).FirstOrDefault(o => o.Id == id);
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }
            
        }
        public IList<CompraAutomaticoViewModel> compraProveedor(int idProveedor)
        {
            try {

                var model = context.CompraAutomatico
          .FromSql($"EXECUTE dbo.pr_PR_GeneraCompraAutomatica {idProveedor}")
          .ToList();
                return model;

            }
            catch(Exception)
            {
                throw;

            }




        }

        public TbPrOrden GetComprasById(int id)
        {
            try
            {
                return context.TbPrOrden.Include(o => o.IdProveedorNavigation).FirstOrDefault(o => o.Id == id);
            }
            catch (Exception)
            {
                throw;
            }

        }


        //public TbPrOrden GetAllOrdenDetalleByOrdenId(int id)
        //{
        //    try
        //    {
        //        return context.TbPrOrden.Include(o => o.TbPrOrdenDetalle).ThenInclude(od => od.IdInventarioNavigation).FirstOrDefault(o => o.Id == id);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
        public IList<TbPrOrdenDetalle> GetAllOrdenDetalleByOrdenId(int id)
        {
            try
            {
                return context.TbPrOrdenDetalle.Where(o => o.IdOrdenNavigation.Id == id).ToList();
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");

                throw;
            }
        }

        public bool SaveOrdenDetalle(IList<TbPrOrdenDetalle> domain)
        {
            try
            {
                context.TbPrOrdenDetalle.AddRange(domain);
                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");

                throw;
            }
        }

        public bool UpdateOrdenDetalle(IList<TbPrOrdenDetalle> domain)
        {
            try
            {
                context.TbPrOrdenDetalle.UpdateRange(domain);
                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");

                throw;
            }
        }

        public bool DeleteOrdenDetalle(IList<int> domain, int idOrden)
        {
            try
            {
                var od = context.TbPrOrden.Include(o => o.TbPrOrdenDetalle).FirstOrDefault(o => o.Id == idOrden);

                var eliminados = new List<TbPrOrdenDetalle>();

                foreach (var item in od.TbPrOrdenDetalle)
                {
                    foreach (var i in domain)
                    {
                        if (item.Id == i)
                            eliminados.Add(item);
                    }
                }

                context.TbPrOrdenDetalle.RemoveRange(eliminados);
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
