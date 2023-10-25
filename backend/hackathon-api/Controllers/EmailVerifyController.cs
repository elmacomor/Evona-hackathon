using Microsoft.AspNetCore.Mvc;
using hackathon_api.Data;
using hackathon_api.Models.DTOs;
using hackathon_api.Services;
using hackathon_api.Models;
using hackathon_api.Repositories.Achivements;

namespace hackathon_api.NewFolder
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class EmailVerifyController:ControllerBase
    {
        private readonly DBMainContext _dbContext;
        private readonly IVerifyEmailService _verifyEmailService;
        private readonly IResponseService _responseService;
        private readonly IUserAchivementsRepository _userAchivementsRepository;
        public EmailVerifyController(DBMainContext dbcontex, IVerifyEmailService verifyEmailService, IResponseService responseService, IUserAchivementsRepository userAchivementsRepository)
        {
            _dbContext = dbcontex;
            _verifyEmailService = verifyEmailService;
            _responseService = responseService;
            _userAchivementsRepository= userAchivementsRepository;
        }

        [HttpPost]
        public async Task<IActionResult> VerifyEmailAsync(EmailVerificationDTO emailVerification)
        {
           var emailSent = await _verifyEmailService.VerifyEmailAsync(emailVerification);
           if (emailSent.result)
                return await _responseService.Response(200, $"{ emailSent.statusMessage }");
           else
                return await _responseService.Response(400, $"ERROR: { emailSent.statusMessage }");
        }


        [HttpPost]
        public async Task<IActionResult> VerifyButton(string UserID)
        {
            User u = _dbContext.Users.Find(UserID);
            if(u==null)
            {
                return BadRequest("User not found");
            }
            u.IsVerified = true;
            _dbContext.SaveChanges();
            _userAchivementsRepository.VerifiedAchivement(UserID);
            return Ok("Successfully verified!");

        }
    }
}
