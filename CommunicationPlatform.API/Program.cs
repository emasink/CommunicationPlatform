using CommunicationPlatform.API.CustomExceptionMiddleware;
using CommunicationPlatform.API.Extensions;
using CommunicationPlatform.Persistence;
using CommunicationPlatform.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddPersistence();
builder.Services.AddServices();

var app = builder.Build();

app.ConfigureCustomExceptionMiddleware();
app.UseExceptionHandler(opt => { });
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.ConfigureCustomExceptionMiddleware();
app.UseRouting();
app.UseEndpoints(endpoints => endpoints.MapControllers());
app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}