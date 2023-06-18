using Microsoft.AspNetCore.Mvc;
using PokemonBackend.Api;
using PokemonBackend.Model;

namespace PokemonBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly IGetPokemon _getPokemon;
        private readonly ILogger<PokemonController> _logger;

        public PokemonController(ILogger<PokemonController> logger, IGetPokemon getPokemon)
        {
            _logger = logger;
            _getPokemon = getPokemon;
        }

        [HttpGet(Name = "GetPokemon")]
        public async Task<List<ResponsePokemon?>> Get()
        {
            return await _getPokemon.GetPokemons();
        }
    }
}