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
    public class StarshipCharactersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StarshipCharactersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/StarshipCharacters
        [HttpGet]
        public IEnumerable<StarshipCharacter> GetStarshipCharacter()
        {
            return _context.StarshipCharacter;
        }

        // GET: api/StarshipCharacters/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStarshipCharacter([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var starshipCharacter = await _context.StarshipCharacter.FindAsync(id);

            if (starshipCharacter == null)
            {
                return NotFound();
            }

            return Ok(starshipCharacter);
        }

        // PUT: api/StarshipCharacters/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStarshipCharacter([FromRoute] int id, [FromBody] StarshipCharacter starshipCharacter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != starshipCharacter.StarshipId)
            {
                return BadRequest();
            }

            _context.Entry(starshipCharacter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StarshipCharacterExists(id))
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

        // POST: api/StarshipCharacters
        [HttpPost]
        public async Task<IActionResult> PostStarshipCharacter([FromBody] StarshipCharacter starshipCharacter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.StarshipCharacter.Add(starshipCharacter);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StarshipCharacterExists(starshipCharacter.StarshipId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStarshipCharacter", new { id = starshipCharacter.StarshipId }, starshipCharacter);
        }

        // DELETE: api/StarshipCharacters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStarshipCharacter([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var starshipCharacter = await _context.StarshipCharacter.FindAsync(id);
            if (starshipCharacter == null)
            {
                return NotFound();
            }

            _context.StarshipCharacter.Remove(starshipCharacter);
            await _context.SaveChangesAsync();

            return Ok(starshipCharacter);
        }

        private bool StarshipCharacterExists(int id)
        {
            return _context.StarshipCharacter.Any(e => e.StarshipId == id);
        }
    }
}