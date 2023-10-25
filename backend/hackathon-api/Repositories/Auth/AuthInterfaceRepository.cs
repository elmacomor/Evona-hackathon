using hackathon_api.Models;
using hackathon_api.Models.DTOs;

namespace hackathon_api.Repositories.Auth;
public interface AuthInterfaceRepository
{
    public Task<User> Login(LoginDTO user);
    public Task<User> CreateUser(LoginDTO user);
    public Task<bool> UpdateLastLogInDateTime(string userId);
}
