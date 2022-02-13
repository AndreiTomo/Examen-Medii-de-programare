using Microsoft.EntityFrameworkCore.Migrations;

namespace Examen_Medii_de_programare.Migrations
{
    public partial class Varianta3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProducatorID",
                table: "Toy",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Producator",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeProducator = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producator", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Toy_ProducatorID",
                table: "Toy",
                column: "ProducatorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Toy_Producator_ProducatorID",
                table: "Toy",
                column: "ProducatorID",
                principalTable: "Producator",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Toy_Producator_ProducatorID",
                table: "Toy");

            migrationBuilder.DropTable(
                name: "Producator");

            migrationBuilder.DropIndex(
                name: "IX_Toy_ProducatorID",
                table: "Toy");

            migrationBuilder.DropColumn(
                name: "ProducatorID",
                table: "Toy");
        }
    }
}
