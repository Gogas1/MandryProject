﻿using Mandry.Models.DB;

namespace Mandry.Interfaces.Services
{
    public interface IAuthenticationService
    {
        string GetJwtFor(User user);
        bool VerifyPassword(User user, string password);
        Task<GoogleUserInfo?> VerifyGoogleAccessToken(string token);
    }

    public class GoogleUserInfo
    {
        public string AccessToken { get; set; } = string.Empty;
        public string Id { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool VerifiedEmail { get; set; } = false;
        public string Name { get; set; } = string.Empty;
        public string GivenName { get; set; } = string.Empty;
        public string FamilyName { get; set; } = string.Empty;
        public string Picture { get; set; } = string.Empty;
    }
}
