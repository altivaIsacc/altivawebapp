using AltivaWebApp.Context;
using AltivaWebApp.Domains;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;

namespace AltivaWebApp.Controllers
{
    [Route("{culture}/Devolucion")]
    public class DevolucionController : Controller
    {
        EmpresasContext bd;
        public DevolucionController(EmpresasContext _bd)
        {
            this.bd = _bd;
        }
        public IActionResult Index()
        {           
            return View("DevolucionIndex");
        }
        [HttpPost("_DevolucionesGrid")]
        public IActionResult _DevolucionesGrid(long id = 0, string vendedor = "", string cliente = "", string fechaDesde = "", string fechaHasta = "", string estado = "")
        {
            if (vendedor == null) { vendedor = ""; }
            if (cliente == null) { cliente = ""; }
            if (estado == null) { estado = ""; }
            if (fechaDesde == null) { fechaDesde = ""; }
            else
            {
                System.DateTime ff = System.Convert.ToDateTime(fechaDesde).Date;
                fechaDesde = ff.ToString("dd/MM/yyyy");
            }

            if (fechaHasta == null) { fechaHasta = ""; }
            else
            {
                System.DateTime ff = System.Convert.ToDateTime(fechaHasta).Date;
                fechaHasta = ff.ToString("dd/MM/yyyy");
            }
            string consulta = "SELECT tb_FA_Devolucion.IdDevolucion, tb_FA_Devolucion.Fecha, tb_FA_Devolucion.Estado, tb_FA_Devolucion.Total, tb_FA_Devolucion.IdContacto, tb_FA_Devolucion.IdVendedor,  tb_FA_Devolucion.Creacion, tb_FA_Devolucion.Modificacion, tb_FA_Devolucion.Nota, vs_CR_Contacto.NombreCompleto AS Cliente, vs_SE_Usuario.Nombre AS Vendedor, vs_SE_Usuario.Iniciales,  vs_SE_Usuario_1.Nombre AS Creador, vs_SE_Usuario_2.Nombre AS Modificador FROM tb_FA_Devolucion INNER JOIN  vs_SE_Usuario ON tb_FA_Devolucion.IdVendedor = vs_SE_Usuario.Id INNER JOIN  vs_CR_Contacto ON tb_FA_Devolucion.IdContacto = vs_CR_Contacto.IdContacto INNER JOIN  vs_SE_Usuario AS vs_SE_Usuario_1 ON tb_FA_Devolucion.IdCreador = vs_SE_Usuario_1.Id INNER JOIN  vs_SE_Usuario AS vs_SE_Usuario_2 ON tb_FA_Devolucion.IdModificador = vs_SE_Usuario_2.Id";
            string where = "";

            SqlCommand cmd = new SqlCommand();
            ;
            if (id != 0)
            {

                SqlParameter idPar = new SqlParameter("@id", id);
                cmd.Parameters.Add(idPar);

                if (where == "") { where = " WHERE"; } else { where += " AND "; }
                where += " IdDevolucion = @id";


            }
            if (vendedor != "")
            {
                SqlParameter VendedorPar = new SqlParameter("@vendedor", "%" + vendedor + "%");
                cmd.Parameters.Add(VendedorPar);

                if (where == "") { where = " WHERE"; } else { where += " AND"; }
                where += " vs_SE_Usuario.Nombre  LIKE @vendedor";
            }
            if (cliente != "")
            {
                SqlParameter ClientePar = new SqlParameter("@Cliente","%" + cliente + "%");
                cmd.Parameters.Add(ClientePar);

                if (where == "") { where = " WHERE"; } else { where += " AND"; }
                where += " vs_CR_Contacto.NombreCompleto LIKE @Cliente";
            }
            if (fechaDesde != "")
            {
                System.DateTime fDesde;
                if (System.DateTime.TryParse(fechaDesde, out fDesde))
                {
                    SqlParameter desdePar = new SqlParameter("@desde", fDesde);
                    cmd.Parameters.Add(desdePar);

                    if (where == "") { where = " WHERE"; } else { where += " AND"; }
                    where += " tb_FA_Devolucion.Fecha >= @desde";
                }
            }
            if (fechaHasta != "")
            {

                System.DateTime fHasta;
                if (System.DateTime.TryParse(fechaHasta, out fHasta))
                {
                    SqlParameter hastaPar = new SqlParameter("@hasta", fHasta);
                    cmd.Parameters.Add(hastaPar);

                    if (where == "") { where = " WHERE"; } else { where += " AND"; }
                    where += " tb_FA_Devolucion.Fecha <= @hasta";
                }

            }
          
                if (estado != "")
                {
                    SqlParameter estadoPar = new SqlParameter("@Estado", estado);
                    cmd.Parameters.Add(estadoPar);
                    if (where == "") { where = " WHERE"; } else { where += " AND"; }
                    where += " tb_FA_Devolucion.Estado = @Estado";
                }
        
           
            cmd.CommandText = consulta + where;
            DataTable dt = new DataTable();
            AltivaData.Provider.SQL.fill(cmd, dt, StringFactory.StringEmpresas);
            ViewBag.resultado = dt.AsEnumerable().ToList();
            return PartialView("_DevolucionesGrid");
        }
        [HttpGet("v")]
        public IActionResult DevolucionVer(long id)
        {
            Devolucion item = bd.Devoluciones.Where(p => p.IdDevolucion == id).FirstOrDefault();
            item.Detalle = bd.DevolucionesDetalle.Where(p => p.IdDevolucion == id).ToList();
            return View("DevolucionVer",item);
        }
        [HttpGet("e")]
        public IActionResult e(long id)
        {
            Devolucion item;
            if (id == 0)
            {
                item = new Devolucion();
                item.Nota = "";
                item.Fecha = System.DateTime.Now.Date;
                item.Estado = 0;
                item.Creacion = System.DateTime.Now;
                item.Modificacion = System.DateTime.Now;
                item.Total = 0;
                item.IdCreador = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);           
            }
            else {
                item = bd.Devoluciones.Where(p => p.IdDevolucion == id).FirstOrDefault();           
            }
            Empresa e = bd.Empresas.Where(p => p.Id == (int)HttpContext.Session.GetInt32("idEmpresa")).FirstOrDefault();
            PuntoVenta pv = bd.PuntosVenta.Where(p => p.IdPuntoVenta == e.IdPuntoVenta).FirstOrDefault();

