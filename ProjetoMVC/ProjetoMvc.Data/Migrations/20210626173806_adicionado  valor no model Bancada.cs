using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoMvc.Data.Migrations
{
    public partial class adicionadovalornomodelBancada : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Valor",
                table: "Bancadas",
                type: "DECIMAL(10,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Valor",
                table: "Bancadas");
        }
    }
}
