using AspireApp172.ApiService.Data;
using AspireApp172.ApiService.Models;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();

// Register data context
builder.Services.AddSingleton<AppDbContext>();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Add CORS for development
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

app.UseCors();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Pet Sitter Endpoints
app.MapGet("/api/petsitters", (AppDbContext db) =>
{
    return Results.Ok(db.GetAllPetSitters());
})
.WithName("GetAllPetSitters")
.WithTags("PetSitters");

app.MapGet("/api/petsitters/{id}", (int id, AppDbContext db) =>
{
    var sitter = db.GetPetSitterById(id);
    return sitter is not null ? Results.Ok(sitter) : Results.NotFound();
})
.WithName("GetPetSitterById")
.WithTags("PetSitters");

app.MapPost("/api/petsitters", (PetSitter petSitter, AppDbContext db) =>
{
    var created = db.AddPetSitter(petSitter);
    return Results.Created($"/api/petsitters/{created.Id}", created);
})
.WithName("CreatePetSitter")
.WithTags("PetSitters");

app.MapPut("/api/petsitters/{id}", (int id, PetSitter petSitter, AppDbContext db) =>
{
    petSitter.Id = id;
    var updated = db.UpdatePetSitter(petSitter);
    return updated ? Results.Ok(petSitter) : Results.NotFound();
})
.WithName("UpdatePetSitter")
.WithTags("PetSitters");

app.MapDelete("/api/petsitters/{id}", (int id, AppDbContext db) =>
{
    var deleted = db.DeletePetSitter(id);
    return deleted ? Results.NoContent() : Results.NotFound();
})
.WithName("DeletePetSitter")
.WithTags("PetSitters");

// Booking Endpoints
app.MapGet("/api/bookings", (AppDbContext db) =>
{
    return Results.Ok(db.GetAllBookings());
})
.WithName("GetAllBookings")
.WithTags("Bookings");

app.MapGet("/api/bookings/{id}", (int id, AppDbContext db) =>
{
    var booking = db.GetBookingById(id);
    return booking is not null ? Results.Ok(booking) : Results.NotFound();
})
.WithName("GetBookingById")
.WithTags("Bookings");

app.MapGet("/api/petsitters/{petSitterId}/bookings", (int petSitterId, AppDbContext db) =>
{
    return Results.Ok(db.GetBookingsByPetSitter(petSitterId));
})
.WithName("GetBookingsByPetSitter")
.WithTags("Bookings");

app.MapPost("/api/bookings", (Booking booking, AppDbContext db) =>
{
    var created = db.AddBooking(booking);
    return Results.Created($"/api/bookings/{created.Id}", created);
})
.WithName("CreateBooking")
.WithTags("Bookings");

app.MapPut("/api/bookings/{id}", (int id, Booking booking, AppDbContext db) =>
{
    booking.Id = id;
    var updated = db.UpdateBooking(booking);
    return updated ? Results.Ok(booking) : Results.NotFound();
})
.WithName("UpdateBooking")
.WithTags("Bookings");

// Review Endpoints
app.MapGet("/api/reviews", (AppDbContext db) =>
{
    return Results.Ok(db.GetAllReviews());
})
.WithName("GetAllReviews")
.WithTags("Reviews");

app.MapGet("/api/petsitters/{petSitterId}/reviews", (int petSitterId, AppDbContext db) =>
{
    return Results.Ok(db.GetReviewsByPetSitter(petSitterId));
})
.WithName("GetReviewsByPetSitter")
.WithTags("Reviews");

app.MapPost("/api/reviews", (Review review, AppDbContext db) =>
{
    var created = db.AddReview(review);
    return Results.Created($"/api/reviews/{created.Id}", created);
})
.WithName("CreateReview")
.WithTags("Reviews");

// Pet Endpoints
app.MapGet("/api/pets", (AppDbContext db) =>
{
    return Results.Ok(db.GetAllPets());
})
.WithName("GetAllPets")
.WithTags("Pets");

app.MapGet("/api/pets/{id}", (int id, AppDbContext db) =>
{
    var pet = db.GetPetById(id);
    return pet is not null ? Results.Ok(pet) : Results.NotFound();
})
.WithName("GetPetById")
.WithTags("Pets");

app.MapPost("/api/pets", (Pet pet, AppDbContext db) =>
{
    var created = db.AddPet(pet);
    return Results.Created($"/api/pets/{created.Id}", created);
})
.WithName("CreatePet")
.WithTags("Pets");

app.MapDefaultEndpoints();

app.Run();
