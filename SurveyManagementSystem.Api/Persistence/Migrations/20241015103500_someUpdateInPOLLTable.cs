using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SurveyManagementSystem.Api.Migrations
{
    /// <inheritdoc />
    public partial class someUpdateInPOLLTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "Polls",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Polls_Title",
                table: "Polls",
                column: "Title",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Polls_Title",
                table: "Polls");

            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "Polls");
        }
    }
}
