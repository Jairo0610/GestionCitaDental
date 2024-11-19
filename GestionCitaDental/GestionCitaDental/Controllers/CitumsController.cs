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
    public class CitumsController : Controller
    {
        private readonly ClinicaDentalContext _context;

        public CitumsController(ClinicaDentalContext context)
        {
            _context = context;
        }

        // GET: Citums
        public async Task<IActionResult> Index()
        {
            var clinicaDentalContext = _context.TblCita.Include(t => t.IdEstadoNavigation).Include(t => t.IdOdontologoNavigation).Include(t => t.IdPacienteNavigation).Include(t => t.IdProcesoNavigation);
            return View(await clinicaDentalContext.ToListAsync());
        }

        // GET: Citums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCitum = await _context.TblCita
                .Include(t => t.IdEstadoNavigation)
                .Include(t => t.IdOdontologoNavigation)
                .Include(t => t.IdPacienteNavigation)
                .Include(t => t.IdProcesoNavigation)
                .FirstOrDefaultAsync(m => m.IdCita == id);
            if (tblCitum == null)
            {
                return NotFound();
            }

            return View(tblCitum);
        }

        // GET: Citums/Create
        public IActionResult Create()
        {
            ViewData["IdEstado"] = new SelectList(_context.TblEstadoCita, "IdEstadoCita", "IdEstadoCita");
            ViewData["IdOdontologo"] = new SelectList(_context.TblOdontologos, "IdOdontologo", "IdOdontologo");
            ViewData["IdPaciente"] = new SelectList(_context.TblPacientes, "IdPaciente", "IdPaciente");
            ViewData["IdProceso"] = new SelectList(_context.TblProcedimientos, "IdProcedimiento", "IdProcedimiento");
            return View();
        }

        // POST: Citums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCita,IdPaciente,IdProceso,IdOdontologo,FechaCita,IdEstado")] TblCitum tblCitum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblCitum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEstado"] = new SelectList(_context.TblEstadoCita, "IdEstadoCita", "IdEstadoCita", tblCitum.IdEstado);
            ViewData["IdOdontologo"] = new SelectList(_context.TblOdontologos, "IdOdontologo", "IdOdontologo", tblCitum.IdOdontologo);
            ViewData["IdPaciente"] = new SelectList(_context.TblPacientes, "IdPaciente", "IdPaciente", tblCitum.IdPaciente);
            ViewData["IdProceso"] = new SelectList(_context.TblProcedimientos, "IdProcedimiento", "IdProcedimiento", tblCitum.IdProceso);
            return View(tblCitum);
        }

        // GET: Citums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCitum = await _context.TblCita.FindAsync(id);
            if (tblCitum == null)
            {
                return NotFound();
            }
            ViewData["IdEstado"] = new SelectList(_context.TblEstadoCita, "IdEstadoCita", "IdEstadoCita", tblCitum.IdEstado);
            ViewData["IdOdontologo"] = new SelectList(_context.TblOdontologos, "IdOdontologo", "IdOdontologo", tblCitum.IdOdontologo);
            ViewData["IdPaciente"] = new SelectList(_context.TblPacientes, "IdPaciente", "IdPaciente", tblCitum.IdPaciente);
            ViewData["IdProceso"] = new SelectList(_context.TblProcedimientos, "IdProcedimiento", "IdProcedimiento", tblCitum.IdProceso);
            return View(tblCitum);
        }

        // POST: Citums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCita,IdPaciente,IdProceso,IdOdontologo,FechaCita,IdEstado")] TblCitum tblCitum)
        {
            if (id != tblCitum.IdCita)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblCitum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblCitumExists(tblCitum.IdCita))
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
            ViewData["IdEstado"] = new SelectList(_context.TblEstadoCita, "IdEstadoCita", "IdEstadoCita", tblCitum.IdEstado);
            ViewData["IdOdontologo"] = new SelectList(_context.TblOdontologos, "IdOdontologo", "IdOdontologo", tblCitum.IdOdontologo);
            ViewData["IdPaciente"] = new SelectList(_context.TblPacientes, "IdPaciente", "IdPaciente", tblCitum.IdPaciente);
            ViewData["IdProceso"] = new SelectList(_context.TblProcedimientos, "IdProcedimiento", "IdProcedimiento", tblCitum.IdProceso);
            return View(tblCitum);
        }

        // GET: Citums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCitum = await _context.TblCita
                .Include(t => t.IdEstadoNavigation)
                .Include(t => t.IdOdontologoNavigation)
                .Include(t => t.IdPacienteNavigation)
                .Include(t => t.IdProcesoNavigation)
                .FirstOrDefaultAsync(m => m.IdCita == id);
            if (tblCitum == null)
            {
                return NotFound();
            }

            return View(tblCitum);
        }

        // POST: Citums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblCitum = await _context.TblCita.FindAsync(id);
            if (tblCitum != null)
            {
                _context.TblCita.Remove(tblCitum);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblCitumExists(int id)
        {
            return _context.TblCita.Any(e => e.IdCita == id);
        }
    }
}
