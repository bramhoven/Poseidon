using Microsoft.EntityFrameworkCore.Migrations;

namespace Poseidon.Migrations.Mysql.Migrations.MysqlServer
{
    public partial class AddServerStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Servers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Servers_CloudProviderId",
                table: "Servers",
                column: "CloudProviderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Servers_CloudProviders_CloudProviderId",
                table: "Servers",
                column: "CloudProviderId",
                principalTable: "CloudProviders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servers_CloudProviders_CloudProviderId",
                table: "Servers");

            migrationBuilder.DropIndex(
                name: "IX_Servers_CloudProviderId",
                table: "Servers");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Servers");
        }
    }
}
