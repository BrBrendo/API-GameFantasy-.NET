﻿using System;
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
    public class TimeController : ControllerBase
    {
        private readonly CampeonatoContexto _context;

        public TimeController(CampeonatoContexto context)
        {
            _context = context;
        }

        // GET: api/Time
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Time>>> GetTimes()
        {
            return await _context.Times.ToListAsync();
        }

        // GET: api/Time/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Time>> GetTime(int id)
        {
            var time = await _context.Times.FindAsync(id);

            if (time == null)
            {
                return NotFound();
            }

            return time;
        }

        // PUT: api/Time/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTime(int id, Time time)
        {


            if (!TimeExists(id))
            {
                return BadRequest();
            }
            
      

            try
            {
                time.Id = id;
                _context.Entry(time).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TimeExists(id))
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

        // POST: api/Time
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Time>> PostTime(Time time)
        {
            
            _context.Times.Add(time);
            await _context.SaveChangesAsync();
             
            return CreatedAtAction("GetTime", new { id = time.Id }, time);

        }

        // DELETE: api/Time/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Time>> DeleteTime(int id)
        {
            var time = await _context.Times.FindAsync(id);
            if (time == null)
            {
                return NotFound();
            }

            _context.Times.Remove(time);
            await _context.SaveChangesAsync();

            return time;
        }

        private bool TimeExists(int id)
        {
            return _context.Times.Any(e => e.Id == id);
        }
    }
}