using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MyApp.Application.Interfaces.Service;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure.Services
{
    public class JWTAuthServices : IAuthServices
    {
        private readonly IConfiguration _configuration;

        public JWTAuthServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task<string> GenerateToken(Users users)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, users.UserId.ToString()),
                new Claim(ClaimTypes.Email, users.Email),
                new Claim(ClaimTypes.Role, users.Role.Name)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken();
        }
    }
}
