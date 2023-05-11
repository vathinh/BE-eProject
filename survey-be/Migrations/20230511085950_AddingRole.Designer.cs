﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using survey_be.Data;

#nullable disable

namespace survey_be.Migrations
{
    [DbContext(typeof(SurveyDbContext))]
    [Migration("20230511085950_AddingRole")]
    partial class AddingRole
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("survey_be.Models.Answer", b =>
                {
                    b.Property<int>("AnswerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AnswerId"));

                    b.Property<string>("AnswerContent")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("CorrectAnswer")
                        .HasColumnType("boolean");

                    b.Property<int>("QuestionId")
                        .HasColumnType("integer");

                    b.HasKey("AnswerId");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers");

                    b.HasData(
                        new
                        {
                            AnswerId = 1,
                            AnswerContent = "Answer Content 1",
                            CorrectAnswer = true,
                            QuestionId = 1
                        },
                        new
                        {
                            AnswerId = 2,
                            AnswerContent = "Answer Content 2",
                            CorrectAnswer = false,
                            QuestionId = 1
                        },
                        new
                        {
                            AnswerId = 3,
                            AnswerContent = "Answer Content 3",
                            CorrectAnswer = true,
                            QuestionId = 2
                        });
                });

            modelBuilder.Entity("survey_be.Models.CompetitionContent", b =>
                {
                    b.Property<int>("CompetitionContentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CompetitionContentId"));

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("SurveyId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("TimeEndCompetition")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("TimeStartCompetition")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("CompetitionContentId");

                    b.HasIndex("SurveyId");

                    b.ToTable("CompetitionContents");

                    b.HasData(
                        new
                        {
                            CompetitionContentId = 1,
                            Location = "District 1",
                            Name = "Competition 1",
                            SurveyId = 1,
                            TimeEndCompetition = new DateTime(2023, 5, 18, 8, 59, 50, 830, DateTimeKind.Utc).AddTicks(4051),
                            TimeStartCompetition = new DateTime(2023, 5, 11, 8, 59, 50, 830, DateTimeKind.Utc).AddTicks(4049)
                        },
                        new
                        {
                            CompetitionContentId = 2,
                            Location = "District 2",
                            Name = "Competition 2",
                            SurveyId = 2,
                            TimeEndCompetition = new DateTime(2023, 5, 25, 8, 59, 50, 830, DateTimeKind.Utc).AddTicks(4059),
                            TimeStartCompetition = new DateTime(2023, 5, 11, 8, 59, 50, 830, DateTimeKind.Utc).AddTicks(4058)
                        },
                        new
                        {
                            CompetitionContentId = 3,
                            Location = "District 3",
                            Name = "Competition 3",
                            SurveyId = 3,
                            TimeEndCompetition = new DateTime(2023, 6, 1, 8, 59, 50, 830, DateTimeKind.Utc).AddTicks(4061),
                            TimeStartCompetition = new DateTime(2023, 5, 11, 8, 59, 50, 830, DateTimeKind.Utc).AddTicks(4060)
                        });
                });

            modelBuilder.Entity("survey_be.Models.CompetitionResult", b =>
                {
                    b.Property<int>("NumberUserJoined")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("NumberUserJoined"));

                    b.Property<int>("CompetitionContentId")
                        .HasColumnType("integer");

                    b.Property<int>("CompetitionResultId")
                        .HasColumnType("integer");

                    b.Property<int>("PrizeId")
                        .HasColumnType("integer");

                    b.Property<int>("ResponseId")
                        .HasColumnType("integer");

                    b.HasKey("NumberUserJoined");

                    b.HasIndex("CompetitionContentId");

                    b.HasIndex("PrizeId");

                    b.HasIndex("ResponseId");

                    b.ToTable("CompetitionResults");

                    b.HasData(
                        new
                        {
                            NumberUserJoined = 10,
                            CompetitionContentId = 1,
                            CompetitionResultId = 0,
                            PrizeId = 1,
                            ResponseId = 1
                        },
                        new
                        {
                            NumberUserJoined = 15,
                            CompetitionContentId = 2,
                            CompetitionResultId = 0,
                            PrizeId = 2,
                            ResponseId = 2
                        },
                        new
                        {
                            NumberUserJoined = 8,
                            CompetitionContentId = 3,
                            CompetitionResultId = 0,
                            PrizeId = 3,
                            ResponseId = 3
                        });
                });

            modelBuilder.Entity("survey_be.Models.Faq", b =>
                {
                    b.Property<int>("FaqId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("FaqId"));

                    b.Property<string>("FaqContent")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FaqQuestion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("FaqId");

                    b.ToTable("Faqs");

                    b.HasData(
                        new
                        {
                            FaqId = 1,
                            FaqContent = "We accept returns within 30 days of purchase with a valid receipt.",
                            FaqQuestion = "What is your return policy?"
                        },
                        new
                        {
                            FaqId = 2,
                            FaqContent = "You can track your order by logging into your account or by using the tracking number provided in your shipping confirmation email.",
                            FaqQuestion = "How do I track my order?"
                        },
                        new
                        {
                            FaqId = 3,
                            FaqContent = "We offer free shipping on orders over $50.",
                            FaqQuestion = "Do you offer free shipping?"
                        });
                });

            modelBuilder.Entity("survey_be.Models.Prize", b =>
                {
                    b.Property<int>("PrizeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PrizeId"));

                    b.Property<string>("PrizeDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PrizeName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PrizeId");

                    b.ToTable("Prizes");

                    b.HasData(
                        new
                        {
                            PrizeId = 1,
                            PrizeDescription = "A brand new iPhone",
                            PrizeName = "First Prize"
                        },
                        new
                        {
                            PrizeId = 2,
                            PrizeDescription = "A high-end gaming laptop",
                            PrizeName = "Second Prize"
                        },
                        new
                        {
                            PrizeId = 3,
                            PrizeDescription = "A 50-inch 4K Smart TV",
                            PrizeName = "Third Prize"
                        });
                });

            modelBuilder.Entity("survey_be.Models.Question", b =>
                {
                    b.Property<int>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("QuestionId"));

                    b.Property<string>("QuestionContent")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("SurveyId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("QuestionId");

                    b.HasIndex("SurveyId");

                    b.ToTable("Questions");

                    b.HasData(
                        new
                        {
                            QuestionId = 1,
                            QuestionContent = "Question Content 1",
                            SurveyId = 1,
                            Title = "Question 1",
                            Type = "Type 1"
                        },
                        new
                        {
                            QuestionId = 2,
                            QuestionContent = "Question Content 2",
                            SurveyId = 1,
                            Title = "Question 2",
                            Type = "Type 2"
                        },
                        new
                        {
                            QuestionId = 3,
                            QuestionContent = "Question Content 3",
                            SurveyId = 2,
                            Title = "Question 3",
                            Type = "Type 3"
                        });
                });

            modelBuilder.Entity("survey_be.Models.Response", b =>
                {
                    b.Property<int>("ResponseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ResponseId"));

                    b.Property<int>("SurveyId")
                        .HasColumnType("integer");

                    b.Property<int>("TotalMark")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("ResponseId");

                    b.HasIndex("SurveyId");

                    b.HasIndex("UserId");

                    b.ToTable("Responses");

                    b.HasData(
                        new
                        {
                            ResponseId = 1,
                            SurveyId = 1,
                            TotalMark = 8,
                            UserId = 1
                        },
                        new
                        {
                            ResponseId = 2,
                            SurveyId = 1,
                            TotalMark = 6,
                            UserId = 2
                        },
                        new
                        {
                            ResponseId = 3,
                            SurveyId = 1,
                            TotalMark = 9,
                            UserId = 3
                        },
                        new
                        {
                            ResponseId = 4,
                            SurveyId = 2,
                            TotalMark = 7,
                            UserId = 1
                        },
                        new
                        {
                            ResponseId = 5,
                            SurveyId = 2,
                            TotalMark = 5,
                            UserId = 2
                        },
                        new
                        {
                            ResponseId = 6,
                            SurveyId = 2,
                            TotalMark = 8,
                            UserId = 3
                        },
                        new
                        {
                            ResponseId = 7,
                            SurveyId = 3,
                            TotalMark = 9,
                            UserId = 1
                        },
                        new
                        {
                            ResponseId = 8,
                            SurveyId = 3,
                            TotalMark = 7,
                            UserId = 2
                        },
                        new
                        {
                            ResponseId = 9,
                            SurveyId = 3,
                            TotalMark = 8,
                            UserId = 3
                        });
                });

            modelBuilder.Entity("survey_be.Models.SupportInformation", b =>
                {
                    b.Property<int>("SupportInformationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SupportInformationId"));

                    b.Property<string>("SupportInformationContent")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("SupportInformationId");

                    b.HasIndex("UserId");

                    b.ToTable("SupportInformations");

                    b.HasData(
                        new
                        {
                            SupportInformationId = 1,
                            SupportInformationContent = "I'm having trouble accessing my account.",
                            UserId = 1
                        },
                        new
                        {
                            SupportInformationId = 2,
                            SupportInformationContent = "I can't find the answer to my question.",
                            UserId = 2
                        },
                        new
                        {
                            SupportInformationId = 3,
                            SupportInformationContent = "I think there's a bug in the system.",
                            UserId = 1
                        });
                });

            modelBuilder.Entity("survey_be.Models.Survey", b =>
                {
                    b.Property<int>("SurveyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SurveyId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Img")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserRoleId")
                        .HasColumnType("integer");

                    b.HasKey("SurveyId");

                    b.HasIndex("UserRoleId");

                    b.ToTable("Surveys");

                    b.HasData(
                        new
                        {
                            SurveyId = 1,
                            Description = "Description for Survey 1",
                            Img = "img1.jpg",
                            Title = "Survey 1",
                            UserRoleId = 2
                        },
                        new
                        {
                            SurveyId = 2,
                            Description = "Description for Survey 2",
                            Img = "img2.jpg",
                            Title = "Survey 2",
                            UserRoleId = 2
                        },
                        new
                        {
                            SurveyId = 3,
                            Description = "Description for Survey 3",
                            Img = "img3.jpg",
                            Title = "Survey 3",
                            UserRoleId = 3
                        });
                });

            modelBuilder.Entity("survey_be.Models.UserInfo", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("RollNo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Section")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Specification")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserClass")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserPassword")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserRoleId")
                        .HasColumnType("integer");

                    b.HasKey("UserId");

                    b.HasIndex("UserRoleId");

                    b.ToTable("UserInfos");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            IsActive = true,
                            RollNo = "",
                            Section = "",
                            Specification = "",
                            UserClass = "",
                            UserName = "admin",
                            UserPassword = "adminpass",
                            UserRoleId = 1
                        },
                        new
                        {
                            UserId = 2,
                            IsActive = true,
                            RollNo = "001",
                            Section = "A",
                            Specification = "science",
                            UserClass = "12A",
                            UserName = "john",
                            UserPassword = "johnpass",
                            UserRoleId = 2
                        },
                        new
                        {
                            UserId = 3,
                            IsActive = true,
                            RollNo = "101",
                            Section = "B",
                            Specification = "arts",
                            UserClass = "11B",
                            UserName = "jane",
                            UserPassword = "janepass",
                            UserRoleId = 2
                        },
                        new
                        {
                            UserId = 4,
                            IsActive = true,
                            RollNo = "",
                            Section = "",
                            Specification = "librarian",
                            UserClass = "",
                            UserName = "peter",
                            UserPassword = "peterpass",
                            UserRoleId = 3
                        },
                        new
                        {
                            UserId = 5,
                            IsActive = true,
                            RollNo = "",
                            Section = "",
                            Specification = "teacher",
                            UserClass = "",
                            UserName = "susan",
                            UserPassword = "susanpass",
                            UserRoleId = 3
                        });
                });

            modelBuilder.Entity("survey_be.Models.UserRole", b =>
                {
                    b.Property<int>("UserRoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserRoleId"));

                    b.Property<string>("UserRoleName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserRoleId");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            UserRoleId = 1,
                            UserRoleName = "Administrator"
                        },
                        new
                        {
                            UserRoleId = 2,
                            UserRoleName = "Student"
                        },
                        new
                        {
                            UserRoleId = 3,
                            UserRoleName = "Staff"
                        });
                });

            modelBuilder.Entity("survey_be.Models.Answer", b =>
                {
                    b.HasOne("survey_be.Models.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("survey_be.Models.CompetitionContent", b =>
                {
                    b.HasOne("survey_be.Models.Survey", "Survey")
                        .WithMany("CompetitionContents")
                        .HasForeignKey("SurveyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Survey");
                });

            modelBuilder.Entity("survey_be.Models.CompetitionResult", b =>
                {
                    b.HasOne("survey_be.Models.CompetitionContent", "CompetitionContent")
                        .WithMany("CompetitionResults")
                        .HasForeignKey("CompetitionContentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("survey_be.Models.Prize", "Prize")
                        .WithMany("CompetitionResults")
                        .HasForeignKey("PrizeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("survey_be.Models.Response", "Response")
                        .WithMany("CompetitionResults")
                        .HasForeignKey("ResponseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CompetitionContent");

                    b.Navigation("Prize");

                    b.Navigation("Response");
                });

            modelBuilder.Entity("survey_be.Models.Question", b =>
                {
                    b.HasOne("survey_be.Models.Survey", "Survey")
                        .WithMany("Questions")
                        .HasForeignKey("SurveyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Survey");
                });

            modelBuilder.Entity("survey_be.Models.Response", b =>
                {
                    b.HasOne("survey_be.Models.Survey", "Survey")
                        .WithMany("Responses")
                        .HasForeignKey("SurveyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("survey_be.Models.UserInfo", "UserInfo")
                        .WithMany("Responses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Survey");

                    b.Navigation("UserInfo");
                });

            modelBuilder.Entity("survey_be.Models.SupportInformation", b =>
                {
                    b.HasOne("survey_be.Models.UserInfo", "UserInfo")
                        .WithMany("SupportInformations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserInfo");
                });

            modelBuilder.Entity("survey_be.Models.Survey", b =>
                {
                    b.HasOne("survey_be.Models.UserRole", "UserRole")
                        .WithMany("Surveys")
                        .HasForeignKey("UserRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("survey_be.Models.UserInfo", b =>
                {
                    b.HasOne("survey_be.Models.UserRole", "UserRole")
                        .WithMany("UserInfos")
                        .HasForeignKey("UserRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("survey_be.Models.CompetitionContent", b =>
                {
                    b.Navigation("CompetitionResults");
                });

            modelBuilder.Entity("survey_be.Models.Prize", b =>
                {
                    b.Navigation("CompetitionResults");
                });

            modelBuilder.Entity("survey_be.Models.Question", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("survey_be.Models.Response", b =>
                {
                    b.Navigation("CompetitionResults");
                });

            modelBuilder.Entity("survey_be.Models.Survey", b =>
                {
                    b.Navigation("CompetitionContents");

                    b.Navigation("Questions");

                    b.Navigation("Responses");
                });

            modelBuilder.Entity("survey_be.Models.UserInfo", b =>
                {
                    b.Navigation("Responses");

                    b.Navigation("SupportInformations");
                });

            modelBuilder.Entity("survey_be.Models.UserRole", b =>
                {
                    b.Navigation("Surveys");

                    b.Navigation("UserInfos");
                });
#pragma warning restore 612, 618
        }
    }
}
