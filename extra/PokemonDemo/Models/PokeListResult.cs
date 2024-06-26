using System.Text.Json.Serialization;

namespace PokemonDemo.Models;

public record class PokemonListResult(
    [property: JsonPropertyName("count")] int Count,
    [property: JsonPropertyName("results")] Pokemon[] Pokemons
);

