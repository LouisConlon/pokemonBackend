using System.Runtime.CompilerServices;

namespace PokemonBackend.Model
{
    public class PokemonDTO
    {
        public string name { get; set; }

        public Sprites sprites { get; set; }

        public ResponsePokemon ToDomain()
        {
            return new ResponsePokemon()
            {
                Name = name,
                ImageUrl = sprites.front_default
            };
        }
    }

    public class Sprites
    {
        public string front_default { get; set; }
    }
}