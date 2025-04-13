using Zoologico.API.Models;

namespace Zoologico.API.DTOs
{
    public class CuidadoDTO
    {
        public int id { get; set; }
        public string NomeCuidado { get; set; }
        public string Descricao { get; set; }
        public string Frequencia { get; set; }
    }
}
