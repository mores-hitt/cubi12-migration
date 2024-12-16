using Auth.Src.Data;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;
using Auth.Src.Repositories;
using Auth.Src.Repositories.Interfaces;
using Auth.Src.Services.Interfaces;
using Auth.Src.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using Auth.Src.Exceptions;

namespace Auth.Src.Extensions
{
    public static class AppServiceExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            InitEnvironmentVariables();
            AddAutoMapper(services);
            AddServices(services);
            AddSwaggerGen(services);
            AddDbContext(services);
            AddUnitOfWork(services);
            AddAuthentication(services, config);
            AddHttpContextAccesor(services);
        }

        private static void InitEnvironmentVariables()
        {
            Env.Load();
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IMapperService, MapperService>();
            services.AddScoped<IAuthService, AuthService>();
        }

        private static void AddSwaggerGen(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cubitwelve API", Version = "v1" })
            );

        }

        private static void AddDbContext(IServiceCollection services)
        {
            var connectionUrl = Env.GetString("DB_CONNECTION");

            services.AddDbContext<DataContext>(opt => {
                opt.UseSqlServer(connectionUrl, sqlServerOpt => {
                    sqlServerOpt.EnableRetryOnFailure(
                        maxRetryCount: 10,
                        maxRetryDelay: System.TimeSpan.FromSeconds(30),
                        errorNumbersToAdd: null
                    );
                });
            });
        }

        private static void AddUnitOfWork(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        private static void AddAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile).Assembly);
        }

        private static IServiceCollection AddAuthentication(IServiceCollection services, IConfiguration config)
        {
            var jwtSecret = Env.GetString("JWT_SECRET") ??
                throw new InvalidJwtException("JWT_SECRET not present in .ENV");

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSecret)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            return services;
        }

        private static void AddHttpContextAccesor(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
        }


    }
}