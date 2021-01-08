using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Poseidon.Migrations.Postgres.Migrations.PostgresServer
{
    public partial class AddPublicSshKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IpAddress");

            migrationBuilder.AddColumn<int>(
                name: "CloudProviderId",
                table: "Servers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PublicSshKeyId",
                table: "Servers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CloudProviders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CloudProviders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IpAddresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Gateway = table.Column<string>(nullable: true),
                    Ip = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Netmask = table.Column<string>(nullable: true),
                    Version = table.Column<int>(nullable: false),
                    ServerId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IpAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IpAddresses_Servers_ServerId",
                        column: x => x.ServerId,
                        principalTable: "Servers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PublicSshKeys",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Fingerprint = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    PublicKey = table.Column<string>(nullable: true),
                    ProviderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicSshKeys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PublicSshKeys_CloudProviders_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "CloudProviders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Servers_CloudProviderId",
                table: "Servers",
                column: "CloudProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Servers_PublicSshKeyId",
                table: "Servers",
                column: "PublicSshKeyId");

            migrationBuilder.CreateIndex(
                name: "IX_IpAddresses_ServerId",
                table: "IpAddresses",
                column: "ServerId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicSshKeys_ProviderId",
                table: "PublicSshKeys",
                column: "ProviderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Servers_CloudProviders_CloudProviderId",
                table: "Servers",
                column: "CloudProviderId",
                principalTable: "CloudProviders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Servers_PublicSshKeys_PublicSshKeyId",
                table: "Servers",
                column: "PublicSshKeyId",
                principalTable: "PublicSshKeys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servers_CloudProviders_CloudProviderId",
                table: "Servers");

            migrationBuilder.DropForeignKey(
                name: "FK_Servers_PublicSshKeys_PublicSshKeyId",
                table: "Servers");

            migrationBuilder.DropTable(
                name: "IpAddresses");

            migrationBuilder.DropTable(
                name: "PublicSshKeys");

            migrationBuilder.DropTable(
                name: "CloudProviders");

            migrationBuilder.DropIndex(
                name: "IX_Servers_CloudProviderId",
                table: "Servers");

            migrationBuilder.DropIndex(
                name: "IX_Servers_PublicSshKeyId",
                table: "Servers");

            migrationBuilder.DropColumn(
                name: "CloudProviderId",
                table: "Servers");

            migrationBuilder.DropColumn(
                name: "PublicSshKeyId",
                table: "Servers");

            migrationBuilder.CreateTable(
                name: "IpAddress",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Ip = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ServerId = table.Column<Guid>(type: "uuid", nullable: true)
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
    }
}
