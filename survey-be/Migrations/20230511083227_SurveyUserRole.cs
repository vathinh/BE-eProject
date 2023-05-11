using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace survey_be.Migrations
{
    /// <inheritdoc />
    public partial class SurveyUserRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "CompetitionContents",
                keyColumn: "CompetitionContentId",
                keyValue: 1,
                columns: new[] { "TimeEndCompetition", "TimeStartCompetition" },
                values: new object[] { new DateTime(2023, 5, 14, 6, 48, 27, 55, DateTimeKind.Utc).AddTicks(1495), new DateTime(2023, 5, 7, 6, 48, 27, 55, DateTimeKind.Utc).AddTicks(1494) });

            migrationBuilder.UpdateData(
                table: "CompetitionContents",
                keyColumn: "CompetitionContentId",
                keyValue: 2,
                columns: new[] { "TimeEndCompetition", "TimeStartCompetition" },
                values: new object[] { new DateTime(2023, 5, 21, 6, 48, 27, 55, DateTimeKind.Utc).AddTicks(1505), new DateTime(2023, 5, 7, 6, 48, 27, 55, DateTimeKind.Utc).AddTicks(1505) });

            migrationBuilder.UpdateData(
                table: "CompetitionContents",
                keyColumn: "CompetitionContentId",
                keyValue: 3,
                columns: new[] { "TimeEndCompetition", "TimeStartCompetition" },
                values: new object[] { new DateTime(2023, 5, 28, 6, 48, 27, 55, DateTimeKind.Utc).AddTicks(1507), new DateTime(2023, 5, 7, 6, 48, 27, 55, DateTimeKind.Utc).AddTicks(1506) });
        }
    }
}
