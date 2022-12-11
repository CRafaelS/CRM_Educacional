using Microsoft.AspNetCore.Mvc;
using educacional.Models;
using educacional.Repository;

namespace educacional.Controllers
{
    [ApiController]
    [Route("candidatos")]
    public class CandiatosController : Controller
    {
        private readonly CandidatoRepository _crmEducacionalRepository;

        public CandiatosController(CandidatoRepository crmEducacionalRepository)
        {
            _crmEducacionalRepository = crmEducacionalRepository;
        }

        [HttpPost]
        public IActionResult CriarCandidato([FromBody] Candidato candidato)
        {
            return Created("", _crmEducacionalRepository.criarCandidato(candidato));
        }

        [HttpGet]
        public IActionResult CandidatosView()
        {
            var candidatos = _crmEducacionalRepository.pegarCandidatos();
            // ViewData["Title"] = "Candidatos";
            // IList<Candidato> candidatoList = _crmEducacionalRepository.pegarCandidatos().ToList().AsNoTracking();
            // ViewBag.candidatos = candidatoList;
            return Ok(candidatos);
        }
    }

}

