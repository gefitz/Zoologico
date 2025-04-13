using AutoMapper;
using Zoologico.API.Models;

namespace Zoologico.API.DTOs.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<AnimalDTO, AnimalModel>().ReverseMap();
            CreateMap<CuidadoDTO, CuidadoModel>().ReverseMap();
        }
    }
}
