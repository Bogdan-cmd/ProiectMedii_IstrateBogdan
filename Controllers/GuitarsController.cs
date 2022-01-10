using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectMediiMaster_BogdanIstrate.Data;
using ProjectMediiMaster_BogdanIstrate.Models;

namespace ProjectMediiMaster_BogdanIstrate.Controllers
{
    [Authorize(Roles = "Employee")]
    public class GuitarsController : Controller
    {
        private readonly LibraryContext _context;

        public GuitarsController(LibraryContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        // GET: Guitars
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["CategorySortParm"] = String.IsNullOrEmpty(sortOrder) ? "category_desc" : "";
            ViewData["PriceSortParm"] = sortOrder == "Price" ? "price_desc" : "Price";
            ViewData["CurrentSort"] = sortOrder;
            ViewData["CurrentFilter"] = searchString;

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            var guitars = from b in _context.Guitars
                          select b;

            if (!String.IsNullOrEmpty(searchString))
            {
                guitars = guitars.Where(s => s.Name.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    guitars = guitars.OrderByDescending(b => b.Name);
                    break;
                case "category_desc":
                    guitars = guitars.OrderByDescending(b => b.Name);
                    break;
                case "Price":
                    guitars = guitars.OrderBy(b => b.Price);
                    break;
                case "price_desc":
                    guitars = guitars.OrderByDescending(b => b.Price);
                    break;
                default:
                    guitars = guitars.OrderBy(b => b.Name);
                    break;
            }
            int pageSize = 2;
            return View(await PaginatedList<Guitar>.CreateAsync(guitars.AsNoTracking(), pageNumber ??
           1, pageSize));
        }

        [AllowAnonymous]
        // GET: Guitars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guitar = await _context.Guitars
                .Include(s => s.GuitarOrders)
                .ThenInclude(e => e.AppCustomer)
                .ThenInclude(r => r.Reviews)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (guitar == null)
            {
                return NotFound();
            }

            return View(guitar);
        }

        // GET: Guitars/Create
        public IActionResult Create()
        {
            return View();
        }

        [AllowAnonymous]
        // POST: Guitars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Price,Category")] Guitar guitar)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(guitar);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException /* ex*/)
            {

                ModelState.AddModelError("", "Unable to save changes. " +
                "Try again, and if the problem persists ");
            }
            return View(guitar);
        }

        [AllowAnonymous]
        // GET: Guitars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guitar = await _context.Guitars.FindAsync(id);
            if (guitar == null)
            {
                return NotFound();
            }
            return View(guitar);
        }

        [AllowAnonymous]

        // POST: Guitars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var studentToUpdate = await _context.Guitars.FirstOrDefaultAsync(s => s.Id == id);
            if (await TryUpdateModelAsync<Guitar>(
                studentToUpdate,
                "",
                s => s.Name, s => s.Description, s => s.Price, s => s.Category))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException /* ex */)
                {
                    ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists");
                }
            }
            return View(studentToUpdate);
        }

        [AllowAnonymous]

        // GET: Guitars/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guitar = await _context.Guitars
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (guitar == null)
            {
                return NotFound();
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                "Delete failed. Try again";
            }

            return View(guitar);
        }

        [AllowAnonymous]

        // POST: Guitars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var guitar = await _context.Guitars.FindAsync(id);
            if (guitar == null)
            {
                return RedirectToAction(nameof(Index));
            }

            try
            {
                _context.Guitars.Remove(guitar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException /* ex */)
            {

                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
        }

        private bool GuitarExists(int id)
        {
            return _context.Guitars.Any(e => e.Id == id);
        }
    }
}
