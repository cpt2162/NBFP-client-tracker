using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class Encryption : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RecipientFirst",
                table: "Household",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RecipientLast",
                table: "Household",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Household",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EligibilityAttestationDate", "LastUpdated", "RecipientFirst", "RecipientLast" },
                values: new object[] { new DateTime(2025, 4, 7, 9, 43, 1, 979, DateTimeKind.Utc).AddTicks(7519), new DateTime(2025, 4, 7, 9, 43, 1, 979, DateTimeKind.Utc).AddTicks(7670), "Dayquan", "Jones" });

            migrationBuilder.UpdateData(
                table: "Household",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EligibilityAttestationDate", "LastUpdated", "RecipientFirst", "RecipientLast" },
                values: new object[] { new DateTime(2025, 4, 12, 9, 43, 1, 979, DateTimeKind.Utc).AddTicks(7790), new DateTime(2025, 4, 12, 9, 43, 1, 979, DateTimeKind.Utc).AddTicks(7791), "Daniel", "Abrams" });

            migrationBuilder.UpdateData(
                table: "HouseholdVisit",
                keyColumn: "Id",
                keyValue: 1,
                column: "VisitDate",
                value: new DateTime(2025, 4, 12, 9, 43, 1, 979, DateTimeKind.Utc).AddTicks(9289));

            migrationBuilder.UpdateData(
                table: "HouseholdVisit",
                keyColumn: "Id",
                keyValue: 2,
                column: "VisitDate",
                value: new DateTime(2025, 4, 15, 9, 43, 1, 979, DateTimeKind.Utc).AddTicks(9409));

            migrationBuilder.CreateIndex(
                name: "IX_HouseholdVisit_HouseholdId",
                table: "HouseholdVisit",
                column: "HouseholdId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseholdMember_HouseholdId",
                table: "HouseholdMember",
                column: "HouseholdId");

            migrationBuilder.AddForeignKey(
                name: "FK_HouseholdMember_Household_HouseholdId",
                table: "HouseholdMember",
                column: "HouseholdId",
                principalTable: "Household",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HouseholdVisit_Household_HouseholdId",
                table: "HouseholdVisit",
                column: "HouseholdId",
                principalTable: "Household",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HouseholdMember_Household_HouseholdId",
                table: "HouseholdMember");

            migrationBuilder.DropForeignKey(
                name: "FK_HouseholdVisit_Household_HouseholdId",
                table: "HouseholdVisit");

            migrationBuilder.DropIndex(
                name: "IX_HouseholdVisit_HouseholdId",
                table: "HouseholdVisit");

            migrationBuilder.DropIndex(
                name: "IX_HouseholdMember_HouseholdId",
                table: "HouseholdMember");

            migrationBuilder.DropColumn(
                name: "RecipientFirst",
                table: "Household");

            migrationBuilder.DropColumn(
                name: "RecipientLast",
                table: "Household");

            migrationBuilder.UpdateData(
                table: "Household",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EligibilityAttestationDate", "LastUpdated" },
                values: new object[] { new DateTime(2025, 3, 24, 19, 49, 23, 12, DateTimeKind.Utc).AddTicks(6887), new DateTime(2025, 3, 24, 19, 49, 23, 12, DateTimeKind.Utc).AddTicks(7037) });

            migrationBuilder.UpdateData(
                table: "Household",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EligibilityAttestationDate", "LastUpdated" },
                values: new object[] { new DateTime(2025, 3, 29, 19, 49, 23, 12, DateTimeKind.Utc).AddTicks(7152), new DateTime(2025, 3, 29, 19, 49, 23, 12, DateTimeKind.Utc).AddTicks(7153) });

            migrationBuilder.UpdateData(
                table: "HouseholdVisit",
                keyColumn: "Id",
                keyValue: 1,
                column: "VisitDate",
                value: new DateTime(2025, 3, 29, 19, 49, 23, 12, DateTimeKind.Utc).AddTicks(8674));

            migrationBuilder.UpdateData(
                table: "HouseholdVisit",
                keyColumn: "Id",
                keyValue: 2,
                column: "VisitDate",
                value: new DateTime(2025, 4, 1, 19, 49, 23, 12, DateTimeKind.Utc).AddTicks(8792));
        }
    }
}
