namespace CinemaAPI.Dtos
{
    public class AddTicketDto
    {
        public DateOnly PurchaseDate { get; set; }
        public int MovieId { get; set; }
        public int ViewerId { get; set; }
    }
}