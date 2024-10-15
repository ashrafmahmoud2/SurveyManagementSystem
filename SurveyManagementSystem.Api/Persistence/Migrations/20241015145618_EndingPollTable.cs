﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SurveyManagementSystem.Api.Migrations
{
    /// <inheritdoc />
    public partial class EndingPollTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartAt",
                table: "Polls",
                newName: "StartsAt");

            migrationBuilder.RenameColumn(
                name: "EndAt",
                table: "Polls",
                newName: "EndsAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartsAt",
                table: "Polls",
                newName: "StartAt");

            migrationBuilder.RenameColumn(
                name: "EndsAt",
                table: "Polls",
                newName: "EndAt");
        }
    }
}
