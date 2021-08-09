using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameFantasyAPI.Model
{
    public class Campeonato
    {
        public int Id { get; set; }
        public string Campeao { get; set; }
        public string Vice { get; set; }
        public string Terceiro { get; set; }
        public List<Partida> Partidas { get; set; }

    }
}
