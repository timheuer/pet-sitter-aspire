using AspireApp172.ApiService.Models;

namespace AspireApp172.ApiService.Data;

public class AppDbContext
{
    private static readonly List<PetSitter> _petSitters = [];
    private static readonly List<Booking> _bookings = [];
    private static readonly List<Review> _reviews = [];
    private static readonly List<Pet> _pets = [];
    private static int _nextPetSitterId = 1;
    private static int _nextBookingId = 1;
    private static int _nextReviewId = 1;
    private static int _nextPetId = 1;
    private static bool _isSeeded = false;

    public AppDbContext()
    {
        if (!_isSeeded)
        {
            SeedData();
            _isSeeded = true;
        }
    }

    // Pet Sitters
    public IEnumerable<PetSitter> GetAllPetSitters() => _petSitters;
    
    public PetSitter? GetPetSitterById(int id) => _petSitters.FirstOrDefault(ps => ps.Id == id);
    
    public PetSitter AddPetSitter(PetSitter petSitter)
    {
        petSitter.Id = _nextPetSitterId++;
        _petSitters.Add(petSitter);
        return petSitter;
    }

    public bool UpdatePetSitter(PetSitter petSitter)
    {
        var existing = GetPetSitterById(petSitter.Id);
        if (existing == null) return false;
        
        _petSitters.Remove(existing);
        _petSitters.Add(petSitter);
        return true;
    }

    public bool DeletePetSitter(int id)
    {
        var petSitter = GetPetSitterById(id);
        if (petSitter == null) return false;
        
        _petSitters.Remove(petSitter);
        return true;
    }

    // Bookings
    public IEnumerable<Booking> GetAllBookings() => _bookings;
    
    public IEnumerable<Booking> GetBookingsByPetSitter(int petSitterId) => 
        _bookings.Where(b => b.PetSitterId == petSitterId);
    
    public Booking? GetBookingById(int id) => _bookings.FirstOrDefault(b => b.Id == id);
    
    public Booking AddBooking(Booking booking)
    {
        booking.Id = _nextBookingId++;
        booking.CreatedAt = DateTime.UtcNow;
        _bookings.Add(booking);
        return booking;
    }

    public bool UpdateBooking(Booking booking)
    {
        var existing = GetBookingById(booking.Id);
        if (existing == null) return false;
        
        _bookings.Remove(existing);
        _bookings.Add(booking);
        return true;
    }

    // Reviews
    public IEnumerable<Review> GetAllReviews() => _reviews;
    
    public IEnumerable<Review> GetReviewsByPetSitter(int petSitterId) => 
        _reviews.Where(r => r.PetSitterId == petSitterId);
    
    public Review AddReview(Review review)
    {
        review.Id = _nextReviewId++;
        review.CreatedAt = DateTime.UtcNow;
        _reviews.Add(review);
        
        // Update sitter rating
        var sitter = GetPetSitterById(review.PetSitterId);
        if (sitter != null)
        {
            var sitterReviews = GetReviewsByPetSitter(review.PetSitterId).ToList();
            sitter.Rating = sitterReviews.Average(r => r.Rating);
            sitter.ReviewCount = sitterReviews.Count;
        }
        
        return review;
    }

    // Pets
    public IEnumerable<Pet> GetAllPets() => _pets;
    
    public Pet? GetPetById(int id) => _pets.FirstOrDefault(p => p.Id == id);
    
    public Pet AddPet(Pet pet)
    {
        pet.Id = _nextPetId++;
        _pets.Add(pet);
        return pet;
    }

