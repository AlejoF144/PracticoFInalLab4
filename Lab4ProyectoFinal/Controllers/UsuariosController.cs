using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab4ProyectoFinal.Data;
using Lab4ProyectoFinal.Models;
using X.PagedList.Extensions;
using Microsoft.AspNetCore.Authorization;


namespace Lab4ProyectoFinal.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly AppDbContext _context;

        public UsuariosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index(string buscarUsuario, int? page)
        {
            int pageSize = 6;
            int pageNumber = page ?? 1;

            var usuarios = _context.Usuarios
                .Include(u => u.MetodoDePago)
                .Include(u => u.Domicilio)
                .AsQueryable();
            
            
            if (!string.IsNullOrEmpty(buscarUsuario))
            {
                usuarios = usuarios.Where(u => u.Nombre!.Contains(buscarUsuario));
            }

       
            var UsuariosPaginados = usuarios.OrderByDescending(p => p.Id).ToPagedList(pageNumber, pageSize);

            return View(UsuariosPaginados);

        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .Include(u => u.MetodoDePago)
                .Include(u => u.Domicilio)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuarios/Create
        [Authorize(Roles = "Admin,Manager")]
        public IActionResult Create()
        {
            ViewData["MetodoDePagoId"] = new SelectList(_context.MetodoDePagos, "Id", "MarcaDeTarjeta");
            ViewData["DomicilioId"] = new SelectList(_context.Domicilio, "Id", "Calle");
            return View();
        }

        // POST: Usuarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Nivel,Estado,ImagenCarpeta,MetodoDePagoId,DomicilioId")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MetodoDePagoId"] = new SelectList(_context.MetodoDePagos, "Id", "MarcaDeTarjeta", usuario.MetodoDePagoId);
            ViewData["DomicilioId"] = new SelectList(_context.Domicilio, "Id", "Calle", usuario.DomicilioId);
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .Include(u => u.MetodoDePago)
                .Include(u => u.Domicilio)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (usuario == null)
            {
                return NotFound();
            }

            ViewData["MetodoDePagoId"] = new SelectList(_context.MetodoDePagos, "Id", "MarcaDeTarjeta", usuario.MetodoDePagoId);
            ViewData["DomicilioId"] = new SelectList(_context.Domicilio, "Id", "Calle", usuario.DomicilioId);
            return View(usuario);
        }


        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Nivel,Estado,ImagenCarpeta,MetodoDePagoId,DomicilioId")] Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.Id))
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
            ViewData["DomicilioId"] = new SelectList(_context.Domicilio, "Id", "Id", usuario.DomicilioId);
            ViewData["MetodoDePagoId"] = new SelectList(_context.MetodoDePagos, "Id", "Id", usuario.MetodoDePagoId);
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .Include(u => u.MetodoDePago)
                .Include(u => u.Domicilio)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }


        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }
    }
}
