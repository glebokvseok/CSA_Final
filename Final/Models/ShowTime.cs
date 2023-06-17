using System;
using System.Text.Json.Serialization;

namespace Final.Models;

public record ShowTime {
    [JsonPropertyName("id")] public int Id { get; set; }
    [JsonPropertyName("film_name")] public string FilmName { get; set; } = null!;
    [JsonPropertyName("date")] public DateTime Date { get; set; }
    [JsonIgnore] public int FilmId { get; set; }
}