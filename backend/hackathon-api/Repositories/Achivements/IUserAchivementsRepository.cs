using hackathon_api.Models;
using hackathon_api.Models.DTOs;

namespace hackathon_api.Repositories.Achivements;

public interface IUserAchivementsRepository
{
    public Task<bool> AddAchivementToUserAsync(UserAchivementCreateDTO createDTO);
    public Task<bool> CheckUserAchivementAsync(string userId, string achivementType);
    public Task<bool> TwoDaysLogIn(string userId);
    public Task<bool> VerifiedAchivement(string userID);
  
    //public Task<bool> CheckTransactionAchivementAsync(string userId, TypeOfTransaction typeOfTransaction);
}
