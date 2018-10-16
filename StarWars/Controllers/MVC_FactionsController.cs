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
    public class MVC_FactionsController : Controller
    {
        private readonly AppDbContext _context;

        public MVC_FactionsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: MVC_Factions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Factions.ToListAsync());
        }

        // GET: MVC_Factions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faction = await _context.Factions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (faction == null)
            {
                return NotFound();
            }

            return View(faction);
        }

        // GET: MVC_Factions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MVC_Factions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FactionName,ImageUrl")] Faction faction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(faction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(faction);
        }

        // GET: MVC_Factions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faction = await _context.Factions.FindAsync(id);
            if (faction == null)
            {
                return NotFound();
            }
            return View(faction);
        }

        // POST: MVC_Factions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FactionName,ImageUrl")] Faction faction)
        {
            if (id != faction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(faction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FactionExists(faction.Id))
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
            return View(faction);
        }

        // GET: MVC_Factions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faction = await _context.Factions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (faction == null)
            {
                return NotFound();
            }

            return View(faction);
        }

        // POST: MVC_Factions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var faction = await _context.Factions.FindAsync(id);
            _context.Factions.Remove(faction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FactionExists(int id)
        {
            return _context.Factions.Any(e => e.Id == id);
        }
    }
}
