using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class FixStaticSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Flags",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Flags",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Flags",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 10, 21, 21, 49, 35, 246, DateTimeKind.Local).AddTicks(8100));

            migrationBuilder.UpdateData(
                table: "Flags",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 10, 21, 21, 49, 35, 301, DateTimeKind.Local).AddTicks(271));
        }
    }
}
