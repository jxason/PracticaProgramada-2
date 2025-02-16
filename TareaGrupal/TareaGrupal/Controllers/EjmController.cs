using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TareaGrupal.Data;
using TareaGrupal.Models;   

namespace WebApplication2.Controllers
{
    public class EjmController : Controller
    {
        private readonly AppDbContext _context;

        public EjmController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Prueba()
        {
            return View();
        }
        public async Task<IActionResult> Index()
        {
            //var Prueba = await _context.Prueba.ToListAsync();
            return View(Prueba);
        }

        // Método para crear un producto
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,first_name")] Ejm prueba)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prueba);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(prueba);
        }
        public async Task<IActionResult> Edit(int id)
        {
            //var producto = await _context.Prueba.FindAsync(id);
           // if (producto == null)
            {
                return NotFound();
            }
            return View();
        }

        // Actualizar un producto
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Ejm prueba)
        {
            if (id != prueba.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prueba);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    /*if (!PruebaExists(prueba.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }*/
                }
                return RedirectToAction(nameof(Index));
            }
            return View(Prueba);
        }

        /*public async Task<IActionResult> Delete(int id)
        {
            //var prueba = await _context.Prueba.FindAsync(id);
            if (prueba == null)
            {
                return NotFound();
            }
            return View(prueba);
        }*/

        [HttpPost]
        public async Task<IActionResult> Delete(int id, Ejm prueba)
        {
            if (id != prueba.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Remove(prueba);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    /*if (!PruebaExists(prueba.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }*/
                }
                return RedirectToAction(nameof(Index));
            }
            return View(Prueba);
        }

        // Verificar si el producto existe
        /*private bool PruebaExists(int id)
        {
           return _context.Prueba.Any(e => e.id == id);
        }*/


    }
}
