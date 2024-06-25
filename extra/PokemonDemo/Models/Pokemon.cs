
using System.Text.Json.Serialization;

namespace PokemonDemo.Models;

public record class Pokemon(
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("height")] int Height,
    [property: JsonPropertyName("sprites")] Sprites Image,
    [property: JsonPropertyName("moves")] Moveset[] Moves
);

public record class GetName(
    [property: JsonPropertyName("name")] string Name
);

public record class Moveset(
    [property: JsonPropertyName("move")] GetName Move
);