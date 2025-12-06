namespace AspireApp172.ApiService.Models;

public class Booking
{
    public int Id { get; set; }
    public int PetSitterId { get; set; }
    public required string PetOwnerName { get; set; }
    public required string PetOwnerEmail { get; set; }
    public required string PetOwnerPhone { get; set; }
    public List<int> PetIds { get; set; } = [];
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public decimal TotalPrice { get; set; }
    public BookingStatus Status { get; set; }
    public string? SpecialRequests { get; set; }
    public DateTime CreatedAt { get; set; }
}

public enum BookingStatus
{
    Pending,
    Confirmed,
    Cancelled,
    Completed
}
