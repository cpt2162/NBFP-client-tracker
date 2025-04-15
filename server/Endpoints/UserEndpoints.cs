using Microsoft.EntityFrameworkCore;
using server.Models;
using server.Services;

namespace server.Endpoints;

public static class UserEndpoints
{
    public static void MapUserEndpoints(this WebApplication app)
    {
        app.MapGet("/users", async (NBFPDbContext db) =>
        {
            var users = await db.User.ToListAsync();
            return users; // Note: This returns encrypted data; decrypt if needed for display
        })
        .WithName("GetUsers");

        app.MapPost("/users", async (NBFPDbContext db, PasswordService passwordService, User user) =>
        {
            if (string.IsNullOrEmpty(user.Password))
                return Results.BadRequest("Password is required.");

            user.Password = passwordService.HashPassword(user.Password);
            db.User.Add(user);
            await db.SaveChangesAsync();
            return Results.Created($"/users/{user.Id}", user);
        })
        .WithName("CreateUser");

        app.MapGet("/users/{id}", async (NBFPDbContext db, EncryptionService encryptionService, int id) =>
        {
            var user = await db.User.FindAsync(id);
            if (user == null)
                return Results.NotFound();

            return Results.Ok(new
            {
                user.Id,
                user.Username           
            });
        })
        .WithName("GetUserById");
    }
}