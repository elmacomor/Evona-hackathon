using hackathon_api.Models;
using hackathon_api.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using hackathon_api.Data;

namespace hackathon_api.Repositories.Achivements;
public class UserAchivementsRepository : IUserAchivementsRepository
{
    private DBMainContext _dbContext;
    public UserAchivementsRepository(DBMainContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<bool> AddAchivementToUserAsync(UserAchivementCreateDTO createDTO)
    {
        try
        {
            var achivement = new UserAchivement()
            {
                UserId = createDTO.UserId,
                Achivement = await _dbContext.Achivements.FirstOrDefaultAsync(x => x.AchivementType == createDTO.AchivementType)
            };
            await _dbContext.UserAchivements.AddAsync(achivement);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {

            throw;
        }
        
    }
    public async Task<bool> CheckUserAchivementAsync(string userId,string achivementType) 
    {
        var userHasAchivement = await _dbContext.UserAchivements.Include(s => s.Achivement).AsNoTracking().
                                                                FirstOrDefaultAsync(s => s.UserId == userId && 
                                                                s.Achivement != null &&
                                                                s.Achivement.AchivementType == achivementType);
        return (userHasAchivement != null && userHasAchivement.Achivement != null) ? await Task.FromResult(true) : false;
    }

    public async Task<bool> TwoDaysLogIn(string userId)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(a => a.Id == userId);
        if (user == null) { return false; }
        var result = DateTime.Now - user.LastLogin;
        Console.WriteLine(result.ToString());
        return true;

    }
    public async Task<bool> VerifiedAchivement(string userID)
    {
        User u = _dbContext.Users.Find(userID);
        if (u == null)
        {
            return false;
        }
        if (u.IsVerified == true)
        {

            UserAchivementCreateDTO obj = new UserAchivementCreateDTO()
            {
                UserId = userID,
                AchivementType = "EmailVerification"
            };
            await AddAchivementToUserAsync(obj);
            return true;
        }
        return false;
    }
  
   
}
