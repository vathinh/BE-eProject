using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace survey_be.Migrations
{
    /// <inheritdoc />
    public partial class AddingRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
