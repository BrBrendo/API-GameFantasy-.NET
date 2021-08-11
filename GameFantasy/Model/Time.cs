using System.ComponentModel.DataAnnotations;

namespace GameFantasyAPI.Model
{
    public class Time
    {

        public int Id { get; set; }
        [MinLength(3, ErrorMessage = "O nome precisa ter no mínimo 3 caracteres ou mais.")]
        public string Nome { get; set; }
        public int Pontos { get; set; }

        
    }
}

  


