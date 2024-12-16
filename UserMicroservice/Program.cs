using user_microservice.Src.Extensions;
using user_microservice.Src.Middlewares;
using user_microservice.Src.Controllers;
using MassTransit;
using Shared.Library.Messages;
using user_microservice.Src.Consumers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddGrpc(options =>
{
    options.Interceptors.Add<ExceptionHandlingInterceptor>();
});

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<CreateUserConsumer>();
    x.AddConsumer<UpdatePasswordConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.ReceiveEndpoint("user-created-queue", ep => //CAMBIAR NOMBRE DE QUEUE
        {
            ep.ConfigureConsumer<CreateUserConsumer>(context);
        });

        cfg.ReceiveEndpoint("update-password-queue", ep => //CAMBIAR NOMBRE DE QUEUE
        {
            ep.ConfigureConsumer<UpdatePasswordConsumer>(context);
        });
    });
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