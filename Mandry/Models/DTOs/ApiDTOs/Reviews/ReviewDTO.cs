namespace Mandry.Models.DTOs.ApiDTOs.Reviews
{
    public class ReviewDTO
    {
        public UserDataDTO Creator { get; set; }
        public float Rating { get; set; }
        public string Text { get; set; } = string.Empty;
    }
}
