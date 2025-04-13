using AutoMapper;
using Zoologico.API.DTOs;
using Zoologico.API.Models;
using Zoologico.API.Repository.Interfaces;

namespace Zoologico.API.Services
{
    public class CuidadoService
    {
        private readonly IRepository<CuidadoModel> _repository;
        private readonly IMapper _mapper;

        public CuidadoService(IRepository<CuidadoModel> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<bool> Create(CuidadoDTO cuidado)
        {
            return await _repository.Create(_mapper.Map<CuidadoModel>(cuidado));
        }
        public async Task<IEnumerable<CuidadoDTO>> Search(CuidadoDTO cuidado)
        {
            var listCuidado = await _repository.Search(_mapper.Map<CuidadoModel>(cuidado));
            if (listCuidado == null)
                return null;
            return _mapper.Map<IEnumerable<CuidadoDTO>>(listCuidado);

        }
        public async Task<bool> Update(CuidadoDTO cuidado)
        {
            return await _repository.Update(_mapper.Map<CuidadoModel>(cuidado));
        }
        public async Task<bool> Delete(int id)
        {
            CuidadoModel cuidado = await _repository.SearchId(id);
            if (cuidado == null)
                return false;
            return await _repository.Remove(_mapper.Map<CuidadoModel>(cuidado));
        }

    }
}
