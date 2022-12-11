using Microsoft.AspNetCore.Mvc;
using educacional.Models;
using educacional.Repository;

namespace educacional.Controllers
{
    [ApiController]
    [Route("Candidatos")]
    public class CandiatosController : Controller
    {
        private readonly CandidatoRepository _crmEducacionalRepository;

        [HttpPost("Cadastro")]
        public IActionResult CriarCandidato(Candidato candidato)
        {
            var novoCandidato = _crmEducacionalRepository.addCandidato(candidato);
            return View(novoCandidato);
        }

        [HttpGet]
        public IActionResult CandidatosView()
        {
            ViewData["Title"] = "Candidatos";
            IList<Candidato> candidatoList = _crmEducacionalRepository.pegarCandidatos().ToList();
            ViewBag.candidato = candidatoList;
            return View();
        }
    }

}

