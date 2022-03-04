using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Brive.ProyectoFinal.Api.Context;
using Brive.ProyectoFinal.Api.Models;

namespace Brive.ProyectoFinal.Api
{
    public class BusquedasvistasController : Controller
    {
        private readonly AppDbContext _context;

        public BusquedasvistasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Busquedasvistas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Busquedas.ToListAsync());
        }

        // GET: Busquedasvistas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var busquedas = await _context.Busquedas
                .FirstOrDefaultAsync(m => m.ID_BUSQUEDA == id);
            if (busquedas == null)
            {
                return NotFound();
            }

            return View(busquedas);
        }

        // GET: Busquedasvistas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Busquedasvistas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_BUSQUEDA,EMPRESA_BUSCADA,RESULTADO_BUSQUEDA,FECHA_BUSQUEDA")] Busquedas busquedas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(busquedas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(busquedas);
        }

        // GET: Busquedasvistas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var busquedas = await _context.Busquedas.FindAsync(id);
            if (busquedas == null)
            {
                return NotFound();
            }
            return View(busquedas);
        }

        // POST: Busquedasvistas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_BUSQUEDA,EMPRESA_BUSCADA,RESULTADO_BUSQUEDA,FECHA_BUSQUEDA")] Busquedas busquedas)
        {
            if (id != busquedas.ID_BUSQUEDA)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(busquedas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BusquedasExists(busquedas.ID_BUSQUEDA))
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
            return View(busquedas);
        }

        // GET: Busquedasvistas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var busquedas = await _context.Busquedas
                .FirstOrDefaultAsync(m => m.ID_BUSQUEDA == id);
            if (busquedas == null)
            {
                return NotFound();
            }

            return View(busquedas);
        }

        // POST: Busquedasvistas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var busquedas = await _context.Busquedas.FindAsync(id);
            _context.Busquedas.Remove(busquedas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BusquedasExists(int id)
        {
            return _context.Busquedas.Any(e => e.ID_BUSQUEDA == id);
        }
    }
}
