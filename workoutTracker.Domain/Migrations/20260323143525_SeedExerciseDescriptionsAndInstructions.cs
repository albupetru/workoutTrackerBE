using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace workoutTracker.Domain.Migrations
{
    /// <inheritdoc />
    public partial class SeedExerciseDescriptionsAndInstructions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: new Guid("4a7b067b-549e-4e6a-9d57-5f6735e4f88f"),
                columns: new[] { "CreatedOn", "Description", "Instructions", "ModifiedOn", "VerifiedOn" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 3, 23, 16, 35, 25, 126, DateTimeKind.Unspecified).AddTicks(2281), new TimeSpan(0, 2, 0, 0, 0)), "A horizontal pressing movement performed with a deliberate pause at the chest. The pause eliminates the stretch-reflex, forcing the muscles to generate force from a dead stop and building strength at the most challenging point of the lift.", "Set up on the bench with eyes under the bar, retract your shoulder blades and arch your lower back slightly.\nUnrack the bar and position it over your lower chest with locked-out elbows.\nDescend with control, flaring the elbows slightly outward, until the bar touches your chest.\nPause for 1-2 full seconds — the bar must be motionless with no downward bounce.\nDrive the bar back up explosively, pressing your feet into the floor for leg drive.\nRe-rack only after achieving full lockout at the top.", new DateTimeOffset(new DateTime(2026, 3, 23, 16, 35, 25, 126, DateTimeKind.Unspecified).AddTicks(2281), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 3, 23, 16, 35, 25, 126, DateTimeKind.Unspecified).AddTicks(2281), new TimeSpan(0, 2, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: new Guid("6bdc7a80-8bfa-4b8e-bbe4-0b5597279071"),
                columns: new[] { "CreatedOn", "Description", "Instructions", "ModifiedOn", "VerifiedOn" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 3, 23, 16, 35, 25, 126, DateTimeKind.Unspecified).AddTicks(2281), new TimeSpan(0, 2, 0, 0, 0)), "A powerlifting squat variation where the bar rests lower on the rear deltoids rather than the traps. The lower bar position shifts the torso angle forward, recruiting the posterior chain more aggressively and allowing heavier loads to be moved.", "Position the bar across your rear deltoids, not your traps. Grip just outside shoulder width.\nStep back with two controlled steps, feet shoulder-width or slightly wider, toes turned out 15-30 degrees.\nTake a deep breath into your belly, brace your core hard, and push your knees out in the direction of your toes.\nDescend by hinging at the hips simultaneously with bending the knees, maintaining a forward torso lean.\nSquat until hip crease is at or below the top of the knee.\nDrive through the entire foot explosively, keeping the chest up and knees out on the ascent.", new DateTimeOffset(new DateTime(2026, 3, 23, 16, 35, 25, 126, DateTimeKind.Unspecified).AddTicks(2281), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 3, 23, 16, 35, 25, 126, DateTimeKind.Unspecified).AddTicks(2281), new TimeSpan(0, 2, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: new Guid("7c9e6679-7425-40de-944b-e07fc1f90ae7"),
                columns: new[] { "CreatedOn", "Description", "Instructions", "ModifiedOn", "VerifiedOn" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 3, 23, 16, 35, 25, 126, DateTimeKind.Unspecified).AddTicks(2281), new TimeSpan(0, 2, 0, 0, 0)), "The foundational hip-hinge movement for building total-body strength. The conventional stance targets the posterior chain — hamstrings, glutes, and spinal erectors — while also demanding significant upper back and grip strength to keep the bar controlled.", "Stand with feet hip-width apart, bar over mid-foot. Grip the bar just outside your legs, double-overhand or mixed grip.\nHinge at the hips to reach the bar, then drop the hips until your shins touch the bar without letting it roll forward.\nRetract your shoulder blades, lift your chest, and create tension in your lats by 'bending the bar around your legs'.\nTake a big breath, brace hard, then drive your feet into the floor while simultaneously pulling the slack out of the bar.\nKeep the bar in contact with your legs throughout the pull. Lock out by squeezing glutes and driving hips through at the top.\nReturn the bar to the floor with control by hinging at the hips first, then bending the knees once the bar passes them.", new DateTimeOffset(new DateTime(2026, 3, 23, 16, 35, 25, 126, DateTimeKind.Unspecified).AddTicks(2281), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 3, 23, 16, 35, 25, 126, DateTimeKind.Unspecified).AddTicks(2281), new TimeSpan(0, 2, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5b3e3f65-ef2f-4646-b4d0-5f3e312bdd5e"),
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 3, 23, 16, 35, 25, 132, DateTimeKind.Unspecified).AddTicks(399), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 3, 23, 16, 35, 25, 132, DateTimeKind.Unspecified).AddTicks(399), new TimeSpan(0, 2, 0, 0, 0)) });

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_CreatedById",
                table: "Exercise",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercise_Users_CreatedById",
                table: "Exercise",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_Users_CreatedById",
                table: "Exercise");

            migrationBuilder.DropIndex(
                name: "IX_Exercise_CreatedById",
                table: "Exercise");

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: new Guid("4a7b067b-549e-4e6a-9d57-5f6735e4f88f"),
                columns: new[] { "CreatedOn", "Description", "Instructions", "ModifiedOn", "VerifiedOn" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 3, 22, 12, 35, 17, 258, DateTimeKind.Unspecified).AddTicks(474), new TimeSpan(0, 2, 0, 0, 0)), "", "", new DateTimeOffset(new DateTime(2026, 3, 22, 12, 35, 17, 258, DateTimeKind.Unspecified).AddTicks(474), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 3, 22, 12, 35, 17, 258, DateTimeKind.Unspecified).AddTicks(474), new TimeSpan(0, 2, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: new Guid("6bdc7a80-8bfa-4b8e-bbe4-0b5597279071"),
                columns: new[] { "CreatedOn", "Description", "Instructions", "ModifiedOn", "VerifiedOn" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 3, 22, 12, 35, 17, 258, DateTimeKind.Unspecified).AddTicks(474), new TimeSpan(0, 2, 0, 0, 0)), "", "", new DateTimeOffset(new DateTime(2026, 3, 22, 12, 35, 17, 258, DateTimeKind.Unspecified).AddTicks(474), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 3, 22, 12, 35, 17, 258, DateTimeKind.Unspecified).AddTicks(474), new TimeSpan(0, 2, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: new Guid("7c9e6679-7425-40de-944b-e07fc1f90ae7"),
                columns: new[] { "CreatedOn", "Description", "Instructions", "ModifiedOn", "VerifiedOn" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 3, 22, 12, 35, 17, 258, DateTimeKind.Unspecified).AddTicks(474), new TimeSpan(0, 2, 0, 0, 0)), "", "", new DateTimeOffset(new DateTime(2026, 3, 22, 12, 35, 17, 258, DateTimeKind.Unspecified).AddTicks(474), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 3, 22, 12, 35, 17, 258, DateTimeKind.Unspecified).AddTicks(474), new TimeSpan(0, 2, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5b3e3f65-ef2f-4646-b4d0-5f3e312bdd5e"),
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 3, 22, 12, 35, 17, 263, DateTimeKind.Unspecified).AddTicks(1471), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 3, 22, 12, 35, 17, 263, DateTimeKind.Unspecified).AddTicks(1471), new TimeSpan(0, 2, 0, 0, 0)) });
        }
    }
}
