using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoMvc.Data.Migrations
{
    public partial class AdicionadoProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(250)", nullable: false),
                    Descricao = table.Column<string>(type: "VARCHAR(250)", nullable: false),
                    Valor = table.Column<decimal>(type: "DECIMAL(10,2)", nullable: false),
                    Quantidade = table.Column<int>(type: "INT", nullable: false),
                    Imagem = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    CategoriaId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produtos_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CategoriaId",
                table: "Produtos",
                column: "CategoriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
