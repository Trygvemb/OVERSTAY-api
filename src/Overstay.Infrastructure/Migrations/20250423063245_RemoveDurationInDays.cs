using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Overstay.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveDurationInDays : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DurationInDays",
                table: "VisaTypes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DurationInDays",
                table: "VisaTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "VisaTypes",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000001"),
                column: "DurationInDays",
                value: 90);

            migrationBuilder.UpdateData(
                table: "VisaTypes",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000002"),
                column: "DurationInDays",
                value: 180);

            migrationBuilder.UpdateData(
                table: "VisaTypes",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000003"),
                column: "DurationInDays",
                value: 365);

            migrationBuilder.UpdateData(
                table: "VisaTypes",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000004"),
                column: "DurationInDays",
                value: 365);

            migrationBuilder.UpdateData(
                table: "VisaTypes",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000005"),
                column: "DurationInDays",
                value: 7);

            migrationBuilder.UpdateData(
                table: "VisaTypes",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000006"),
                column: "DurationInDays",
                value: 180);
        }
    }
}
