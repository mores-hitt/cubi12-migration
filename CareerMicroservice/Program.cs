using Career.Src.Controllers;
using Career.Src.Data;
using Career.Src.Repositories;
using Career.Src.Repositories.Interfaces;
using Career.Src.Services;
using Career.Src.Services.Interfaces;
using Career.Src.Mapping;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.Configure<DataContext>(builder.Configuration.GetSection("ConnectionStrings:MongoDB"));
builder.Services.AddSingleton<DataContext>();
builder.Services.AddScoped<ICareersRepository, CareersRepository>();
builder.Services.AddScoped<ICareersService, CareersService>();
builder.Services.AddScoped<IMapperService, MapperService>();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddGrpc();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<DataContext>();
    Seed.SeedData(context);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapGrpcService<CareersController>();

app.Run();
