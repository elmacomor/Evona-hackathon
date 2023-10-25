using hackathon_api.Models;
using hackathon_api.Models.DTOs;

namespace hackathon_api.Repositories.Achivements;
public interface IAchivementsRepository
{
    public Task<List<AchivementsGETDTO>> GetAchivementsForUserAsync(string userId);
}
