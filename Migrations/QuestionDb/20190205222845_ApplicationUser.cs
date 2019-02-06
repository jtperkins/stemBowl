using Microsoft.EntityFrameworkCore.Migrations;

namespace stembowl.Migrations.QuestionDb
{
    public partial class ApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_AspNetUsers_LeaderId",
                table: "Teams");

            migrationBuilder.RenameColumn(
                name: "LeaderId",
                table: "Teams",
                newName: "LeaderID");

            migrationBuilder.RenameIndex(
                name: "IX_Teams_LeaderId",
                table: "Teams",
                newName: "IX_Teams_LeaderID");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_AspNetUsers_LeaderID",
                table: "Teams",
                column: "LeaderID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_AspNetUsers_LeaderID",
                table: "Teams");

            migrationBuilder.RenameColumn(
                name: "LeaderID",
                table: "Teams",
                newName: "LeaderId");

            migrationBuilder.RenameIndex(
                name: "IX_Teams_LeaderID",
                table: "Teams",
                newName: "IX_Teams_LeaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_AspNetUsers_LeaderId",
                table: "Teams",
                column: "LeaderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
