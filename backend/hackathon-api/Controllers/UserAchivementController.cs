using hackathon_api.Repositories.UsersScore;
using Microsoft.AspNetCore.Mvc;

namespace hackathon_api.Controllers;
public class UserAchivementController : Controller
{
    private readonly IUsersScoreRepository _usersScoreRepository;

    public UserAchivementController(IUsersScoreRepository usersScoreRepository)
    {
        _usersScoreRepository = usersScoreRepository;
    }
    #region scoreboard
    [Route("/get-scoreboard")]
    [HttpGet]
    public async Task<IActionResult> GetUsersScoreBoardAsync()
    {
        return Ok(await _usersScoreRepository.GetUsersScoreBoardAsync());
    }
    #endregion


}
