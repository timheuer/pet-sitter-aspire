namespace AspireApp172.ApiService.Models;

public class PetSitter
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Location { get; set; }
    public required string Bio { get; set; }
    public decimal PricePerNight { get; set; }
    public List<string> PetTypesAccepted { get; set; } = [];
    public int MaxPets { get; set; }
    public bool HasYard { get; set; }
    public bool AcceptsLargeDogs { get; set; }
    public string? ImageUrl { get; set; }
    public double Rating { get; set; }
    public int ReviewCount { get; set; }
    public List<string> Amenities { get; set; } = [];
    public required string Email { get; set; }
    public required string Phone { get; set; }
}
