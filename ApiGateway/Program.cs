using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using ApiGateway.Src.Services.Interfaces;
using ApiGateway.Src.Services;
using ApiGateway.Src.Clients;
using ApiGateway.Src.Clients.Interfaces;
using Grpc.Net.Client;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.CustomSchemaIds(type => type.FullName);
});
builder.Services.AddSingleton(services =>
{
    return GrpcChannel.ForAddress("http://localhost:5275");
});
builder.Services.AddSingleton(services =>
{
    return GrpcChannel.ForAddress("http://localhost:5375");
});


builder.Services.AddControllers();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddScoped<IAuthServiceClient>(provider =>
{
    var httpClient = provider.GetRequiredService<HttpClient>();
    var baseUrl = "http://localhost:5235";
    return new AuthServiceClient(httpClient, baseUrl);
});

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserServiceClient, UserServiceClient>();
builder.Services.AddScoped<ICareerService, CareerService>();
builder.Services.AddScoped<ICareerServiceClient, CareerServiceClient>();
builder.Services.AddScoped<ILegacyService, LegacyService>();
builder.Services.AddScoped<ILegacyServiceClient, LegacyServiceClient>();
builder.Services.AddScoped<ISubjectService, SubjectService>();
builder.Services.AddScoped<ISubjectServiceClient, SubjectServiceClient>();

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

