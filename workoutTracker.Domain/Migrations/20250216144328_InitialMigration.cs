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
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Instructions = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "ExerciseTag",
                columns: table => new
                {
                    ExerciseId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TagId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseTag", x => new { x.ExerciseId, x.TagId });
                    table.ForeignKey(
                        name: "FK_ExerciseTag_Exercise_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseTag_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TagChild",
                columns: table => new
                {
                    ParentId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ChildId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagChild", x => new { x.ParentId, x.ChildId });
                    table.ForeignKey(
                        name: "FK_TagChild_Tag_ChildId",
                        column: x => x.ChildId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagChild_Tag_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Exercise",
                columns: new[] { "Id", "Description", "Instructions", "Name" },
                values: new object[,]
                {
                    { new Guid("4a7b067b-549e-4e6a-9d57-5f6735e4f88f"), "", "", "Bench Press (Paused)" },
                    { new Guid("6bdc7a80-8bfa-4b8e-bbe4-0b5597279071"), "", "", "Low Bar Squat" },
                    { new Guid("7c9e6679-7425-40de-944b-e07fc1f90ae7"), "", "", "Conventional Deadlift" }
                });

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("25553f65-ef2f-4646-b4d0-5f3e312bdd5e"), "Calves" },
                    { new Guid("2b3e3f65-ef2f-4646-b4d0-5f3e312bdd5f"), "Chest" },
                    { new Guid("2b3e3f65-ef2f-4646-b4d0-5f3e312bdd60"), "Forearms" },
                    { new Guid("2b3e3f65-ef2f-4646-b4d0-5f3e312bdd61"), "Lower Back" },
                    { new Guid("2b3e3f65-ef2f-4646-b4d0-5f3e312bdd63"), "Shoulders" },
                    { new Guid("2b3e3f65-ef2f-4646-b4d0-5f3e312bdd64"), "Thighs" },
                    { new Guid("2b3e3f65-ef2f-4646-b4d0-5f3e312bdd65"), "Upper Arms" },
                    { new Guid("2b3e3f65-ef2f-4646-b4d0-5f3e312bdd67"), "Abdominals" },
                    { new Guid("752e3f65-ef2f-4646-b4d0-5f3e312bdd5f"), "Calves Gastroc" },
                    { new Guid("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd11"), "Adductors" },
                    { new Guid("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd5e"), "Biceps" },
                    { new Guid("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd5f"), "Obliques" },
                    { new Guid("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd60"), "Calves Soleus" },
                    { new Guid("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd62"), "Forearm Extensors" },
                    { new Guid("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd63"), "Forearm Flexors" },
                    { new Guid("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd64"), "Front Delts" },
                    { new Guid("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd65"), "Glutes" },
                    { new Guid("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd66"), "Hamstrings" },
                    { new Guid("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd67"), "Lats" },
                    { new Guid("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd68"), "Pectorals" },
                    { new Guid("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd69"), "Quadriceps" },
                    { new Guid("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd6a"), "Rear Delts" },
                    { new Guid("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd6b"), "Side Delts" },
                    { new Guid("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd6d"), "Triceps" },
                    { new Guid("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd6e"), "Spinal Erectors" },
                    { new Guid("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd6f"), "Rectus Abdominis" },
                    { new Guid("8b3e3f65-ef2f-4646-b4d0-5f3e312bdd50"), "Lower Body" },
                    { new Guid("8b3e3f65-ef2f-4646-b4d0-5f3e312bdd51"), "Core" },
                    { new Guid("8b3e3f65-ef2f-4646-b4d0-5f3e312bdd5f"), "Upper Body" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedById", "CreatedOn", "DeletedById", "DeletedOn", "Email", "GoogleId", "ModifiedById", "ModifiedOn", "Name" },
                values: new object[] { new Guid("5b3e3f65-ef2f-4646-b4d0-5f3e312bdd5e"), new Guid("5b3e3f65-ef2f-4646-b4d0-5f3e312bdd5e"), new DateTimeOffset(new DateTime(2025, 2, 16, 16, 43, 28, 578, DateTimeKind.Unspecified).AddTicks(233), new TimeSpan(0, 2, 0, 0, 0)), null, null, "", "", new Guid("5b3e3f65-ef2f-4646-b4d0-5f3e312bdd5e"), new DateTimeOffset(new DateTime(2025, 2, 16, 16, 43, 28, 578, DateTimeKind.Unspecified).AddTicks(233), new TimeSpan(0, 2, 0, 0, 0)), "Automatic Process" });

            migrationBuilder.InsertData(
                table: "ExerciseTag",
                columns: new[] { "ExerciseId", "TagId" },
                values: new object[,]
                {
                    { new Guid("4a7b067b-549e-4e6a-9d57-5f6735e4f88f"), new Guid("2b3e3f65-ef2f-4646-b4d0-5f3e312bdd5f") },
                    { new Guid("4a7b067b-549e-4e6a-9d57-5f6735e4f88f"), new Guid("2b3e3f65-ef2f-4646-b4d0-5f3e312bdd63") },
                    { new Guid("4a7b067b-549e-4e6a-9d57-5f6735e4f88f"), new Guid("2b3e3f65-ef2f-4646-b4d0-5f3e312bdd65") },
                    { new Guid("4a7b067b-549e-4e6a-9d57-5f6735e4f88f"), new Guid("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd64") },
                    { new Guid("4a7b067b-549e-4e6a-9d57-5f6735e4f88f"), new Guid("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd68") },
                    { new Guid("4a7b067b-549e-4e6a-9d57-5f6735e4f88f"), new Guid("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd6d") },
                    { new Guid("6bdc7a80-8bfa-4b8e-bbe4-0b5597279071"), new Guid("2b3e3f65-ef2f-4646-b4d0-5f3e312bdd61") },
                    { new Guid("6bdc7a80-8bfa-4b8e-bbe4-0b5597279071"), new Guid("2b3e3f65-ef2f-4646-b4d0-5f3e312bdd64") },
                    { new Guid("6bdc7a80-8bfa-4b8e-bbe4-0b5597279071"), new Guid("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd65") },
                    { new Guid("6bdc7a80-8bfa-4b8e-bbe4-0b5597279071"), new Guid("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd69") },
                    { new Guid("6bdc7a80-8bfa-4b8e-bbe4-0b5597279071"), new Guid("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd6e") },
                    { new Guid("7c9e6679-7425-40de-944b-e07fc1f90ae7"), new Guid("2b3e3f65-ef2f-4646-b4d0-5f3e312bdd61") },
                    { new Guid("7c9e6679-7425-40de-944b-e07fc1f90ae7"), new Guid("2b3e3f65-ef2f-4646-b4d0-5f3e312bdd64") },
                    { new Guid("7c9e6679-7425-40de-944b-e07fc1f90ae7"), new Guid("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd65") },
                    { new Guid("7c9e6679-7425-40de-944b-e07fc1f90ae7"), new Guid("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd66") },
                    { new Guid("7c9e6679-7425-40de-944b-e07fc1f90ae7"), new Guid("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd6e") }
                });

            migrationBuilder.InsertData(
                table: "TagChild",
                columns: new[] { "ChildId", "ParentId" },
                values: new object[,]
                {
                    { new Guid("752e3f65-ef2f-4646-b4d0-5f3e312bdd5f"), new Guid("25553f65-ef2f-4646-b4d0-5f3e312bdd5e") },
                    { new Guid("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd60"), new Guid("25553f65-ef2f-4646-b4d0-5f3e312bdd5e") },
                    { new Guid("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd68"), new Guid("2b3e3f65-ef2f-4646-b4d0-5f3e312bdd5f") },
                    { new Guid("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd62"), new Guid("2b3e3f65-ef2f-4646-b4d0-5f3e312bdd60") },
                    { new Guid("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd63"), new Guid("2b3e3f65-ef2f-4646-b4d0-5f3e312bdd60") },
                    { new Guid("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd6e"), new Guid("2b3e3f65-ef2f-4646-b4d0-5f3e312bdd61") },
                    { new Guid("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd64"), new Guid("2b3e3f65-ef2f-4646-b4d0-5f3e312bdd63") },
                    { new Guid("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd6a"), new Guid("2b3e3f65-ef2f-4646-b4d0-5f3e312bdd63") },
                    { new Guid("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd6b"), new Guid("2b3e3f65-ef2f-4646-b4d0-5f3e312bdd63") },
                    { new Guid("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd11"), new Guid("2b3e3f65-ef2f-4646-b4d0-5f3e312bdd64") },
                    { new Guid("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd65"), new Guid("2b3e3f65-ef2f-4646-b4d0-5f3e312bdd64") },
                    { new Guid("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd66"), new Guid("2b3e3f65-ef2f-4646-b4d0-5f3e312bdd64") },
                    { new Guid("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd69"), new Guid("2b3e3f65-ef2f-4646-b4d0-5f3e312bdd64") },
                    { new Guid("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd5e"), new Guid("2b3e3f65-ef2f-4646-b4d0-5f3e312bdd65") },
                    { new Guid("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd6d"), new Guid("2b3e3f65-ef2f-4646-b4d0-5f3e312bdd65") },
                    { new Guid("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd5f"), new Guid("2b3e3f65-ef2f-4646-b4d0-5f3e312bdd67") },
                    { new Guid("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd6f"), new Guid("2b3e3f65-ef2f-4646-b4d0-5f3e312bdd67") },
                    { new Guid("25553f65-ef2f-4646-b4d0-5f3e312bdd5e"), new Guid("8b3e3f65-ef2f-4646-b4d0-5f3e312bdd50") },
                    { new Guid("2b3e3f65-ef2f-4646-b4d0-5f3e312bdd64"), new Guid("8b3e3f65-ef2f-4646-b4d0-5f3e312bdd50") },
                    { new Guid("2b3e3f65-ef2f-4646-b4d0-5f3e312bdd61"), new Guid("8b3e3f65-ef2f-4646-b4d0-5f3e312bdd51") },
                    { new Guid("2b3e3f65-ef2f-4646-b4d0-5f3e312bdd67"), new Guid("8b3e3f65-ef2f-4646-b4d0-5f3e312bdd51") },
                    { new Guid("2b3e3f65-ef2f-4646-b4d0-5f3e312bdd5f"), new Guid("8b3e3f65-ef2f-4646-b4d0-5f3e312bdd5f") },
                    { new Guid("2b3e3f65-ef2f-4646-b4d0-5f3e312bdd60"), new Guid("8b3e3f65-ef2f-4646-b4d0-5f3e312bdd5f") },
                    { new Guid("2b3e3f65-ef2f-4646-b4d0-5f3e312bdd63"), new Guid("8b3e3f65-ef2f-4646-b4d0-5f3e312bdd5f") },
                    { new Guid("2b3e3f65-ef2f-4646-b4d0-5f3e312bdd65"), new Guid("8b3e3f65-ef2f-4646-b4d0-5f3e312bdd5f") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseTag_TagId",
                table: "ExerciseTag",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_TagChild_ChildId",
                table: "TagChild",
                column: "ChildId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseTag");

            migrationBuilder.DropTable(
                name: "TagChild");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Exercise");

            migrationBuilder.DropTable(
                name: "Tag");
        }
    }
}
