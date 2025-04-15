using Microsoft.EntityFrameworkCore;
using server.Models;
using server.Services;

namespace server.Endpoints;

public static class HouseholdEndpoints
{
    public static void MapHouseholdEndpoints(this WebApplication app)
    {
        app.MapGet("/households", async (NBFPDbContext db) =>
        {
            var households = await db.Household.ToListAsync();
            return households;
        })
        .WithName("GetHouseholds");

        app.MapPost("/households", async (NBFPDbContext db, EncryptionService encryptionService, Household household) =>
        {
            household.Address = encryptionService.Encrypt(household.Address);
            household.RecipientFirst = encryptionService.Encrypt(household.RecipientFirst);
            household.RecipientLast = encryptionService.Encrypt(household.RecipientLast);
            household.EligibilityType = encryptionService.Encrypt(household.EligibilityType);
            household.LastUpdated = DateTime.Now;
            household.EligibilityAttestationDate = DateTime.Now;
            household.LastUpdated = DateTime.Now;
            db.Household.Add(household);
            await db.SaveChangesAsync();
            return Results.Created($"/households/{household.Id}", household);
        })
        .WithName("CreateHousehold");

        app.MapGet("/households/{id}", async (NBFPDbContext db, EncryptionService encryptionService, int id) =>
        {
            var household = await db.Household.FindAsync(id);
            if (household == null) {
                return Results.NotFound();
            }

            return Results.Ok(new
            {
                household.Id,
                RecipientFirst = encryptionService.Decrypt(household.RecipientFirst),
                RecipientLast = encryptionService.Decrypt(household.RecipientLast),
                Address = encryptionService.Decrypt(household.Address),
                household.Members,
                household.Infants,
                household.Toddlers,
                household.Children,
                household.Adults,
                household.Seniors,
                EligibilityType = encryptionService.Decrypt(household.EligibilityType),
                household.EligibilityAttestationDate,
                household.LastUpdated
            });
        })
        .WithName("GetHouseholdById");

        app.MapPut("/households/{id}", async (NBFPDbContext db, EncryptionService encryptionService, int id, Household updatedHousehold) =>
        {
            var household = await db.Household.FindAsync(id);
            if (household == null)
                return Results.NotFound();

            household.RecipientFirst = encryptionService.Encrypt(updatedHousehold.RecipientFirst);
            household.RecipientLast = encryptionService.Encrypt(updatedHousehold.RecipientLast);
            household.Address = encryptionService.Encrypt(updatedHousehold.Address);
            household.Members = updatedHousehold.Members;
            household.Infants = updatedHousehold.Infants;
            household.Toddlers = updatedHousehold.Toddlers;
            household.Children = updatedHousehold.Children;
            household.Adults = updatedHousehold.Adults;
            household.Seniors = updatedHousehold.Seniors;
            household.EligibilityType = encryptionService.Encrypt(updatedHousehold.EligibilityType);
            household.EligibilityAttestationDate = updatedHousehold.EligibilityAttestationDate;
            household.LastUpdated = DateTime.Now;

            await db.SaveChangesAsync();
            return Results.NoContent();
        })
        .WithName("UpdateHousehold");

        app.MapDelete("/households/{id}", async (NBFPDbContext db, int id) =>
        {
            var household = await db.Household.FindAsync(id);
            if (household == null)
                return Results.NotFound();

            db.Household.Remove(household);
            await db.SaveChangesAsync();
            return Results.NoContent();
        })
        .WithName("DeleteHousehold");
    }
}