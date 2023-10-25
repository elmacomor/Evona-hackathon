using hackathon_api.Repositories.Achivements;
using hackathon_api.Repositories.Auth;
using hackathon_api.Repositories.Transactions;
using hackathon_api.Services;
using Microsoft.EntityFrameworkCore;
using hackathon_api.Data;
using System;
using hackathon_api.Repositories.TicketRepository;
using hackathon_api.Repositories.UsersScore;
using hackathon_api.Repositories.VerifyRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/* DATABASE */
builder.Services.AddDbContext<DBMainContext>(options =>
{
    var mainConnectionString = builder.Configuration.GetConnectionString("DBConnection");
    if (mainConnectionString != null)
    {
        options.UseSqlServer(mainConnectionString);
    }
    else
    {
        Console.WriteLine("ERROR: Unable to connect to the server!");
    }
});


builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<AuthInterfaceRepository, Auth>();
builder.Services.AddScoped<IResponseService, ResponseService>();
builder.Services.AddScoped<ITokenHandlerService, TokenHandlerService>();
builder.Services.AddScoped<IVerifyEmailService, VerifyEmailService>();
builder.Services.AddScoped<IUserAchivementsRepository, UserAchivementsRepository>();
builder.Services.AddScoped<IAchivementsRepository, AchivementsRepository>();
builder.Services.AddScoped<ITransactionsRepository, TransactionsRepository>();
builder.Services.AddScoped<ITicketRepository,TicketRepository>();
builder.Services.AddScoped<IUsersScoreRepository,UsersScoreRepository>();
builder.Services.AddScoped<IVerifyRepository, VerifyRepository>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:5173") // Update with your React app's domain
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider
        .GetRequiredService<DBMainContext>();

    // Here is the migration executed
    dbContext.Database.Migrate();
}
// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{


app.UseSwagger();
app.UseSwaggerUI();



app.UseCors();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
