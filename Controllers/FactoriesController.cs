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
using ProjectMediiMaster_BogdanIstrate.Models.LibraryViewModels;

namespace ProjectMediiMaster_BogdanIstrate.Controllers
{
    
    public class FactoriesController : Controller
    {
        private readonly LibraryContext _context;

        public FactoriesController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Factories
        public async Task<IActionResult> Index(int? id, int? guitarID)
        {
            var viewModel = new FactoryIndexData();
            viewModel.Factories = await _context.Factories
            .Include(i => i.ReleasedGuitars)
            .ThenInclude(i => i.Guitar)
            .ThenInclude(i => i.GuitarOrders)
            .ThenInclude(i => i.AppCustomer)
            .AsNoTracking()
            .OrderBy(i => i.FactoryName)
            .ToListAsync();
            if (id != null)
            {
                ViewData["FactoryID"] = id.Value;
                Factory factory = viewModel.Factories.Where(
                i => i.ID == id.Value).Single();
                viewModel.Guitars = factory.ReleasedGuitars.Select(s => s.Guitar);
            }
            if (guitarID != null)
            {
                ViewData["GuitarID"] = guitarID.Value;
                viewModel.GuitarOrders = viewModel.Guitars.Where(
                x => x.Id == guitarID).Single().GuitarOrders;
            }
            return View(viewModel);
        }

        // GET: Factories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factory = await _context.Factories
                .FirstOrDefaultAsync(m => m.ID == id);
            if (factory == null)
            {
                return NotFound();
            }

            return View(factory);
        }

        // GET: Factories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Factories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FactoryName,Adress")] Factory factory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(factory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(factory);
        }

        // GET: Factories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factory = await _context.Factories
            .Include(i => i.ReleasedGuitars).ThenInclude(i => i.Guitar)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.ID == id);
            if (factory == null)
            {
                return NotFound();
            }
            PopulateReleasedGuitarData(factory);
            return View(factory);
            }
            private void PopulateReleasedGuitarData(Factory factory)
            {
                var allGuitars = _context.Guitars;
                var factoryGuitars = new HashSet<int>(factory.ReleasedGuitars.Select(c => c.GuitarID));
                var viewModel = new List<ReleasedGuitarData>();
                foreach (var guitar in allGuitars)
                {
                    viewModel.Add(new ReleasedGuitarData
                    {
                        GuitarID = guitar.Id,
                        Title = guitar.Name,
                        IsReleased = factoryGuitars.Contains(guitar.Id)
                    });
                }
                ViewData["Guitars"] = viewModel;
            }
        

        // POST: Factories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, string[] selectedGuitars)
        {
            if (id == null)
            {
                return NotFound();
            }
            var factoryToUpdate = await _context.Factories
            .Include(i => i.ReleasedGuitars)
            .ThenInclude(i => i.Guitar)
            .FirstOrDefaultAsync(m => m.ID == id);
            if (await TryUpdateModelAsync<Factory>(
            factoryToUpdate,
            "",
            i => i.FactoryName, i => i.Adress))
            {
                UpdateReleasedGuitars(selectedGuitars, factoryToUpdate);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException /* ex */)
                {

                    ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists, ");
                }
                return RedirectToAction(nameof(Index));
            }
            UpdateReleasedGuitars(selectedGuitars, factoryToUpdate);
            PopulateReleasedGuitarData(factoryToUpdate);
            return View(factoryToUpdate);
        }
        private void UpdateReleasedGuitars(string[] selectedGuitars, Factory factoryToUpdate)
        {
            if (selectedGuitars == null)
            {
                factoryToUpdate.ReleasedGuitars = new List<ReleasedGuitar>();
                return;
            }
            var selectedGuitarsHS = new HashSet<string>(selectedGuitars);
            var releasedGuitars = new HashSet<int>
            (factoryToUpdate.ReleasedGuitars.Select(c => c.Guitar.Id));
            foreach (var guitar in _context.Guitars)
            {
                if (selectedGuitarsHS.Contains(guitar.Id.ToString()))
                {
                    if (!releasedGuitars.Contains(guitar.Id))
                    {
                        factoryToUpdate.ReleasedGuitars.Add(new ReleasedGuitar
                        {
                            FactoryID =
                       factoryToUpdate.ID,
                            GuitarID = guitar.Id
                        });
                    }
                }
                else
                {
                    if (releasedGuitars.Contains(guitar.Id))
                    {
                        ReleasedGuitar guitarToRemove = factoryToUpdate.ReleasedGuitars.FirstOrDefault(i
                       => i.GuitarID == guitar.Id);
                        _context.Remove(guitarToRemove);
                    }
                }
            }
        }

            // GET: Factories/Delete/5
            public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factory = await _context.Factories
                .FirstOrDefaultAsync(m => m.ID == id);
            if (factory == null)
            {
                return NotFound();
            }

            return View(factory);
        }

        // POST: Factories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var factory = await _context.Factories.FindAsync(id);
            _context.Factories.Remove(factory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FactoryExists(int id)
        {
            return _context.Factories.Any(e => e.ID == id);
        }
    }
}
