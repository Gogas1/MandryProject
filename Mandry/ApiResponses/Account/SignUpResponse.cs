using Mandry.Interfaces.Validation;
using Mandry.Models.DTOs;

namespace Mandry.ApiResponses.Account
{
    public class SignUpResponse
    {
        public bool Success { get; set; }
        public bool IsValidationFailed { get; set; }
        public bool IsAccountExisting { get; set; }
        public ICollection<ValidationErrors> ValidationErrorsGrous { get; set; } = new List<ValidationErrors>();
        public string Token { get; set; } = string.Empty;
        public SignUpObfuscatedUserData? ObfuscatedUserData { get; set; }
        public UserDataDTO? UserData { get; set; }
    }

    public class SignUpObfuscatedUserData
    {
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
