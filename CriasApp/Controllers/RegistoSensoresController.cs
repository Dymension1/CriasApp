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
    public class RegistoSensoresController : Controller
    {
        private readonly CriasContext _context;

        public RegistoSensoresController(CriasContext context)
        {
            _context = context;
        }

        // GET: RegistoSensores
        public async Task<IActionResult> Index()
        {
              return _context.RegistoSensores != null ? 
                          View(await _context.RegistoSensores.ToListAsync()) :
                          Problem("Entity set 'CriasContext.RegistoSensores'  is null.");
        }

        // GET: RegistoSensores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RegistoSensores == null)
            {
                return NotFound();
            }

            var registoSensores = await _context.RegistoSensores
                .FirstOrDefaultAsync(m => m.IdSensor == id);
            if (registoSensores == null)
            {
                return NotFound();
            }

            return View(registoSensores);
        }

        // GET: RegistoSensores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RegistoSensores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSensor,freCardiaca,preSanguinea,freRespiratoria,temperatura")] RegistoSensores registoSensores)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registoSensores);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(registoSensores);
        }

        // GET: RegistoSensores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RegistoSensores == null)
            {
                return NotFound();
            }

            var registoSensores = await _context.RegistoSensores.FindAsync(id);
            if (registoSensores == null)
            {
                return NotFound();
            }
            return View(registoSensores);
        }

        // POST: RegistoSensores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSensor,freCardiaca,preSanguinea,freRespiratoria,temperatura")] RegistoSensores registoSensores)
        {
            if (id != registoSensores.IdSensor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registoSensores);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistoSensoresExists(registoSensores.IdSensor))
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
            return View(registoSensores);
        }

        // GET: RegistoSensores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RegistoSensores == null)
            {
                return NotFound();
            }

            var registoSensores = await _context.RegistoSensores
                .FirstOrDefaultAsync(m => m.IdSensor == id);
            if (registoSensores == null)
            {
                return NotFound();
            }

            return View(registoSensores);
        }

        // POST: RegistoSensores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RegistoSensores == null)
            {
                return Problem("Entity set 'CriasContext.RegistoSensores'  is null.");
            }
            var registoSensores = await _context.RegistoSensores.FindAsync(id);
            if (registoSensores != null)
            {
                _context.RegistoSensores.Remove(registoSensores);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistoSensoresExists(int id)
        {
          return (_context.RegistoSensores?.Any(e => e.IdSensor == id)).GetValueOrDefault();
        }
    }
}
