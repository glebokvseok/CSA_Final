using System;
using System.Text.Json.Serialization;

namespace Final.Models;

public record Movie {
    [JsonPropertyName("id")] public int Id { get; set; }
    [JsonPropertyName("name")] public string Name { get; set; } = null!;
    [JsonIgnore] public Genre Genre { get; set; }
    [JsonPropertyName("duration")] public double Duration { get; set; }
    [JsonPropertyName("rating")] public double Rating { get; set; }
    [JsonPropertyName("genre")] public string GenreName { get; set; } = null!;
}