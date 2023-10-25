using hackathon_api.Models;
using hackathon_api.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Bcpg.OpenPgp;
using hackathon_api.Data;
using System.Security.Cryptography;
using System.Text;

namespace hackathon_api.Repositories.Auth;
public class Auth : AuthInterfaceRepository
{
    private readonly DBMainContext _dbContext;
    public Auth(DBMainContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<User> Login(LoginDTO user)
    {
        user.Id = user.Id;//HashPassword(user.Password);
        var _user = await _dbContext.Users.AsNoTracking().Where(s => s.Username == user.UserName && s.Id == user.Id).FirstOrDefaultAsync();
        return _user;
    }
    public async Task<User> CreateUser(LoginDTO user)
    {
        var newUser = new User();
        newUser.Id = user.Id;
        newUser.Username = user.UserName;

        newUser.LastLogin = DateTime.Now;
        newUser.FirstLogin = DateTime.Now;

        await _dbContext.Users.AddAsync(newUser);
        await _dbContext.SaveChangesAsync();

        return newUser;
    }
    public async Task<bool> UpdateLastLogInDateTime(string userId)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(s=> s.Id ==  userId);
        user.LastLogin = DateTime.Now;
        await _dbContext.SaveChangesAsync();
        return await Task.FromResult(true);
    }
    public string HashPassword(string password)
    {
        StringBuilder Sb = new StringBuilder();


        using (SHA256 hash = SHA256Managed.Create())
        {

            Encoding enc = Encoding.UTF8;

            Byte[] result = hash.ComputeHash(enc.GetBytes(password));


            foreach (Byte b in result)

                Sb.Append(b.ToString("x2"));

        }
        return Sb.ToString();
    }
}
