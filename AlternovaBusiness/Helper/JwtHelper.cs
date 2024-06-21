using AlternovaBusiness.interfaces;
using AlternovaData.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AlternovaBusiness.Helper
{
    public class JwtHelper : IJwtHelper
    {
        private readonly IConfiguration _configuration; 

        public JwtHelper(IConfiguration configuration)
        {
            // Assign injected configuration to local _configuration
            _configuration = configuration; 
        }

        // Method to generate JWT token for a given user
        public string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler(); 
            var jwtSecret = _configuration["JwtConfig:Secret"];
            // Convert secret key to byte array
            var key = Encoding.ASCII.GetBytes(jwtSecret); 

            // JWT token descriptor containing claims, expiration, and signing credentials
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] 
                {
                    new Claim("id", user.Id.ToString()), 
                    new Claim(ClaimTypes.Email, user.Email), 
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7), 
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature) 
            };
            // Create JWT token
            var token = tokenHandler.CreateToken(tokenDescriptor); 
            // Write JWT token as a string
            return tokenHandler.WriteToken(token); 
        }
    }
}
