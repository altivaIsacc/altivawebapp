using AltivaWebApp.Context;
using AltivaWebApp.Domains;
using AltivaWebApp.Helpers;
using AltivaWebApp.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public class MovimientoRepository: BaseRepository<TbFaMovimiento>, IMovimientoRepository
    {
        public MovimientoRepository(EmpresasContext context) : base(context)
        {

        }
        public TbFaMovimiento GetMovimientoById(long id)
        {
            try
            {
                return context.TbFaMovimiento.Include(t => t.IdTipoDocumentoNavigation).FirstOrDefault(o => o.IdMovimiento == id);
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }

        }
        public TbFaMovimiento GetMovimientoByNota(long id)
        {
            try
            {
                return context.TbFaMovimiento.Include(m => m.IdTipoDocumentoNavigation).FirstOrDefault(o => o.IdDocumento == id);
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }

        }
        public IList<TbFaMovimiento> GetAllMovimientos()
        {
            try
            {
                return context.TbFaMovimiento.ToList();
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }

        }
        public bool SaveMovimientoJustificante(IList<TbFaMovimientoJustificante> domain)
        {
            try
            {
                context.TbFaMovimientoJustificante.AddRange(domain);
                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");

                throw;
            }
        }

        public bool UpdateMovimientoJustificante(IList<TbFaMovimientoJustificante> domain)
        {
            try
            {
                context.TbFaMovimientoJustificante.UpdateRange(domain);
                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");

                throw;
            }
        }
        public IList<TbFaMovimientoJustificante> GetJustificantesByMovimientoId(long id)
        {
            try
            {
                return context.TbFaMovimientoJustificante.Where(o => o.IdMovimientoNavigation.IdMovimiento == id).ToList();
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");

                throw;
            }
        }
        public bool DeleteMovimientoJustificante(IList<int> domain, int idMovimiento)
        {
            try
            {
                var od = context.TbFaMovimiento.Include(o => o.TbFaMovimientoJustificante).FirstOrDefault(o => o.IdMovimiento == idMovimiento);

                var eliminados = new List<TbFaMovimientoJustificante>();

                foreach (var item in od.TbFaMovimientoJustificante)
                {
                    foreach (var i in domain)
                    {
                        if (item.IdMovimientoJustificante == i)
                            eliminados.Add(item);
                    }
                }

                context.TbFaMovimientoJustificante.RemoveRange(eliminados);
                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");

                throw;
            }
        }
        public IList<DocumentosContactoViewModel> getDocumentosContacto()
        {

            IList<DocumentosContactoViewModel> domain = new List<DocumentosContactoViewModel>();
            string connectionString = null;
            SqlConnection connection;
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            int i = 0;
            string sql = "Select * from vs_FA_DocumentosContacto";

            connectionString = StringProvider.StringEmpresas;

            connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                command = new SqlCommand(sql, connection);
                adapter.SelectCommand = command;
                adapter.Fill(ds);
                adapter.Dispose();
                command.Dispose();
                connection.Close();

                for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {

                    domain.Add(new DocumentosContactoViewModel {
                        
                        Nombre = (string) ds.Tables[0].Rows[i].ItemArray[0],
                        IdMovimiento = (long) ds.Tables[0].Rows[i].ItemArray[1],
                        IdContacto = (long) ds.Tables[0].Rows[i].ItemArray[2],
                        IdDocumento = (long)ds.Tables[0].Rows[i].ItemArray[3],
                        IdTipoDocumento = (int)ds.Tables[0].Rows[i].ItemArray[4],
                        IdUsuario = (long)ds.Tables[0].Rows[i].ItemArray[5],
                        Cxp = (bool)ds.Tables[0].Rows[i].ItemArray[6],
                        Cxc = (bool)ds.Tables[0].Rows[i].ItemArray[7],
                        IdMoneda = (int)ds.Tables[0].Rows[i].ItemArray[8],
                        MontoBase = (double)ds.Tables[0].Rows[i].ItemArray[9],
                        MontoDolar = (double)ds.Tables[0].Rows[i].ItemArray[10],
                        MontoEuro = (double)ds.Tables[0].Rows[i].ItemArray[11],
                        DisponibleDolar = (string)ds.Tables[0].Rows[i].ItemArray[12],
                        DisponibleBase = (double)ds.Tables[0].Rows[i].ItemArray[13],
                        DisponibleEuro = (double)ds.Tables[0].Rows[i].ItemArray[14],
                        AplicadoBase = (double)ds.Tables[0].Rows[i].ItemArray[15],
                        AplicadoDolar = (double)ds.Tables[0].Rows[i].ItemArray[16],
                        AplicadoEuro = (double)ds.Tables[0].Rows[i].ItemArray[17],
                        SaldoBase = (double)ds.Tables[0].Rows[i].ItemArray[18],
                        SaldoDolar = (double)ds.Tables[0].Rows[i].ItemArray[19],
                        SaldoEuro = (double)ds.Tables[0].Rows[i].ItemArray[20],
                        FechaCreacion = (DateTime)ds.Tables[0].Rows[i].ItemArray[21],
                        EsDebito = (bool)ds.Tables[0].Rows[i].ItemArray[22],
                        Concecutivo = (long)ds.Tables[0].Rows[i].ItemArray[23],
                        FechaDocumento = (DateTime)ds.Tables[0].Rows[i].ItemArray[24],
                        IdVendedor = (long)ds.Tables[0].Rows[i].ItemArray[25],
                        IdUsuarioCreador = (long)ds.Tables[0].Rows[i].ItemArray[26],
                        IdPuntoVenta = (long)ds.Tables[0].Rows[i].ItemArray[27],
                        FechaVencimiento = (DateTime)ds.Tables[0].Rows[i].ItemArray[28],
                        Estado = (int)ds.Tables[0].Rows[i].ItemArray[29]
                    });

                }

                return domain;

            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;

            }

        }

    }
}
