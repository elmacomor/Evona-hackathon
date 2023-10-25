using hackathon_api.Data;
using hackathon_api.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace hackathon_api.Repositories.UsersScore;

public class UsersScoreRepository : IUsersScoreRepository
{
    private readonly DBMainContext _dbContext;
    public UsersScoreRepository(DBMainContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<List<UsersScoreDTO>> GetUsersScoreBoardAsync()
    {
        var usersScore = _dbContext.Users.ToList()
                                   .Select((user,itemRank) => new UsersScoreDTO
                                   {
                                       Rank = itemRank + 1,
                                       Name = user.Name,
                                       Points = user.Points,
                                       Level = ReturnLevel(user.Points)
                                   }).ToList().OrderByDescending(user => user.Points);
        return await Task.FromResult(usersScore.ToList());
    }
    public int ReturnLevel(int points)
    {
        if (points < 200)
            return 1;
        else if (points >= 200 && points < 600)
            return 2;
        else if (points >= 600 && points < 1200)
            return 3;
        else if (points >= 1200 && points < 3300)
            return 4;
        return 5;
    }
}
