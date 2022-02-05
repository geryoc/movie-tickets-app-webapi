using Microsoft.EntityFrameworkCore;
using MovieTicketsApp.WebApi.Shared.Database;

var builder = WebApplication.CreateBuilder(args);

// 1. Add Services
builder.Services.AddControllers();

builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MainDatabase")));

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

// 2. Build App
var app = builder.Build();

// 3. Use Services (Pipeline)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// 4. Run
app.Run();
