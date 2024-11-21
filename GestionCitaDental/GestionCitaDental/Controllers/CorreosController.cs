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
    public class CorreosController : Controller
    {
        private readonly DbClinicaDentalContext _context;

        public CorreosController(DbClinicaDentalContext context)
        {
            _context = context;
        }

        // GET: Correos
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblCorreos.ToListAsync());
        }

        // GET: Correos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCorreo = await _context.TblCorreos
                .FirstOrDefaultAsync(m => m.IdCorreo == id);
            if (tblCorreo == null)
            {
                return NotFound();
            }

            return View(tblCorreo);
        }

        // GET: Correos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Correos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCorreo,Correo")] TblCorreo tblCorreo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblCorreo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblCorreo);
        }

        // GET: Correos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCorreo = await _context.TblCorreos.FindAsync(id);
            if (tblCorreo == null)
            {
                return NotFound();
            }
            return View(tblCorreo);
        }

        // POST: Correos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCorreo,Correo")] TblCorreo tblCorreo)
        {
            if (id != tblCorreo.IdCorreo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblCorreo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblCorreoExists(tblCorreo.IdCorreo))
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
            return View(tblCorreo);
        }

        // GET: Correos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCorreo = await _context.TblCorreos
                .FirstOrDefaultAsync(m => m.IdCorreo == id);
            if (tblCorreo == null)
            {
                return NotFound();
            }

            return View(tblCorreo);
        }

        // POST: Correos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblCorreo = await _context.TblCorreos.FindAsync(id);
            if (tblCorreo != null)
            {
                _context.TblCorreos.Remove(tblCorreo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblCorreoExists(int id)
        {
            return _context.TblCorreos.Any(e => e.IdCorreo == id);
        }
    }
}
