using AutoMapper;
using hackathon_api.Data;
using hackathon_api.Models;
using hackathon_api.Models.DTOs;
using hackathon_api.Repositories.Auth;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace hackathon_api.Repositories.TicketRepository;
public class TicketRepository : ITicketRepository
{
    private readonly DBMainContext _dbContext;
    private readonly AuthInterfaceRepository _authRepository;
    private readonly IMapper _mapper;
    public TicketRepository(DBMainContext dbContext, AuthInterfaceRepository authInterfaceRepository, IMapper mapper)
    {
        _dbContext = dbContext;
        _authRepository = authInterfaceRepository;
        _mapper = mapper;
    }
    public async Task<bool> AddTicketAsync(TicketPOSTDTO ticketPost)
    {
        var player = ticketPost.Player;
        //var userMapped = _mapper.Map<LoginDTO>(player);

        var loginDtoUser = new LoginDTO()
        {
            Id = player.Id,
            UserName = player.UserName,
        };

        if (await _authRepository.Login(loginDtoUser) == null)
            await _authRepository.CreateUser(loginDtoUser);

        var gameType = CheckGameType(ticketPost.GameType);
        var newTicket = new Ticket()
        {
            GameType = gameType,
            UserId = ticketPost.Player.Id,
            FreeBet = ticketPost.FreeBet,
            TicketDate = DateTime.Now,
            Amount = ticketPost.Amount,
            TxId = ticketPost.TxId,
            ReferenceTxId = ticketPost.ReferenceTxId
        };
        await _dbContext.AddAsync(newTicket);

        var user = await _dbContext.Users.FirstOrDefaultAsync(s=>s.Id == ticketPost.Player.Id && s.Username == ticketPost.Player.UserName);
        var nameOfCountFieldOfGame = $"{ ticketPost.GameType }Count";

        var propertyInfo = user.GetType().GetProperty(nameOfCountFieldOfGame);

        if (propertyInfo != null)
        {
            int currentValue = Convert.ToInt16(propertyInfo.GetValue(user));
            propertyInfo.SetValue(user, currentValue + 1);
        }



        await _dbContext.SaveChangesAsync();
        return true;
    }
    public GameType CheckGameType(string gameTypeStr)
    {
        var property = (GameType)Enum.Parse(typeof(GameType), gameTypeStr);
        return property;
    }
}
