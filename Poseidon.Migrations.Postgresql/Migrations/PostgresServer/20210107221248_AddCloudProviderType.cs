using Microsoft.EntityFrameworkCore.Migrations;

namespace Poseidon.Migrations.Postgres.Migrations.PostgresServer
{
    public partial class AddCloudProviderType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CloudProviderType",
                table: "CloudProviders",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CloudProviderType",
                table: "CloudProviders");
        }
    }
}
