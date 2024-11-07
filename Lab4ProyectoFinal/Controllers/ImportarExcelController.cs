using Microsoft.AspNetCore.Mvc;
using ClosedXML.Excel;
using Lab4ProyectoFinal.Models;
using Lab4ProyectoFinal.Data;
using Microsoft.AspNetCore.Authorization;

namespace Lab4ProyectoFinal.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ImportarExcelController : Controller
    {
        private readonly AppDbContext _context;
        public ImportarExcelController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SubirExcel(IFormFile excel)
        {
            try
            {
                var workbook = new XLWorkbook(excel.OpenReadStream());
                var hoja = workbook.Worksheet(1);
                var primeraFila = hoja.FirstRowUsed().RangeAddress.FirstAddress.RowNumber;
                var ultimaFila = hoja.LastRowUsed().RangeAddress.LastAddress.RowNumber;

                List<Producto> productos = new List<Producto>();
                for (int i = primeraFila + 1; i <= ultimaFila; i++)
                {
                    var fila = hoja.Row(i);
                    Producto producto = new Producto();
                    producto.Nombre = fila.Cell(1).GetString();
                    producto.Marca = fila.Cell(2).GetValue<string>();
                    producto.Precio = fila.Cell(3).GetValue<decimal>();
                    producto.Categoria = fila.Cell(4).GetValue<string>();
                    producto.Tamaño = fila.Cell(5).GetValue<string>();
                    producto.Descripcion = fila.Cell(6).GetValue<string>();
                    producto.ImagenCarpeta = fila.Cell(7).GetValue<string>();
                    productos.Add(producto);
                }
                _context.Productos.AddRange(productos);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return RedirectToAction("Index", "Productoes");
        }
    }
}
