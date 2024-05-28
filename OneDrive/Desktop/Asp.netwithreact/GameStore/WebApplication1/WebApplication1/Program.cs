using WebApplication1.Entities;
using WebApplication1.EndPoints;
using WebApplication1.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IGamesRespository, InMeMGamesRespository>();
var connString = builder.Configuration.GetConnectionString("GameStoreContext");
var app = builder.Build();
app.MapGamesEndPoints();
app.Run();
