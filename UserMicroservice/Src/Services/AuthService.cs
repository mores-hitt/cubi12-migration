using System.Security.Claims;
using user_microservice.Src.Exceptions;
using user_microservice.Src.Repositories.Interfaces;
using user_microservice.Src.Services.Interfaces;
using DotNetEnv;
using Grpc.Core;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace user_microservice.Src.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly IMapperService _mapperService;
        private readonly string _jwtSecret;

        public AuthService(IUnitOfWork unitOfWork,
        IConfiguration configuration,
        IMapperService mapperService
        )
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _mapperService = mapperService;
            _jwtSecret = Env.GetString("JWT_SECRET") ?? throw new InvalidJwtException("JWT_SECRET not found");
        }

        public string CreateToken(string email, string role)
        {
            var claims = new List<Claim>{
                new (ClaimTypes.Email, email),
                new (ClaimTypes.Role, role),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSecret));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(60),
                signingCredentials: creds
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        public string GetUserEmailInToken(ServerCallContext callContext)
        {
            var httpUser = GetHttpUser(callContext);

            //Get Claims from JWT
            var userEmail = httpUser.FindFirstValue(ClaimTypes.Email) ??
                throw new UnauthorizedAccessException("Invalid user email in token");
            return userEmail;
        }

        public string GetUserRoleInToken(ServerCallContext callContext)
        {
            var httpUser = GetHttpUser(callContext);

            //Get Claims from JWT
            var userRole = httpUser.FindFirstValue(ClaimTypes.Role) ??
                throw new UnauthorizedAccessException("Invalid role in token");
            return userRole;
        }

        #region PRIVATE_METHODS

        private ClaimsPrincipal GetHttpUser(ServerCallContext callContext)
        {
            var httpContext = callContext.GetHttpContext();
                if (!httpContext.User.Identity?.IsAuthenticated ?? false)
                    throw new UnauthorizedAccessException("User not authenticated");
            
            return httpContext.User;
        }

        #endregion

    }
}