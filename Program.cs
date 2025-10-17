using DesafioPOO.Db;
using DesafioPOO.Interfaces;
using Microsoft.EntityFrameworkCore;
using DesafioPOO.Services;
using DesafioPOO.Endpoints;

#region Builder
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IProprietarioService, ProprietarioService>();
builder.Services.AddScoped<IImovelService, ImovelService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DbContexto>(options =>
{
  options.UseMySql(
    builder.Configuration.GetConnectionString("mysql"),
    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("mysql"))
  );
});

var app = builder.Build();
#endregion

#region Endpoints
app.MapProprietarioEndpoints();
app.MapCasaEndpoints();
#endregion

#region App
app.UseSwagger();
app.UseSwaggerUI();

app.Run();
#endregion