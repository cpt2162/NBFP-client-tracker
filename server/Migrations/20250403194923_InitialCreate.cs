using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Household",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Members = table.Column<int>(type: "integer", nullable: false),
                    Infants = table.Column<int>(type: "integer", nullable: false),
                    Toddlers = table.Column<int>(type: "integer", nullable: false),
                    Children = table.Column<int>(type: "integer", nullable: false),
                    Adults = table.Column<int>(type: "integer", nullable: false),
                    Seniors = table.Column<int>(type: "integer", nullable: false),
                    EligibilityType = table.Column<string>(type: "text", nullable: false),
                    EligibilityAttestationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Others_Authorized = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Household", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HouseholdMember",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HouseholdId = table.Column<int>(type: "integer", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseholdMember", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HouseholdVisit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HouseholdId = table.Column<int>(type: "integer", nullable: false),
                    VisitDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    StaffName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseholdVisit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Household",
                columns: new[] { "Id", "Address", "Adults", "Children", "EligibilityAttestationDate", "EligibilityType", "Infants", "LastUpdated", "Members", "Others_Authorized", "Seniors", "Toddlers" },
                values: new object[,]
                {
                    { 1, "123 Main St, Buffalo, NY, 14203", 1, 2, new DateTime(2025, 3, 24, 19, 49, 23, 12, DateTimeKind.Utc).AddTicks(6887), "Categorical", 1, new DateTime(2025, 3, 24, 19, 49, 23, 12, DateTimeKind.Utc).AddTicks(7037), 5, null, 0, 1 },
                    { 2, "456 Elm St, Buffalo, NY, 14203", 2, 1, new DateTime(2025, 3, 29, 19, 49, 23, 12, DateTimeKind.Utc).AddTicks(7152), "Income", 0, new DateTime(2025, 3, 29, 19, 49, 23, 12, DateTimeKind.Utc).AddTicks(7153), 3, null, 0, 0 }
                });

            migrationBuilder.InsertData(
                table: "HouseholdMember",
                columns: new[] { "Id", "Age", "FirstName", "HouseholdId", "LastName" },
                values: new object[,]
                {
                    { 1, 0, "John", 1, "Doe" },
                    { 2, 0, "Jane", 1, "Doe" },
                    { 3, 0, "Alice", 1, "Doe" },
                    { 4, 0, "Bob", 1, "Doe" },
                    { 5, 0, "Al", 1, "Doe" },
                    { 6, 0, "Alice", 2, "Smith" },
                    { 7, 0, "Bob", 2, "Smith" },
                    { 8, 0, "Charlie", 2, "Smith" }
                });

            migrationBuilder.InsertData(
                table: "HouseholdVisit",
                columns: new[] { "Id", "HouseholdId", "StaffName", "VisitDate" },
                values: new object[,]
                {
                    { 1, 1, "Cameron Turner", new DateTime(2025, 3, 29, 19, 49, 23, 12, DateTimeKind.Utc).AddTicks(8674) },
                    { 2, 2, "Cameron Turner", new DateTime(2025, 4, 1, 19, 49, 23, 12, DateTimeKind.Utc).AddTicks(8792) }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Password", "Username" },
                values: new object[] { 1, "nbfpfeedsmore", "nbfpAdmin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Household");

            migrationBuilder.DropTable(
                name: "HouseholdMember");

            migrationBuilder.DropTable(
                name: "HouseholdVisit");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
