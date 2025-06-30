using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wallet.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RelacionamentoCobrancas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataVencimento",
                table: "Cobrancas");

            migrationBuilder.CreateIndex(
                name: "IX_Cobrancas_CarteiraId",
                table: "Cobrancas",
                column: "CarteiraId");

            migrationBuilder.CreateIndex(
                name: "IX_Cobrancas_CategoriaId",
                table: "Cobrancas",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Cobrancas_ContatoId",
                table: "Cobrancas",
                column: "ContatoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cobrancas_UserId",
                table: "Cobrancas",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cobrancas_Carteiras_CarteiraId",
                table: "Cobrancas",
                column: "CarteiraId",
                principalTable: "Carteiras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cobrancas_Categorias_CategoriaId",
                table: "Cobrancas",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cobrancas_Contatos_ContatoId",
                table: "Cobrancas",
                column: "ContatoId",
                principalTable: "Contatos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cobrancas_Users_UserId",
                table: "Cobrancas",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cobrancas_Carteiras_CarteiraId",
                table: "Cobrancas");

            migrationBuilder.DropForeignKey(
                name: "FK_Cobrancas_Categorias_CategoriaId",
                table: "Cobrancas");

            migrationBuilder.DropForeignKey(
                name: "FK_Cobrancas_Contatos_ContatoId",
                table: "Cobrancas");

            migrationBuilder.DropForeignKey(
                name: "FK_Cobrancas_Users_UserId",
                table: "Cobrancas");

            migrationBuilder.DropIndex(
                name: "IX_Cobrancas_CarteiraId",
                table: "Cobrancas");

            migrationBuilder.DropIndex(
                name: "IX_Cobrancas_CategoriaId",
                table: "Cobrancas");

            migrationBuilder.DropIndex(
                name: "IX_Cobrancas_ContatoId",
                table: "Cobrancas");

            migrationBuilder.DropIndex(
                name: "IX_Cobrancas_UserId",
                table: "Cobrancas");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataVencimento",
                table: "Cobrancas",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
