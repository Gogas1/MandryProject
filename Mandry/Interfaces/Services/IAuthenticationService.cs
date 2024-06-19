using Mandry.Models.DB;

namespace Mandry.Interfaces.Services
{
    public interface IAuthenticationService
    {
        string GetJwtFor(User user);
        bool VerifyPassword(User user, string password);
    }

}
