using Mandry.Models.DTOs;

namespace Mandry.ApiResponses.Account
{
    public class GetUserDataResponse
    {
        public bool UserDoesNoExist { get; set; }
        public UserDataDTO? UserData { get; set; }
    }
}
