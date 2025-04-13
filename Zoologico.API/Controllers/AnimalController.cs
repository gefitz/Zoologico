using Microsoft.AspNetCore.Mvc;
using Zoologico.API.DTOs;
using Zoologico.API.Models;
using Zoologico.API.Services;

namespace Zoologico.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class AnimalController : Controller
    {
        private readonly AnimalService _service;
        private readonly LogModel _log;

        public AnimalController(AnimalService service, LogModel log)
        {
            _service = service;
            _log = log;
        }

        [HttpPost("BuscarAnimal")]
        public async Task<ActionResult<IEnumerable<AnimalDTO>>> BuscarAnimal(AnimalDTO animal)
        {
            var ret = await _service.Search(animal);
            if (ret == null)
            {
                return BadRequest(_log);
            }
            return Ok(ret);
        }
        [HttpPost("CadastrarAnimal")]
        public async Task<ActionResult<IEnumerable<AnimalDTO>>> CadastrarAnimal(AnimalDTO animal)
        {
            if (!ModelState.IsValid)
            {
                var listMenssagemErro = ModelState.Where(errors => errors.Value.Errors.Any())
                    .SelectMany(erro => erro.Value.Errors)
                    .Select(e => e.ErrorMessage).ToList();
                _log.Mensagem = string.Join(", ", listMenssagemErro);
                _log.Classe = "Controller";
                _log.Metodo = "Cadastrar";
                return BadRequest(_log);
            }
            if (await _service.Create(animal))
            {
                return Ok();
            }
            return BadRequest(_log);
        }
        [HttpPut]
        public async Task<ActionResult<IEnumerable<AnimalDTO>>> UpdateAnimal(AnimalDTO animal)
        {
            if (ModelState.IsValid)
            {
                var listMenssagemErro = ModelState.Where(errors => errors.Value.Errors.Any())
                    .SelectMany(erro => erro.Value.Errors)
                    .Select(e => e.ErrorMessage).ToList();
                _log.Mensagem = string.Join(", ", listMenssagemErro);
            }
            if (await _service.Update(animal))
            {
                return Ok();
            }
            return BadRequest(_log);
        }
        [HttpDelete]
        public async Task<ActionResult<IEnumerable<AnimalDTO>>> RemoverAnimal(AnimalDTO animal)
        {
            if (await _service.Delete(animal))
            {
                return Ok();
            }
            return BadRequest(_log);
        }
    }
}
