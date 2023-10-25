using hackathon_api.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using hackathon_api.Data;
using hackathon_api.Models;

namespace hackathon_api.Repositories.Achivements;
public class AchivementsRepository : IAchivementsRepository
{
    private readonly DBMainContext _dbContext;
    public AchivementsRepository(DBMainContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<List<AchivementsGETDTO>> GetAchivementsForUserAsync(string userId)
    {
        var userData = await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(s => s.Id == userId);
        var achivements = await _dbContext.Achivements.ToListAsync();

        var userAchivements = new List<AchivementsGETDTO>();
        foreach(var achivement in achivements)
        {
            var userAchivement = new AchivementsGETDTO()
            {
                Name = $"{achivement.Name} {achivement.Treashold}",
                Points = achivement.Points.ToString(),
                TreashHold = achivement.Treashold.ToString()
            };

            var userFieldName = $"{achivement.Name}";
            if (achivement.Name != "Withdraw" && achivement.Name != "Deposit")
            {
                userFieldName += "Count";
            }
            else
            {
                if (achivement.Name == "Withdraw")
                {
                    userFieldName += "al";
                }
                userFieldName += "CumulativeAmount";
            }

            
            //var userCountFieldName = $"{achivement.Name}Count";
            var countField = userData.GetType().GetProperty(userFieldName).GetValue(userData, null);
            var countFieldValue = countField != null ? Convert.ToInt32(countField) : 0;
            var substract = countFieldValue - achivement.Treashold;
            if (achivement.Name != "Withdrawal" && achivement.Name != "Deposit")
            {
                var propertyInfo = userData.GetType().GetProperty(userFieldName);

                if (propertyInfo != null)
                {
                    var valueForUser = countFieldValue - achivement.Treashold < 0 ? 0 : countFieldValue - achivement.Treashold;
                    propertyInfo.SetValue(userData, valueForUser);
                }
            }
            userAchivement.UserTreashHold = countFieldValue > achivement.Treashold ? (countFieldValue - substract).ToString() : countFieldValue.ToString();

            userAchivements.Add(userAchivement);
        }
        return userAchivements;
    }
}
