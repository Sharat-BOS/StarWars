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
    public class MVC_CharacterTypesController : Controller
    {
        private readonly AppDbContext _context;

        public MVC_CharacterTypesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: MVC_CharacterTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.CharacterTypes.ToListAsync());
        }

        // GET: MVC_CharacterTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var characterType = await _context.CharacterTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (characterType == null)
            {
                return NotFound();
            }

            return View(characterType);
        }

        // GET: MVC_CharacterTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MVC_CharacterTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CharacterTypeName")] CharacterType characterType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(characterType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(characterType);
        }

        // GET: MVC_CharacterTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var characterType = await _context.CharacterTypes.FindAsync(id);
            if (characterType == null)
            {
                return NotFound();
            }
            return View(characterType);
        }

        // POST: MVC_CharacterTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CharacterTypeName")] CharacterType characterType)
        {
            if (id != characterType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(characterType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CharacterTypeExists(characterType.Id))
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
            return View(characterType);
        }

        // GET: MVC_CharacterTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var characterType = await _context.CharacterTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (characterType == null)
            {
                return NotFound();
            }

            return View(characterType);
        }

        // POST: MVC_CharacterTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var characterType = await _context.CharacterTypes.FindAsync(id);
            _context.CharacterTypes.Remove(characterType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CharacterTypeExists(int id)
        {
            return _context.CharacterTypes.Any(e => e.Id == id);
        }
    }
}
