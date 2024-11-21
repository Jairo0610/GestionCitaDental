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
    public class UsuariosController : Controller
    {
        private readonly DbClinicaDentalContext _context;

        public UsuariosController(DbClinicaDentalContext context)
        {
            _context = context;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            var dbClinicaDentalContext = _context.TblUsuarios.Include(t => t.IdCorreoNavigation).Include(t => t.IdTipoUsuarioNavigation);
            return View(await dbClinicaDentalContext.ToListAsync());
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblUsuario = await _context.TblUsuarios
                .Include(t => t.IdCorreoNavigation)
                .Include(t => t.IdTipoUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (tblUsuario == null)
            {
                return NotFound();
            }

            return View(tblUsuario);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            ViewData["IdCorreo"] = new SelectList(_context.TblCorreos, "IdCorreo", "Correo");
            ViewData["IdTipoUsuario"] = new SelectList(_context.TblTipoUsuarios, "IdTipoUsuario", "IdTipoUsuario");
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUsuario,Usuario,Contraseña,IdCorreo,IdCorreoNavigation")] TblUsuario tblUsuario)
        {
            if (ModelState.IsValid)
            {
                TblCorreo tblCorreo = tblUsuario.IdCorreoNavigation;
                _context.Add(tblCorreo);
                _context.Add(tblUsuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCorreo"] = new SelectList(_context.TblCorreos, "IdCorreo", "Correo", tblUsuario.IdCorreo);
            ViewData["IdTipoUsuario"] = new SelectList(_context.TblTipoUsuarios, "IdTipoUsuario", "Descripcion", tblUsuario.IdTipoUsuario);
            return View(tblUsuario);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblUsuario = await _context.TblUsuarios.FindAsync(id);
            if (tblUsuario == null)
            {
                return NotFound();
            }
            ViewData["IdCorreo"] = new SelectList(_context.TblCorreos, "IdCorreo", "Correo", tblUsuario.IdCorreo);
            ViewData["IdTipoUsuario"] = new SelectList(_context.TblTipoUsuarios, "IdTipoUsuario", "Descripcion", tblUsuario.IdTipoUsuario);
            return View(tblUsuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUsuario,Usuario,Contraseña,IdCorreo,IdTipoUsuario")] TblUsuario tblUsuario)
        {
            if (id != tblUsuario.IdUsuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblUsuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblUsuarioExists(tblUsuario.IdUsuario))
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
            ViewData["IdCorreo"] = new SelectList(_context.TblCorreos, "IdCorreo", "Correo", tblUsuario.IdCorreo);
            ViewData["IdTipoUsuario"] = new SelectList(_context.TblTipoUsuarios, "IdTipoUsuario", "Descripcion", tblUsuario.IdTipoUsuario);
            return View(tblUsuario);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblUsuario = await _context.TblUsuarios
                .Include(t => t.IdCorreoNavigation)
                .Include(t => t.IdTipoUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (tblUsuario == null)
            {
                return NotFound();
            }

            return View(tblUsuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblUsuario = await _context.TblUsuarios.FindAsync(id);
            if (tblUsuario != null)
            {
                _context.TblUsuarios.Remove(tblUsuario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblUsuarioExists(int id)
        {
            return _context.TblUsuarios.Any(e => e.IdUsuario == id);
        }
    }
}
