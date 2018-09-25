using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StarWars.Models;

namespace StarWars.Controllers
{
    [Route("api/starwars/webapi/[controller]")]
    [ApiController]
    public class FactionsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FactionsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Factions
        [HttpGet]
        public IEnumerable<Faction> GetFactions()
        {
            return _context.Factions.Include(f=>f.Characters).ThenInclude(c=>c.CharacterType);
        }

        // GET: api/Factions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFaction([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var faction = await _context.Factions.FindAsync(id);

            if (faction == null)
            {
                return NotFound();
            }

            return Ok(faction);
        }

        // PUT: api/Factions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFaction([FromRoute] int id, [FromBody] Faction faction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != faction.Id)
            {
                return BadRequest();
            }

            _context.Entry(faction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FactionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Factions
        [HttpPost]
        public async Task<IActionResult> PostFaction([FromBody] Faction faction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Factions.Add(faction);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFaction", new { id = faction.Id }, faction);
        }

        // DELETE: api/Factions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFaction([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var faction = await _context.Factions.FindAsync(id);
            if (faction == null)
            {
                return NotFound();
            }

            _context.Factions.Remove(faction);
            await _context.SaveChangesAsync();

            return Ok(faction);
        }

        private bool FactionExists(int id)
        {
            return _context.Factions.Any(e => e.Id == id);
        }
    }
}