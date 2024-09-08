namespace Mandry.Models.Requests.Reviews
{
    public class AddReviewModel
    {
        public string ToHousingId { get; set; }
        public string ToUserId { get; set; }
        public float Rating { get; set; }
        public string Text { get; set; }
    }
}
