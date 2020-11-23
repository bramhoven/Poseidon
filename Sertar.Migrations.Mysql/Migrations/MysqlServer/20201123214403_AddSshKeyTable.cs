using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sertar.Migrations.Mysql.Migrations.MysqlServer
{
    public partial class AddSshKeyTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SshKeys",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Format = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PrivateKey = table.Column<string>(nullable: true),
                    PublicKey = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SshKeys", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SshKeys");
        }
    }
}
