using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Final.Models;

public record TicketRequest {
    [Required][JsonPropertyName("showtime_id")] public int ShowtimeId { get; set; }
    [Required][JsonPropertyName("quantity")] public int Quantity { get; set; }
}