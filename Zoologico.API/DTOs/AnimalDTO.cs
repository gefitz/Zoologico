using Zoologico.API.Models;

namespace Zoologico.API.DTOs
{
    public class AnimalDTO
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime dthNascimento { get; set; }
        public string Especie { get; set; }
        public string Habitat { get; set; }
        public string PaisOrigem { get; set; }
        public IEnumerable<CuidadoDTO>? Cuidados { get; set; }
        public static implicit operator AnimalDTO(AnimalModel model)
        {
            return new AnimalDTO
            {
                id = model.id,
                Nome = model.Nome,
                Descricao = model.Descricao,
                Cuidados = (IEnumerable<CuidadoDTO>)model.Cuidados,
                Especie = model.Especie,
                Habitat = model.Habitat,
                PaisOrigem = model.PaisOrigem,
                dthNascimento = model.dthNascimento,
            };
        }
    }
}
