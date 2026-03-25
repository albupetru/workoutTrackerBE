using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace workoutTracker.Domain.Migrations
{
    /// <inheritdoc />
    public partial class AddTagTypeToTag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TagType",
                table: "Tag",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

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
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("25553f65-ef2f-4646-b4d0-5f3e312bdd5e"),
                column: "TagType",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("2b3e3f65-ef2f-4646-b4d0-5f3e312bdd5f"),
                column: "TagType",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("2b3e3f65-ef2f-4646-b4d0-5f3e312bdd60"),
                column: "TagType",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("2b3e3f65-ef2f-4646-b4d0-5f3e312bdd61"),
                column: "TagType",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("2b3e3f65-ef2f-4646-b4d0-5f3e312bdd63"),
                column: "TagType",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("2b3e3f65-ef2f-4646-b4d0-5f3e312bdd64"),
                column: "TagType",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("2b3e3f65-ef2f-4646-b4d0-5f3e312bdd65"),
                column: "TagType",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("2b3e3f65-ef2f-4646-b4d0-5f3e312bdd67"),
                column: "TagType",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("752e3f65-ef2f-4646-b4d0-5f3e312bdd5f"),
                column: "TagType",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd11"),
                column: "TagType",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd5e"),
                column: "TagType",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd5f"),
                column: "TagType",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd60"),
                column: "TagType",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd62"),
                column: "TagType",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd63"),
                column: "TagType",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd64"),
                column: "TagType",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd65"),
                column: "TagType",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd66"),
                column: "TagType",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd67"),
                column: "TagType",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd68"),
                column: "TagType",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd69"),
                column: "TagType",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd6a"),
                column: "TagType",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd6b"),
                column: "TagType",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd6d"),
                column: "TagType",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd6e"),
                column: "TagType",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd6f"),
                column: "TagType",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("8b3e3f65-ef2f-4646-b4d0-5f3e312bdd50"),
                column: "TagType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("8b3e3f65-ef2f-4646-b4d0-5f3e312bdd51"),
                column: "TagType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("8b3e3f65-ef2f-4646-b4d0-5f3e312bdd5f"),
                column: "TagType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5b3e3f65-ef2f-4646-b4d0-5f3e312bdd5e"),
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 3, 25, 19, 52, 15, 998, DateTimeKind.Unspecified).AddTicks(1315), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 3, 25, 19, 52, 15, 998, DateTimeKind.Unspecified).AddTicks(1315), new TimeSpan(0, 2, 0, 0, 0)) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TagType",
                table: "Tag");

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: new Guid("4a7b067b-549e-4e6a-9d57-5f6735e4f88f"),
                columns: new[] { "CreatedOn", "ModifiedOn", "VerifiedOn" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 3, 23, 16, 35, 25, 126, DateTimeKind.Unspecified).AddTicks(2281), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 3, 23, 16, 35, 25, 126, DateTimeKind.Unspecified).AddTicks(2281), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 3, 23, 16, 35, 25, 126, DateTimeKind.Unspecified).AddTicks(2281), new TimeSpan(0, 2, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: new Guid("6bdc7a80-8bfa-4b8e-bbe4-0b5597279071"),
                columns: new[] { "CreatedOn", "ModifiedOn", "VerifiedOn" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 3, 23, 16, 35, 25, 126, DateTimeKind.Unspecified).AddTicks(2281), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 3, 23, 16, 35, 25, 126, DateTimeKind.Unspecified).AddTicks(2281), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 3, 23, 16, 35, 25, 126, DateTimeKind.Unspecified).AddTicks(2281), new TimeSpan(0, 2, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: new Guid("7c9e6679-7425-40de-944b-e07fc1f90ae7"),
                columns: new[] { "CreatedOn", "ModifiedOn", "VerifiedOn" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 3, 23, 16, 35, 25, 126, DateTimeKind.Unspecified).AddTicks(2281), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 3, 23, 16, 35, 25, 126, DateTimeKind.Unspecified).AddTicks(2281), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 3, 23, 16, 35, 25, 126, DateTimeKind.Unspecified).AddTicks(2281), new TimeSpan(0, 2, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5b3e3f65-ef2f-4646-b4d0-5f3e312bdd5e"),
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 3, 23, 16, 35, 25, 132, DateTimeKind.Unspecified).AddTicks(399), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 3, 23, 16, 35, 25, 132, DateTimeKind.Unspecified).AddTicks(399), new TimeSpan(0, 2, 0, 0, 0)) });
        }
    }
}
