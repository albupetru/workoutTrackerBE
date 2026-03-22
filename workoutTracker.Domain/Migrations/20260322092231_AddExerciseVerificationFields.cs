using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace workoutTracker.Domain.Migrations
{
    /// <inheritdoc />
    public partial class AddExerciseVerificationFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "VerifiedById",
                table: "Exercise",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "VerifiedOn",
                table: "Exercise",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: new Guid("4a7b067b-549e-4e6a-9d57-5f6735e4f88f"),
                columns: new[] { "VerifiedById", "VerifiedOn" },
                values: new object[] { new Guid("5b3e3f65-ef2f-4646-b4d0-5f3e312bdd5e"), new DateTimeOffset(new DateTime(2026, 3, 22, 11, 22, 30, 701, DateTimeKind.Unspecified).AddTicks(7439), new TimeSpan(0, 2, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: new Guid("6bdc7a80-8bfa-4b8e-bbe4-0b5597279071"),
                columns: new[] { "VerifiedById", "VerifiedOn" },
                values: new object[] { new Guid("5b3e3f65-ef2f-4646-b4d0-5f3e312bdd5e"), new DateTimeOffset(new DateTime(2026, 3, 22, 11, 22, 30, 701, DateTimeKind.Unspecified).AddTicks(7439), new TimeSpan(0, 2, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: new Guid("7c9e6679-7425-40de-944b-e07fc1f90ae7"),
                columns: new[] { "VerifiedById", "VerifiedOn" },
                values: new object[] { new Guid("5b3e3f65-ef2f-4646-b4d0-5f3e312bdd5e"), new DateTimeOffset(new DateTime(2026, 3, 22, 11, 22, 30, 701, DateTimeKind.Unspecified).AddTicks(7439), new TimeSpan(0, 2, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5b3e3f65-ef2f-4646-b4d0-5f3e312bdd5e"),
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 3, 22, 11, 22, 30, 709, DateTimeKind.Unspecified).AddTicks(6729), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 3, 22, 11, 22, 30, 709, DateTimeKind.Unspecified).AddTicks(6729), new TimeSpan(0, 2, 0, 0, 0)) });

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_VerifiedById",
                table: "Exercise",
                column: "VerifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_VerifiedOn",
                table: "Exercise",
                column: "VerifiedOn");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercise_Users_VerifiedById",
                table: "Exercise",
                column: "VerifiedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_Users_VerifiedById",
                table: "Exercise");

            migrationBuilder.DropIndex(
                name: "IX_Exercise_VerifiedById",
                table: "Exercise");

            migrationBuilder.DropIndex(
                name: "IX_Exercise_VerifiedOn",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "VerifiedById",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "VerifiedOn",
                table: "Exercise");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5b3e3f65-ef2f-4646-b4d0-5f3e312bdd5e"),
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 3, 21, 22, 27, 6, 819, DateTimeKind.Unspecified).AddTicks(8015), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 3, 21, 22, 27, 6, 819, DateTimeKind.Unspecified).AddTicks(8015), new TimeSpan(0, 2, 0, 0, 0)) });
        }
    }
}
