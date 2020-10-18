using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sertar.Migrations.Postgres.Migrations.PostgresServer
{
    public partial class ServerInitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Servers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CloudId = table.Column<string>(nullable: true),
                    InstallationScriptLocation = table.Column<string>(nullable: true),
                    MainIpAddress = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IpAddress",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Ip = table.Column<string>(nullable: true),
                    ServerId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IpAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IpAddress_Servers_ServerId",
                        column: x => x.ServerId,
                        principalTable: "Servers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IpAddress_ServerId",
                table: "IpAddress",
                column: "ServerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IpAddress");

            migrationBuilder.DropTable(
                name: "Servers");
        }
    }
}
