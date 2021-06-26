using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoMvc.Data.Migrations
{
    public partial class adicionadoreferenciadematerialnaBancada : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MaterialId",
                table: "Bancadas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bancadas_MaterialId",
                table: "Bancadas",
                column: "MaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bancadas_Materiais_MaterialId",
                table: "Bancadas",
                column: "MaterialId",
                principalTable: "Materiais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bancadas_Materiais_MaterialId",
                table: "Bancadas");

            migrationBuilder.DropIndex(
                name: "IX_Bancadas_MaterialId",
                table: "Bancadas");

            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "Bancadas");
        }
    }
}
