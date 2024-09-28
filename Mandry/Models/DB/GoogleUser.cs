namespace Mandry.Models.DB
{
    public class GoogleUser
    {
        public string Id { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool VerifiedEmail { get; set; } = false;
        public string Name { get; set; } = string.Empty;
        public string GivenName { get; set; } = string.Empty;
        public string FamilyName { get; set; } = string.Empty;
        public string Picture { get; set; } = string.Empty;

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
