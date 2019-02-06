using Microsoft.EntityFrameworkCore.Migrations;

namespace stembowl.Migrations.QuestionDb
{
    public partial class ApplicationUser2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answer_Questions_QuestionID",
                table: "Answer");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Teams_TeamID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Teams_TeamID",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamAnswers_Teams_TeamID",
                table: "TeamAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_AspNetUsers_LeaderID",
                table: "Teams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teams",
                table: "Teams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Questions",
                table: "Questions");

            migrationBuilder.RenameTable(
                name: "Teams",
                newName: "Team");

            migrationBuilder.RenameTable(
                name: "Questions",
                newName: "Question");

            migrationBuilder.RenameIndex(
                name: "IX_Teams_LeaderID",
                table: "Team",
                newName: "IX_Team_LeaderID");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_TeamID",
                table: "Question",
                newName: "IX_Question_TeamID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Team",
                table: "Team",
                column: "TeamID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Question",
                table: "Question",
                column: "QuestionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Answer_Question_QuestionID",
                table: "Answer",
                column: "QuestionID",
                principalTable: "Question",
                principalColumn: "QuestionID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Team_TeamID",
                table: "AspNetUsers",
                column: "TeamID",
                principalTable: "Team",
                principalColumn: "TeamID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Team_TeamID",
                table: "Question",
                column: "TeamID",
                principalTable: "Team",
                principalColumn: "TeamID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Team_AspNetUsers_LeaderID",
                table: "Team",
                column: "LeaderID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamAnswers_Team_TeamID",
                table: "TeamAnswers",
                column: "TeamID",
                principalTable: "Team",
                principalColumn: "TeamID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answer_Question_QuestionID",
                table: "Answer");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Team_TeamID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_Team_TeamID",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_Team_AspNetUsers_LeaderID",
                table: "Team");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamAnswers_Team_TeamID",
                table: "TeamAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Team",
                table: "Team");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Question",
                table: "Question");

            migrationBuilder.RenameTable(
                name: "Team",
                newName: "Teams");

            migrationBuilder.RenameTable(
                name: "Question",
                newName: "Questions");

            migrationBuilder.RenameIndex(
                name: "IX_Team_LeaderID",
                table: "Teams",
                newName: "IX_Teams_LeaderID");

            migrationBuilder.RenameIndex(
                name: "IX_Question_TeamID",
                table: "Questions",
                newName: "IX_Questions_TeamID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teams",
                table: "Teams",
                column: "TeamID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Questions",
                table: "Questions",
                column: "QuestionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Answer_Questions_QuestionID",
                table: "Answer",
                column: "QuestionID",
                principalTable: "Questions",
                principalColumn: "QuestionID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Teams_TeamID",
                table: "AspNetUsers",
                column: "TeamID",
                principalTable: "Teams",
                principalColumn: "TeamID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Teams_TeamID",
                table: "Questions",
                column: "TeamID",
                principalTable: "Teams",
                principalColumn: "TeamID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamAnswers_Teams_TeamID",
                table: "TeamAnswers",
                column: "TeamID",
                principalTable: "Teams",
                principalColumn: "TeamID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_AspNetUsers_LeaderID",
                table: "Teams",
                column: "LeaderID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
