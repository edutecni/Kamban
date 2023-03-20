using Microsoft.EntityFrameworkCore.Migrations;

namespace Kamban.Migrations
{
    public partial class PopulaTabela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
            migrationBuilder.DeleteData(
                table: "Equipes",
                keyColumn: "EquipeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Equipes",
                keyColumn: "EquipeId",
                keyValue: 2);
        }
    }
}
