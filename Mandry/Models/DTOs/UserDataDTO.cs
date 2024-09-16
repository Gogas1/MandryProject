using Mandry.Models.DTOs.ApiDTOs;
using Mandry.Models.DTOs.User;

namespace Mandry.Models.DTOs
{
    public class UserDataDTO
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public float AverageRating { get; set; }
        public int ReviewsCount { get; set; }
        public DateTime OwnerFrom { get; set; }
        public ImageDTO? Avatar { get; set; }
        public UserAboutDTO? UserAbout { get; set; }
    }
}
