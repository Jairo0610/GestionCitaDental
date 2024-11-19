using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestionCitaDental.Models;

namespace GestionCitaDental.Controllers
{
    public class EstadoCitumsController : Controller
    {
        private readonly ClinicaDentalContext _context;

        public EstadoCitumsController(ClinicaDentalContext context)
        {
            _context = context;
        }

        // GET: EstadoCitums
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblEstadoCita.ToListAsync());
        }

        // GET: EstadoCitums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblEstadoCitum = await _context.TblEstadoCita
                .FirstOrDefaultAsync(m => m.IdEstadoCita == id);
            if (tblEstadoCitum == null)
            {
                return NotFound();
            }

            return View(tblEstadoCitum);
        }

        // GET: EstadoCitums/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EstadoCitums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEstadoCita,Descripcion")] TblEstadoCitum tblEstadoCitum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblEstadoCitum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblEstadoCitum);
        }

        // GET: EstadoCitums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblEstadoCitum = await _context.TblEstadoCita.FindAsync(id);
            if (tblEstadoCitum == null)
            {
                return NotFound();
            }
            return View(tblEstadoCitum);
        }

        // POST: EstadoCitums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEstadoCita,Descripcion")] TblEstadoCitum tblEstadoCitum)
        {
            if (id != tblEstadoCitum.IdEstadoCita)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblEstadoCitum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblEstadoCitumExists(tblEstadoCitum.IdEstadoCita))
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
            return View(tblEstadoCitum);
        }

        // GET: EstadoCitums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblEstadoCitum = await _context.TblEstadoCita
                .FirstOrDefaultAsync(m => m.IdEstadoCita == id);
            if (tblEstadoCitum == null)
            {
                return NotFound();
            }

            return View(tblEstadoCitum);
        }

        // POST: EstadoCitums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblEstadoCitum = await _context.TblEstadoCita.FindAsync(id);
            if (tblEstadoCitum != null)
            {
                _context.TblEstadoCita.Remove(tblEstadoCitum);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblEstadoCitumExists(int id)
        {
            return _context.TblEstadoCita.Any(e => e.IdEstadoCita == id);
        }
    }
}
