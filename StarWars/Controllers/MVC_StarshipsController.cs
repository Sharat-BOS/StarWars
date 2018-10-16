using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StarWars.Models;

namespace StarWars.Controllers
{
    public class MVC_StarshipsController : Controller
    {
        private readonly AppDbContext _context;

        public MVC_StarshipsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: MVC_Starships
        public async Task<IActionResult> Index()
        {
            return View(await _context.Starships.ToListAsync());
        }

        // GET: MVC_Starships/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var starship = await _context.Starships
                .FirstOrDefaultAsync(m => m.Id == id);
            if (starship == null)
            {
                return NotFound();
            }

            return View(starship);
        }

        // GET: MVC_Starships/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MVC_Starships/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StarshipName,ImageUrl")] Starship starship)
        {
            if (ModelState.IsValid)
            {
                _context.Add(starship);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(starship);
        }

        // GET: MVC_Starships/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var starship = await _context.Starships.FindAsync(id);
            if (starship == null)
            {
                return NotFound();
            }
            return View(starship);
        }

        // POST: MVC_Starships/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StarshipName,ImageUrl")] Starship starship)
        {
            if (id != starship.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(starship);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StarshipExists(starship.Id))
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
            return View(starship);
        }

        // GET: MVC_Starships/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var starship = await _context.Starships
                .FirstOrDefaultAsync(m => m.Id == id);
            if (starship == null)
            {
                return NotFound();
            }

            return View(starship);
        }

        // POST: MVC_Starships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var starship = await _context.Starships.FindAsync(id);
            _context.Starships.Remove(starship);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StarshipExists(int id)
        {
            return _context.Starships.Any(e => e.Id == id);
        }
    }
}