    private void SeedData()
    {
        // Seed Pet Sitters
        var sitters = new List<PetSitter>
        {
            new()
            {
                Id = _nextPetSitterId++,
                Name = "Sarah Johnson",
                Location = "Seattle, WA",
                Bio = "Experienced pet lover with 5+ years of caring for dogs and cats. I have a large backyard and live near a dog park!",
                PricePerNight = 45.00m,
                PetTypesAccepted = ["Dog", "Cat"],
                MaxPets = 3,
                HasYard = true,
                AcceptsLargeDogs = true,
                ImageUrl = "https://randomuser.me/api/portraits/women/44.jpg",
                Rating = 4.8,
                ReviewCount = 24,
                Amenities = ["Large Yard", "Dog Park Nearby", "24/7 Supervision", "Pet First Aid Certified"],
                Email = "sarah.johnson@email.com",
                Phone = "(206) 555-0123"
            },
            new()
            {
                Id = _nextPetSitterId++,
                Name = "Mike Chen",
                Location = "Portland, OR",
                Bio = "Veterinary technician offering professional pet care. Specialized in senior pets and those with special medical needs.",
                PricePerNight = 65.00m,
                PetTypesAccepted = ["Dog", "Cat", "Bird"],
                MaxPets = 2,
                HasYard = false,
                AcceptsLargeDogs = false,
                ImageUrl = "https://randomuser.me/api/portraits/men/32.jpg",
                Rating = 4.9,
                ReviewCount = 42,
                Amenities = ["Medical Care", "Medication Administration", "Daily Updates", "Indoor Play Area"],
                Email = "mike.chen@email.com",
                Phone = "(503) 555-0456"
            },
            new()
            {
                Id = _nextPetSitterId++,
                Name = "Emily Rodriguez",
                Location = "San Francisco, CA",
                Bio = "Dog trainer and enthusiast! I love active dogs and provide daily exercise, training sessions, and lots of playtime.",
                PricePerNight = 55.00m,
                PetTypesAccepted = ["Dog"],
                MaxPets = 4,
                HasYard = true,
                AcceptsLargeDogs = true,
                ImageUrl = "https://randomuser.me/api/portraits/women/68.jpg",
                Rating = 5.0,
                ReviewCount = 31,
                Amenities = ["Dog Training", "Daily Walks", "Large Yard", "Beach Access", "Photo Updates"],
                Email = "emily.rodriguez@email.com",
                Phone = "(415) 555-0789"
            },
            new()
            {
                Id = _nextPetSitterId++,
                Name = "David Wilson",
                Location = "Austin, TX",
                Bio = "Retired firefighter with lots of time to spoil your furry friends. Calm, patient, and experienced with all breeds.",
                PricePerNight = 40.00m,
                PetTypesAccepted = ["Dog", "Cat"],
                MaxPets = 2,
                HasYard = true,
                AcceptsLargeDogs = true,
                ImageUrl = "https://randomuser.me/api/portraits/men/52.jpg",
                Rating = 4.7,
                ReviewCount = 18,
                Amenities = ["Quiet Home", "Large Yard", "Flexible Schedule", "Pet CPR Certified"],
                Email = "david.wilson@email.com",
                Phone = "(512) 555-0234"
            },
            new()
            {
                Id = _nextPetSitterId++,
                Name = "Jessica Taylor",
                Location = "Denver, CO",
                Bio = "Cat whisperer! I specialize in caring for cats and have a dedicated cat room with climbing trees and toys.",
                PricePerNight = 35.00m,
                PetTypesAccepted = ["Cat", "Bird", "Small Animals"],
                MaxPets = 5,
                HasYard = false,
                AcceptsLargeDogs = false,
                ImageUrl = "https://randomuser.me/api/portraits/women/26.jpg",
                Rating = 4.9,
                ReviewCount = 37,
                Amenities = ["Cat-Friendly Home", "Multiple Litter Boxes", "Climbing Trees", "Video Check-ins"],
                Email = "jessica.taylor@email.com",
                Phone = "(720) 555-0567"
            },
            new()
            {
                Id = _nextPetSitterId++,
                Name = "Robert Martinez",
                Location = "Boston, MA",
                Bio = "Family home with kids who love animals! Great for social dogs who enjoy company and playtime.",
                PricePerNight = 50.00m,
                PetTypesAccepted = ["Dog"],
                MaxPets = 3,
                HasYard = true,
                AcceptsLargeDogs = true,
                ImageUrl = "https://randomuser.me/api/portraits/men/75.jpg",
                Rating = 4.6,
                ReviewCount = 15,
                Amenities = ["Family Environment", "Kids", "Fenced Yard", "Park Nearby"],
                Email = "robert.martinez@email.com",
                Phone = "(617) 555-0890"
            }
        };
        
        _petSitters.AddRange(sitters);

        // Seed some sample reviews
        var reviews = new List<Review>
        {
            new()
            {
                Id = _nextReviewId++,
                PetSitterId = 1,
                BookingId = 1,
                ReviewerName = "John Doe",
                Rating = 5,
                Comment = "Sarah was amazing! My dog had a wonderful time and came home tired and happy.",
                CreatedAt = DateTime.UtcNow.AddDays(-30)
            },
            new()
            {
                Id = _nextReviewId++,
                PetSitterId = 2,
                BookingId = 2,
                ReviewerName = "Jane Smith",
                Rating = 5,
                Comment = "Mike took excellent care of my senior cat. He sent daily updates and handled her medication perfectly.",
                CreatedAt = DateTime.UtcNow.AddDays(-20)
            },
            new()
            {
                Id = _nextReviewId++,
                PetSitterId = 3,
                BookingId = 3,
                ReviewerName = "Tom Brown",
                Rating = 5,
                Comment = "Emily is a true professional! My dog learned new tricks and had the best time ever.",
                CreatedAt = DateTime.UtcNow.AddDays(-15)
            }
        };
        
        _reviews.AddRange(reviews);

        // Seed sample pets
        var pets = new List<Pet>
        {
            new()
            {
                Id = _nextPetId++,
                Name = "Max",
                Type = "Dog",
                Breed = "Golden Retriever",
                Age = 3,
                ImageUrl = "https://images.unsplash.com/photo-1633722715463-d30f4f325e24?w=400"
            },
            new()
            {
                Id = _nextPetId++,
                Name = "Luna",
                Type = "Cat",
                Breed = "Siamese",
                Age = 2,
                ImageUrl = "https://images.unsplash.com/photo-1513360371669-4adf3dd7dff8?w=400"
            }
        };
        
        _pets.AddRange(pets);
    }
}
