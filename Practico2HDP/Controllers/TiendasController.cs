using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Practico2HDP.Data;
using Practico2HDP.Models;

namespace Practico2HDP.Controllers
{
    public class TiendasController : Controller
    {
        private readonly BiciContext _context;

        public TiendasController(BiciContext context)
        {
            _context = context;
        }

        // GET: Tiendas
        public async Task<IActionResult> Index()
        {
            return _context.Tienda != null ?
                        View(await _context.Tienda.ToListAsync()) :
                        Problem("Entity set 'BiciContext.Tienda'  is null.");
        }

        // GET: Tiendas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tienda == null)
            {
                return NotFound();
            }

            var tienda = await _context.Tienda
                .FirstOrDefaultAsync(m => m.TiendaID == id);
            if (tienda == null)
            {
                return NotFound();
            }

            return View(tienda);
        }

        // GET: Tiendas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tiendas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TiendaID,RazonSocial,Direccion,Tel,Email")] Tienda tienda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tienda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tienda);
        }

        // GET: Tiendas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tienda == null)
            {
                return NotFound();
            }

            var tienda = await _context.Tienda.FindAsync(id);
            if (tienda == null)
            {
                return NotFound();
            }
            return View(tienda);
        }

        // POST: Tiendas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TiendaID,RazonSocial,Direccion,Tel,Email")] Tienda tienda)
        {
            if (id != tienda.TiendaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tienda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TiendaExists(tienda.TiendaID))
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
            return View(tienda);
        }

        // GET: Tiendas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tienda == null)
            {
                return NotFound();
            }

            var tienda = await _context.Tienda
                .FirstOrDefaultAsync(m => m.TiendaID == id);
            if (tienda == null)
            {
                return NotFound();
            }

            return View(tienda);
        }

        // POST: Tiendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tienda == null)
            {
                return Problem("Entity set 'BiciContext.Tienda'  is null.");
            }
            var tienda = await _context.Tienda.FindAsync(id);
            if (tienda != null)
            {
                _context.Tienda.Remove(tienda);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TiendaExists(int id)
        {
            return (_context.Tienda?.Any(e => e.TiendaID == id)).GetValueOrDefault();
        }
    }
}
