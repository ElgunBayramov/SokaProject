using Microsoft.EntityFrameworkCore.Migrations;

namespace Soka.Domain.Migrations
{
    public partial class End : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "Rank",
                schema: "Membership",
                table: "Roles",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rank",
                schema: "Membership",
                table: "Roles");
        }
    }
}
