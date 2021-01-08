using Microsoft.EntityFrameworkCore.Migrations;

namespace Poseidon.Migrations.Postgres.Migrations.PostgresServer
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
