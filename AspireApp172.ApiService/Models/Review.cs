namespace AspireApp172.ApiService.Models;

public class Review
{
    public int Id { get; set; }
    public int PetSitterId { get; set; }
    public int BookingId { get; set; }
    public required string ReviewerName { get; set; }
    public int Rating { get; set; } // 1-5 stars
    public required string Comment { get; set; }
    public DateTime CreatedAt { get; set; }
}
