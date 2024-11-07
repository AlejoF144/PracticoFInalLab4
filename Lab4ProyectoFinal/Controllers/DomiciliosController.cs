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
    public class DomiciliosController : Controller
    {
        private readonly AppDbContext _context;

        public DomiciliosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Domicilios
        public IActionResult Index(string buscarDomicilio, int? page)
        {
            int pageSize = 6;
            int pageNumber = page ?? 1;

            var domicilios = from domicilio in _context.Domicilio select domicilio;

            // Filtrar los productos según el término de búsqueda
            if (!string.IsNullOrEmpty(buscarDomicilio))
            {
                domicilios = domicilios.Where(s => s.Calle!.Contains(buscarDomicilio));
            }
            //Mas nuevo se ve primero
            var DomiciliosPaginadas = domicilios.OrderByDescending(p => p.Id).ToPagedList(pageNumber, pageSize);


            return View(DomiciliosPaginadas);
        }

        // GET: Domicilios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var domicilio = await _context.Domicilio
                .FirstOrDefaultAsync(m => m.Id == id);
            if (domicilio == null)
            {
                return NotFound();
            }

            return View(domicilio);
        }

        // GET: Domicilios/Create
        [Authorize(Roles = "Admin,Manager")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Domicilios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Calle")] Domicilio domicilio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(domicilio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(domicilio);
        }

        // GET: Domicilios/Edit/5
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var domicilio = await _context.Domicilio.FindAsync(id);
            if (domicilio == null)
            {
                return NotFound();
            }
            return View(domicilio);
        }

        // POST: Domicilios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Calle")] Domicilio domicilio)
        {
            if (id != domicilio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(domicilio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DomicilioExists(domicilio.Id))
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
            return View(domicilio);
        }
        [Authorize(Roles = "Admin,Manager")]
        // GET: Domicilios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var domicilio = await _context.Domicilio
                .FirstOrDefaultAsync(m => m.Id == id);
            if (domicilio == null)
            {
                return NotFound();
            }

            return View(domicilio);
        }

        // POST: Domicilios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var domicilio = await _context.Domicilio.FindAsync(id);
            if (domicilio != null)
            {
                _context.Domicilio.Remove(domicilio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DomicilioExists(int id)
        {
            return _context.Domicilio.Any(e => e.Id == id);
        }
    }
}
