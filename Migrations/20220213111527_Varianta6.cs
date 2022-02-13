using Microsoft.EntityFrameworkCore.Migrations;

namespace Examen_Medii_de_programare.Migrations
{
    public partial class Varianta6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ToyCategory",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToyID = table.Column<int>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToyCategory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ToyCategory_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ToyCategory_Toy_ToyID",
                        column: x => x.ToyID,
                        principalTable: "Toy",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ToyCategory_CategoryID",
                table: "ToyCategory",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ToyCategory_ToyID",
                table: "ToyCategory",
                column: "ToyID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToyCategory");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
