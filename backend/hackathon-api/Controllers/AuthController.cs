using AutoMapper;
using hackathon_api.Models.DTOs;
using hackathon_api.Repositories.Achivements;
using hackathon_api.Repositories.Auth;
using hackathon_api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace hackathon_api.Controllers;
public class AuthController : Controller
{
    private readonly AuthInterfaceRepository _authInterfaceRepository;
    private readonly IMapper _mapper;
    private readonly ITokenHandlerService _tokenHandlerService;
    private readonly IResponseService _responseService;
    private readonly IUserAchivementsRepository _userAchivements;
 
    public AuthController(AuthInterfaceRepository authInterfaceRepository, IMapper mapper, ITokenHandlerService tokenHandlerService, IResponseService responseService, IUserAchivementsRepository userAchivements)
    {
        _authInterfaceRepository = authInterfaceRepository;
        _mapper = mapper;
        _tokenHandlerService = tokenHandlerService;
        _responseService = responseService;
        _userAchivements = userAchivements;
    }
    [HttpPost]
    [Route("/hackathon/api/Data/login")]
    public async Task<IActionResult> LoginAsync(LoginDTO login)
    {
        var loginDto = _mapper.Map<LoginDTO>(login);
        var userAchivementFirstLogin = new UserAchivementCreateDTO();
        var validUser = await _authInterfaceRepository.Login(loginDto);
        if (validUser != null)
        {
            await _authInterfaceRepository.UpdateLastLogInDateTime(validUser.Id);
            var tempUser = _mapper.Map<LoginDTO>(validUser);
            var twoDaysLogin = await _userAchivements.CheckUserAchivementAsync(validUser.Id, "TwoDaysAchivement");
            if (!twoDaysLogin)
            {
                await _userAchivements.TwoDaysLogIn(validUser.Id);
            }
        }
        else
        {
            validUser = await _authInterfaceRepository.CreateUser(loginDto);
        }

        userAchivementFirstLogin = new UserAchivementCreateDTO()
        {
            UserId = validUser.Id,
            AchivementType = "FirstLogin"
        };

        var checkUserAch = await _userAchivements.CheckUserAchivementAsync(validUser.Id, userAchivementFirstLogin.AchivementType);
        if (!checkUserAch)
            await _userAchivements.AddAchivementToUserAsync(userAchivementFirstLogin);

        return await _responseService.Response(200, validUser);

    }
    [HttpPost]
    [Route("Login-app/{Id}/{UserName}")]
    public async Task<IActionResult> LoginAppAsync(string Id, string UserName)
    {
        var login = new LoginDTO(){
            Id = Id,
            UserName = UserName
        };
        var loginDto = _mapper.Map<LoginDTO>(login);
        var userAchivementFirstLogin = new UserAchivementCreateDTO();
        var validUser = await _authInterfaceRepository.Login(loginDto);
        if (validUser != null)
        {
            await _authInterfaceRepository.UpdateLastLogInDateTime(validUser.Id);
            var tempUser = _mapper.Map<LoginDTO>(validUser);
            var twoDaysLogin = await _userAchivements.CheckUserAchivementAsync(validUser.Id, "TwoDaysAchivement");
            if (!twoDaysLogin)
            {
                await _userAchivements.TwoDaysLogIn(validUser.Id);
            }
            TokenDTO loginResponse = new()
            {
                UserName = loginDto.UserName,
                Token = await _tokenHandlerService.CreateTokenAsync(tempUser)
            };
        }
        else
        {
            return await _responseService.Response(401, null);
        }

        userAchivementFirstLogin = new UserAchivementCreateDTO()
        {
            UserId = validUser.Id,
            AchivementType = "FirstLogin"
        };

        var checkUserAch = await _userAchivements.CheckUserAchivementAsync(validUser.Id, userAchivementFirstLogin.AchivementType);
        if (!checkUserAch)
            await _userAchivements.AddAchivementToUserAsync(userAchivementFirstLogin);

        return await _responseService.Response(200, validUser);

    }

}

