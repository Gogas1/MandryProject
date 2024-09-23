namespace Mandry.Models.Requests.Housing
{
    public class AddReservationModel
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string HousingId { get; set; } = string.Empty;        
        public string UserId { get; set; } = string.Empty;
    }
}
