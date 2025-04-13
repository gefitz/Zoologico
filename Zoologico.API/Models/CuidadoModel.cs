using Zoologico.API.DTOs;

namespace Zoologico.API.Models
{
    public class CuidadoModel
    {
        public int id { get; set; }
        public string NomeCuidado { get; set; }
        public string Descricao { get; set; }
        public string Frequencia { get; set; }
        public IEnumerable<AnimalModel> Animais { get; set; }
    }
}
