using Microsoft.EntityFrameworkCore.Migrations;

namespace Sertar.Migrations.Mysql.Migrations.MysqlServer
{
    public partial class AddIpVersionAndServerRootUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RootUser",
                table: "Servers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "IpAddress",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RootUser",
                table: "Servers");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "IpAddress");
        }
    }
}
