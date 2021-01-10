using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Poseidon.Migrations.Mysql.Migrations.MysqlServer
{
    public partial class AddHealthCheckProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CloudProviderId",
                table: "Servers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HealthCheckPropertiesId",
                table: "Servers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HealthCheckProperties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    HealthCheckPath = table.Column<string>(nullable: true),
                    Protocol = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthCheckProperties", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Servers_HealthCheckPropertiesId",
                table: "Servers",
                column: "HealthCheckPropertiesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Servers_HealthCheckProperties_HealthCheckPropertiesId",
                table: "Servers",
                column: "HealthCheckPropertiesId",
                principalTable: "HealthCheckProperties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servers_HealthCheckProperties_HealthCheckPropertiesId",
                table: "Servers");

            migrationBuilder.DropTable(
                name: "HealthCheckProperties");

            migrationBuilder.DropIndex(
                name: "IX_Servers_HealthCheckPropertiesId",
                table: "Servers");

            migrationBuilder.DropColumn(
                name: "CloudProviderId",
                table: "Servers");

            migrationBuilder.DropColumn(
                name: "HealthCheckPropertiesId",
                table: "Servers");
        }
    }
}
