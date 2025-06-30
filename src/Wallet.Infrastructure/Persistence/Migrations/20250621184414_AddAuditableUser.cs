using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wallet.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddAuditableUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Cobrancas",
                newName: "UpdateByUserId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "Contatos",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreateByUserId",
                table: "Contatos",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "Contatos",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "UpdateByUserId",
                table: "Contatos",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "Cobrancas",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreateByUserId",
                table: "Cobrancas",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "Cobrancas",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "Categorias",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreateByUserId",
                table: "Categorias",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "Categorias",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "UpdateByUserId",
                table: "Categorias",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "Carteiras",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreateByUserId",
                table: "Carteiras",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "Carteiras",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "UpdateByUserId",
                table: "Carteiras",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "Contatos");

            migrationBuilder.DropColumn(
                name: "CreateByUserId",
                table: "Contatos");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "Contatos");

            migrationBuilder.DropColumn(
                name: "UpdateByUserId",
                table: "Contatos");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "Cobrancas");

            migrationBuilder.DropColumn(
                name: "CreateByUserId",
                table: "Cobrancas");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "Cobrancas");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "CreateByUserId",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "UpdateByUserId",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "Carteiras");

            migrationBuilder.DropColumn(
                name: "CreateByUserId",
                table: "Carteiras");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "Carteiras");

            migrationBuilder.DropColumn(
                name: "UpdateByUserId",
                table: "Carteiras");

            migrationBuilder.RenameColumn(
                name: "UpdateByUserId",
                table: "Cobrancas",
                newName: "UserId");
        }
    }
}
