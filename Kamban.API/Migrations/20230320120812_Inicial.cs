using Microsoft.EntityFrameworkCore.Migrations;

namespace Kamban.API.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipes",
                columns: table => new
                {
                    EquipeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipeNome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Abreviacao = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipes", x => x.EquipeId);
                });

            migrationBuilder.InsertData(
                table: "Equipes",
                columns: new[] { "EquipeId", "Abreviacao", "EquipeNome" },
                values: new object[] { 1, "PH", "Equipe Paulo Henrique" });

            migrationBuilder.InsertData(
                table: "Equipes",
                columns: new[] { "EquipeId", "Abreviacao", "EquipeNome" },
                values: new object[] { 2, "AS", "Equipe Antonio Silveira" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipes");
        }
    }
}
