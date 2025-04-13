using Zoologico.API.DTOs;

namespace Zoologico.API.Models
{
    public class AnimalModel
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime dthNascimento { get; set; }
        public string Especie { get; set; }
        public string Habitat { get; set; }
        public string PaisOrigem { get; set; }
        public IEnumerable<CuidadoModel> Cuidados { get; set; }
    }
}
