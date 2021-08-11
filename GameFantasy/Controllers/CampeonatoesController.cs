using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameFantasyAPI.Data;
using GameFantasyAPI.Model;
using System.Text.Json;
using GameFantasyAPI.View;

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
        public async Task<ActionResult<IEnumerable<ViewModel>>> GetCampeonato( )
        {
            
            // algoritimo de placar aleatorio
            int c = _context.Times.Count();

            for (int i = 1; i <= c; i++)
            {

                for (int j = 1; j <= c; j++)
                {
                    if (i != j)
                    {

                        Time time1 = _context.Times.Find(i);

                        Time time2 = _context.Times.Find(j);

                        string times = time1.Nome.ToString() + " X " + time2.Nome.ToString();
                        //distribuição dos pontos da partida
                        Random randNum = new Random();

                        int v1 = randNum.Next(4);
                        int v2 = randNum.Next(4);
                        if (v1 > v2)
                        {
                            int pt = time1.Pontos + 1;

                            time1.Pontos = pt;
                            _context.Entry(time1).State = EntityState.Modified;
                            await _context.SaveChangesAsync();
                        }
                        else
                        {
                            int pt = time2.Pontos + 1;
                            time1.Pontos = pt;
                            _context.Entry(time1).State = EntityState.Modified;
                            await _context.SaveChangesAsync();
                        }



                        //placar
                        string placar = v1.ToString() +" X "+ v2.ToString();
                        var p = new Campeonato { Times = times, Placar = placar };
                        await _context.Campeonatos.AddAsync(p);
                        
                        await _context.SaveChangesAsync();
                    }
                }

            }
            // gerar campeoes
            string nome1="";
            string nome2 = "";
            string nome3="";
            int contador = 0;
            var campQuery = 
                (from i in _context.Times
                 select i).OrderByDescending(x => x.Pontos).Take(3);
          
            foreach ( Time i in campQuery)
            {
                contador++;
                switch (contador)
                { 
                
                    case 1:
                        nome1 = i.Nome;
                        break;
                    case 2:
                        nome2 = i.Nome;
                        break;
                    case 3:
                        nome3 = i.Nome;
                        break;

                }
                
            }
            //persistir vencedores
            Vencedor n = new Vencedor { Campeao = nome1, Vice = nome2, Terceiro = nome3 };
            await _context.Vencedores.AddAsync(n);
            await _context.SaveChangesAsync();
            // persistir lista com vencedores e as partidas
            var a = _context.Campeonatos.ToList();
            var b = _context.Vencedores.ToList();
            ViewModel model = new ViewModel { Campeonato = a, Vencedores = b };
            await _context.ViewModels.AddAsync(model);
            await _context.SaveChangesAsync();

           
           return _context.ViewModels.ToList(); 
        
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
