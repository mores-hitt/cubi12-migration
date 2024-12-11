using Ocelot.DependencyInjection;
using ApiGateway.Src.Service;
using Ocelot.Middleware;
using ApiGateway.Src.Service.Interfaces;
using ApiGateway.Src.Services.Interfaces;
using ApiGateway.Src.Services;
using ApiGateway.Src.Clients;
using ApiGateway.Src.Clients.Interfaces;
using Grpc.Net.Client;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddOcelot(builder.Configuration);
//builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
builder.Services.AddSingleton(services =>
{
    return GrpcChannel.ForAddress("http://localhost:5275");
});

builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddControllers();
builder.Services.AddScoped<ICareerService, CareerService>();
builder.Services.AddScoped<ICareerServiceClient, CareerServiceClient>();
builder.Services.AddScoped<ILegacyService, LegacyService>();
builder.Services.AddScoped<ILegacyServiceClient, LegacyServiceClient>();

builder.Services.AddHttpClient();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//await app.UseOcelot();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

