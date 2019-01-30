using Microsoft.EntityFrameworkCore.Migrations;

namespace stembowl.Migrations.QuestionDb
{
    public partial class UpdateAnswer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Correct",
                table: "Answer",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Correct",
                table: "Answer");
        }
    }
}
