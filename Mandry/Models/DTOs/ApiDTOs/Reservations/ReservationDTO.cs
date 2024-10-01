namespace Mandry.Models.DTOs.ApiDTOs.Reservations
{
    public class ReservationDTO
    {
        public Guid Id { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public string Code { get; set; } = string.Empty;
        public decimal FullPrice { get; set; }

        public HousingDTO Housing { get; set; }
    }

    public class HousingDTO
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }
}
