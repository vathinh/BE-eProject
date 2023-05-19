using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace survey_be.Migrations
{
    /// <inheritdoc />
    public partial class NameMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CompetitionResults",
                table: "CompetitionResults");

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CompetitionResults",
                keyColumn: "CompetitionResultId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CompetitionResults",
                keyColumn: "CompetitionResultId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CompetitionResults",
                keyColumn: "CompetitionResultId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "ResponseId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "ResponseId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "ResponseId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "ResponseId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "ResponseId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "ResponseId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "CompetitionContents",
                keyColumn: "CompetitionContentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CompetitionContents",
                keyColumn: "CompetitionContentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CompetitionContents",
                keyColumn: "CompetitionContentId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Prizes",
                keyColumn: "PrizeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Prizes",
                keyColumn: "PrizeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Prizes",
                keyColumn: "PrizeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "ResponseId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "ResponseId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "ResponseId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Surveys",
                keyColumn: "SurveyId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Surveys",
                keyColumn: "SurveyId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Surveys",
                keyColumn: "SurveyId",
                keyValue: 3);

            migrationBuilder.AlterColumn<int>(
                name: "NumberUserJoined",
                table: "CompetitionResults",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "CompetitionResultId",
                table: "CompetitionResults",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompetitionResults",
                table: "CompetitionResults",
                column: "NumberUserJoined");

            migrationBuilder.UpdateData(
                table: "UserInfos",
                keyColumn: "UserId",
                keyValue: 1,
                column: "AdmissionDate",
                value: new DateTime(2023, 5, 19, 11, 12, 24, 563, DateTimeKind.Utc).AddTicks(5121));

            migrationBuilder.UpdateData(
                table: "UserInfos",
                keyColumn: "UserId",
                keyValue: 2,
                column: "AdmissionDate",
                value: new DateTime(2023, 5, 19, 11, 12, 24, 563, DateTimeKind.Utc).AddTicks(5128));

            migrationBuilder.UpdateData(
                table: "UserInfos",
                keyColumn: "UserId",
                keyValue: 3,
                column: "AdmissionDate",
                value: new DateTime(2023, 5, 19, 11, 12, 24, 563, DateTimeKind.Utc).AddTicks(5131));

            migrationBuilder.UpdateData(
                table: "UserInfos",
                keyColumn: "UserId",
                keyValue: 4,
                column: "AdmissionDate",
                value: new DateTime(2023, 5, 19, 11, 12, 24, 563, DateTimeKind.Utc).AddTicks(5134));

            migrationBuilder.UpdateData(
                table: "UserInfos",
                keyColumn: "UserId",
                keyValue: 5,
                column: "AdmissionDate",
                value: new DateTime(2023, 5, 19, 11, 12, 24, 563, DateTimeKind.Utc).AddTicks(5136));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CompetitionResults",
                table: "CompetitionResults");

            migrationBuilder.AlterColumn<int>(
                name: "CompetitionResultId",
                table: "CompetitionResults",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "NumberUserJoined",
                table: "CompetitionResults",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompetitionResults",
                table: "CompetitionResults",
                column: "CompetitionResultId");

            migrationBuilder.InsertData(
                table: "Prizes",
                columns: new[] { "PrizeId", "PrizeDescription", "PrizeName" },
                values: new object[,]
                {
                    { 1, "A brand new iPhone", "First Prize" },
                    { 2, "A high-end gaming laptop", "Second Prize" },
                    { 3, "A 50-inch 4K Smart TV", "Third Prize" }
                });

            migrationBuilder.InsertData(
                table: "Surveys",
                columns: new[] { "SurveyId", "Description", "Img", "Title", "UserRoleId" },
                values: new object[,]
                {
                    { 1, "Description for Survey 1", "img1.jpg", "Survey 1", 2 },
                    { 2, "Description for Survey 2", "img2.jpg", "Survey 2", 2 },
                    { 3, "Description for Survey 3", "img3.jpg", "Survey 3", 3 }
                });

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

            migrationBuilder.InsertData(
                table: "CompetitionContents",
                columns: new[] { "CompetitionContentId", "Location", "Name", "SurveyId", "TimeEndCompetition", "TimeStartCompetition" },
                values: new object[,]
                {
                    { 1, "District 1", "Competition 1", 1, new DateTime(2023, 5, 23, 10, 13, 0, 952, DateTimeKind.Utc).AddTicks(6176), new DateTime(2023, 5, 16, 10, 13, 0, 952, DateTimeKind.Utc).AddTicks(6175) },
                    { 2, "District 2", "Competition 2", 2, new DateTime(2023, 5, 30, 10, 13, 0, 952, DateTimeKind.Utc).AddTicks(6182), new DateTime(2023, 5, 16, 10, 13, 0, 952, DateTimeKind.Utc).AddTicks(6182) },
                    { 3, "District 3", "Competition 3", 3, new DateTime(2023, 6, 6, 10, 13, 0, 952, DateTimeKind.Utc).AddTicks(6184), new DateTime(2023, 5, 16, 10, 13, 0, 952, DateTimeKind.Utc).AddTicks(6184) }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "QuestionId", "QuestionContent", "SurveyId", "Type" },
                values: new object[,]
                {
                    { 1, "Question Content 1", 1, "Type 1" },
                    { 2, "Question Content 2", 1, "Type 2" },
                    { 3, "Question Content 3", 2, "Type 3" }
                });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "ResponseId", "SurveyId", "TotalMark", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 8, 1 },
                    { 2, 1, 6, 2 },
                    { 3, 1, 9, 3 },
                    { 4, 2, 7, 1 },
                    { 5, 2, 5, 2 },
                    { 6, 2, 8, 3 },
                    { 7, 3, 9, 1 },
                    { 8, 3, 7, 2 },
                    { 9, 3, 8, 3 }
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "AnswerId", "AnswerContent", "CorrectAnswer", "QuestionId" },
                values: new object[,]
                {
                    { 1, "Answer Content 1", true, 1 },
                    { 2, "Answer Content 2", false, 1 },
                    { 3, "Answer Content 3", true, 2 }
                });

            migrationBuilder.InsertData(
                table: "CompetitionResults",
                columns: new[] { "CompetitionResultId", "CompetitionContentId", "NumberUserJoined", "PrizeId", "ResponseId" },
                values: new object[,]
                {
                    { 1, 1, 10, 1, 1 },
                    { 2, 2, 15, 2, 2 },
                    { 3, 3, 8, 3, 3 }
                });
        }
    }
}
