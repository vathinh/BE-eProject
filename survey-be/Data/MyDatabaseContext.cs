using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using survey_be.Models;

namespace survey_be.Data;

public partial class MyDatabaseContext : DbContext
{
    public MyDatabaseContext(DbContextOptions<MyDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Answer> Answers { get; set; }

    public virtual DbSet<Competition> Competitions { get; set; }

    public virtual DbSet<Faq> Faqs { get; set; }

    public virtual DbSet<Prize> Prizes { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Supportinformation> Supportinformations { get; set; }

    public virtual DbSet<Survey> Surveys { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    public virtual DbSet<Userdatum> Userdata { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Answer>(entity =>
        {
            entity.HasKey(e => e.AnswerId).HasName("answer_pkey");

            entity.ToTable("answer");

            entity.Property(e => e.AnswerId).HasColumnName("answer_id");
            entity.Property(e => e.AnswerContent)
                .HasMaxLength(1000)
                .HasColumnName("answer_content");
            entity.Property(e => e.Mark).HasColumnName("mark");
            entity.Property(e => e.QuestionId).HasColumnName("question_id");
            entity.Property(e => e.SurveyId).HasColumnName("survey_id");

            entity.HasOne(d => d.Question).WithMany(p => p.Answers)
                .HasForeignKey(d => d.QuestionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("answer_question_id_fkey");

            entity.HasOne(d => d.Survey).WithMany(p => p.Answers)
                .HasForeignKey(d => d.SurveyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("answer_survey_id_fkey");
        });

        modelBuilder.Entity<Competition>(entity =>
        {
            entity.HasKey(e => e.CompetitionId).HasName("competition_pkey");

            entity.ToTable("competition");

            entity.Property(e => e.CompetitionId).HasColumnName("competition_id");
            entity.Property(e => e.Duration)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("duration");
            entity.Property(e => e.Location)
                .HasMaxLength(100)
                .HasColumnName("location");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
            entity.Property(e => e.NumberLimitUser).HasColumnName("number_limit_user");
            entity.Property(e => e.NumberUserJoined).HasColumnName("number_user_joined");
            entity.Property(e => e.StatusCompetition)
                .HasMaxLength(100)
                .HasColumnName("status_competition");
            entity.Property(e => e.SurveyId).HasColumnName("survey_id");
            entity.Property(e => e.TimeEndCompetition)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("time_end_competition");
            entity.Property(e => e.TimeStartCompetition)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("time_start_competition");

            entity.HasOne(d => d.Survey).WithMany(p => p.Competitions)
                .HasForeignKey(d => d.SurveyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("competition_survey_id_fkey");
        });

        modelBuilder.Entity<Faq>(entity =>
        {
            entity.HasKey(e => e.FaqId).HasName("faqs_pkey");

            entity.ToTable("faqs");

            entity.Property(e => e.FaqId).HasColumnName("faq_id");
            entity.Property(e => e.FaqContent)
                .HasMaxLength(1000)
                .HasColumnName("faq_content");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Faqs)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("faqs_user_id_fkey");
        });

        modelBuilder.Entity<Prize>(entity =>
        {
            entity.HasKey(e => e.PrizeId).HasName("prize_pkey");

            entity.ToTable("prize");

            entity.Property(e => e.PrizeId).HasColumnName("prize_id");
            entity.Property(e => e.CompetitionId).HasColumnName("competition_id");
            entity.Property(e => e.PrizeDescription)
                .HasMaxLength(150)
                .HasColumnName("prize_description");
            entity.Property(e => e.PrizeName)
                .HasMaxLength(100)
                .HasColumnName("prize_name");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Competition).WithMany(p => p.Prizes)
                .HasForeignKey(d => d.CompetitionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("prize_competition_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.Prizes)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("prize_user_id_fkey");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.QuestionId).HasName("question_pkey");

            entity.ToTable("question");

            entity.Property(e => e.QuestionId).HasColumnName("question_id");
            entity.Property(e => e.AnswerContent)
                .HasMaxLength(1000)
                .HasColumnName("answer_content");
            entity.Property(e => e.SurveyId).HasColumnName("survey_id");

            entity.HasOne(d => d.Survey).WithMany(p => p.Questions)
                .HasForeignKey(d => d.SurveyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("question_survey_id_fkey");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("role_pkey");

            entity.ToTable("role");

            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.RoleDescription)
                .HasMaxLength(1000)
                .HasColumnName("role_description");
            entity.Property(e => e.RoleName)
                .HasMaxLength(100)
                .HasColumnName("role_name");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("status_pkey");

            entity.ToTable("status");

            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .HasColumnName("description");
            entity.Property(e => e.StatusContent)
                .HasMaxLength(100)
                .HasColumnName("status_content");
        });

        modelBuilder.Entity<Supportinformation>(entity =>
        {
            entity.HasKey(e => e.SupportId).HasName("supportinformation_pkey");

            entity.ToTable("supportinformation");

            entity.Property(e => e.SupportId).HasColumnName("support_id");
            entity.Property(e => e.SupportContent)
                .HasMaxLength(1000)
                .HasColumnName("support_content");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Supportinformations)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("supportinformation_user_id_fkey");
        });

        modelBuilder.Entity<Survey>(entity =>
        {
            entity.HasKey(e => e.SurveyId).HasName("survey_pkey");

            entity.ToTable("survey");

            entity.Property(e => e.SurveyId).HasColumnName("survey_id");
            entity.Property(e => e.StatusSurvey)
                .HasMaxLength(100)
                .HasColumnName("status_survey");
            entity.Property(e => e.SurveyName)
                .HasMaxLength(300)
                .HasColumnName("survey_name");
            entity.Property(e => e.SurveyTitle)
                .HasMaxLength(200)
                .HasColumnName("survey_title");
            entity.Property(e => e.SurveyType)
                .HasMaxLength(150)
                .HasColumnName("survey_type");
            entity.Property(e => e.TotalMark).HasColumnName("total_mark");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Surveys)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("survey_user_id_fkey");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("user_role_pkey");

            entity.ToTable("user_role");

            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_role_user_id_fkey");
        });

        modelBuilder.Entity<Userdatum>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("userdata_pkey");

            entity.ToTable("userdata");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.RegistrationType)
                .HasMaxLength(150)
                .HasColumnName("registration_type");
            entity.Property(e => e.StatusId)
                .HasMaxLength(100)
                .HasColumnName("status_id");
            entity.Property(e => e.UserCode)
                .HasMaxLength(150)
                .HasColumnName("user_code");
            entity.Property(e => e.UserName)
                .HasMaxLength(150)
                .HasColumnName("user_name");
            entity.Property(e => e.UserPassword)
                .HasMaxLength(100)
                .HasColumnName("user_password");
            entity.Property(e => e.UserRole)
                .HasMaxLength(150)
                .HasColumnName("user_role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
