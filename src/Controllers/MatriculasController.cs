using Microsoft.AspNetCore.Mvc;
using educacional.Repository;
using educacional.Models;

namespace educacional.Controllers
{
    [ApiController]
    [Route("matriculas")]
    public class MatriculasController : Controller
    {
        private readonly MatriculaRepository _matriculaRepository;

        public MatriculasController(MatriculaRepository matriculaRepository)
        {
            _matriculaRepository = matriculaRepository;
        }

        [HttpPost]
        public IActionResult CriarMatricula([FromBody] MatriculaDTO matricula)
        {
            return Created("", _matriculaRepository.criarMatricula(matricula));
        }

        [HttpGet]
        public IActionResult MatriculasView()
        {
            var matriculas = _matriculaRepository.pegarMatriculas();
            return Ok(matriculas);
        }
    }
}