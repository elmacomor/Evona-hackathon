using hackathon_api.Models.DTOs;

namespace hackathon_api.Repositories.UsersScore;
public interface IUsersScoreRepository
{
    public Task<List<UsersScoreDTO>> GetUsersScoreBoardAsync();
    public int ReturnLevel(int points);
}
