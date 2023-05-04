﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using survey_be.Data;

#nullable disable

namespace survey_be.Migrations
{
    [DbContext(typeof(SurveyDbContext))]
    partial class SurveyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.HasKey("SurveyId");

                    b.ToTable("Surveys");

                    b.HasData(
                        new
                        {
                            SurveyId = 1,
                            Description = "Description for Survey 1",
                            Img = "img1.jpg",
                            Title = "Survey 1"
                        },
                        new
                        {
                            SurveyId = 2,
                            Description = "Description for Survey 2",
                            Img = "img2.jpg",
                            Title = "Survey 2"
                        },
                        new
                        {
                            SurveyId = 3,
                            Description = "Description for Survey 3",
                            Img = "img3.jpg",
                            Title = "Survey 3"
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

            modelBuilder.Entity("survey_be.Models.Question", b =>
                {
                    b.HasOne("survey_be.Models.Survey", "Survey")
                        .WithMany("Questions")
                        .HasForeignKey("SurveyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Survey");
                });

            modelBuilder.Entity("survey_be.Models.Question", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("survey_be.Models.Survey", b =>
                {
                    b.Navigation("Questions");
                });
#pragma warning restore 612, 618
        }
    }
}
