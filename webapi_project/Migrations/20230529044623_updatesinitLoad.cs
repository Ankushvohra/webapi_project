using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi_project.Migrations
{
    public partial class updatesinitLoad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Datecreated",
                table: "trails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "NationalParks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Established",
                table: "NationalParks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Datecreated",
                table: "trails");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "NationalParks");

            migrationBuilder.DropColumn(
                name: "Established",
                table: "NationalParks");
        }
    }
}
