using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wallet.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class removeUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cobrancas_Users_UserId",
                table: "Cobrancas");

            migrationBuilder.DropIndex(
                name: "IX_Cobrancas_UserId",
                table: "Cobrancas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Cobrancas_UserId",
                table: "Cobrancas",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cobrancas_Users_UserId",
                table: "Cobrancas",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
