using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameFantasyAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameFantasyAPI.Data;


namespace GameFantasyAPI.Model
{
 
    public class ViewModel
    {
      
          public int Id { get; set; }
          public List<Campeonato> Campeonato { get; set; }
          public List<Vencedor> Vencedores { get; set; }
        
    }
}
