using hackathon_api.Models.DTOs;
using hackathon_api.Repositories.TicketRepository;
using Microsoft.AspNetCore.Mvc;

namespace hackathon_api.Controllers;
public class TicketController : Controller
{
    private readonly ITicketRepository _ticketRepository;
    public TicketController(ITicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }
    [Route("/hackathon/api/Data/bet")]
    [HttpPost]
    public async Task<IActionResult> AddTicketBetAsync(TicketPOSTDTO ticketPost)
    {
        await _ticketRepository.AddTicketAsync(ticketPost);
        return Ok();
    }
    [Route("/hackathon/api/Data/win")]
    [HttpPost]
    public async Task<IActionResult> AddTicketWinAsync(TicketPOSTDTO ticketPost)
    {
        await _ticketRepository.AddTicketAsync(ticketPost);
        return Ok();
    }
}
