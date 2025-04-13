using AutoMapper;
using Zoologico.API.DTOs;
using Zoologico.API.Models;
using Zoologico.API.Repository.Interfaces;

namespace Zoologico.API.Services
{
    public class AnimalService
    {
        private readonly IRepository<AnimalModel> _repository;
        private readonly IMapper _mapper;

        public AnimalService(IRepository<AnimalModel> repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Create (AnimalDTO animal)
        {
            return await _repository.Create(_mapper.Map<AnimalModel>(animal));
        }
        public async Task<IEnumerable<AnimalDTO>> Search(AnimalDTO animal)
        {
            var listAnimal = await _repository.Search(_mapper.Map<AnimalModel>(animal));
            if (listAnimal == null)
                return null;
            
            return _mapper.Map<IEnumerable<AnimalDTO>>(listAnimal);

        }
        public async Task<bool> Update (AnimalDTO animal)
        {
            return await _repository.Update(_mapper.Map<AnimalModel>(animal));
        }
        public async Task<bool> Delete (AnimalDTO animal)
        {
            return await _repository.Remove(_mapper.Map<AnimalModel>(animal));
        }
    }
}
