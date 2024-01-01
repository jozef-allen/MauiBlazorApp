# MAUI Blazor Hybrid App with API Integration for Secure Login Flow

## Project Overview

This is a MAUI Blazor Hybrid app that integrates with a custom API to handle user registration, login and token-based authentication. I plan to use this registration and login UI to build out a full app in the future. The repo for API it uses is here: https://github.com/jozef-allen/database_api.

## Goals

- To build a MAUI Blazor Hybrid app
- To integrate the three elements successfull (DB, API, app)
- To understand a complete login and authentication process in .NET

## Technologies Used

- MAUI Blazor
- .NET 6
- MySQL
- Pomelo.EntityFrameworkCore.MySql
- JWT for token-based authentication
- HttpClient for API communication

## Useful resources

- [.NET MAUI Blazor app + API series](https://www.youtube.com/watch?v=paPe68vT2Mg&list=PLn-SpzWnVxDeSS5EHIsmQwU7iv_pU49K8&index=1)
- [Connecting to local web services from Android emulators](https://www.youtube.com/watch?v=kvNhLKuAySA)
- [JWT encoder and key generator](https://dinochiesa.github.io/jwt/)
- [Salting and Hashing Passwords](https://www.youtube.com/watch?v=qgpsIBLvrGY)

## Process

### Starting point

I used some tutorials from [@GitHubUsername](https://github.com/mistrypragnesh40/) to form the basis of this system. However, my eventual system diverged from these guides in a few ways:
- I used MySQL instead of SQLite
- I used Pomelo instead of EntityFrameworkCore for migrations
- I added error handling that weren't present in the guides

### MySQL

I set up a MySQL database to hold the user account information, as my eventual goal with the app is to use a centralised database rather than a SQLite database that would be local to the app.

### API

I set up a basic CRUD API that could handle some user registration functions without authentication and to test the connection from the API to the database.

### App and Android emulator

I then linked up the app to the process so that information from the database could be represented in the app, via the API. This helped me to iron out any kinks in general. It took a while to address issues with communication between the Android emulator and the API. With the help of this video (https://www.youtube.com/watch?v=kvNhLKuAySA) and the Microsoft article it mentions (https://learn.microsoft.com/en-us/dotnet/maui/data-cloud/local-web-services?view=net-maui-8.0), adjustments were made to use the second localhost port for the API (HTTP instead of HTTPS). This would not be ideal in a live environment but is OK during development. The app was then configured to target '10.0.2.2' instead of 'localhost' for Android emulator access. I also configured cross-origin resource sharing (CORS) in the API so that it could be contactable from the app.

### Login flow

Now that things were up-and-running, I implemented the registration and login system in the API and app code, and migrated this across to the database (code-first approach).

I created a JWT key and implemented access and refresh tokens. Currently the project is set to create access tokens that last for 5 seconds so that the refresh functionality can easily be checked. This can easily be changed in RegistrationController.cs in the API. Upon receiving tokens, the app stores them in SecureStorage and they can be retrieved from there every time the app root page is visited.

## Wins & challenges

### Wins

- I learnt about the hashing and salting of passwords to provide two layers of security when stored in the database, and saw this in action.
- I implemented access and refresh tokens.
- I built a successful MAUI Blazor hybrid app that functions as intended with API and database.

### Challenges 

- A time-consuming obstacle was figuring out how to get the Android emulator working instead of running the app in Windows Machine.
- It also took a while to get Pomelo.EntityFrameworkCore.MySql working instead of MySql.Data.EntityFrameworkCore as the tutorial recommended - this was because I was using a different database type.
- Implementing error handling - for instance, for if the API is uncontactable - meant using a custom class that diverged from the tutorial. This then impacted all methods and took a while to implement.

## Going forward

I intend to use this as a foundation for future app projects and am confident I know this system well now.