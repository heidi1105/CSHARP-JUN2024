using System.Net.Http.Headers;
using System.Text.Json;
using PokemonDemo.Models;

namespace PokemonDemo.Services;

public class PokemonApiService
{
    private static readonly HttpClient _client;

    static PokemonApiService()
    {
        _client = new HttpClient();
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public static async Task<Pokemon> ProcessPokemonAsync(string url)
    {
        await using Stream stream =
        await _client.GetStreamAsync(url);
        Pokemon? Result =
            await JsonSerializer.DeserializeAsync<Pokemon>(stream);
        return Result;
    }

    public static async Task<PokemonListResult> ProcessAllPokeAsync()
    {
        await using Stream stream =
        await _client.GetStreamAsync("https://pokeapi.co/api/v2/pokemon?limit=100000&offset=0");
        PokemonListResult? Result = await JsonSerializer.DeserializeAsync<PokemonListResult>(stream);        
        return Result;
    }


}