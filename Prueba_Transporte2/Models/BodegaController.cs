using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Prueba_Transporte2.Models
{
    public class BodegaController : Controller
    {
        private readonly Base_PruebasContext _context;

        public BodegaController(Base_PruebasContext context)
        {
            _context = context;
        }

        // GET: Bodega
        public async Task<IActionResult> Index()
        {
              return _context.Bodegas != null ? 
                          View(await _context.Bodegas.ToListAsync()) :
                          Problem("Entity set 'Base_PruebasContext.Bodegas'  is null.");
        }

        // GET: Bodega/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Bodegas == null)
            {
                return NotFound();
            }

            var bodega = await _context.Bodegas
                .FirstOrDefaultAsync(m => m.BodegaId == id);
            if (bodega == null)
            {
                return NotFound();
            }

            return View(bodega);
        }

        // GET: Bodega/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bodega/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BodegaId,Nombre,Ubicacion")] Bodega bodega)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bodega);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bodega);
        }

        // GET: Bodega/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Bodegas == null)
            {
                return NotFound();
            }

            var bodega = await _context.Bodegas.FindAsync(id);
            if (bodega == null)
            {
                return NotFound();
            }
            return View(bodega);
        }

        // POST: Bodega/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BodegaId,Nombre,Ubicacion")] Bodega bodega)
        {
            if (id != bodega.BodegaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bodega);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BodegaExists(bodega.BodegaId))
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
            return View(bodega);
        }

        // GET: Bodega/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Bodegas == null)
            {
                return NotFound();
            }

            var bodega = await _context.Bodegas
                .FirstOrDefaultAsync(m => m.BodegaId == id);
            if (bodega == null)
            {
                return NotFound();
            }

            return View(bodega);
        }

        // POST: Bodega/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Bodegas == null)
            {
                return Problem("Entity set 'Base_PruebasContext.Bodegas'  is null.");
            }
            var bodega = await _context.Bodegas.FindAsync(id);
            if (bodega != null)
            {
                _context.Bodegas.Remove(bodega);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BodegaExists(int id)
        {
          return (_context.Bodegas?.Any(e => e.BodegaId == id)).GetValueOrDefault();
        }
    }
}
