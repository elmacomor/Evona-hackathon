using hackathon_api.Models;
using Microsoft.EntityFrameworkCore;

namespace hackathon_api.Data;

public class DBMainContext : DbContext
{
    public DBMainContext(DbContextOptions<DBMainContext> options) : base(options)
    {

    }
    public DbSet<User> Users { get; set; }
    public DbSet<Achivement> Achivements { get; set; }
    public DbSet<UserAchivement> UserAchivements { get; set; }
    public DbSet<Match> Matches { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
}