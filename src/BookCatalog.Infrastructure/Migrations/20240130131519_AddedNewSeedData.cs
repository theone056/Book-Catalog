using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookCatalog.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BookCategories",
                columns: new[] { "BookId", "CategoryId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishDate",
                value: new DateTime(2024, 1, 30, 21, 15, 18, 780, DateTimeKind.Local).AddTicks(8894));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishDate",
                value: new DateTime(2024, 1, 30, 20, 35, 5, 703, DateTimeKind.Local).AddTicks(9215));
        }
    }
}
