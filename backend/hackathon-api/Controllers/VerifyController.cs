using hackathon_api.Models.DTOs;
using hackathon_api.Repositories.VerifyRepository;
using Microsoft.AspNetCore.Mvc;

namespace hackathon_api.Controllers;
public class VerifyController : Controller
{
    private readonly IVerifyRepository _verifyRepository;

    public VerifyController(IVerifyRepository verifyRepository)
    {
        _verifyRepository = verifyRepository;
    }
    [HttpPut]
    [Route("/hackathon/api/Data/verify")]
    public async Task<bool> VerifyAsync(VerifyDTO verify)
    {
        return await _verifyRepository.VerifyUserAsync(verify);
    }
}
