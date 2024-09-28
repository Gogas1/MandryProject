using Mandry.Interfaces.Services;

namespace Mandry.ApiResponses.Authentication
{
    public class VerifyGoogleTokenResponse
    {
        public string AccessToken { get; set; } = string.Empty;
        public GoogleUserInfo UserInfo { get; set; }
    }
}
