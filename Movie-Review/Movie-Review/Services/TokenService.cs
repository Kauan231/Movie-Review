using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Movie_Review.Models;

namespace Movie_Review.Services
{
    public class TokenService
    {
        private IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(User User)
        {
            Claim[] claims = new Claim[]
            {
                new Claim("username", User.UserName),
                new Claim("id", User.Id),
                new Claim("loginTimestamp", DateTime.UtcNow.ToString())
            };
            
            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value)); 

            var signingCredentials =
                new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);


            var token = new JwtSecurityToken
                (
                expires: DateTime.Now.AddMinutes(10),
                claims: claims,
                signingCredentials: signingCredentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}