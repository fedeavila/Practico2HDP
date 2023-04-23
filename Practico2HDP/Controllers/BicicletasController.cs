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
    public class BicicletasController : Controller
    {
        private readonly BiciContext _context;

        public BicicletasController(BiciContext context)
        {
            _context = context;
        }

        // GET: Bicicletas
        public async Task<IActionResult> Index()
        {
            return _context.Bicicleta != null ?
                        View(await _context.Bicicleta.ToListAsync()) :
                        Problem("Entity set 'BiciContext.Bicicleta'  is null.");
        }

        // GET: Bicicletas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Bicicleta == null)
            {
                return NotFound();
            }

            var bicicleta = await _context.Bicicleta
                .FirstOrDefaultAsync(m => m.BicicletaID == id);
            if (bicicleta == null)
            {
                return NotFound();
            }

            return View(bicicleta);
        }

        // GET: Bicicletas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bicicletas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BicicletaID,Marca,Modelo,Categoria,EsElectrica,Color,Anio")] Bicicleta bicicleta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bicicleta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bicicleta);
        }

        // GET: Bicicletas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Bicicleta == null)
            {
                return NotFound();
            }

            var bicicleta = await _context.Bicicleta.FindAsync(id);
            if (bicicleta == null)
            {
                return NotFound();
            }
            return View(bicicleta);
        }

        // POST: Bicicletas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BicicletaID,Marca,Modelo,Categoria,EsElectrica,Color,Anio")] Bicicleta bicicleta)
        {
            if (id != bicicleta.BicicletaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bicicleta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BicicletaExists(bicicleta.BicicletaID))
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
            return View(bicicleta);
        }

        // GET: Bicicletas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Bicicleta == null)
            {
                return NotFound();
            }

            var bicicleta = await _context.Bicicleta
                .FirstOrDefaultAsync(m => m.BicicletaID == id);
            if (bicicleta == null)
            {
                return NotFound();
            }

            return View(bicicleta);
        }

        // POST: Bicicletas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Bicicleta == null)
            {
                return Problem("Entity set 'BiciContext.Bicicleta'  is null.");
            }
            var bicicleta = await _context.Bicicleta.FindAsync(id);
            if (bicicleta != null)
            {
                _context.Bicicleta.Remove(bicicleta);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BicicletaExists(int id)
        {
            return (_context.Bicicleta?.Any(e => e.BicicletaID == id)).GetValueOrDefault();
        }
    }
}
