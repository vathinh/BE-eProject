using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace survey_be.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Responses_UserRoles_UserRoleId",
                table: "Responses");

            migrationBuilder.DropIndex(
                name: "IX_Responses_UserRoleId",
                table: "Responses");

            migrationBuilder.DropColumn(
                name: "UserRoleId",
                table: "Responses");

            migrationBuilder.AddColumn<int>(
                name: "UserRoleId",
                table: "Surveys",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "CompetitionContents",
                keyColumn: "CompetitionContentId",
                keyValue: 1,
                columns: new[] { "TimeEndCompetition", "TimeStartCompetition" },
                values: new object[] { new DateTime(2023, 5, 18, 8, 56, 30, 884, DateTimeKind.Utc).AddTicks(3009), new DateTime(2023, 5, 11, 8, 56, 30, 884, DateTimeKind.Utc).AddTicks(3007) });

            migrationBuilder.UpdateData(
                table: "CompetitionContents",
                keyColumn: "CompetitionContentId",
                keyValue: 2,
                columns: new[] { "TimeEndCompetition", "TimeStartCompetition" },
                values: new object[] { new DateTime(2023, 5, 25, 8, 56, 30, 884, DateTimeKind.Utc).AddTicks(3017), new DateTime(2023, 5, 11, 8, 56, 30, 884, DateTimeKind.Utc).AddTicks(3016) });

            migrationBuilder.UpdateData(
                table: "CompetitionContents",
                keyColumn: "CompetitionContentId",
                keyValue: 3,
                columns: new[] { "TimeEndCompetition", "TimeStartCompetition" },
                values: new object[] { new DateTime(2023, 6, 1, 8, 56, 30, 884, DateTimeKind.Utc).AddTicks(3019), new DateTime(2023, 5, 11, 8, 56, 30, 884, DateTimeKind.Utc).AddTicks(3018) });

            migrationBuilder.UpdateData(
                table: "Surveys",
                keyColumn: "SurveyId",
                keyValue: 1,
                column: "UserRoleId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Surveys",
                keyColumn: "SurveyId",
                keyValue: 2,
                column: "UserRoleId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Surveys",
                keyColumn: "SurveyId",
                keyValue: 3,
                column: "UserRoleId",
                value: 3);

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_UserRoleId",
                table: "Surveys",
                column: "UserRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Surveys_UserRoles_UserRoleId",
                table: "Surveys",
                column: "UserRoleId",
                principalTable: "UserRoles",
                principalColumn: "UserRoleId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Surveys_UserRoles_UserRoleId",
                table: "Surveys");

            migrationBuilder.DropIndex(
                name: "IX_Surveys_UserRoleId",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "UserRoleId",
                table: "Surveys");

            migrationBuilder.AddColumn<int>(
                name: "UserRoleId",
                table: "Responses",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "CompetitionContents",
                keyColumn: "CompetitionContentId",
                keyValue: 1,
                columns: new[] { "TimeEndCompetition", "TimeStartCompetition" },
                values: new object[] { new DateTime(2023, 5, 18, 8, 32, 27, 482, DateTimeKind.Utc).AddTicks(723), new DateTime(2023, 5, 11, 8, 32, 27, 482, DateTimeKind.Utc).AddTicks(719) });

            migrationBuilder.UpdateData(
                table: "CompetitionContents",
                keyColumn: "CompetitionContentId",
                keyValue: 2,
                columns: new[] { "TimeEndCompetition", "TimeStartCompetition" },
                values: new object[] { new DateTime(2023, 5, 25, 8, 32, 27, 482, DateTimeKind.Utc).AddTicks(735), new DateTime(2023, 5, 11, 8, 32, 27, 482, DateTimeKind.Utc).AddTicks(735) });

            migrationBuilder.UpdateData(
                table: "CompetitionContents",
                keyColumn: "CompetitionContentId",
                keyValue: 3,
                columns: new[] { "TimeEndCompetition", "TimeStartCompetition" },
                values: new object[] { new DateTime(2023, 6, 1, 8, 32, 27, 482, DateTimeKind.Utc).AddTicks(737), new DateTime(2023, 5, 11, 8, 32, 27, 482, DateTimeKind.Utc).AddTicks(737) });

            migrationBuilder.UpdateData(
                table: "Responses",
                keyColumn: "ResponseId",
                keyValue: 1,
                column: "UserRoleId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Responses",
                keyColumn: "ResponseId",
                keyValue: 2,
                column: "UserRoleId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Responses",
                keyColumn: "ResponseId",
                keyValue: 3,
                column: "UserRoleId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Responses",
                keyColumn: "ResponseId",
                keyValue: 4,
                column: "UserRoleId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Responses",
                keyColumn: "ResponseId",
                keyValue: 5,
                column: "UserRoleId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Responses",
                keyColumn: "ResponseId",
                keyValue: 6,
                column: "UserRoleId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Responses",
                keyColumn: "ResponseId",
                keyValue: 7,
                column: "UserRoleId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Responses",
                keyColumn: "ResponseId",
                keyValue: 8,
                column: "UserRoleId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Responses",
                keyColumn: "ResponseId",
                keyValue: 9,
                column: "UserRoleId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Responses_UserRoleId",
                table: "Responses",
                column: "UserRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Responses_UserRoles_UserRoleId",
                table: "Responses",
                column: "UserRoleId",
                principalTable: "UserRoles",
                principalColumn: "UserRoleId");
        }
    }
}
