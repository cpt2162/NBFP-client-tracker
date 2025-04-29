using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
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
            foreach (var user in users)
            {
                user.Password = string.Empty;
            }
            return users;
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
        .WithName("GetUserById")
        .RequireAuthorization();

        app.MapPost("/login", async (NBFPDbContext db, PasswordService passwordService, IConfiguration config, User login) =>
        {
            var user = await db.User.FirstOrDefaultAsync(u => u.Username == login.Username);
            if (user == null)
                return Results.NotFound("User not found.");

            Console.WriteLine($"Login attempt: Username = {login.Username}, Password = {login.Password}");
            Console.WriteLine(user.Password);

            if (!passwordService.VerifyPassword(login.Password, user.Password))
                return Results.Unauthorized();

            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(config["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[]
                {
                    new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Name, user.Username)
                }),
                Expires = DateTime.UtcNow.AddHours(int.Parse(config["Jwt:ExpireHours"])),
                Issuer = config["Jwt:Issuer"],
                Audience = config["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Results.Ok(new { Token = tokenString, UserId = user.Id, Username = user.Username });
        }).WithName("Login");

    }
}