namespace Mandry.Models.Requests.Account
{
    public class SignUpGoogleModel
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public string Accesstoken { get; set; } = string.Empty;
    }
}
