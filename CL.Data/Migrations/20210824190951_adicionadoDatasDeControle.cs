using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CL.Data.Migrations
{
    public partial class adicionadoDatasDeControle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataCriacao",
                table: "Cliente",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UltimaAtualizacao",
                table: "Cliente",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "UltimaAtualizacao",
                table: "Cliente");
        }
    }
}
