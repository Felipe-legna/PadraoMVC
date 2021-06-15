using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoMvc.Data.Migrations
{
    public partial class AdicionadoCRUDdoMaterial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ComprimentoPeca",
                table: "Peca");

            migrationBuilder.DropColumn(
                name: "LarguraPeca",
                table: "Peca");

            migrationBuilder.AddColumn<decimal>(
                name: "Comprimento",
                table: "Peca",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Largura",
                table: "Peca",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "MetroQuadrado",
                table: "Bancadas",
                type: "DECIMAL(10,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateTable(
                name: "Materiais",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Valor = table.Column<decimal>(nullable: false),
                    Imagem = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    AtreladoDolar = table.Column<bool>(nullable: false),
                    CategoriaId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materiais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Materiais_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Materiais_CategoriaId",
                table: "Materiais",
                column: "CategoriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Materiais");

            migrationBuilder.DropColumn(
                name: "Comprimento",
                table: "Peca");

            migrationBuilder.DropColumn(
                name: "Largura",
                table: "Peca");

            migrationBuilder.AddColumn<decimal>(
                name: "ComprimentoPeca",
                table: "Peca",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "LarguraPeca",
                table: "Peca",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "MetroQuadrado",
                table: "Bancadas",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(10,2)");
        }
    }
}
