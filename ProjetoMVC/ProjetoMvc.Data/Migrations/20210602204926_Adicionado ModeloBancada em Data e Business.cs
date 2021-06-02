using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoMvc.Data.Migrations
{
    public partial class AdicionadoModeloBancadaemDataeBusiness : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bancadas_Categorias_CategoriaId",
                table: "Bancadas");

            migrationBuilder.DropIndex(
                name: "IX_Bancadas_CategoriaId",
                table: "Bancadas");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Bancadas");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Bancadas");

            migrationBuilder.DropColumn(
                name: "Metodo",
                table: "Bancadas");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Bancadas");

            migrationBuilder.DropColumn(
                name: "QuantidadePecas",
                table: "Bancadas");

            migrationBuilder.AddColumn<Guid>(
                name: "ModeloBancadaId",
                table: "Bancadas",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ModelosBancadas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(250)", nullable: false),
                    Descricao = table.Column<string>(type: "VARCHAR(250)", nullable: false),
                    Metodo = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    CategoriaId = table.Column<Guid>(nullable: true),
                    QuantidadePecas = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelosBancadas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModelosBancadas_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bancadas_ModeloBancadaId",
                table: "Bancadas",
                column: "ModeloBancadaId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelosBancadas_CategoriaId",
                table: "ModelosBancadas",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bancadas_ModelosBancadas_ModeloBancadaId",
                table: "Bancadas",
                column: "ModeloBancadaId",
                principalTable: "ModelosBancadas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bancadas_ModelosBancadas_ModeloBancadaId",
                table: "Bancadas");

            migrationBuilder.DropTable(
                name: "ModelosBancadas");

            migrationBuilder.DropIndex(
                name: "IX_Bancadas_ModeloBancadaId",
                table: "Bancadas");

            migrationBuilder.DropColumn(
                name: "ModeloBancadaId",
                table: "Bancadas");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoriaId",
                table: "Bancadas",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Bancadas",
                type: "VARCHAR(250)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Metodo",
                table: "Bancadas",
                type: "VARCHAR(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Bancadas",
                type: "VARCHAR(250)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "QuantidadePecas",
                table: "Bancadas",
                type: "INT",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Bancadas_CategoriaId",
                table: "Bancadas",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bancadas_Categorias_CategoriaId",
                table: "Bancadas",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
