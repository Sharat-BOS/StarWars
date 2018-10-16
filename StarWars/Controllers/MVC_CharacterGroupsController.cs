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
    public class MVC_CharacterGroupsController : Controller
    {
        private readonly AppDbContext _context;

        public MVC_CharacterGroupsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: MVC_CharacterGroups
        public async Task<IActionResult> Index()
        {
            return View(await _context.CharacterGroups.ToListAsync());
        }

        // GET: MVC_CharacterGroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var characterGroup = await _context.CharacterGroups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (characterGroup == null)
            {
                return NotFound();
            }

            return View(characterGroup);
        }

        // GET: MVC_CharacterGroups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MVC_CharacterGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GroupName")] CharacterGroup characterGroup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(characterGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(characterGroup);
        }

        // GET: MVC_CharacterGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var characterGroup = await _context.CharacterGroups.FindAsync(id);
            if (characterGroup == null)
            {
                return NotFound();
            }
            return View(characterGroup);
        }

        // POST: MVC_CharacterGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GroupName")] CharacterGroup characterGroup)
        {
            if (id != characterGroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(characterGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CharacterGroupExists(characterGroup.Id))
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
            return View(characterGroup);
        }

        // GET: MVC_CharacterGroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var characterGroup = await _context.CharacterGroups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (characterGroup == null)
            {
                return NotFound();
            }

            return View(characterGroup);
        }

        // POST: MVC_CharacterGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var characterGroup = await _context.CharacterGroups.FindAsync(id);
            _context.CharacterGroups.Remove(characterGroup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CharacterGroupExists(int id)
        {
            return _context.CharacterGroups.Any(e => e.Id == id);
        }
    }
}
