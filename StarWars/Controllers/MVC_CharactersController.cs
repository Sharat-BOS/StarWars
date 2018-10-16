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
    public class MVC_CharactersController : Controller
    {
        private readonly AppDbContext _context;

        public MVC_CharactersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: MVC_Characters
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Characters.Include(c => c.CharacterGroup).Include(c => c.CharacterType).Include(c => c.Faction);
            return View(await appDbContext.ToListAsync());
        }

        // GET: MVC_Characters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var character = await _context.Characters
                .Include(c => c.CharacterGroup)
                .Include(c => c.CharacterType)
                .Include(c => c.Faction)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (character == null)
            {
                return NotFound();
            }

            return View(character);
        }

        // GET: MVC_Characters/Create
        public IActionResult Create()
        {
            ViewData["CharacterGroupID"] = new SelectList(_context.CharacterGroups, "Id", "Id");
            ViewData["CharacterTypeID"] = new SelectList(_context.CharacterTypes, "Id", "Id");
            ViewData["FactionID"] = new SelectList(_context.Factions, "Id", "Id");
            return View();
        }

        // POST: MVC_Characters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CharacterName,CharacterTypeID,CharacterGroupID,HomePlanet,Purpose,FactionID,ImageUrl")] Character character)
        {
            if (ModelState.IsValid)
            {
                _context.Add(character);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CharacterGroupID"] = new SelectList(_context.CharacterGroups, "Id", "Id", character.CharacterGroupID);
            ViewData["CharacterTypeID"] = new SelectList(_context.CharacterTypes, "Id", "Id", character.CharacterTypeID);
            ViewData["FactionID"] = new SelectList(_context.Factions, "Id", "Id", character.FactionID);
            return View(character);
        }

        // GET: MVC_Characters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var character = await _context.Characters.FindAsync(id);
            if (character == null)
            {
                return NotFound();
            }
            ViewData["CharacterGroupID"] = new SelectList(_context.CharacterGroups, "Id", "Id", character.CharacterGroupID);
            ViewData["CharacterTypeID"] = new SelectList(_context.CharacterTypes, "Id", "Id", character.CharacterTypeID);
            ViewData["FactionID"] = new SelectList(_context.Factions, "Id", "Id", character.FactionID);
            return View(character);
        }

        // POST: MVC_Characters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CharacterName,CharacterTypeID,CharacterGroupID,HomePlanet,Purpose,FactionID,ImageUrl")] Character character)
        {
            if (id != character.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(character);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CharacterExists(character.Id))
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
            ViewData["CharacterGroupID"] = new SelectList(_context.CharacterGroups, "Id", "Id", character.CharacterGroupID);
            ViewData["CharacterTypeID"] = new SelectList(_context.CharacterTypes, "Id", "Id", character.CharacterTypeID);
            ViewData["FactionID"] = new SelectList(_context.Factions, "Id", "Id", character.FactionID);
            return View(character);
        }

        // GET: MVC_Characters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var character = await _context.Characters
                .Include(c => c.CharacterGroup)
                .Include(c => c.CharacterType)
                .Include(c => c.Faction)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (character == null)
            {
                return NotFound();
            }

            return View(character);
        }

        // POST: MVC_Characters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var character = await _context.Characters.FindAsync(id);
            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CharacterExists(int id)
        {
            return _context.Characters.Any(e => e.Id == id);
        }
    }
}
