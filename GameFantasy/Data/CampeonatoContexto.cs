using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameFantasyAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace GameFantasyAPI.Data
{
    public class CampeonatoContexto : DbContext
    {
        public DbSet<Time> Times { get; set; }
        public DbSet<Vencedor> Vencedores { get; set; }
        public DbSet<Campeonato> Campeonatos { get; set; }

        public DbSet<ViewModel> ViewModels { get; set; }
        public DbSet<PaginaTime> PaginaTimes { get; set; }

        public CampeonatoContexto(DbContextOptions<CampeonatoContexto>opcoes) : base (opcoes)
        {

        }

    



    }


}



