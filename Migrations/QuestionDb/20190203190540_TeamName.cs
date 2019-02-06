using Microsoft.EntityFrameworkCore.Migrations;

namespace stembowl.Migrations.QuestionDb
{
    public partial class TeamName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_AspNetUsers_LeaderId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Answers_TeamID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Answers_TeamID",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamAnswers_Questions_QuestionID1",
                table: "TeamAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamAnswers_Answers_TeamID",
                table: "TeamAnswers");

            migrationBuilder.DropIndex(
                name: "IX_TeamAnswers_QuestionID1",
                table: "TeamAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Answers",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "QuestionID1",
                table: "TeamAnswers");

            migrationBuilder.RenameTable(
                name: "Answers",
                newName: "Teams");

            migrationBuilder.RenameIndex(
                name: "IX_Answers_LeaderId",
                table: "Teams",
                newName: "IX_Teams_LeaderId");

            migrationBuilder.AddColumn<string>(
                name: "TeamName",
                table: "Teams",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teams",
                table: "Teams",
                column: "TeamID");

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
                name: "FK_Teams_AspNetUsers_LeaderId",
                table: "Teams",
                column: "LeaderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "FK_Teams_AspNetUsers_LeaderId",
                table: "Teams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teams",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "TeamName",
                table: "Teams");

            migrationBuilder.RenameTable(
                name: "Teams",
                newName: "Answers");

            migrationBuilder.RenameIndex(
                name: "IX_Teams_LeaderId",
                table: "Answers",
                newName: "IX_Answers_LeaderId");

            migrationBuilder.AddColumn<int>(
                name: "QuestionID1",
                table: "TeamAnswers",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Answers",
                table: "Answers",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_TeamAnswers_QuestionID1",
                table: "TeamAnswers",
                column: "QuestionID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_AspNetUsers_LeaderId",
                table: "Answers",
                column: "LeaderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Answers_TeamID",
                table: "AspNetUsers",
                column: "TeamID",
                principalTable: "Answers",
                principalColumn: "TeamID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Answers_TeamID",
                table: "Questions",
                column: "TeamID",
                principalTable: "Answers",
                principalColumn: "TeamID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamAnswers_Questions_QuestionID1",
                table: "TeamAnswers",
                column: "QuestionID1",
                principalTable: "Questions",
                principalColumn: "QuestionID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamAnswers_Answers_TeamID",
                table: "TeamAnswers",
                column: "TeamID",
                principalTable: "Answers",
                principalColumn: "TeamID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
