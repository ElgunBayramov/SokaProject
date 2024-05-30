using Microsoft.EntityFrameworkCore.Migrations;

namespace Soka.Domain.Migrations
{
    public partial class PasswordAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PassWord",
                schema: "Membership",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PassWord",
                schema: "Membership",
                table: "Users");
        }
    }
}
