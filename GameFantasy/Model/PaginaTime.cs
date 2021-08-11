using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameFantasyAPI.Model
{
    public class PaginaTime
    {
        public int Id { get; set; }
        public int Pagina { get; set; }
        public int TamanhoPagina { get; set; }
        public int QtdPagina { get; set; }
        public List<Time> Itens { get; set; }
    }
}
