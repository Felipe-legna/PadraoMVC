using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoMvc.Data.Migrations
{
    public partial class AdicionadoBancadas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bancadas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Descricao = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Frontao = table.Column<decimal>(nullable: false),
                    Saia = table.Column<decimal>(nullable: false),
                    Imagem = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    CategoriaId = table.Column<Guid>(nullable: true),
                    QuantidadePecas = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bancadas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bancadas_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Peca",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    LarguraPeca = table.Column<decimal>(nullable: false),
                    ApoioLargura = table.Column<int>(nullable: false),
                    TotalLarguraPeca = table.Column<decimal>(nullable: false),
                    ComprimentoPeca = table.Column<decimal>(nullable: false),
                    ApoioComprimento = table.Column<int>(nullable: false),
                    ComprimentoFogaoEmbutido = table.Column<decimal>(nullable: false),
                    Base = table.Column<int>(nullable: false),
                    AlturaDaBase = table.Column<decimal>(nullable: false),
                    TotalComprimentoPeca = table.Column<decimal>(nullable: false),
                    MetroQuadradoPeca = table.Column<decimal>(nullable: false),
                    BancadaId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peca", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Peca_Bancadas_BancadaId",
                        column: x => x.BancadaId,
                        principalTable: "Bancadas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bancadas_CategoriaId",
                table: "Bancadas",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Peca_BancadaId",
                table: "Peca",
                column: "BancadaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Peca");

            migrationBuilder.DropTable(
                name: "Bancadas");
        }
    }
}
