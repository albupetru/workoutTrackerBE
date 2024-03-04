using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workoutTracker.Domain.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    GoogleId = table.Column<string>(type: "TEXT", nullable: false),
                    DeletedById = table.Column<Guid>(type: "TEXT", nullable: true),
                    CreatedById = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "TEXT", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
                    DeletedOn = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    ModifiedById = table.Column<Guid>(type: "TEXT", nullable: false),
                    ModifiedOn = table.Column<DateTimeOffset>(type: "TEXT", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Exercise",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("4a7b067b-549e-4e6a-9d57-5f6735e4f88f"), "Bench Press" },
                    { new Guid("6bdc7a80-8bfa-4b8e-bbe4-0b5597279071"), "Squat" },
                    { new Guid("7c9e6679-7425-40de-944b-e07fc1f90ae7"), "Deadlift" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedById", "CreatedOn", "DeletedById", "DeletedOn", "Email", "GoogleId", "ModifiedById", "ModifiedOn", "Name" },
                values: new object[] { new Guid("5b3e3f65-ef2f-4646-b4d0-5f3e312bdd5e"), new Guid("5b3e3f65-ef2f-4646-b4d0-5f3e312bdd5e"), new DateTimeOffset(new DateTime(2024, 3, 4, 16, 8, 41, 46, DateTimeKind.Unspecified).AddTicks(6787), new TimeSpan(0, 2, 0, 0, 0)), null, null, "", "", new Guid("5b3e3f65-ef2f-4646-b4d0-5f3e312bdd5e"), new DateTimeOffset(new DateTime(2024, 3, 4, 16, 8, 41, 46, DateTimeKind.Unspecified).AddTicks(6787), new TimeSpan(0, 2, 0, 0, 0)), "Automatic Process" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exercise");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
