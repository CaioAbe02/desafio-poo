using DesafioPOO.Db;
using Microsoft.EntityFrameworkCore;

#region Builder
var builder = WebApplication.CreateBuilder(args);

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

#region App
app.UseSwagger();
app.UseSwaggerUI();

app.Run();
#endregion