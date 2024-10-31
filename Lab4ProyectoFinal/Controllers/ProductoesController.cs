using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab4ProyectoFinal.Models;
using Lab4ProyectoFinal.Services;
using DocumentFormat.OpenXml.InkML;
using X.PagedList.Extensions;


namespace Lab4ProyectoFinal.Controllers
{
    public class ProductoesController : Controller
    {
        private readonly AppDbContext _context;

        public ProductoesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Productoes

        public IActionResult Index(string buscarProducto, int? page)
        {
            int pageSize = 3; 
            int pageNumber = page ?? 1; 

            var productos = from producto in _context.Productos select producto;

            // Filtrar los productos según el término de búsqueda
            if (!string.IsNullOrEmpty(buscarProducto))
            {
                productos = productos.Where(s => s.Nombre!.Contains(buscarProducto));
            }
            //Mas nuevo se ve primero
            var productosPaginados = productos.OrderByDescending(p => p.Id).ToPagedList(pageNumber, pageSize);


            return View(productosPaginados);
        }




        /* public async Task<IActionResult> Index(string buscarProducto)
         {
             var productos = from producto in _context.Productos select producto;

             if (!String.IsNullOrEmpty(buscarProducto))
             {
                 productos=productos.Where(s=>s.Nombre!.Contains(buscarProducto));
             }
             return View(await productos.OrderByDescending(p => p.Id).ToListAsync());
             //return View(await _context.Productos.OrderByDescending(p=>p.Id).ToListAsync()); //Productos mas nuevo arriba de todo
         }*/


        // GET: Productoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // GET: Productoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Productoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Marca,Precio,Categoria,Tamaño,Descripcion,ImagenCarpeta")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(producto);
        }

        // GET: Productoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        // POST: Productoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Marca,Precio,Categoria,Tamaño,Descripcion,ImagenCarpeta")] Producto producto)
        {
            if (id != producto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoExists(producto.Id))
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
            return View(producto);
        }

        // GET: Productoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // POST: Productoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoExists(int id)
        {
            return _context.Productos.Any(e => e.Id == id);
        }
    }
}
