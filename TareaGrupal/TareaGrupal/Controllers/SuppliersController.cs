using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TareaGrupal.Data;
using TareaGrupal.Models;


namespace TareaGrupal.Controllers
{
    public class SupplierController : Controller
    {
        private readonly AppDbContext _context;

        public SupplierController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Principal()
        {
            return View();
        }

        public async Task<IActionResult> Index()
        {
            var Supplier = await _context.suppliers.ToListAsync();
            return View(Supplier);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, name, description, price, supplier_id")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                _context.Add(supplier);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(supplier);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var supplier = await _context.suppliers.FindAsync(id);
            if (supplier == null)
            {
                return NotFound();
            }
            return View(supplier);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Supplier supplier)
        {
            if (id != supplier.id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(supplier);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (SupplierExists(supplier.id))
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
            return View(supplier);
        }
        private bool SupplierExists(int id)
        {
            return _context.suppliers.Any(e => e.id == id);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var supplier = await _context.suppliers.FindAsync(id);
            if (supplier == null)
            {
                return NotFound();
            }
            return View(supplier);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id, Supplier supplier)
        {
            if (id != supplier.id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Remove(supplier);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupplierExists(supplier.id))
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
            return View(supplier);
        }
    }
}