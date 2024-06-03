using WebApplication1.Entities;
using WebApplication1.EndPoints;
using WebApplication1.Repositories;
using WebApplication1.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRepositories(builder.Configuration);
var app = builder.Build();
app.Services.IntializeDb();
app.MapGamesEndPoints();
app.Run();
