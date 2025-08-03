using CommunicationPlatform.Persistence;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddPersistence();

var host = builder.Build();

host.Run();