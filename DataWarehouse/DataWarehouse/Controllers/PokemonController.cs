using DataWarehouse.Library.Classes.Pokemon;
using DataWarehouse.Library.Managers;
using Microsoft.AspNetCore.Mvc;

namespace DataWarehouse.Controllers
{
    [ApiController]
    [Route("Pokemon")]
    public class PokemonController : ControllerBase
    {
        private readonly ILogger<PokemonController> _logger;
        private PokemonManager _pokemonManager = new PokemonManager();

        public PokemonController(ILogger<PokemonController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetPokemonEvents")]
        public IActionResult GetPokemonEvents()
        {
            List<PokemonEvent> result = _pokemonManager.GetPokemonEvents();

            return Ok(result);
        }
    }
}