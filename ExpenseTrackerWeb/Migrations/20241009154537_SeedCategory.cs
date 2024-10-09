using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExpenseTrackerWeb.Migrations
{
    /// <inheritdoc />
    public partial class SeedCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDateTime", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 9, 21, 45, 36, 283, DateTimeKind.Local).AddTicks(156), "Utilities" },
                    { 2, new DateTime(2024, 10, 9, 21, 45, 36, 283, DateTimeKind.Local).AddTicks(166), "Transport" },
                    { 3, new DateTime(2024, 10, 9, 21, 45, 36, 283, DateTimeKind.Local).AddTicks(167), "Foods" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
