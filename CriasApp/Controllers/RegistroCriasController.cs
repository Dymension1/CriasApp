using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CriasApp.Models;

namespace CriasApp.Controllers
{
    public class RegistroCriasController : Controller
    {
        private readonly CriasContext _context;

        public RegistroCriasController(CriasContext context)
        {
            _context = context;
        }

        // GET: RegistroCrias
        public async Task<IActionResult> Index()
        {
              return _context.RegistroCrias != null ? 
                          View(await _context.RegistroCrias.ToListAsync()) :
                          Problem("Entity set 'CriasContext.RegistroCrias'  is null.");
        }

        // GET: RegistroCrias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RegistroCrias == null)
            {
                return NotFound();
            }

            var registroCria = await _context.RegistroCrias
                .FirstOrDefaultAsync(m => m.IdCria == id);
            if (registroCria == null)
            {
                return NotFound();
            }

            return View(registroCria);
        }

        // GET: RegistroCrias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RegistroCrias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCria,Fecha,Peso,Costo,Nombre,Descripcion")] RegistroCria registroCria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registroCria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(registroCria);
        }

        // GET: RegistroCrias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RegistroCrias == null)
            {
                return NotFound();
            }

            var registroCria = await _context.RegistroCrias.FindAsync(id);
            if (registroCria == null)
            {
                return NotFound();
            }
            return View(registroCria);
        }

        // POST: RegistroCrias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCria,Fecha,Peso,Costo,Nombre,Descripcion")] RegistroCria registroCria)
        {
            if (id != registroCria.IdCria)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registroCria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistroCriaExists(registroCria.IdCria))
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
            return View(registroCria);
        }

        // GET: RegistroCrias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RegistroCrias == null)
            {
                return NotFound();
            }

            var registroCria = await _context.RegistroCrias
                .FirstOrDefaultAsync(m => m.IdCria == id);
            if (registroCria == null)
            {
                return NotFound();
            }

            return View(registroCria);
        }

        // POST: RegistroCrias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RegistroCrias == null)
            {
                return Problem("Entity set 'CriasContext.RegistroCrias'  is null.");
            }
            var registroCria = await _context.RegistroCrias.FindAsync(id);
            if (registroCria != null)
            {
                _context.RegistroCrias.Remove(registroCria);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistroCriaExists(int id)
        {
          return (_context.RegistroCrias?.Any(e => e.IdCria == id)).GetValueOrDefault();
        }
    }
}
