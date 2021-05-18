using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoMvc.Data.Migrations
{
    public partial class Ajustadoitemsdapecapararodaralistadebancadas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlturaDaBase",
                table: "Peca");

            migrationBuilder.DropColumn(
                name: "Base",
                table: "Peca");

            migrationBuilder.DropColumn(
                name: "ComprimentoFogaoEmbutido",
                table: "Peca");

            migrationBuilder.DropColumn(
                name: "TotalComprimentoPeca",
                table: "Peca");

            migrationBuilder.DropColumn(
                name: "TotalLarguraPeca",
                table: "Peca");

            migrationBuilder.AlterColumn<decimal>(
                name: "ApoioLargura",
                table: "Peca",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "ApoioComprimento",
                table: "Peca",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ApoioLargura",
                table: "Peca",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<int>(
                name: "ApoioComprimento",
                table: "Peca",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AddColumn<decimal>(
                name: "AlturaDaBase",
                table: "Peca",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Base",
                table: "Peca",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "ComprimentoFogaoEmbutido",
                table: "Peca",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalComprimentoPeca",
                table: "Peca",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalLarguraPeca",
                table: "Peca",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
