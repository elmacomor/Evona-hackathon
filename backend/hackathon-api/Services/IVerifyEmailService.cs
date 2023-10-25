using hackathon_api.Models.DTOs;

namespace hackathon_api.Services;
public interface IVerifyEmailService
{
    public Task<(bool result, string statusMessage)> VerifyEmailAsync(EmailVerificationDTO emailVerification);
}
