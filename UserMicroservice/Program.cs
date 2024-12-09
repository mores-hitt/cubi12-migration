using user_microservice.Src.Extensions;
using user_microservice.Src.Middlewares;
using user_microservice.Src.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddGrpc(options =>
{
    options.Interceptors.Add<ExceptionHandlingInterceptor>();
});

builder.Services.AddGrpcReflection();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddApplicationServices(builder.Configuration);

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapGrpcReflectionService();
}

app.UseAuthentication();
app.UseAuthorization();

// app.UseIsUserEnabled();

app.UseHttpsRedirection();

app.MapGrpcService<SubjectsController>();
app.MapGrpcService<UsersController>();

// Database Bootstrap
AppSeedService.SeedDatabase(app);

app.Run();