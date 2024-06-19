using Mandry.Interfaces.Validation;
using Mandry.Models.DTOs;

namespace Mandry.ApiResponses.Authentication
{
    public class LoginUserUsingEmailAndPasswordResponse
    {
        public bool IsSuccess { get; set; }
        public bool IsValidationFailed { get; set; }
        public bool IsAccountNotExisted { get; set; }
        public IEnumerable<ValidationErrors> ValidationErrorGroups { get; set; } = new List<ValidationErrors>();
        public string Token { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public UserDataDTO? UserData { get; set; }
    }
}
