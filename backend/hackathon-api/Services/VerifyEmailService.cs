using MimeKit;
using MailKit.Security;
using hackathon_api.Models.DTOs;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using hackathon_api.Data;
using hackathon_api.Models;
using hackathon_api.Repositories.Achivements;

namespace hackathon_api.Services;
public class VerifyEmailService : IVerifyEmailService
{
    private readonly IConfiguration _configuration;
    private readonly DBMainContext _dbContext;
    private readonly IUserAchivementsRepository _userachivement;
    public VerifyEmailService(IConfiguration configuration,DBMainContext dbcontext, IUserAchivementsRepository userachivement)
    {
        _configuration = configuration;
        _dbContext = dbcontext;
        _userachivement = userachivement;
    }
    public async Task<(bool result, string statusMessage)> VerifyEmailAsync(EmailVerificationDTO emailVerification)
    {
        try
        {
            User u = _dbContext.Users.Find(emailVerification.UserId);
            if (!await _userachivement.CheckUserAchivementAsync(emailVerification.UserId, "EmailVerification"))
            {
                var message = new MimeMessage();
                var emailSender = _configuration.GetValue<string>("EmailSender");
                message.From.Add(new MailboxAddress("no-reply", emailSender));

                message.To.Add(new MailboxAddress(u.Name, u.Email));

                message.Subject = "E-mail verification";
                message.Body = new TextPart("plain")
                {
                    Text = "Click the following link to verify your e-mail: https://evona-hack-2023.vercel.app/"
                };
                using var client = new MailKit.Net.Smtp.SmtpClient();
                await client.ConnectAsync("smtp.office365.com", 587, SecureSocketOptions.StartTls);
                await client.AuthenticateAsync("team4hackathon@outlook.com", "hackathonteam4");
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
            else
            {
                return (true, "User already verified");
            }
        }
        catch (Exception ex)
        {
            return (false, ex.ToString());
        }
        return (true, "Verification Email has been sent!");
    }

}
