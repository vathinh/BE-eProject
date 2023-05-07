using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace survey_be.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompetitionContents",
                columns: table => new
                {
                    CompetitionContentId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    TimeStartCompetition = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TimeEndCompetition = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    SurveyId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitionContents", x => x.CompetitionContentId);
                    table.ForeignKey(
                        name: "FK_CompetitionContents_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Surveys",
                        principalColumn: "SurveyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Faqs",
                columns: table => new
                {
                    FaqId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FaqQuestion = table.Column<string>(type: "text", nullable: false),
                    FaqContent = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faqs", x => x.FaqId);
                });

            migrationBuilder.CreateTable(
                name: "Prizes",
                columns: table => new
                {
                    PrizeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PrizeName = table.Column<string>(type: "text", nullable: false),
                    PrizeDescription = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prizes", x => x.PrizeId);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserRoleId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserRoleName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.UserRoleId);
                });

            migrationBuilder.CreateTable(
                name: "UserInfos",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    UserPassword = table.Column<string>(type: "text", nullable: false),
                    RollNo = table.Column<string>(type: "text", nullable: false),
                    UserClass = table.Column<string>(type: "text", nullable: false),
                    Specification = table.Column<string>(type: "text", nullable: false),
                    Section = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    UserRoleId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfos", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_UserInfos_UserRoles_UserRoleId",
                        column: x => x.UserRoleId,
                        principalTable: "UserRoles",
                        principalColumn: "UserRoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Responses",
                columns: table => new
                {
                    ResponseId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TotalMark = table.Column<int>(type: "integer", nullable: false),
                    SurveyId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responses", x => x.ResponseId);
                    table.ForeignKey(
                        name: "FK_Responses_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Surveys",
                        principalColumn: "SurveyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Responses_UserInfos_UserId",
                        column: x => x.UserId,
                        principalTable: "UserInfos",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupportInformations",
                columns: table => new
                {
                    SupportInformationId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SupportInformationContent = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportInformations", x => x.SupportInformationId);
                    table.ForeignKey(
                        name: "FK_SupportInformations_UserInfos_UserId",
                        column: x => x.UserId,
                        principalTable: "UserInfos",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompetitionResults",
                columns: table => new
                {
                    NumberUserJoined = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompetitionResultId = table.Column<int>(type: "integer", nullable: false),
                    ResponseId = table.Column<int>(type: "integer", nullable: false),
                    PrizeId = table.Column<int>(type: "integer", nullable: false),
                    CompetitionContentId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitionResults", x => x.NumberUserJoined);
                    table.ForeignKey(
                        name: "FK_CompetitionResults_CompetitionContents_CompetitionContentId",
                        column: x => x.CompetitionContentId,
                        principalTable: "CompetitionContents",
                        principalColumn: "CompetitionContentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompetitionResults_Prizes_PrizeId",
                        column: x => x.PrizeId,
                        principalTable: "Prizes",
                        principalColumn: "PrizeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompetitionResults_Responses_ResponseId",
                        column: x => x.ResponseId,
                        principalTable: "Responses",
                        principalColumn: "ResponseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CompetitionContents",
                columns: new[] { "CompetitionContentId", "Location", "Name", "SurveyId", "TimeEndCompetition", "TimeStartCompetition" },
                values: new object[,]
                {
                    { 1, "District 1", "Competition 1", 1, new DateTime(2023, 5, 14, 6, 48, 27, 55, DateTimeKind.Utc).AddTicks(1495), new DateTime(2023, 5, 7, 6, 48, 27, 55, DateTimeKind.Utc).AddTicks(1494) },
                    { 2, "District 2", "Competition 2", 2, new DateTime(2023, 5, 21, 6, 48, 27, 55, DateTimeKind.Utc).AddTicks(1505), new DateTime(2023, 5, 7, 6, 48, 27, 55, DateTimeKind.Utc).AddTicks(1505) },
                    { 3, "District 3", "Competition 3", 3, new DateTime(2023, 5, 28, 6, 48, 27, 55, DateTimeKind.Utc).AddTicks(1507), new DateTime(2023, 5, 7, 6, 48, 27, 55, DateTimeKind.Utc).AddTicks(1506) }
                });

            migrationBuilder.InsertData(
                table: "Faqs",
                columns: new[] { "FaqId", "FaqContent", "FaqQuestion" },
                values: new object[,]
                {
                    { 1, "We accept returns within 30 days of purchase with a valid receipt.", "What is your return policy?" },
                    { 2, "You can track your order by logging into your account or by using the tracking number provided in your shipping confirmation email.", "How do I track my order?" },
                    { 3, "We offer free shipping on orders over $50.", "Do you offer free shipping?" }
                });

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
                table: "UserRoles",
                columns: new[] { "UserRoleId", "UserRoleName" },
                values: new object[,]
                {
                    { 1, "Administrator" },
                    { 2, "Student" },
                    { 3, "Staff" }
                });

            migrationBuilder.InsertData(
                table: "UserInfos",
                columns: new[] { "UserId", "IsActive", "RollNo", "Section", "Specification", "UserClass", "UserName", "UserPassword", "UserRoleId" },
                values: new object[,]
                {
                    { 1, true, "", "", "", "", "admin", "adminpass", 1 },
                    { 2, true, "001", "A", "science", "12A", "john", "johnpass", 2 },
                    { 3, true, "101", "B", "arts", "11B", "jane", "janepass", 2 },
                    { 4, true, "", "", "librarian", "", "peter", "peterpass", 3 },
                    { 5, true, "", "", "teacher", "", "susan", "susanpass", 3 }
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
                table: "SupportInformations",
                columns: new[] { "SupportInformationId", "SupportInformationContent", "UserId" },
                values: new object[,]
                {
                    { 1, "I'm having trouble accessing my account.", 1 },
                    { 2, "I can't find the answer to my question.", 2 },
                    { 3, "I think there's a bug in the system.", 1 }
                });

            migrationBuilder.InsertData(
                table: "CompetitionResults",
                columns: new[] { "NumberUserJoined", "CompetitionContentId", "CompetitionResultId", "PrizeId", "ResponseId" },
                values: new object[,]
                {
                    { 8, 3, 0, 3, 3 },
                    { 10, 1, 0, 1, 1 },
                    { 15, 2, 0, 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionContents_SurveyId",
                table: "CompetitionContents",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionResults_CompetitionContentId",
                table: "CompetitionResults",
                column: "CompetitionContentId");

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionResults_PrizeId",
                table: "CompetitionResults",
                column: "PrizeId");

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionResults_ResponseId",
                table: "CompetitionResults",
                column: "ResponseId");

            migrationBuilder.CreateIndex(
                name: "IX_Responses_SurveyId",
                table: "Responses",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_Responses_UserId",
                table: "Responses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SupportInformations_UserId",
                table: "SupportInformations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInfos_UserRoleId",
                table: "UserInfos",
                column: "UserRoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompetitionResults");

            migrationBuilder.DropTable(
                name: "Faqs");

            migrationBuilder.DropTable(
                name: "SupportInformations");

            migrationBuilder.DropTable(
                name: "CompetitionContents");

            migrationBuilder.DropTable(
                name: "Prizes");

            migrationBuilder.DropTable(
                name: "Responses");

            migrationBuilder.DropTable(
                name: "UserInfos");

            migrationBuilder.DropTable(
                name: "UserRoles");
        }
    }
}
