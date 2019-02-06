using Microsoft.EntityFrameworkCore.Migrations;

namespace stembowl.Migrations.QuestionDb
{
    public partial class FixingTeams2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Answer",
                table: "TeamMembers");

            migrationBuilder.DropColumn(
                name: "Correct",
                table: "TeamMembers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Answer",
                table: "TeamMembers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Correct",
                table: "TeamMembers",
                nullable: false,
                defaultValue: false);
        }
    }
}
