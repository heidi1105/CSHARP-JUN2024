
using System.Text.Json.Serialization;

namespace PokemonDemo.Models;

public record class Sprites(
    [property: JsonPropertyName("front_default")] string front,
    [property: JsonPropertyName("front_shiny")] string frontShiny,
    [property: JsonPropertyName("front_male")] string male,
    [property: JsonPropertyName("front_female")] string female
);