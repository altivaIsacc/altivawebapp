using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AltivaWebApp.Context;
using AltivaWebApp.Domains;

namespace AltivaWebApp.Controllers
{
    public class ContabilidadConfig : Controller
    {
        private readonly EmpresasContext _context;

        public ContabilidadConfig(EmpresasContext context)
        {
            _context = context;
        }

        // GET: ContabilidadConfig
        public async Task<IActionResult> Index()
        {
            return View(await _context.TbCoConfiguracion.ToListAsync());
        }

        // GET: ContabilidadConfig/Details/5
        public async Task<IActionResult> Details(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbCoConfiguracion = await _context.TbCoConfiguracion
                .FirstOrDefaultAsync(m => m.IdConfiguracion == id);
            if (tbCoConfiguracion == null)
            {
                return NotFound();
            }

            return View(tbCoConfiguracion);
        }

        // GET: ContabilidadConfig/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContabilidadConfig/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdConfiguracion,FechaCreacion,IdUsuario,TamanoCuenta,Nivel1,Nivel2,Nivel3,Nivel4,Nivel5,Nivel6,Nivel8,Ejemplo,Nivel7,FechaDesde,FechaHasta")] TbCoConfiguracion tbCoConfiguracion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbCoConfiguracion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbCoConfiguracion);
        }

        // GET: ContabilidadConfig/Edit/5
        public async Task<IActionResult> Edit(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbCoConfiguracion = await _context.TbCoConfiguracion.FindAsync(id);
            if (tbCoConfiguracion == null)
            {
                return NotFound();
            }
            return View(tbCoConfiguracion);
        }

        // POST: ContabilidadConfig/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(short id, [Bind("IdConfiguracion,FechaCreacion,IdUsuario,TamanoCuenta,Nivel1,Nivel2,Nivel3,Nivel4,Nivel5,Nivel6,Nivel8,Ejemplo,Nivel7,FechaDesde,FechaHasta")] TbCoConfiguracion tbCoConfiguracion)
        {
            if (id != tbCoConfiguracion.IdConfiguracion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbCoConfiguracion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbCoConfiguracionExists(tbCoConfiguracion.IdConfiguracion))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tbCoConfiguracion);
        }

        // GET: ContabilidadConfig/Delete/5
        public async Task<IActionResult> Delete(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbCoConfiguracion = await _context.TbCoConfiguracion
                .FirstOrDefaultAsync(m => m.IdConfiguracion == id);
            if (tbCoConfiguracion == null)
            {
                return NotFound();
            }

            return View(tbCoConfiguracion);
        }

        // POST: ContabilidadConfig/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(short id)
        {
            var tbCoConfiguracion = await _context.TbCoConfiguracion.FindAsync(id);
            _context.TbCoConfiguracion.Remove(tbCoConfiguracion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbCoConfiguracionExists(short id)
        {
            return _context.TbCoConfiguracion.Any(e => e.IdConfiguracion == id);
        }
    }
}
