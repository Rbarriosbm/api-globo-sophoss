using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_globo_sophos.DBContext;
using api_globo_sophos.Models;

namespace api_globo_sophos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HeroController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Hero
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hero>>> GetHeroes()
        {
            return await _context.Heroes.ToListAsync();
        }

        // GET: api/Hero/name
        //[HttpGet("{Name]")]
        //public async Task<ActionResult<IEnumerable<Hero>>> GetHero(string name)
        //{
        //    var heroByName = await _context.Heroes.Where(x => x.Name == name).ToListAsync();

        //    if (heroByName == null)
        //    {
        //        return NotFound();
        //    };

        //    return heroByName;
        //}

        //// GET: api/Hero/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Hero>> GetHero(int id)
        //{
        //    var hero = await _context.Heroes.FindAsync(id);

        //    if (hero == null)
        //    {
        //        return NotFound();
        //    }

        //    return hero;
        //}

        // PUT: api/Hero/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754


        [HttpPut("{id}")]
        public async Task<IActionResult> PutHero(int id, Hero hero)
        {
            if (id != hero.HeroId)
            {
                return BadRequest();
            }

            _context.Entry(hero).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HeroExists(id))
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

        // POST: api/Hero
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Hero>> PostHero(Hero hero)
        //{
        //    _context.Heroes.Add(hero);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetHero", new { id = hero.HeroId }, hero);
        //}

        // DELETE: api/Hero/5


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHero(int id)
        {
            var hero = await _context.Heroes.FindAsync(id);
            if (hero == null)
            {
                return NotFound();
            }

            _context.Heroes.Remove(hero);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HeroExists(int id)
        {
            return _context.Heroes.Any(e => e.HeroId == id);
        }
    }
}
