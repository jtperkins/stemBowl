using Microsoft.EntityFrameworkCore.Migrations;

namespace stembowl.Migrations.QuestionDb
{
    public partial class FixingTeams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_Question_TeamID",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "TeamID",
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

            migrationBuilder.AlterColumn<int>(
                name: "QuestionID",
                table: "TeamAnswers",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teams",
                table: "Teams",
                column: "TeamID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Questions",
                table: "Questions",
                column: "QuestionID");

            migrationBuilder.CreateTable(
                name: "TeamMembers",
                columns: table => new
                {
                    TeamMembersID = table.Column<string>(nullable: false),
                    TeamID = table.Column<string>(nullable: true),
                    TeamMemberID = table.Column<string>(nullable: true),
                    Answer = table.Column<string>(nullable: true),
                    Correct = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMembers", x => x.TeamMembersID);
                    table.ForeignKey(
                        name: "FK_TeamMembers_Teams_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Teams",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeamMembers_AspNetUsers_TeamMemberID",
                        column: x => x.TeamMemberID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeamAnswers_QuestionID",
                table: "TeamAnswers",
                column: "QuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_TeamID",
                table: "TeamMembers",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_TeamMemberID",
                table: "TeamMembers",
                column: "TeamMemberID");

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
                name: "FK_TeamAnswers_Questions_QuestionID",
                table: "TeamAnswers",
                column: "QuestionID",
                principalTable: "Questions",
                principalColumn: "QuestionID",
                onDelete: ReferentialAction.Cascade);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answer_Questions_QuestionID",
                table: "Answer");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Teams_TeamID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamAnswers_Questions_QuestionID",
                table: "TeamAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamAnswers_Teams_TeamID",
                table: "TeamAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_AspNetUsers_LeaderID",
                table: "Teams");

            migrationBuilder.DropTable(
                name: "TeamMembers");

            migrationBuilder.DropIndex(
                name: "IX_TeamAnswers_QuestionID",
                table: "TeamAnswers");

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

            migrationBuilder.AlterColumn<string>(
                name: "QuestionID",
                table: "TeamAnswers",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "TeamID",
                table: "Question",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Team",
                table: "Team",
                column: "TeamID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Question",
                table: "Question",
                column: "QuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_Question_TeamID",
                table: "Question",
                column: "TeamID");

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
    }
}
