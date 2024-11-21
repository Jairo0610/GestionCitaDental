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
        private readonly DbClinicaDentalContext _context;

        public CitumsController(DbClinicaDentalContext context)
        {
            _context = context;
        }

        // GET: Citums
        public async Task<IActionResult> Index()
        {
            var dbClinicaDentalContext = _context.TblCita.Include(t => t.IdEstadoCitaNavigation).Include(t => t.IdOdontologoNavigation).Include(t => t.IdPacienteNavigation).Include(t => t.IdProcedimientoNavigation);
            return View(await dbClinicaDentalContext.ToListAsync());
        }

        // GET: Citums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCitum = await _context.TblCita
                .Include(t => t.IdEstadoCitaNavigation)
                .Include(t => t.IdOdontologoNavigation)
                .Include(t => t.IdPacienteNavigation)
                .Include(t => t.IdProcedimientoNavigation)
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
            ViewData["IdEstadoCita"] = new SelectList(_context.TblEstadoCita, "IdEstadoCita", "Descripcion");
            ViewData["IdOdontologo"] = new SelectList(_context.TblOdontologos, "IdOdontologo", "Nombre");
            ViewData["IdPaciente"] = new SelectList(_context.TblPacientes, "IdPaciente", "Nombre");
            ViewData["IdProcedimiento"] = new SelectList(_context.TblProcedimientos, "IdProcedimiento", "Descripcion");
            return View();
        }

        // POST: Citums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCita,IdPaciente,IdProcedimiento,IdOdontologo,IdEstadoCita,Fecha")] TblCitum tblCitum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblCitum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEstadoCita"] = new SelectList(_context.TblEstadoCita, "IdEstadoCita", "Descripcion", tblCitum.IdEstadoCita);
            ViewData["IdOdontologo"] = new SelectList(_context.TblOdontologos, "IdOdontologo", "Nombre", tblCitum.IdOdontologo);
            ViewData["IdPaciente"] = new SelectList(_context.TblPacientes, "IdPaciente", "Nombre", tblCitum.IdPaciente);
            ViewData["IdProcedimiento"] = new SelectList(_context.TblProcedimientos, "IdProcedimiento", "Descripcion", tblCitum.IdProcedimiento);
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
            ViewData["IdEstadoCita"] = new SelectList(_context.TblEstadoCita, "IdEstadoCita", "Descripcion", tblCitum.IdEstadoCita);
            ViewData["IdOdontologo"] = new SelectList(_context.TblOdontologos, "IdOdontologo", "Nombre", tblCitum.IdOdontologo);
            ViewData["IdPaciente"] = new SelectList(_context.TblPacientes, "IdPaciente", "Nombre", tblCitum.IdPaciente);
            ViewData["IdProcedimiento"] = new SelectList(_context.TblProcedimientos, "IdProcedimiento", "Descripcion", tblCitum.IdProcedimiento);
            return View(tblCitum);
        }

        // POST: Citums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCita,IdPaciente,IdProcedimiento,IdOdontologo,IdEstadoCita,Fecha")] TblCitum tblCitum)
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
            ViewData["IdEstadoCita"] = new SelectList(_context.TblEstadoCita, "IdEstadoCita", "Descripcion", tblCitum.IdEstadoCita);
            ViewData["IdOdontologo"] = new SelectList(_context.TblOdontologos, "IdOdontologo", "Nombre", tblCitum.IdOdontologo);
            ViewData["IdPaciente"] = new SelectList(_context.TblPacientes, "IdPaciente", "Nombre", tblCitum.IdPaciente);
            ViewData["IdProcedimiento"] = new SelectList(_context.TblProcedimientos, "IdProcedimiento", "Descripcion", tblCitum.IdProcedimiento);
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
                .Include(t => t.IdEstadoCitaNavigation)
                .Include(t => t.IdOdontologoNavigation)
                .Include(t => t.IdPacienteNavigation)
                .Include(t => t.IdProcedimientoNavigation)
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
