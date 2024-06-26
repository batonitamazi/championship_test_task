using Microsoft.Data.SqlClient;
using System.Data;
using Upgaming_test_task.NewFolder;
using Upgaming_test_task.Repositories;
using Upgaming_test_task.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IScoreService, ScoreService>();
builder.Services.AddScoped<IScoreRepository, ScoreRepository>();
builder.Services.AddTransient<IDbConnection>(provider => new SqlConnection("Server=localhost;Database=ChampionShip;Integrated Security=True; TrustServerCertificate=True;"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
