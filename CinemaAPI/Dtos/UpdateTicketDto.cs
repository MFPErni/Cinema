namespace CinemaAPI.Dtos
{
    public class UpdateTicketDto
    {
        public int Id { get; set; }
        public DateOnly PurchaseDate { get; set; }
        public int MovieId { get; set; }
        public int ViewerId { get; set; }
    }
}