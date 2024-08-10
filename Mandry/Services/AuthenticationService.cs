using Mandry.Interfaces.Services;
using Mandry.Models.DB;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Mandry.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IConfiguration _config;

        public AuthenticationService(IConfiguration config)
        {
            _config = config;
        }

        public string GetJwtFor(User user)
        {
            var config = _config.GetSection("Jwt");
            var claims = new List<Claim> { new Claim(JwtRegisteredClaimNames.Name, user.Name), new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()) };

            var jwt = new JwtSecurityToken(
                issuer: config["Issuer"] ?? throw new Exception("Issuer in not specified"),
                audience: config["Audience"] ?? throw new Exception("Issuer is not specified"),
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(int.Parse(config["ExpiresMinuts"] ?? throw new Exception("Expiration time is not specified")))),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(config["JWTKey"] ?? throw new Exception("JWT key is not specified"))),
                    SecurityAlgorithms.HmacSha256)
                );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        public bool VerifyPassword(User user, string password)
        {
            PasswordHasher<User> hasher = new PasswordHasher<User>();
            var verificationResult = hasher.VerifyHashedPassword(user, user.PasswordHash, password);
            if (verificationResult == PasswordVerificationResult.Failed)
            {
                return false;
            }

            return true;
        }
    }
}
