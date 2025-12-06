namespace AspireApp172.ApiService.Models;

public class Pet
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Type { get; set; } // Dog, Cat, Bird, etc.
    public required string Breed { get; set; }
    public int Age { get; set; }
    public string? SpecialNeeds { get; set; }
    public string? ImageUrl { get; set; }
}
