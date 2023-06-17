using System.Threading.Tasks;
using Final.Interfaces;
using Final.Models;
using Microsoft.AspNetCore.Mvc;

namespace Final.Controllers; 

[Route("cinema")]
[ApiController]
public class CinemaController : Controller {
    public CinemaController(
        IMovieAccessLayer movieAccessLayer,
        IShowTimeAccessLayer showTimeAccessLayer) {
        _movieAccessLayer = movieAccessLayer;
        _showTimeAccessLayer = showTimeAccessLayer;
    }

    [HttpGet("movies")]
    public async Task<IActionResult> GetMovies() {
        return Ok(await _movieAccessLayer.GetMovies());
    }

    [HttpGet("showtimes")]
    public async Task<IActionResult> GetShowTimes() {
        return Ok(await _showTimeAccessLayer.GetShowTimes());
    }

    [HttpPost("tickets")]
    public async Task<IActionResult> BookTickets([FromBody] TicketRequest request) {
        if (request.Quantity <= 0 || request.Quantity > 50) {
            return BadRequest($"Invalid tickets quantity: {request.Quantity}");
        }

        try {
            if (!await _showTimeAccessLayer.CheckShowTimeExistence(request.ShowtimeId)) {
                return NotFound($"Show time with id {request.ShowtimeId} does not exist");
            }
        } catch {
            return BadRequest(ErrorResponseMessage);
        }

        return Ok("Tickets were booked successfully");
    }
    
    private const string ErrorResponseMessage = "Service is temporarily unavailable";

    private readonly IMovieAccessLayer _movieAccessLayer;
    private readonly IShowTimeAccessLayer _showTimeAccessLayer;
}