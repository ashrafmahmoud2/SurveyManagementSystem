using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SurveyManagementSystem.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddValidatorAndConfigrationInVoteAndVoteAnswerTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Votes_PollId",
                table: "Votes");

            migrationBuilder.DropIndex(
                name: "IX_VoteAnswers_VoteId",
                table: "VoteAnswers");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_PollId_UserId",
                table: "Votes",
                columns: new[] { "PollId", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VoteAnswers_VoteId_QuestionId",
                table: "VoteAnswers",
                columns: new[] { "VoteId", "QuestionId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Votes_PollId_UserId",
                table: "Votes");

            migrationBuilder.DropIndex(
                name: "IX_VoteAnswers_VoteId_QuestionId",
                table: "VoteAnswers");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_PollId",
                table: "Votes",
                column: "PollId");

            migrationBuilder.CreateIndex(
                name: "IX_VoteAnswers_VoteId",
                table: "VoteAnswers",
                column: "VoteId");
        }
    }
}
