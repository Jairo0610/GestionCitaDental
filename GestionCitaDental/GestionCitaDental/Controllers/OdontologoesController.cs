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
    public class OdontologoesController : Controller
    {
        private readonly DbClinicaDentalContext _context;

        public OdontologoesController(DbClinicaDentalContext context)
        {
            _context = context;
        }

        // GET: Odontologoes
        public async Task<IActionResult> Index()
        {
            var dbClinicaDentalContext = _context.TblOdontologos.Include(t => t.IdCorreoNavigation);
            return View(await dbClinicaDentalContext.ToListAsync());
        }

        // GET: Odontologoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblOdontologo = await _context.TblOdontologos
                .Include(t => t.IdCorreoNavigation)
                .FirstOrDefaultAsync(m => m.IdOdontologo == id);
            if (tblOdontologo == null)
            {
                return NotFound();
            }

            return View(tblOdontologo);
        }

        // GET: Odontologoes/Create
        public IActionResult Create()
        {
            ViewData["IdCorreo"] = new SelectList(_context.TblCorreos, "IdCorreo", "Correo");
            return View();
        }

        // POST: Odontologoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdOdontologo,Nombre,Telefono,IdCorreoNavigation")] TblOdontologo tblOdontologo)
        {
            if (ModelState.IsValid)
            {
                TblCorreo tblCorreo = tblOdontologo.IdCorreoNavigation;
                _context.Add(tblCorreo);
                _context.Add(tblOdontologo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCorreo"] = new SelectList(_context.TblCorreos, "IdCorreo", "Correo", tblOdontologo.IdCorreo);
            return View(tblOdontologo);
        }

        // GET: Odontologoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblOdontologo = await _context.TblOdontologos.FindAsync(id);
            if (tblOdontologo == null)
            {
                return NotFound();
            }
            ViewData["IdCorreo"] = new SelectList(_context.TblCorreos, "IdCorreo", "Correo", tblOdontologo.IdCorreo);
            return View(tblOdontologo);
        }

        // POST: Odontologoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdOdontologo,Nombre,Telefono,IdCorreo")] TblOdontologo tblOdontologo)
        {
            if (id != tblOdontologo.IdOdontologo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblOdontologo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblOdontologoExists(tblOdontologo.IdOdontologo))
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
            ViewData["IdCorreo"] = new SelectList(_context.TblCorreos, "IdCorreo", "Correo", tblOdontologo.IdCorreo);
            return View(tblOdontologo);
        }

        // GET: Odontologoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblOdontologo = await _context.TblOdontologos
                .Include(t => t.IdCorreoNavigation)
                .FirstOrDefaultAsync(m => m.IdOdontologo == id);
            if (tblOdontologo == null)
            {
                return NotFound();
            }

            return View(tblOdontologo);
        }

        // POST: Odontologoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblOdontologo = await _context.TblOdontologos.FindAsync(id);
            if (tblOdontologo != null)
            {
                _context.TblOdontologos.Remove(tblOdontologo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblOdontologoExists(int id)
        {
            return _context.TblOdontologos.Any(e => e.IdOdontologo == id);
        }
    }
}
