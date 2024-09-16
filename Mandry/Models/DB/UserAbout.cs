namespace Mandry.Models.DB
{
    public class UserAbout
    {
        public Guid Id { get; set; }
        public string Education { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Birthday { get; set; } = string.Empty;
        public string Hobby { get; set; } = string.Empty;
        public string Skills { get; set; } = string.Empty;
        public string TimeThings { get; set; } = string.Empty;
        public string Profession { get; set; } = string.Empty;
        public string Languages { get; set; } = string.Empty;
        public string Song { get; set; } = string.Empty;
        public string Fact { get; set; } = string.Empty;
        public string Biography { get; set; } = string.Empty;
        public string Pets { get; set; } = string.Empty;
        public string AboutMe { get; set; } = string.Empty;

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
