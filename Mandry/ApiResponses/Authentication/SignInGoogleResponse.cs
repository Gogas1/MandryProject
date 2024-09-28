using Mandry.Interfaces.Services;
using Mandry.Models.DTOs;

namespace Mandry.ApiResponses.Authentication
{
    public class SignInGoogleResponse
    {
        public bool IsAccountExisting { get; set; }
        public string Token { get; set; } = string.Empty;
        public UserDataDTO? UserData { get; set; }
        public GoogleUserInfo UserInfo { get; set; }
    }
}
