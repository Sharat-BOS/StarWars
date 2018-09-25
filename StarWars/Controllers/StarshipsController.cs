﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StarWars.Models;

namespace StarWars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StarshipsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StarshipsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Starships
        [HttpGet]
        public IEnumerable<Starship> GetStarships()
        {
            return _context.Starships;
        }

        // GET: api/Starships/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStarship([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var starship = await _context.Starships.FindAsync(id);

            if (starship == null)
            {
                return NotFound();
            }

            return Ok(starship);
        }

        // PUT: api/Starships/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStarship([FromRoute] int id, [FromBody] Starship starship)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != starship.Id)
            {
                return BadRequest();
            }

            _context.Entry(starship).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StarshipExists(id))
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

        // POST: api/Starships
        [HttpPost]
        public async Task<IActionResult> PostStarship([FromBody] Starship starship)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Starships.Add(starship);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStarship", new { id = starship.Id }, starship);
        }

        // DELETE: api/Starships/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStarship([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var starship = await _context.Starships.FindAsync(id);
            if (starship == null)
            {
                return NotFound();
            }

            _context.Starships.Remove(starship);
            await _context.SaveChangesAsync();

            return Ok(starship);
        }

        private bool StarshipExists(int id)
        {
            return _context.Starships.Any(e => e.Id == id);
        }
    }
}