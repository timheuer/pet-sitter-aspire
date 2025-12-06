using AspireApp172.ApiService.Models;
using System.Net.Http.Json;

namespace AspireApp172.Web.Services;

public class PetSitterApiClient(HttpClient httpClient)
{
    // Pet Sitters
    public async Task<List<PetSitter>?> GetPetSittersAsync(CancellationToken cancellationToken = default)
    {
        return await httpClient.GetFromJsonAsync<List<PetSitter>>("/api/petsitters", cancellationToken);
    }

    public async Task<PetSitter?> GetPetSitterByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await httpClient.GetFromJsonAsync<PetSitter>($"/api/petsitters/{id}", cancellationToken);
    }

    public async Task<PetSitter?> CreatePetSitterAsync(PetSitter petSitter, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.PostAsJsonAsync("/api/petsitters", petSitter, cancellationToken);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<PetSitter>(cancellationToken);
    }

    public async Task<bool> UpdatePetSitterAsync(int id, PetSitter petSitter, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.PutAsJsonAsync($"/api/petsitters/{id}", petSitter, cancellationToken);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeletePetSitterAsync(int id, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.DeleteAsync($"/api/petsitters/{id}", cancellationToken);
        return response.IsSuccessStatusCode;
    }

    // Bookings
    public async Task<List<Booking>?> GetBookingsAsync(CancellationToken cancellationToken = default)
    {
        return await httpClient.GetFromJsonAsync<List<Booking>>("/api/bookings", cancellationToken);
    }

    public async Task<Booking?> GetBookingByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await httpClient.GetFromJsonAsync<Booking>($"/api/bookings/{id}", cancellationToken);
    }

    public async Task<List<Booking>?> GetBookingsByPetSitterAsync(int petSitterId, CancellationToken cancellationToken = default)
    {
        return await httpClient.GetFromJsonAsync<List<Booking>>($"/api/petsitters/{petSitterId}/bookings", cancellationToken);
    }

    public async Task<Booking?> CreateBookingAsync(Booking booking, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.PostAsJsonAsync("/api/bookings", booking, cancellationToken);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Booking>(cancellationToken);
    }

    public async Task<bool> UpdateBookingAsync(int id, Booking booking, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.PutAsJsonAsync($"/api/bookings/{id}", booking, cancellationToken);
        return response.IsSuccessStatusCode;
    }

    // Reviews
    public async Task<List<Review>?> GetReviewsAsync(CancellationToken cancellationToken = default)
    {
        return await httpClient.GetFromJsonAsync<List<Review>>("/api/reviews", cancellationToken);
    }

    public async Task<List<Review>?> GetReviewsByPetSitterAsync(int petSitterId, CancellationToken cancellationToken = default)
    {
        return await httpClient.GetFromJsonAsync<List<Review>>($"/api/petsitters/{petSitterId}/reviews", cancellationToken);
    }

    public async Task<Review?> CreateReviewAsync(Review review, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.PostAsJsonAsync("/api/reviews", review, cancellationToken);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Review>(cancellationToken);
    }

    // Pets
    public async Task<List<Pet>?> GetPetsAsync(CancellationToken cancellationToken = default)
    {
        return await httpClient.GetFromJsonAsync<List<Pet>>("/api/pets", cancellationToken);
    }

    public async Task<Pet?> GetPetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await httpClient.GetFromJsonAsync<Pet>($"/api/pets/{id}", cancellationToken);
    }

    public async Task<Pet?> CreatePetAsync(Pet pet, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.PostAsJsonAsync("/api/pets", pet, cancellationToken);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Pet>(cancellationToken);
    }
}
