using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Prueba_Transporte2.Models
{
    public class EnvioController : Controller
    {
        private readonly Base_PruebasContext _context;

        public EnvioController(Base_PruebasContext context)
        {
            _context = context;
        }

        // GET: Envio
        public async Task<IActionResult> Index()
        {
            var base_PruebasContext = _context.Envios.Include(e => e.Bodega).Include(e => e.Cliente).Include(e => e.PlacaNavigation).Include(e => e.Producto);
            return View(await base_PruebasContext.ToListAsync());
        }

        // GET: Envio/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Envios == null)
            {
                return NotFound();
            }

            var envio = await _context.Envios
                .Include(e => e.Bodega)
                .Include(e => e.Cliente)
                .Include(e => e.PlacaNavigation)
                .Include(e => e.Producto)
                .FirstOrDefaultAsync(m => m.EnvioId == id);
            if (envio == null)
            {
                return NotFound();
            }

            return View(envio);
        }

        // GET: Envio/Create
        public IActionResult Create()
        {
            ViewData["BodegaId"] = new SelectList(_context.Bodegas, "BodegaId", "BodegaId");
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId");
            ViewData["Placa"] = new SelectList(_context.Vehiculos, "Placa", "Placa");
            ViewData["ProductoId"] = new SelectList(_context.Productos, "ProductoId", "ProductoId");
            return View();
        }

        // POST: Envio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EnvioId,ClienteId,ProductoId,Cantidad,Placa,PrecioEnvio,PrecioEnvioNeto,FechaRegistro,FechaEntrega,NumeroGuia,BodegaId")] Envio envio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(envio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BodegaId"] = new SelectList(_context.Bodegas, "BodegaId", "BodegaId", envio.BodegaId);
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId", envio.ClienteId);
            ViewData["Placa"] = new SelectList(_context.Vehiculos, "Placa", "Placa", envio.Placa);
            ViewData["ProductoId"] = new SelectList(_context.Productos, "ProductoId", "ProductoId", envio.ProductoId);
            return View(envio);
        }

        // GET: Envio/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Envios == null)
            {
                return NotFound();
            }

            var envio = await _context.Envios.FindAsync(id);
            if (envio == null)
            {
                return NotFound();
            }
            ViewData["BodegaId"] = new SelectList(_context.Bodegas, "BodegaId", "BodegaId", envio.BodegaId);
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId", envio.ClienteId);
            ViewData["Placa"] = new SelectList(_context.Vehiculos, "Placa", "Placa", envio.Placa);
            ViewData["ProductoId"] = new SelectList(_context.Productos, "ProductoId", "ProductoId", envio.ProductoId);
            return View(envio);
        }

        // POST: Envio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EnvioId,ClienteId,ProductoId,Cantidad,Placa,PrecioEnvio,PrecioEnvioNeto,FechaRegistro,FechaEntrega,NumeroGuia,BodegaId")] Envio envio)
        {
            if (id != envio.EnvioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(envio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnvioExists(envio.EnvioId))
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
            ViewData["BodegaId"] = new SelectList(_context.Bodegas, "BodegaId", "BodegaId", envio.BodegaId);
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId", envio.ClienteId);
            ViewData["Placa"] = new SelectList(_context.Vehiculos, "Placa", "Placa", envio.Placa);
            ViewData["ProductoId"] = new SelectList(_context.Productos, "ProductoId", "ProductoId", envio.ProductoId);
            return View(envio);
        }

        // GET: Envio/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Envios == null)
            {
                return NotFound();
            }

            var envio = await _context.Envios
                .Include(e => e.Bodega)
                .Include(e => e.Cliente)
                .Include(e => e.PlacaNavigation)
                .Include(e => e.Producto)
                .FirstOrDefaultAsync(m => m.EnvioId == id);
            if (envio == null)
            {
                return NotFound();
            }

            return View(envio);
        }

        // POST: Envio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Envios == null)
            {
                return Problem("Entity set 'Base_PruebasContext.Envios'  is null.");
            }
            var envio = await _context.Envios.FindAsync(id);
            if (envio != null)
            {
                _context.Envios.Remove(envio);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnvioExists(int id)
        {
          return (_context.Envios?.Any(e => e.EnvioId == id)).GetValueOrDefault();
        }
    }
}
