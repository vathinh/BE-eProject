using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace survey_be.Migrations
{
    /// <inheritdoc />
    public partial class RemoveQuestionTitle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Questions");

            migrationBuilder.UpdateData(
                table: "CompetitionContents",
                keyColumn: "CompetitionContentId",
                keyValue: 1,
                columns: new[] { "TimeEndCompetition", "TimeStartCompetition" },
                values: new object[] { new DateTime(2023, 5, 23, 10, 13, 0, 952, DateTimeKind.Utc).AddTicks(6176), new DateTime(2023, 5, 16, 10, 13, 0, 952, DateTimeKind.Utc).AddTicks(6175) });

            migrationBuilder.UpdateData(
                table: "CompetitionContents",
                keyColumn: "CompetitionContentId",
                keyValue: 2,
                columns: new[] { "TimeEndCompetition", "TimeStartCompetition" },
                values: new object[] { new DateTime(2023, 5, 30, 10, 13, 0, 952, DateTimeKind.Utc).AddTicks(6182), new DateTime(2023, 5, 16, 10, 13, 0, 952, DateTimeKind.Utc).AddTicks(6182) });

            migrationBuilder.UpdateData(
                table: "CompetitionContents",
                keyColumn: "CompetitionContentId",
                keyValue: 3,
                columns: new[] { "TimeEndCompetition", "TimeStartCompetition" },
                values: new object[] { new DateTime(2023, 6, 6, 10, 13, 0, 952, DateTimeKind.Utc).AddTicks(6184), new DateTime(2023, 5, 16, 10, 13, 0, 952, DateTimeKind.Utc).AddTicks(6184) });

            migrationBuilder.UpdateData(
                table: "UserInfos",
                keyColumn: "UserId",
                keyValue: 1,
                column: "AdmissionDate",
                value: new DateTime(2023, 5, 16, 10, 13, 0, 952, DateTimeKind.Utc).AddTicks(6113));

            migrationBuilder.UpdateData(
                table: "UserInfos",
                keyColumn: "UserId",
                keyValue: 2,
                column: "AdmissionDate",
                value: new DateTime(2023, 5, 16, 10, 13, 0, 952, DateTimeKind.Utc).AddTicks(6115));

            migrationBuilder.UpdateData(
                table: "UserInfos",
                keyColumn: "UserId",
                keyValue: 3,
                column: "AdmissionDate",
                value: new DateTime(2023, 5, 16, 10, 13, 0, 952, DateTimeKind.Utc).AddTicks(6117));

            migrationBuilder.UpdateData(
                table: "UserInfos",
                keyColumn: "UserId",
                keyValue: 4,
                column: "AdmissionDate",
                value: new DateTime(2023, 5, 16, 10, 13, 0, 952, DateTimeKind.Utc).AddTicks(6119));

            migrationBuilder.UpdateData(
                table: "UserInfos",
                keyColumn: "UserId",
                keyValue: 5,
                column: "AdmissionDate",
                value: new DateTime(2023, 5, 16, 10, 13, 0, 952, DateTimeKind.Utc).AddTicks(6120));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Questions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "CompetitionContents",
                keyColumn: "CompetitionContentId",
                keyValue: 1,
                columns: new[] { "TimeEndCompetition", "TimeStartCompetition" },
                values: new object[] { new DateTime(2023, 5, 23, 7, 13, 38, 97, DateTimeKind.Utc).AddTicks(5011), new DateTime(2023, 5, 16, 7, 13, 38, 97, DateTimeKind.Utc).AddTicks(5010) });

            migrationBuilder.UpdateData(
                table: "CompetitionContents",
                keyColumn: "CompetitionContentId",
                keyValue: 2,
                columns: new[] { "TimeEndCompetition", "TimeStartCompetition" },
                values: new object[] { new DateTime(2023, 5, 30, 7, 13, 38, 97, DateTimeKind.Utc).AddTicks(5016), new DateTime(2023, 5, 16, 7, 13, 38, 97, DateTimeKind.Utc).AddTicks(5016) });

            migrationBuilder.UpdateData(
                table: "CompetitionContents",
                keyColumn: "CompetitionContentId",
                keyValue: 3,
                columns: new[] { "TimeEndCompetition", "TimeStartCompetition" },
                values: new object[] { new DateTime(2023, 6, 6, 7, 13, 38, 97, DateTimeKind.Utc).AddTicks(5018), new DateTime(2023, 5, 16, 7, 13, 38, 97, DateTimeKind.Utc).AddTicks(5018) });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 1,
                column: "Title",
                value: "Question 1");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 2,
                column: "Title",
                value: "Question 2");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 3,
                column: "Title",
                value: "Question 3");

            migrationBuilder.UpdateData(
                table: "UserInfos",
                keyColumn: "UserId",
                keyValue: 1,
                column: "AdmissionDate",
                value: new DateTime(2023, 5, 16, 7, 13, 38, 97, DateTimeKind.Utc).AddTicks(4917));

            migrationBuilder.UpdateData(
                table: "UserInfos",
                keyColumn: "UserId",
                keyValue: 2,
                column: "AdmissionDate",
                value: new DateTime(2023, 5, 16, 7, 13, 38, 97, DateTimeKind.Utc).AddTicks(4920));

            migrationBuilder.UpdateData(
                table: "UserInfos",
                keyColumn: "UserId",
                keyValue: 3,
                column: "AdmissionDate",
                value: new DateTime(2023, 5, 16, 7, 13, 38, 97, DateTimeKind.Utc).AddTicks(4922));

            migrationBuilder.UpdateData(
                table: "UserInfos",
                keyColumn: "UserId",
                keyValue: 4,
                column: "AdmissionDate",
                value: new DateTime(2023, 5, 16, 7, 13, 38, 97, DateTimeKind.Utc).AddTicks(4924));

            migrationBuilder.UpdateData(
                table: "UserInfos",
                keyColumn: "UserId",
                keyValue: 5,
                column: "AdmissionDate",
                value: new DateTime(2023, 5, 16, 7, 13, 38, 97, DateTimeKind.Utc).AddTicks(4926));
        }
    }
}
