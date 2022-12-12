using educacional.Models;
using educacional.Repository;
using Microsoft.AspNetCore.Mvc;

namespace educacional.Controllers
{
    [ApiController]
    [Route("cursos")]

    public class CursosController : Controller
    {
        private readonly CursoRepository _cursoRepository;

        public CursosController(CursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        [HttpPost]
        public IActionResult CriarCurso([FromBody] Curso curso)
        {
            return Created("", _cursoRepository.criarCurso(curso));
        }
        [HttpGet]
        public IActionResult CursosView()
        {
            var cursos = _cursoRepository.pegarCursos();
            return Ok(cursos);
        }
    }
    
}