using hackathon_api.Models;
using hackathon_api.Models.DTOs;

namespace hackathon_api.Repositories.TicketRepository;
public interface ITicketRepository
{
    public Task<bool> AddTicketAsync(TicketPOSTDTO ticketPost);
    public GameType CheckGameType(string gameTypeStr);
}
