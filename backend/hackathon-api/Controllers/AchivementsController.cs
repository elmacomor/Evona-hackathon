using hackathon_api.Repositories.Achivements;
using Microsoft.AspNetCore.Mvc;

namespace hackathon_api.Controllers
{
    public class AchivementsController : Controller
    {
        public IAchivementsRepository _achivementsRepository;
        public AchivementsController(IAchivementsRepository achivementsRepository)
        {
            _achivementsRepository = achivementsRepository;
        }
        [Route("/api/data/achivements/{userId}")]
        [HttpGet]
        public async Task<IActionResult> GetAchivementsForUserAsync(string userId)
        {
            return Ok(await _achivementsRepository.GetAchivementsForUserAsync(userId));
        }
    }
}
