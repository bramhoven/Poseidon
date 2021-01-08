using Microsoft.EntityFrameworkCore.Migrations;

namespace Poseidon.Migrations.Mysql.Migrations.MysqlServer
{
    public partial class AddCloudProviderSlug : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "CloudProviders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slug",
                table: "CloudProviders");
        }
    }
}
