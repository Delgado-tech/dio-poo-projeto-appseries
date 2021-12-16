using AppSeries;
using AppSeries.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DioSeries.Web.Controllers
{
    [Route("[controller]")]
    public class SerieController : Controller
    {
        /*
         * GET      - Retornar Algo
         * POST     - Inserir algo
         * PUT      - Alterar algo
         * DELETE   - Excluir algo
         */

        private readonly IRepositorio<Serie> _repositorioSerie;

        public SerieController(IRepositorio<Serie> repositorioSerie) {
            _repositorioSerie = repositorioSerie;
        }

        [HttpGet("")]
        public IActionResult Lista()
        {
            return Ok(_repositorioSerie.Lista().Select(s => new SerieModel(s)));
        }

        [HttpPut("{id}")]
        public IActionResult Atualiza(int id, [FromBody] SerieModel model) {
            model.Id = id;
            _repositorioSerie.Atualiza(id, model.ToSerie()); //AutoMapper
            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult Exclui(int id) {
            _repositorioSerie.Exclui(id);
            return NoContent();
        }

        [HttpPost("")]
        public IActionResult Insere([FromBody] SerieModel model) {
            model.Id = _repositorioSerie.ProximoId();
            Serie serie = model.ToSerie();

            _repositorioSerie.Insere(serie);
            return Created("", serie);
        }

        [HttpGet("{id}")]
        public IActionResult Consulta(int id) {
            return Ok(new SerieModel(_repositorioSerie.Lista().FirstOrDefault(s => s.Id == id)));
        }

    }
}
