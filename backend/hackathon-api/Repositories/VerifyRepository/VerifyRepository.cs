using hackathon_api.Data;
using hackathon_api.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace hackathon_api.Repositories.VerifyRepository;
public class VerifyRepository : IVerifyRepository
{
    private readonly DBMainContext _dbContext;
    public VerifyRepository(DBMainContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<bool> VerifyUserAsync(VerifyDTO verify)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(s => s.Username == verify.Player.UserName
                                                                && s.Id == verify.Player.Id);
        if(user != null)
        {
            if (verify.Type == 1)
                user.IsVerified = true;
        }
        return true;
    }
}
