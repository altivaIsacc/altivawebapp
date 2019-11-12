using AltivaWebApp.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace AltivaWebApp.Repositories
{
    public class SaldoGeneralRepository: BaseRepository<DocumentosSaldoGeneralViewModel>, ISaldoGeneralRepository
    {
        public SaldoGeneralRepository(EmpresasContext context) : base(context)
        {

        }
        public IList<DocumentosSaldoGeneralViewModel> GetDocumentos()
        {
            var model = context.DocumentosSaldoGeneral.FromSql("select m.SaldoBase, m.SaldoEuro, m.SaldoDolar, m.IdContacto, m.FechaCreacion, m.IdMovimiento, m.IdDocumento from tb_FA_Movimiento as m, tb_FD_Factura as f where m.IdDocumento = f.Id ").ToList();
            return model;
        }
        public IList<ContactoSaldoGeneralViewModel> GetContactos()
        {
            var model = context.ContactoSaldoGeneral.FromSql("select c.IdContacto, Nombre, Apellidos, NombreComercial,Cedula, PlazoCredito, MontoMaximo from Tb_CR_Contacto  c inner join TB_FD_CondicionesDePago  cd on c.IdContacto = cd.IdContacto where Cliente = 1 and PlazoCredito <> 0 and c.IdContacto = any(select idcontacto from tb_FA_Movimiento)").ToList();
            return model;
        }
    }
}
