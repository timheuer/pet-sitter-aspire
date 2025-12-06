# PetStay - Pet-Sitting Web Application

## Overview
PetStay is a comprehensive pet-sitting web application similar to Airbnb, built with .NET Aspire, Blazor Server, and ASP.NET Core Web API.

## Features

### For Pet Owners
- **Browse Pet Sitters**: Search and filter pet sitters by location, pet type, and amenities
- **View Detailed Profiles**: See ratings, reviews, amenities, and pricing
- **Book Pet Care**: Submit booking requests with custom dates and special requests
- **Manage Bookings**: Track booking status (Pending, Confirmed, Cancelled, Completed)
- **Leave Reviews**: Rate and review pet sitters after completed stays

### For Pet Sitters
- **Create Profile**: Register as a pet sitter with detailed information
- **Set Pricing**: Define your own rates and availability
- **Receive Bookings**: Get booking requests from pet owners
- **Build Reputation**: Earn ratings and reviews from satisfied customers

## Technology Stack

### Frontend (AspireApp172.Web)
- **Blazor Server** with Interactive Server rendering
- **Bootstrap 5** with Bootstrap Icons
- Responsive design with custom styling

### Backend (AspireApp172.ApiService)
- **ASP.NET Core Minimal APIs**
- In-memory data storage with `AppDbContext`
- RESTful API endpoints for:
  - Pet Sitters
  - Bookings
  - Reviews
  - Pets

### Infrastructure
- **.NET Aspire** for orchestration and service discovery
- Service defaults for health checks and telemetry

## Project Structure

```
AspireApp172/
??? AspireApp172.AppHost/          # Aspire orchestration
??? AspireApp172.ServiceDefaults/  # Shared service configuration
??? AspireApp172.ApiService/       # Backend API
?   ??? Models/                    # Domain models
?   ??? Data/                      # Data context
?   ??? Program.cs                 # API endpoints
??? AspireApp172.Web/              # Frontend Blazor app
    ??? Components/
    ?   ??? Pages/                 # Razor pages
    ?   ??? Layout/                # Layout components
    ??? Services/                  # API clients
    ??? Models/                    # Shared models
```

## API Endpoints

### Pet Sitters
- `GET /api/petsitters` - Get all pet sitters
- `GET /api/petsitters/{id}` - Get pet sitter by ID
- `POST /api/petsitters` - Create new pet sitter
- `PUT /api/petsitters/{id}` - Update pet sitter
- `DELETE /api/petsitters/{id}` - Delete pet sitter

### Bookings
- `GET /api/bookings` - Get all bookings
- `GET /api/bookings/{id}` - Get booking by ID
- `GET /api/petsitters/{petSitterId}/bookings` - Get bookings for a pet sitter
- `POST /api/bookings` - Create new booking
- `PUT /api/bookings/{id}` - Update booking

### Reviews
- `GET /api/reviews` - Get all reviews
- `GET /api/petsitters/{petSitterId}/reviews` - Get reviews for a pet sitter
- `POST /api/reviews` - Create new review

### Pets
- `GET /api/pets` - Get all pets
- `GET /api/pets/{id}` - Get pet by ID
- `POST /api/pets` - Create new pet

## Sample Data

The application comes pre-seeded with:
- 6 diverse pet sitters across different cities
- Sample reviews with ratings
- Example pet profiles

## Running the Application

1. Open the solution in Visual Studio 2022 or later
2. Set `AspireApp172.AppHost` as the startup project
3. Press F5 to run

The Aspire dashboard will open, showing:
- **Web App** - The Blazor frontend
- **API Service** - The backend API

## Key Pages

- **Home** (`/`) - Landing page with app overview
- **Find Pet Sitters** (`/petsitters`) - Browse and search pet sitters
- **Pet Sitter Detail** (`/petsitters/{id}`) - View details and book
- **My Bookings** (`/mybookings`) - Manage your bookings and leave reviews
- **Become a Sitter** (`/becomesitter`) - Register as a pet sitter

## Future Enhancements

- User authentication and authorization
- Real-time messaging between owners and sitters
- Payment integration
- Photo uploads for pets and sitters
- Advanced search with maps integration
- Email notifications
- Persistent database (SQL Server, PostgreSQL)
- Mobile app with .NET MAUI

## License

This is a sample application for demonstration purposes.
