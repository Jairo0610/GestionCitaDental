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
    public class PacientesController : Controller
    {
        private readonly ClinicaDentalContext _context;

        public PacientesController(ClinicaDentalContext context)
        {
            _context = context;
        }

        // GET: Pacientes
        public async Task<IActionResult> Index()
        {
            var clinicaDentalContext = _context.TblPacientes.Include(t => t.IdCorreoNavigation);
            return View(await clinicaDentalContext.ToListAsync());
        }

        // GET: Pacientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPaciente = await _context.TblPacientes
                .Include(t => t.IdCorreoNavigation)
                .FirstOrDefaultAsync(m => m.IdPaciente == id);
            if (tblPaciente == null)
            {
                return NotFound();
            }

            return View(tblPaciente);
        }

        // GET: Pacientes/Create
        public IActionResult Create()
        {
            ViewData["IdCorreo"] = new SelectList(_context.TblCorreos, "IdCorreo", "IdCorreo");
            return View();
        }

        // POST: Pacientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPaciente,Nombre,Telefono,Direccion,Dui,IdCorreo")] TblPaciente tblPaciente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblPaciente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCorreo"] = new SelectList(_context.TblCorreos, "IdCorreo", "IdCorreo", tblPaciente.IdCorreo);
            return View(tblPaciente);
        }

        // GET: Pacientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPaciente = await _context.TblPacientes.FindAsync(id);
            if (tblPaciente == null)
            {
                return NotFound();
            }
            ViewData["IdCorreo"] = new SelectList(_context.TblCorreos, "IdCorreo", "IdCorreo", tblPaciente.IdCorreo);
            return View(tblPaciente);
        }

        // POST: Pacientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPaciente,Nombre,Telefono,Direccion,Dui,IdCorreo")] TblPaciente tblPaciente)
        {
            if (id != tblPaciente.IdPaciente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblPaciente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblPacienteExists(tblPaciente.IdPaciente))
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
            ViewData["IdCorreo"] = new SelectList(_context.TblCorreos, "IdCorreo", "IdCorreo", tblPaciente.IdCorreo);
            return View(tblPaciente);
        }

        // GET: Pacientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPaciente = await _context.TblPacientes
                .Include(t => t.IdCorreoNavigation)
                .FirstOrDefaultAsync(m => m.IdPaciente == id);
            if (tblPaciente == null)
            {
                return NotFound();
            }

            return View(tblPaciente);
        }

        // POST: Pacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblPaciente = await _context.TblPacientes.FindAsync(id);
            if (tblPaciente != null)
            {
                _context.TblPacientes.Remove(tblPaciente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblPacienteExists(int id)
        {
            return _context.TblPacientes.Any(e => e.IdPaciente == id);
        }
    }
}
