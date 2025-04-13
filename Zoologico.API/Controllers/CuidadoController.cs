using Microsoft.AspNetCore.Mvc;
using Zoologico.API.DTOs;
using Zoologico.API.Models;
using Zoologico.API.Services;

namespace Zoologico.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CuidadoController : Controller
    {
        private readonly CuidadoService _service;
        private readonly LogModel _log;

        public CuidadoController(CuidadoService service, LogModel log)
        {
            _service = service;
            _log = log;
        }
        [HttpGet("BuscarCuidado")]
        public async Task<ActionResult<IEnumerable<CuidadoDTO>>> BuscarCuidado()
        {

            var ret = await _service.Search(new CuidadoDTO());
            if (ret == null)
            {
                return BadRequest(_log);
            }
            return Ok(ret);
        }
        [HttpPost("CadastrarCuidado")]
        public async Task<IActionResult> CadastrarCuidado(CuidadoDTO cuidado)
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
            if (await _service.Create(cuidado))
            {
                return Ok();
            }
            return BadRequest(_log);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCuidado(CuidadoDTO cuidado)
        {
            if (!ModelState.IsValid)
            {
                var listMenssagemErro = ModelState.Where(errors => errors.Value.Errors.Any())
                    .SelectMany(erro => erro.Value.Errors)
                    .Select(e => e.ErrorMessage).ToList();
                _log.Mensagem = string.Join(", ", listMenssagemErro);
            }
            if (await _service.Update(cuidado))
            {
                return Ok();
            }
            return BadRequest(_log);
        }
        [HttpDelete]
        public async Task<IActionResult> RemoverCuidado(int id)
        {
            if (await _service.Delete(id))
            {
                return Ok();
            }
            return BadRequest(_log);
        }

    }
}
