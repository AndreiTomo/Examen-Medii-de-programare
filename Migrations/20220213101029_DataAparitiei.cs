using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Examen_Medii_de_programare.Migrations
{
    public partial class DataAparitiei : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataAparitiei",
                table: "Toy",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataAparitiei",
                table: "Toy");
        }
    }
}
