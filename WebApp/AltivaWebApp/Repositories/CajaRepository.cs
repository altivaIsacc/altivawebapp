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
    public class CajaRepository : BaseRepository<TbFaCaja>, ICajaRepository
    {

        public CajaRepository(EmpresasContext context) : base(context)
        {

        }

        public TbFaCajaAperturaDenominacion SaveCajaAperturaDenominacion(TbFaCajaAperturaDenominacion domain)
        {
            try
            {


                context.TbFaCajaAperturaDenominacion.Add(domain);
                context.SaveChanges();

                return domain;
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");

                throw;
            }
        }


        public IList<TbFaCajaArqueo> GetAllById(int id)
        {
            return context.TbFaCajaArqueo.ToList();
        }

        public bool UpdateCajaAperturaDenominacion(IList<TbFaCajaAperturaDenominacion> domain)
        {
            try
            {
                //var users = context.TbFaCajaAperturaDenominacion.AsNoTracking().ToList();
                context.TbFaCajaAperturaDenominacion.UpdateRange(domain);

                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }
        }

        public bool UpdateCajaArqueoDenominacion(IList<TbFaCajaArqueoDenominacion> domain)
        {
            try
            {
                //var users = context.TbFaCajaAperturaDenominacion.AsNoTracking().ToList();
                context.TbFaCajaArqueoDenominacion.UpdateRange(domain);

                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }
        }

        public bool UpdateCajaArqueo(IList<TbFaCajaArqueo> domain)
        {
            try
            {
                //var users = context.TbFaCajaAperturaDenominacion.AsNoTracking().ToList();
                context.TbFaCajaArqueo.UpdateRange(domain);

                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }
        }

        public bool UpdateCajaCierre(IList<TbFaCajaCierre> domain)
        {
            try
            {
                //var users = context.TbFaCajaAperturaDenominacion.AsNoTracking().ToList();
                context.TbFaCajaCierre.UpdateRange(domain);

                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }
        }

        public IList<TbFaCaja> GetInfoCaja(FiltroFechaViewModel _filtroFecha, long _filtroNum, long _filtroPV)
        {
            try
            {
                string filtroFecha = _filtroFecha.Filtrando ? $"Convert(date, FechaCreacion) >= '{_filtroFecha.Desde.Date}' and Convert(date, FechaCreacion) <= '{_filtroFecha.Hasta.Date}' " : "";
                string filtroNum = _filtroNum != 0 ? $"IdCaja = '{_filtroNum}'" : "";
                string filtroPV = _filtroPV != 0 ? $"IdPuntoVenta = '{_filtroPV}'" : "";

                var and1 = "";
                var and2 = "";
                
                var where = "";
                if (filtroFecha != "" && filtroNum != "")
                    and1 = "and";

                if (filtroPV != "" && (filtroFecha != "" || filtroNum != ""))
                    and2 = "and";

                if (filtroFecha != "" || filtroNum != "" || filtroPV != "")
                    where = "where";

                var qry = $"select * from tb_FA_Caja {where} {filtroFecha} {and1} {filtroNum} {and2} {filtroPV}";

                var caja = context.TbFaCaja.FromSql(qry).Include(c => c.IdPuntoVentaNavigation).ToList();
                return caja;


            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }
        }

        public IList<TbFaCaja> GetAllCajas()
        {
            try
            {
                return context.TbFaCaja.Include(a => a.IdCaja).ToList();
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }
        }

        public IList<TbFaCajaAperturaDenominacion> GetAllCajaAperturaDenominacionByIdCaja(int id)
        {
            try
            {
                return context.TbFaCajaAperturaDenominacion.Where(c => c.IdCajaNavigation.IdCaja == id).ToList();
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");

                throw;
            }
        }

        public IList<TbFaCajaArqueoDenominacion> GetAllCajaArqueoDenominacionByIdCaja(int id)
        {
            try
            {
                return context.TbFaCajaArqueoDenominacion.Where(c => c.IdCajaNavigation.IdCaja == id).ToList();
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");

                throw;
            }
        }

        public IList<TbFaCajaArqueo> GetAllCajaArqueoByIdCaja(int id)
        {
            try
            {
                return context.TbFaCajaArqueo.Where(c => c.IdCajaNavigation.IdCaja == id).ToList();
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");

                throw;
            }
        }

        public IList<TbFaCajaCierre> GetAllCajaCierreByIdCaja(int id)
        {
            try
            {
                return context.TbFaCajaCierre.Where(c => c.IdCajaNavigation.IdCaja == id).ToList();
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }
        }

        public TbFaCaja GetCajaById(int id)
        {
            try
            {
                return context.TbFaCaja.FirstOrDefault(c => c.IdCaja == id);
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }
        }
    }
}
