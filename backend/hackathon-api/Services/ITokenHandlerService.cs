using hackathon_api.Models.DTOs;

namespace hackathon_api.Services;
public interface ITokenHandlerService
{
    public Task<string> CreateTokenAsync(LoginDTO user);
}
