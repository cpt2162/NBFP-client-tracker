using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using System.Text;
using server.Models;
using server.Endpoints;
using server.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddDbContext<NBFPDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
        .ConfigureWarnings(w => w.Log(RelationalEventId.PendingModelChangesWarning)));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<PasswordService>();
builder.Services.AddScoped<EncryptionService>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"]
    };
});

builder.Services.AddAuthorization();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<NBFPDbContext>();
    int retries = 5;
    while (retries > 0)
    {
        try
        {
            Console.WriteLine("Checking database connection...");
            db.Database.CanConnect();
            Console.WriteLine("Database connection successful.");
            Console.WriteLine("Attempting to apply migrations...");
            db.Database.Migrate();
            Console.WriteLine("Migrations applied successfully.");
            break;
        }
        catch (Exception ex)
        {
            retries--;
            Console.WriteLine($"Operation failed: {ex.Message}");
            if (retries == 0) {
                Console.WriteLine("All retry attempts exhausted.");
                throw;
            }
            Console.WriteLine($"Retrying in 2 seconds... ({retries} attempts left)");
            Thread.Sleep(2000);
        }
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// app.UseHttpsRedirection();

app.MapGet("/test", () => "Hello World!")
    .WithName("Test");

    // Temporary endpoint to hash password
app.MapGet("/hash-password", (PasswordService passwordService) =>
{
    string password = "nbfpfeedsmore";
    string hashedPassword = passwordService.HashPassword(password);
    return Results.Ok(new { HashedPassword = hashedPassword });
}).WithName("HashPassword");

app.UseAuthentication();
app.UseAuthorization();

app.MapUserEndpoints();
app.MapHouseholdEndpoints();

app.Urls.Add("http://0.0.0.0:80");
app.Run();
