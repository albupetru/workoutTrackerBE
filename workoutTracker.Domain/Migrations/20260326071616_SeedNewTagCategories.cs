using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workoutTracker.Domain.Migrations
{
    /// <inheritdoc />
    public partial class SeedNewTagCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: new Guid("4a7b067b-549e-4e6a-9d57-5f6735e4f88f"),
                columns: new[] { "CreatedOn", "ModifiedOn", "VerifiedOn" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 3, 26, 9, 16, 16, 429, DateTimeKind.Unspecified).AddTicks(197), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 3, 26, 9, 16, 16, 429, DateTimeKind.Unspecified).AddTicks(197), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 3, 26, 9, 16, 16, 429, DateTimeKind.Unspecified).AddTicks(197), new TimeSpan(0, 2, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: new Guid("6bdc7a80-8bfa-4b8e-bbe4-0b5597279071"),
                columns: new[] { "CreatedOn", "ModifiedOn", "VerifiedOn" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 3, 26, 9, 16, 16, 429, DateTimeKind.Unspecified).AddTicks(197), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 3, 26, 9, 16, 16, 429, DateTimeKind.Unspecified).AddTicks(197), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 3, 26, 9, 16, 16, 429, DateTimeKind.Unspecified).AddTicks(197), new TimeSpan(0, 2, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: new Guid("7c9e6679-7425-40de-944b-e07fc1f90ae7"),
                columns: new[] { "CreatedOn", "ModifiedOn", "VerifiedOn" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 3, 26, 9, 16, 16, 429, DateTimeKind.Unspecified).AddTicks(197), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 3, 26, 9, 16, 16, 429, DateTimeKind.Unspecified).AddTicks(197), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 3, 26, 9, 16, 16, 429, DateTimeKind.Unspecified).AddTicks(197), new TimeSpan(0, 2, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "Id", "Name", "TagType" },
                values: new object[,]
                {
                    { new Guid("055e3f65-ef2f-4646-b4d0-5f3e312bdd60"), "Isolation", 5 },
                    { new Guid("0b3e3f65-ef2f-4646-b4d0-5f3e312bdd5f"), "Compound", 5 },
                    { new Guid("333e3f65-ef2f-4646-b4d0-5f3e312bdd5e"), "Bodybuilding", 7 },
                    { new Guid("378504e0-4f89-11d3-9a0c-0305e82c3319"), "Horizontal Pull", 11 },
                    { new Guid("3f2504e0-4f89-11d3-9a0c-0305e82c3312"), "Hip Hinge", 11 },
                    { new Guid("3f2504e0-4f89-11d3-9a0c-0305e82c3322"), "Vertical Pull", 11 },
                    { new Guid("3f2504e0-4f89-11d3-9a0c-0305e82c3324"), "Horizontal Push", 11 },
                    { new Guid("3f2504e0-4f89-11d3-9a0c-0305e82c3326"), "Vertical Push", 11 },
                    { new Guid("3f2504e0-4f89-11d3-9a0c-0305e82c3327"), "Squat Pattern", 11 },
                    { new Guid("3f2504e0-4f89-11d3-9a0c-0305e82c3330"), "Lunge Pattern", 11 },
                    { new Guid("3f2504e0-4f89-11d3-9a0c-0305e82c3331"), "Carry", 11 },
                    { new Guid("3f2504e0-4f89-11d3-9a0c-0305e82c3332"), "Rotation", 11 },
                    { new Guid("4f2504e0-4f89-11d3-9a0c-0305e82c3301"), "Barbell", 4 },
                    { new Guid("4f2504e0-4f89-11d3-9a0c-0305e82c3302"), "Cable Machine", 4 },
                    { new Guid("4f2504e0-4f89-11d3-9a0c-0305e82c3303"), "Dumbbell", 4 },
                    { new Guid("4f2504e0-4f89-11d3-9a0c-0305e82c3304"), "Kettlebell", 4 },
                    { new Guid("4f2504e0-4f89-11d3-9a0c-0305e82c3305"), "Machine", 4 },
                    { new Guid("4f2504e0-4f89-11d3-9a0c-0305e82c3307"), "Smith Machine", 4 },
                    { new Guid("4f2504e0-4f89-11d3-9a0c-0305e82c3308"), "Bodyweight", 4 },
                    { new Guid("4f2504e0-4f89-11d3-9a0c-0305e82c3309"), "Resistance Band", 4 },
                    { new Guid("4f2504e0-4f89-11d3-9a0c-0305e82c3310"), "EZ Bar", 4 },
                    { new Guid("4f2504e0-4f89-11d3-9a0c-0305e82c3311"), "Trap Bar", 4 },
                    { new Guid("5f2504e0-4f89-11d3-9a0c-0305e82c3301"), "Unilateral", 6 },
                    { new Guid("5f2504e0-4f89-11d3-9a0c-0305e82c3302"), "Bilateral", 6 },
                    { new Guid("666e3f65-ef2f-4646-b4d0-5f3e312bdd5f"), "CrossFit", 7 },
                    { new Guid("6b3e3f65-ef2f-4646-b4d0-5f3e312bdd60"), "Powerlifting", 7 },
                    { new Guid("6b3e3f65-ef2f-4646-b4d0-5f3e312bdd61"), "Strongman", 7 },
                    { new Guid("6b3e3f65-ef2f-4646-b4d0-5f3e312bdd62"), "Olympic Weightlifting", 7 },
                    { new Guid("6b3e3f65-ef2f-4646-b4d0-5f3e312bdd63"), "Endurance", 7 },
                    { new Guid("6b3e3f65-ef2f-4646-b4d0-5f3e312bdd64"), "Calisthenics", 7 },
                    { new Guid("6f2504e0-4f89-11d3-9a0c-0305e82c3301"), "Push", 8 },
                    { new Guid("6f2504e0-4f89-11d3-9a0c-0305e82c3302"), "Pull", 8 },
                    { new Guid("6f2504e0-4f89-11d3-9a0c-0305e82c3303"), "Legs", 8 },
                    { new Guid("6f2504e0-4f89-11d3-9a0c-0305e82c3304"), "Upper", 8 },
                    { new Guid("6f2504e0-4f89-11d3-9a0c-0305e82c3305"), "Lower", 8 },
                    { new Guid("6f2504e0-4f89-11d3-9a0c-0305e82c3306"), "Full Body", 8 },
                    { new Guid("7f2504e0-4f89-11d3-9a0c-0305e82c3301"), "Low Back Friendly", 9 },
                    { new Guid("7f2504e0-4f89-11d3-9a0c-0305e82c3302"), "Knee Friendly", 9 },
                    { new Guid("7f2504e0-4f89-11d3-9a0c-0305e82c3303"), "Shoulder Friendly", 9 },
                    { new Guid("7f2504e0-4f89-11d3-9a0c-0305e82c3304"), "Wrist Friendly", 9 },
                    { new Guid("8f2504e0-4f89-11d3-9a0c-0305e82c3301"), "Strength", 10 },
                    { new Guid("8f2504e0-4f89-11d3-9a0c-0305e82c3302"), "Stretching", 10 },
                    { new Guid("8f2504e0-4f89-11d3-9a0c-0305e82c3303"), "Cardio", 10 },
                    { new Guid("8f2504e0-4f89-11d3-9a0c-0305e82c3304"), "Mobility", 10 },
                    { new Guid("8f2504e0-4f89-11d3-9a0c-0305e82c3305"), "Warmup", 10 },
                    { new Guid("8f2504e0-4f89-11d3-9a0c-0305e82c3306"), "Cooldown", 10 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5b3e3f65-ef2f-4646-b4d0-5f3e312bdd5e"),
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 3, 26, 9, 16, 16, 433, DateTimeKind.Unspecified).AddTicks(6450), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 3, 26, 9, 16, 16, 433, DateTimeKind.Unspecified).AddTicks(6450), new TimeSpan(0, 2, 0, 0, 0)) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("055e3f65-ef2f-4646-b4d0-5f3e312bdd60"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("0b3e3f65-ef2f-4646-b4d0-5f3e312bdd5f"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("333e3f65-ef2f-4646-b4d0-5f3e312bdd5e"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("378504e0-4f89-11d3-9a0c-0305e82c3319"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("3f2504e0-4f89-11d3-9a0c-0305e82c3312"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("3f2504e0-4f89-11d3-9a0c-0305e82c3322"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("3f2504e0-4f89-11d3-9a0c-0305e82c3324"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("3f2504e0-4f89-11d3-9a0c-0305e82c3326"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("3f2504e0-4f89-11d3-9a0c-0305e82c3327"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("3f2504e0-4f89-11d3-9a0c-0305e82c3330"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("3f2504e0-4f89-11d3-9a0c-0305e82c3331"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("3f2504e0-4f89-11d3-9a0c-0305e82c3332"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("4f2504e0-4f89-11d3-9a0c-0305e82c3301"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("4f2504e0-4f89-11d3-9a0c-0305e82c3302"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("4f2504e0-4f89-11d3-9a0c-0305e82c3303"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("4f2504e0-4f89-11d3-9a0c-0305e82c3304"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("4f2504e0-4f89-11d3-9a0c-0305e82c3305"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("4f2504e0-4f89-11d3-9a0c-0305e82c3307"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("4f2504e0-4f89-11d3-9a0c-0305e82c3308"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("4f2504e0-4f89-11d3-9a0c-0305e82c3309"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("4f2504e0-4f89-11d3-9a0c-0305e82c3310"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("4f2504e0-4f89-11d3-9a0c-0305e82c3311"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("5f2504e0-4f89-11d3-9a0c-0305e82c3301"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("5f2504e0-4f89-11d3-9a0c-0305e82c3302"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("666e3f65-ef2f-4646-b4d0-5f3e312bdd5f"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("6b3e3f65-ef2f-4646-b4d0-5f3e312bdd60"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("6b3e3f65-ef2f-4646-b4d0-5f3e312bdd61"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("6b3e3f65-ef2f-4646-b4d0-5f3e312bdd62"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("6b3e3f65-ef2f-4646-b4d0-5f3e312bdd63"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("6b3e3f65-ef2f-4646-b4d0-5f3e312bdd64"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("6f2504e0-4f89-11d3-9a0c-0305e82c3301"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("6f2504e0-4f89-11d3-9a0c-0305e82c3302"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("6f2504e0-4f89-11d3-9a0c-0305e82c3303"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("6f2504e0-4f89-11d3-9a0c-0305e82c3304"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("6f2504e0-4f89-11d3-9a0c-0305e82c3305"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("6f2504e0-4f89-11d3-9a0c-0305e82c3306"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("7f2504e0-4f89-11d3-9a0c-0305e82c3301"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("7f2504e0-4f89-11d3-9a0c-0305e82c3302"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("7f2504e0-4f89-11d3-9a0c-0305e82c3303"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("7f2504e0-4f89-11d3-9a0c-0305e82c3304"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("8f2504e0-4f89-11d3-9a0c-0305e82c3301"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("8f2504e0-4f89-11d3-9a0c-0305e82c3302"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("8f2504e0-4f89-11d3-9a0c-0305e82c3303"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("8f2504e0-4f89-11d3-9a0c-0305e82c3304"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("8f2504e0-4f89-11d3-9a0c-0305e82c3305"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("8f2504e0-4f89-11d3-9a0c-0305e82c3306"));

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: new Guid("4a7b067b-549e-4e6a-9d57-5f6735e4f88f"),
                columns: new[] { "CreatedOn", "ModifiedOn", "VerifiedOn" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 3, 25, 19, 52, 15, 993, DateTimeKind.Unspecified).AddTicks(4313), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 3, 25, 19, 52, 15, 993, DateTimeKind.Unspecified).AddTicks(4313), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 3, 25, 19, 52, 15, 993, DateTimeKind.Unspecified).AddTicks(4313), new TimeSpan(0, 2, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: new Guid("6bdc7a80-8bfa-4b8e-bbe4-0b5597279071"),
                columns: new[] { "CreatedOn", "ModifiedOn", "VerifiedOn" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 3, 25, 19, 52, 15, 993, DateTimeKind.Unspecified).AddTicks(4313), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 3, 25, 19, 52, 15, 993, DateTimeKind.Unspecified).AddTicks(4313), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 3, 25, 19, 52, 15, 993, DateTimeKind.Unspecified).AddTicks(4313), new TimeSpan(0, 2, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: new Guid("7c9e6679-7425-40de-944b-e07fc1f90ae7"),
                columns: new[] { "CreatedOn", "ModifiedOn", "VerifiedOn" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 3, 25, 19, 52, 15, 993, DateTimeKind.Unspecified).AddTicks(4313), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 3, 25, 19, 52, 15, 993, DateTimeKind.Unspecified).AddTicks(4313), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 3, 25, 19, 52, 15, 993, DateTimeKind.Unspecified).AddTicks(4313), new TimeSpan(0, 2, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5b3e3f65-ef2f-4646-b4d0-5f3e312bdd5e"),
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 3, 25, 19, 52, 15, 998, DateTimeKind.Unspecified).AddTicks(1315), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 3, 25, 19, 52, 15, 998, DateTimeKind.Unspecified).AddTicks(1315), new TimeSpan(0, 2, 0, 0, 0)) });
        }
    }
}
