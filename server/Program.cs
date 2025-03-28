using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using server.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddOpenApi();
builder.Services.AddDbContext<NBFPDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<NBFPDbContext>();
    int retries = 5;
    while (retries > 0)
    {
        try
        {
            Console.WriteLine("Attempting to apply migrations...");
            db.Database.Migrate();
            Console.WriteLine("Migrations applied successfully.");
            break;
        }
        catch (Npgsql.NpgsqlException ex)
        {
            retries--;
            Console.WriteLine($"Database migration failed: {ex.Message}. Retrying...");
            if (retries == 0) throw;
            Thread.Sleep(2000);
        }
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();


app.MapGet("/users", async (NBFPDbContext db) =>
{
    var users = await db.Users.ToListAsync();
    return users;
})
.WithName("GetUsers");

app.MapPost("/users", async (NBFPDbContext db, User user) =>
{
    db.Users.Add(user);
    await db.SaveChangesAsync();
    return Results.Created($"/users/{user.Id}", user);
})
.WithName("CreateUser");

app.MapGet("/households", async (NBFPDbContext db) =>
{
    var households = await db.Households.ToListAsync();
    return households;
})
.WithName("GetHouseholds");

app.Run();
