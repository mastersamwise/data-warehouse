using DataWarehouse.Library.Classes.Pokemon;
using DataWarehouse.Library.Managers;
using DataWarehouse.Library.Classes;
using Microsoft.AspNetCore.Mvc;
using DataWarehouse.Library.Classes.Common;

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

        [HttpPost("UpdatePokemonEvent")]
        public IActionResult UpdatePokemonEvent(PokemonEvent pokemonEvent)
        {
            DatabaseResult result = _pokemonManager.UpdatePokemonEvent(pokemonEvent);

            return Ok(result);
        }


        [HttpPost("AddPokemonEvent")]
        public IActionResult AddPokemonEvent(PokemonEvent pokemonEvent)
        {
            DatabaseResult result = _pokemonManager.AddPokemonEvent(pokemonEvent);

            return Ok(result);
        }

        [HttpPost("DeletePokemonEvent")]
        public IActionResult DeletePokemonEvent(PokemonEvent pokemonEvent)
        {
            DatabaseResult result = _pokemonManager.DeletePokemonEvent(pokemonEvent);

            return Ok(result);
        }
    }
}