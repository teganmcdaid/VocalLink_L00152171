# VocalLink

VocalLink is a booking system for singers and business owners. Singers manage their availability and bookings, while business owners can find and book singers for events. 
This app is built using **.NET MAUI** and was tested and used on windows.

## Features
- Role-based UI for business owners and singers
- User registration and login
- Booking system (accept/decline bookings)
- Availability calendar for singers
- Email notifications with **SendGrid**

## Technologies Used
- **.NET MAUI**: Cross-platform mobile app framework
- **SQLite**: Local database for storing user and booking data
- **SendGrid**: Email service for notifications
- **xUnit**: Unit testing framework

## Setup

### Prerequisites
1. **.NET SDK**: Install from [here](https://dotnet.microsoft.com/download).
2. **Visual Studio 2022**: Install with **.NET MAUI** support.
3. **SendGrid Account**: Sign up at [SendGrid](https://sendgrid.com/) for the API key.

### Installation
1. Clone the respoitory.
2. Restore the dependecies/NuGet packages.
3. Apply **SendGrid** API Key in developer settings once application is running.

## Acknowledgements
- **SendGrid** for providing the email notification services. [SendGrid Documentation](https://sendgrid.com/docs)
- **.NET MAUI** for enabling cross-platform mobile development. [Learn more about .NET MAUI](https://docs.microsoft.com/en-us/dotnet/maui/what-is-maui)
