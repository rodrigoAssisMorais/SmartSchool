using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartSchool.API.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Idade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "Idade", "Nome" },
                values: new object[,]
                {
                    { new Guid("54467587-568e-4219-ab99-c2a1fae1cff4"), 36, "Lauro" },
                    { new Guid("89565508-0a7e-4a77-bfaa-ea7b7882087c"), 25, "Roberto" },
                    { new Guid("d463643c-6423-49d1-9c14-cda59b05632f"), 32, "Ronaldo" },
                    { new Guid("34072e44-85cd-41a1-912a-fdd3d8842334"), 42, "Rodrigo" },
                    { new Guid("de8ad240-fad6-44bd-b6a2-2c6994714c65"), 46, "Alexandre" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
