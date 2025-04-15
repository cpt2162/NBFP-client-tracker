using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Microsoft.EntityFrameworkCore.Diagnostics;
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

app.MapGet("/households", async (NBFPDbContext db) =>
{
    var households = await db.Household.ToListAsync();
    return households;
})
.WithName("GetHouseholds");

app.MapUserEndpoints();

app.Urls.Add("http://0.0.0.0:80");
app.Run();
