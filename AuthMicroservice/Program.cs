using Microsoft.EntityFrameworkCore;
using Auth.Src.Data;
using Auth.Src.Extensions;
using Auth.Src.Middlewares;
using Auth.Src.Services;
using Auth.Src.Services.Interfaces;
using Auth.Src.Repositories;
using Auth.Src.Repositories.Interfaces;
using RabbitMQ;
using MassTransit;
using Shared.Library.Messages;

var builder = WebApplication.CreateBuilder(args);
var localAllowSpecificOrigins = "_localAllowSpecificOrigins";
var deployedAllowSpecificOrigins = "_deployedAllowSpecificOrigins";

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IBlackListRepository, BlacklistRepository>();
builder.Services.AddScoped<ICareersRepository, CareersRepository>();
builder.Services.AddScoped<IRolesRepository, RolesRepository>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


// Add services to the container.
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: localAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyHeader()
                                .AllowAnyMethod()
                                .AllowCredentials()
                                .WithOrigins("http://localhost:3000",
                                            "http://localhost:8100",
                                            "http://localhost");
                      });
    options.AddPolicy(name: deployedAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyHeader()
                                .AllowAnyMethod()
                                .AllowCredentials()
                                .WithOrigins("https://cubi12.azurewebsites.net",
                                            "https://cubi12.cl",
                                            "https://www.cubi12.cl");
                      });
});

builder.Services.AddMassTransit(x =>
{

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.Send<UserCreatedMessage>(x =>
            {
                x.UseRoutingKeyFormatter(context => "user-created-queue");
            });
        cfg.Send<UpdatePasswordMessage>(x =>
            {
                x.UseRoutingKeyFormatter(context => "update-password-queue");
            });

    });

});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApplicationServices(builder.Configuration);

builder.Services.AddOutputCache(options =>
{
    options.AddBasePolicy(builder => builder.Cache());
});

var app = builder.Build();
app.UseOutputCache();

// Because it's the first middleware, it will catch all exceptions
app.UseExceptionHandling();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(localAllowSpecificOrigins);
}
else
{
    app.UseCors(deployedAllowSpecificOrigins);
}

app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.MapControllers();

// Database Bootstrap
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<DataContext>();
    context.Database.Migrate();
    AppSeedService.SeedDatabase(app);
}

app.Run();