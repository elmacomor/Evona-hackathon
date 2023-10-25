using hackathon_api.Models.DTOs;

namespace hackathon_api.Repositories.VerifyRepository;
public interface IVerifyRepository
{
    public Task<bool> VerifyUserAsync(VerifyDTO verify);
}
