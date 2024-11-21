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
    public class TipoUsuariosController : Controller
    {
        private readonly DbClinicaDentalContext _context;

        public TipoUsuariosController(DbClinicaDentalContext context)
        {
            _context = context;
        }

        // GET: TipoUsuarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblTipoUsuarios.ToListAsync());
        }

        // GET: TipoUsuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblTipoUsuario = await _context.TblTipoUsuarios
                .FirstOrDefaultAsync(m => m.IdTipoUsuario == id);
            if (tblTipoUsuario == null)
            {
                return NotFound();
            }

            return View(tblTipoUsuario);
        }

        // GET: TipoUsuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoUsuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoUsuario,Descripcion")] TblTipoUsuario tblTipoUsuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblTipoUsuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblTipoUsuario);
        }

        // GET: TipoUsuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblTipoUsuario = await _context.TblTipoUsuarios.FindAsync(id);
            if (tblTipoUsuario == null)
            {
                return NotFound();
            }
            return View(tblTipoUsuario);
        }

        // POST: TipoUsuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoUsuario,Descripcion")] TblTipoUsuario tblTipoUsuario)
        {
            if (id != tblTipoUsuario.IdTipoUsuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblTipoUsuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblTipoUsuarioExists(tblTipoUsuario.IdTipoUsuario))
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
            return View(tblTipoUsuario);
        }

        // GET: TipoUsuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblTipoUsuario = await _context.TblTipoUsuarios
                .FirstOrDefaultAsync(m => m.IdTipoUsuario == id);
            if (tblTipoUsuario == null)
            {
                return NotFound();
            }

            return View(tblTipoUsuario);
        }

        // POST: TipoUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblTipoUsuario = await _context.TblTipoUsuarios.FindAsync(id);
            if (tblTipoUsuario != null)
            {
                _context.TblTipoUsuarios.Remove(tblTipoUsuario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblTipoUsuarioExists(int id)
        {
            return _context.TblTipoUsuarios.Any(e => e.IdTipoUsuario == id);
        }
    }
}
