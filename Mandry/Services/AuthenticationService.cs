using Mandry.Interfaces.Services;
using Mandry.Models.DB;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Web;

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

        public async Task<GoogleUserInfo?> VerifyGoogleAccessToken(string token)
        {
            var config = _config.GetSection("Google");
            var clientId = config["ClientId"];

            UriBuilder verificationUriBuilder = new UriBuilder
            {
                Scheme = "https",
                Host = "www.googleapis.com",
                Path = "oauth2/v2/userinfo",
            };
            var verificationQuery = HttpUtility.ParseQueryString(string.Empty);
            verificationQuery["access_token"] = token;
            verificationUriBuilder.Query = verificationQuery.ToString();

            string verificationUri = verificationUriBuilder.ToString();

            using var client = new HttpClient();

            var verificationResponse = await client.GetAsync(verificationUri);

            if(verificationResponse.IsSuccessStatusCode)
            {
                var json = await verificationResponse.Content.ReadAsStringAsync();
                var userInfo = JsonSerializer.Deserialize<GoogleUserInfo>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true, PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower });                

                return userInfo;
            }

            return null;
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
