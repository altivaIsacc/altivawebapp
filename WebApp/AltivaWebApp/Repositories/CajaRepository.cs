using AltivaWebApp.Context;
using AltivaWebApp.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public class CajaRepository: BaseRepository<TbFaCaja>, ICajaRepository
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
            catch (Exception)
            {

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

                throw;
            }
        }

        public IList<TbFaCaja> GetInfoCaja()
        {
            try
            {
               return context.TbFaCaja.ToList();

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IList<TbFaCaja> GetAllCajas()
        {
            try
            {
                return context.TbFaCaja.Include(a => a.IdCaja).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IList<TbFaCajaAperturaDenominacion> GetAllCajaAperturaDenominacionByIdCaja(int id)
        {
            try
            {
                return context.TbFaCajaAperturaDenominacion.Where(c => c.IdCajaNavigation.IdCaja == id).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IList<TbFaCajaArqueoDenominacion> GetAllCajaArqueoDenominacionByIdCaja(int id)
        {
            try
            {
                return context.TbFaCajaArqueoDenominacion.Where(c => c.IdCajaNavigation.IdCaja == id).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IList<TbFaCajaArqueo> GetAllCajaArqueoByIdCaja(int id)
        {
            try
            {
                return context.TbFaCajaArqueo.Where(c => c.IdCajaNavigation.IdCaja == id).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IList<TbFaCajaCierre> GetAllCajaCierreByIdCaja(int id)
        {
            try
            {
                return context.TbFaCajaCierre.Where(c => c.IdCajaNavigation.IdCaja == id).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TbFaCaja GetCajaById(int id)
        {
            try
            {
                return context.TbFaCaja.FirstOrDefault(c => c.IdCaja == id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
