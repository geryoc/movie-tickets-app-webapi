using Microsoft.EntityFrameworkCore;
using MovieTicketsApp.WebApi.Shared.Database;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// 1. Add and configure services
builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter())); // Enums as Strings

builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MainDatabase")));

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

// 2. Build App
var app = builder.Build();

// 3. Define Middleware Pipeline (Use Services)
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

public partial class Program { } // For Visibility to Integration Tests