using Microsoft.EntityFrameworkCore;
using survey_be.Models;

namespace survey_be.Data
{
    public class SurveyDbContext : DbContext
    {
        public SurveyDbContext(DbContextOptions<SurveyDbContext> options)
    : base(options)
        {
        }

        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=surveydb;User Id=myuser;Password=mypassword;");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Survey>(entity =>
            {
                entity.HasKey(e => e.SurveyId);
                entity.Property(e => e.Title).IsRequired();
                entity.Property(e => e.Description).IsRequired();
                entity.Property(e => e.Img).IsRequired();
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.HasKey(e => e.QuestionId);
                entity.Property(e => e.Title).IsRequired();
                entity.Property(e => e.Type).IsRequired();
                entity.Property(e => e.QuestionContent).IsRequired();

                entity.HasOne(e => e.Survey)
                      .WithMany(e => e.Questions)
                      .HasForeignKey(e => e.SurveyId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Answer>(entity =>
            {
                entity.HasKey(e => e.AnswerId);
                entity.Property(e => e.AnswerContent).IsRequired();
                entity.Property(e => e.CorrectAnswer).IsRequired();

                entity.HasOne(e => e.Question)
                      .WithMany(e => e.Answers)
                      .HasForeignKey(e => e.QuestionId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Seed data
            modelBuilder.Entity<Survey>().HasData(
                new Survey { SurveyId = 1, Title = "Survey 1", Description = "Description for Survey 1", Img = "img1.jpg" },
                new Survey { SurveyId = 2, Title = "Survey 2", Description = "Description for Survey 2", Img = "img2.jpg" },
                new Survey { SurveyId = 3, Title = "Survey 3", Description = "Description for Survey 3", Img = "img3.jpg" }
            );

            modelBuilder.Entity<Question>().HasData(
                new Question { QuestionId = 1, Title = "Question 1", Type = "Type 1", QuestionContent = "Question Content 1", SurveyId = 1 },
                new Question { QuestionId = 2, Title = "Question 2", Type = "Type 2", QuestionContent = "Question Content 2", SurveyId = 1 },
                new Question { QuestionId = 3, Title = "Question 3", Type = "Type 3", QuestionContent = "Question Content 3", SurveyId = 2 }
            );

            modelBuilder.Entity<Answer>().HasData(
                new Answer { AnswerId = 1, CorrectAnswer = true, AnswerContent = "Answer Content 1", QuestionId = 1 },
                new Answer { AnswerId = 2, CorrectAnswer = false, AnswerContent = "Answer Content 2", QuestionId = 1 },
                new Answer { AnswerId = 3, CorrectAnswer = true, AnswerContent = "Answer Content 3", QuestionId = 2 }
            );
        }
    }
}
