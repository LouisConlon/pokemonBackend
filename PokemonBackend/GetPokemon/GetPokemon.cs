using PokemonBackend.Model;

namespace PokemonBackend.Api
{
    public class GetPokemon : IGetPokemon
    {
        private readonly HttpClient _httpClient;
        private readonly Random random = new Random();
        private readonly string uri = "https://pokeapi.co/api/v2/pokemon/";

        public GetPokemon(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResponsePokemon>> GetPokemons()
        {
            var indexies = GetRandomIndexies();
            var requests = indexies.Select(i => _httpClient.GetFromJsonAsync<PokemonDTO>(uri + i));
            var response = await Task.WhenAll(requests);
            return response.Select(x => x.ToDomain()).ToList();
        }

        private List<int> GetRandomIndexies()
        {
            var list = new List<int>();
            while (list.Count < 4)
            {
                var number = random.Next(1, 152);
                if (!list.Contains(number))
                    list.Add(number);
            }
            return list;
        }
    }

    public interface IGetPokemon
    {
        Task<List<ResponsePokemon?>> GetPokemons();
    }
}