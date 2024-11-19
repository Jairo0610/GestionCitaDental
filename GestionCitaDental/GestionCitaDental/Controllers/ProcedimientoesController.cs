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
    public class ProcedimientoesController : Controller
    {
        private readonly ClinicaDentalContext _context;

        public ProcedimientoesController(ClinicaDentalContext context)
        {
            _context = context;
        }

        // GET: Procedimientoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblProcedimientos.ToListAsync());
        }

        // GET: Procedimientoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblProcedimiento = await _context.TblProcedimientos
                .FirstOrDefaultAsync(m => m.IdProcedimiento == id);
            if (tblProcedimiento == null)
            {
                return NotFound();
            }

            return View(tblProcedimiento);
        }

        // GET: Procedimientoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Procedimientoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProcedimiento,Descripcion,Costo")] TblProcedimiento tblProcedimiento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblProcedimiento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblProcedimiento);
        }

        // GET: Procedimientoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblProcedimiento = await _context.TblProcedimientos.FindAsync(id);
            if (tblProcedimiento == null)
            {
                return NotFound();
            }
            return View(tblProcedimiento);
        }

        // POST: Procedimientoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProcedimiento,Descripcion,Costo")] TblProcedimiento tblProcedimiento)
        {
            if (id != tblProcedimiento.IdProcedimiento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblProcedimiento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblProcedimientoExists(tblProcedimiento.IdProcedimiento))
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
            return View(tblProcedimiento);
        }

        // GET: Procedimientoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblProcedimiento = await _context.TblProcedimientos
                .FirstOrDefaultAsync(m => m.IdProcedimiento == id);
            if (tblProcedimiento == null)
            {
                return NotFound();
            }

            return View(tblProcedimiento);
        }

        // POST: Procedimientoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblProcedimiento = await _context.TblProcedimientos.FindAsync(id);
            if (tblProcedimiento != null)
            {
                _context.TblProcedimientos.Remove(tblProcedimiento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblProcedimientoExists(int id)
        {
            return _context.TblProcedimientos.Any(e => e.IdProcedimiento == id);
        }
    }
}