            ViewBag.IdTipoPrecioDefecto = pv.IdTipoPrecioDefecto;
            ViewBag.TiposCliente = bd.TbFdTipoCliente.Where(p => p.Inactivo == false).ToList();
            ViewBag.PreciosCatalogo = bd.PreciosCatalogo.ToList();
            item.IdModificador = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
            item.Detalle = bd.DevolucionesDetalle.Where(p => p.IdDevolucion == id).ToList();
            ViewData["Usuarios"] = bd.Usuarios.ToList();
            ViewBag.Motivos = bd.MotivosDevolucion.ToList();
            ViewBag.Inventario = bd.Inventarios.ToList();
            return View("DevolucionCrearEditar", item);
        }
        [HttpPost("guardar")]
        public IActionResult guardar(Devolucion dev)
        {
            try {
                Devolucion item;
                if (dev.IdDevolucion == 0)
                {
                    item = new Devolucion();
                }
                else
                {
                    item = bd.Devoluciones.Find(dev.IdDevolucion);
                }
                item.Fecha = dev.Fecha;
                item.Estado = dev.Estado;
                item.Total = dev.Total;
                if (dev.Nota == null)
                {
                    item.Nota = "";
                }
                else { item.Nota = dev.Nota; }
             
                item.IdContacto = dev.IdContacto;
                item.IdVendedor = dev.IdVendedor;
                item.Creacion = dev.Creacion;
                item.IdCreador = dev.IdCreador;
                item.Modificacion = dev.Modificacion;
                item.IdModificador = dev.IdModificador;
                item.Modificacion = System.DateTime.Now;

                if (dev.IdDevolucion == 0)
                {
                    bd.Devoluciones.Add(item);
                }
                else
                {
                    bd.Devoluciones.Update(item);
                }

                foreach (DevolucionDetalle itemLi in dev.Detalle)
                {
                    if (itemLi.IdDevolucion == 0)
                    {
                        DevolucionDetalle nueva = new DevolucionDetalle();
                        nueva.IdDevolucion = itemLi.IdDevolucion;
                        nueva.IdInventario = itemLi.IdInventario;
                        nueva.Modificacion = itemLi.Modificacion;
                        nueva.Devolver = itemLi.Devolver;
                        nueva.PrecioUnit = itemLi.PrecioUnit;
                        nueva.Total = itemLi.Total;
                        nueva.Creacion = System.DateTime.Now;
                        nueva.IdMotivoDevolucion = itemLi.IdMotivoDevolucion;

                        bd.DevolucionesDetalle.Add(itemLi);
                    }
                    else {
                        if (itemLi.IdDevolucion == dev.IdDevolucion)
                        {

                        }
                        else
                        {

                        }
                    }


                }
                bd.SaveChanges();
                return Json(new { success = true, idDevolucion = item.IdDevolucion });
            }
            catch (System.Exception ex) {
                AltivaLog.Log.Insertar(ex.ToString(), "ERROR");
                return Json(new { success = false, idDevolucion = 0 });
            }
            
           
        }
    }
}
