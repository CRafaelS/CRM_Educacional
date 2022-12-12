using Microsoft.AspNetCore.Mvc;
using educacional.Models;
using educacional.Repository;

namespace educacional.Controllers
{
    [ApiController]
    [Route("candidatos")]
    public class CandiatosController : Controller
    {
        private readonly CandidatoRepository _candidatoRepository;

        public CandiatosController(CandidatoRepository candidatoRepository)
        {
            _candidatoRepository = candidatoRepository;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CriarCandidato([Bind("Nome,Email,CPF")] Candidato candidato)
        {
            if (ModelState.IsValid)
            {
                _candidatoRepository.criarCandidato(candidato);
                return RedirectToAction("CandidatosView");
            }
            return View(candidato);
        }

        [HttpGet]
        public IActionResult CandidatosView()
        {
            // var candidatos = _candidatoRepository.pegarCandidatos();
            // return Ok(candidatos);

            IList<Candidato> candidatos = _candidatoRepository.pegarCandidatos().ToList();
            return View(candidatos);
        }
    }

}

