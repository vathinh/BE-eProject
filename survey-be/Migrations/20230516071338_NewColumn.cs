using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace survey_be.Migrations
{
    /// <inheritdoc />
    public partial class NewColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AdmissionDate",
                table: "UserInfos",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "UserInfos",
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
                table: "UserInfos",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "AdmissionDate", "FullName" },
                values: new object[] { new DateTime(2023, 5, 16, 7, 13, 38, 97, DateTimeKind.Utc).AddTicks(4917), "Admin Fullname" });

            migrationBuilder.UpdateData(
                table: "UserInfos",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "AdmissionDate", "FullName" },
                values: new object[] { new DateTime(2023, 5, 16, 7, 13, 38, 97, DateTimeKind.Utc).AddTicks(4920), "john Fullname" });

            migrationBuilder.UpdateData(
                table: "UserInfos",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "AdmissionDate", "FullName" },
                values: new object[] { new DateTime(2023, 5, 16, 7, 13, 38, 97, DateTimeKind.Utc).AddTicks(4922), "jane Fullname" });

            migrationBuilder.UpdateData(
                table: "UserInfos",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "AdmissionDate", "FullName" },
                values: new object[] { new DateTime(2023, 5, 16, 7, 13, 38, 97, DateTimeKind.Utc).AddTicks(4924), "peter Fullname" });

            migrationBuilder.UpdateData(
                table: "UserInfos",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "AdmissionDate", "FullName" },
                values: new object[] { new DateTime(2023, 5, 16, 7, 13, 38, 97, DateTimeKind.Utc).AddTicks(4926), "susan Fullname" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdmissionDate",
                table: "UserInfos");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "UserInfos");

            migrationBuilder.UpdateData(
                table: "CompetitionContents",
                keyColumn: "CompetitionContentId",
                keyValue: 1,
                columns: new[] { "TimeEndCompetition", "TimeStartCompetition" },
                values: new object[] { new DateTime(2023, 5, 18, 8, 59, 50, 830, DateTimeKind.Utc).AddTicks(4051), new DateTime(2023, 5, 11, 8, 59, 50, 830, DateTimeKind.Utc).AddTicks(4049) });

            migrationBuilder.UpdateData(
                table: "CompetitionContents",
                keyColumn: "CompetitionContentId",
                keyValue: 2,
                columns: new[] { "TimeEndCompetition", "TimeStartCompetition" },
                values: new object[] { new DateTime(2023, 5, 25, 8, 59, 50, 830, DateTimeKind.Utc).AddTicks(4059), new DateTime(2023, 5, 11, 8, 59, 50, 830, DateTimeKind.Utc).AddTicks(4058) });

            migrationBuilder.UpdateData(
                table: "CompetitionContents",
                keyColumn: "CompetitionContentId",
                keyValue: 3,
                columns: new[] { "TimeEndCompetition", "TimeStartCompetition" },
                values: new object[] { new DateTime(2023, 6, 1, 8, 59, 50, 830, DateTimeKind.Utc).AddTicks(4061), new DateTime(2023, 5, 11, 8, 59, 50, 830, DateTimeKind.Utc).AddTicks(4060) });
        }
    }
}
