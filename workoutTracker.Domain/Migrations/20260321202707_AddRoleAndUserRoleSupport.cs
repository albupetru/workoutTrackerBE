using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workoutTracker.Domain.Migrations
{
    /// <inheritdoc />
    public partial class AddRoleAndUserRoleSupport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    RoleType = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RoleId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ExerciseTag",
                columns: new[] { "ExerciseId", "TagId" },
                values: new object[,]
                {
                    { new Guid("4a7b067b-549e-4e6a-9d57-5f6735e4f88f"), new Guid("8b3e3f65-ef2f-4646-b4d0-5f3e312bdd5f") },
                    { new Guid("6bdc7a80-8bfa-4b8e-bbe4-0b5597279071"), new Guid("8b3e3f65-ef2f-4646-b4d0-5f3e312bdd50") },
                    { new Guid("6bdc7a80-8bfa-4b8e-bbe4-0b5597279071"), new Guid("8b3e3f65-ef2f-4646-b4d0-5f3e312bdd51") },
                    { new Guid("7c9e6679-7425-40de-944b-e07fc1f90ae7"), new Guid("8b3e3f65-ef2f-4646-b4d0-5f3e312bdd50") },
                    { new Guid("7c9e6679-7425-40de-944b-e07fc1f90ae7"), new Guid("8b3e3f65-ef2f-4646-b4d0-5f3e312bdd51") }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name", "RoleType" },
                values: new object[,]
                {
                    { new Guid("10000000-0000-0000-0000-000000000001"), "Trial User", 0 },
                    { new Guid("10000000-0000-0000-0000-000000000002"), "User", 1 },
                    { new Guid("10000000-0000-0000-0000-000000000003"), "Content Moderator", 2 },
                    { new Guid("10000000-0000-0000-0000-000000000004"), "Administrator", 3 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5b3e3f65-ef2f-4646-b4d0-5f3e312bdd5e"),
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 3, 21, 22, 27, 6, 819, DateTimeKind.Unspecified).AddTicks(8015), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 3, 21, 22, 27, 6, 819, DateTimeKind.Unspecified).AddTicks(8015), new TimeSpan(0, 2, 0, 0, 0)) });

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DeleteData(
                table: "ExerciseTag",
                keyColumns: new[] { "ExerciseId", "TagId" },
                keyValues: new object[] { new Guid("4a7b067b-549e-4e6a-9d57-5f6735e4f88f"), new Guid("8b3e3f65-ef2f-4646-b4d0-5f3e312bdd5f") });

            migrationBuilder.DeleteData(
                table: "ExerciseTag",
                keyColumns: new[] { "ExerciseId", "TagId" },
                keyValues: new object[] { new Guid("6bdc7a80-8bfa-4b8e-bbe4-0b5597279071"), new Guid("8b3e3f65-ef2f-4646-b4d0-5f3e312bdd50") });

            migrationBuilder.DeleteData(
                table: "ExerciseTag",
                keyColumns: new[] { "ExerciseId", "TagId" },
                keyValues: new object[] { new Guid("6bdc7a80-8bfa-4b8e-bbe4-0b5597279071"), new Guid("8b3e3f65-ef2f-4646-b4d0-5f3e312bdd51") });

            migrationBuilder.DeleteData(
                table: "ExerciseTag",
                keyColumns: new[] { "ExerciseId", "TagId" },
                keyValues: new object[] { new Guid("7c9e6679-7425-40de-944b-e07fc1f90ae7"), new Guid("8b3e3f65-ef2f-4646-b4d0-5f3e312bdd50") });

            migrationBuilder.DeleteData(
                table: "ExerciseTag",
                keyColumns: new[] { "ExerciseId", "TagId" },
                keyValues: new object[] { new Guid("7c9e6679-7425-40de-944b-e07fc1f90ae7"), new Guid("8b3e3f65-ef2f-4646-b4d0-5f3e312bdd51") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5b3e3f65-ef2f-4646-b4d0-5f3e312bdd5e"),
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 2, 16, 16, 43, 28, 578, DateTimeKind.Unspecified).AddTicks(233), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 2, 16, 16, 43, 28, 578, DateTimeKind.Unspecified).AddTicks(233), new TimeSpan(0, 2, 0, 0, 0)) });
        }
    }
}
