using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameFantasyAPI.Data;
using GameFantasyAPI.Model;

namespace GameFantasy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampeonatoesController : ControllerBase
    {
        private readonly CampeonatoContexto _context;

        public CampeonatoesController(CampeonatoContexto context)
        {
            _context = context;
        }

        // GET: api/Campeonatoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Campeonato>>> GetCampeonatos()
        {
            return await _context.Campeonatos.ToListAsync();
        }

        // GET: api/Campeonatoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Campeonato>> GetCampeonato(int id)
        {
            var campeonato = await _context.Campeonatos.FindAsync(id);

            if (campeonato == null)
            {
                return NotFound();
            }

            return campeonato;
        }

        // PUT: api/Campeonatoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCampeonato(int id, Campeonato campeonato)
        {
            if (id != campeonato.Id)
            {
                return BadRequest();
            }

            _context.Entry(campeonato).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CampeonatoExists(id))
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

        // POST: api/Campeonatoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Campeonato>> PostCampeonato(Campeonato campeonato)
        {
            _context.Campeonatos.Add(campeonato);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCampeonato", new { id = campeonato.Id }, campeonato);
        }

        // DELETE: api/Campeonatoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Campeonato>> DeleteCampeonato(int id)
        {
            var campeonato = await _context.Campeonatos.FindAsync(id);
            if (campeonato == null)
            {
                return NotFound();
            }

            _context.Campeonatos.Remove(campeonato);
            await _context.SaveChangesAsync();

            return campeonato;
        }

        private bool CampeonatoExists(int id)
        {
            return _context.Campeonatos.Any(e => e.Id == id);
        }
    }
}
