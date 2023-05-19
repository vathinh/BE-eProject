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
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<SupportInformation> SupportInformations { get; set; }
        public DbSet<Faq> Faqs { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<CompetitionContent> CompetitionContents { get; set; }
        public DbSet<CompetitionResult> CompetitionResults { get; set; }
        public DbSet<Prize> Prizes { get; set; }
           



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=surveydb;User Id=myuser;Password=mypassword;");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //UserRole table
            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => e.UserRoleId);
                entity.Property(e => e.UserRoleName).IsRequired();

            });

            //UserInfo table
            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasKey(e => e.UserId);
                entity.Property(e => e.UserName).IsRequired();
                entity.Property(e => e.UserPassword).IsRequired();
                entity.Property(e => e.RollNo).IsRequired();
                entity.Property(e => e.UserClass).IsRequired();
                entity.Property(e => e.RollNo).IsRequired();
                entity.Property(e => e.Specification).IsRequired();
                entity.Property(e => e.UserClass).IsRequired();
                entity.Property(e => e.Section).IsRequired();
                entity.Property(e => e.IsActive).IsRequired();

                entity.HasOne(e => e.UserRole)
                      .WithMany(e => e.UserInfos)
                      .HasForeignKey(e => e.UserRoleId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            //SupportInformation table
            modelBuilder.Entity<SupportInformation>(entity =>
            {
                entity.HasKey(e => e.SupportInformationId);
                entity.Property(e => e.SupportInformationContent).IsRequired();

                entity.HasOne(e => e.UserInfo)
                      .WithMany(e => e.SupportInformations)
                      .HasForeignKey(e => e.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            //Response table
            modelBuilder.Entity<Response>(entity =>
            {
                entity.HasKey(e => e.ResponseId);
                entity.Property(e => e.TotalMark).IsRequired();


                entity.HasOne(e => e.Survey)
                      .WithMany(e => e.Responses)
                      .HasForeignKey(e => e.SurveyId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.UserInfo)
                     .WithMany(e => e.Responses)
                     .HasForeignKey(e => e.UserId)
                     .OnDelete(DeleteBehavior.Cascade);
            });

            //CompetitionResult table
            modelBuilder.Entity<CompetitionResult>(entity =>
            {
                entity.HasKey(e => e.NumberUserJoined);

                entity.HasOne(e => e.Response)
                      .WithMany(e => e.CompetitionResults)
                      .HasForeignKey(e => e.ResponseId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.CompetitionContent)
                     .WithMany(e => e.CompetitionResults)
                     .HasForeignKey(e => e.CompetitionContentId)
                     .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Prize)
                     .WithMany(e => e.CompetitionResults)
                     .HasForeignKey(e => e.PrizeId)
                     .OnDelete(DeleteBehavior.Cascade);
            });

            //Prize table
            modelBuilder.Entity<Prize>(entity =>
            {
                entity.HasKey(e => e.PrizeId);
                entity.Property(e => e.PrizeName).IsRequired();
                entity.Property(e => e.PrizeDescription).IsRequired();
            });

            //CompetitionContent table
            modelBuilder.Entity<CompetitionContent>(entity =>
            {
                entity.HasKey(e => e.CompetitionContentId);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.TimeStartCompetition).IsRequired();
                entity.Property(e => e.TimeEndCompetition).IsRequired();
                entity.Property(e => e.Location).IsRequired();



                entity.HasOne(e => e.Survey)
                      .WithMany(e => e.CompetitionContents)
                      .HasForeignKey(e => e.SurveyId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            //Survey table
            modelBuilder.Entity<Survey>(entity =>
            {
                entity.HasKey(e => e.SurveyId);
                entity.Property(e => e.Title).IsRequired();
                entity.Property(e => e.Description).IsRequired();
                entity.Property(e => e.Img).IsRequired();

                entity.HasOne(e => e.UserRole)
                  .WithMany(e => e.Surveys)
                  .HasForeignKey(e => e.UserRoleId)
                  .OnDelete(DeleteBehavior.Cascade);
            });

            //Question table
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

            //Answer table
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

            //Faq table
            modelBuilder.Entity<Faq>(entity =>
            {
                entity.HasKey(e => e.FaqId);
                entity.Property(e => e.FaqQuestion).IsRequired();
                entity.Property(e => e.FaqContent).IsRequired();
            });




            // Seed data
            modelBuilder.Entity<Survey>().HasData(
                new Survey { SurveyId = 1, Title = "Survey 1", Description = "Description for Survey 1", Img = "img1.jpg", UserRoleId = 2 },
                new Survey { SurveyId = 2, Title = "Survey 2", Description = "Description for Survey 2", Img = "img2.jpg", UserRoleId = 2 },
                new Survey { SurveyId = 3, Title = "Survey 3", Description = "Description for Survey 3", Img = "img3.jpg", UserRoleId = 3 }
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


            modelBuilder.Entity<UserRole>().HasData(
                 new UserRole { UserRoleId = 1, UserRoleName = "Administrator" },
                 new UserRole { UserRoleId = 2, UserRoleName = "Student" },
                 new UserRole { UserRoleId = 3, UserRoleName = "Staff" }
             );

            modelBuilder.Entity<UserInfo>().HasData(
                new UserInfo { UserId = 1, UserName = "admin", UserPassword = "adminpass", RollNo = "", UserClass = "", Specification = "", Section = "", IsActive = true, UserRoleId = 1 },
                new UserInfo { UserId = 2, UserName = "john", UserPassword = "johnpass", RollNo = "001", UserClass = "12A", Specification = "science", Section = "A", IsActive = true, UserRoleId = 2 },
                new UserInfo { UserId = 3, UserName = "jane", UserPassword = "janepass", RollNo = "101", UserClass = "11B", Specification = "arts", Section = "B", IsActive = true, UserRoleId = 2 },
                new UserInfo { UserId = 4, UserName = "peter", UserPassword = "peterpass", RollNo = "", UserClass = "", Specification = "librarian", Section = "", IsActive = true, UserRoleId = 3 },
                new UserInfo { UserId = 5, UserName = "susan", UserPassword = "susanpass", RollNo = "", UserClass = "", Specification = "teacher", Section = "", IsActive = true, UserRoleId = 3 }
            );

            modelBuilder.Entity<SupportInformation>().HasData(
                new SupportInformation
                {
                    SupportInformationId = 1,
                    SupportInformationContent = "I'm having trouble accessing my account.",
                    UserId = 1
                },
                new SupportInformation
                {
                    SupportInformationId = 2,
                    SupportInformationContent = "I can't find the answer to my question.",
                    UserId = 2
                },
                new SupportInformation
                {
                    SupportInformationId = 3,
                    SupportInformationContent = "I think there's a bug in the system.",
                    UserId = 1
                }
            );

            modelBuilder.Entity<Response>().HasData(
                 new Response { ResponseId = 1, TotalMark = 8, UserId = 1, SurveyId = 1 },
                 new Response { ResponseId = 2, TotalMark = 6, UserId = 2, SurveyId = 1 },
                 new Response { ResponseId = 3, TotalMark = 9, UserId = 3, SurveyId = 1 },
                 new Response { ResponseId = 4, TotalMark = 7, UserId = 1, SurveyId = 2 },
                 new Response { ResponseId = 5, TotalMark = 5, UserId = 2, SurveyId = 2 },
                 new Response { ResponseId = 6, TotalMark = 8, UserId = 3, SurveyId = 2 },
                 new Response { ResponseId = 7, TotalMark = 9, UserId = 1, SurveyId = 3 },
                 new Response { ResponseId = 8, TotalMark = 7, UserId = 2, SurveyId = 3 },
                 new Response { ResponseId = 9, TotalMark = 8, UserId = 3, SurveyId = 3 }
             );

          //  modelBuilder.Entity<CompetitionResult>().HasData(
            //    new CompetitionResult { NumberUserJoined = 10, HighestMark = 9, ResponseId = 1, CompetitionContentId = 1, PrizeId = 1 },
              //  new CompetitionResult { NumberUserJoined = 15, HighestMark = 4, ResponseId = 2, CompetitionContentId = 2, PrizeId = 2 },
              //  new CompetitionResult { NumberUserJoined = 8, HighestMark = 6, ResponseId = 3, CompetitionContentId = 3, PrizeId = 3 }
           // );

            modelBuilder.Entity<Prize>().HasData(
                new Prize { PrizeId = 1, PrizeName = "First Prize", PrizeDescription = "A brand new iPhone" },
                new Prize { PrizeId = 2, PrizeName = "Second Prize", PrizeDescription = "A high-end gaming laptop" },
                new Prize { PrizeId = 3, PrizeName = "Third Prize", PrizeDescription = "A 50-inch 4K Smart TV" }
            );

            modelBuilder.Entity<CompetitionContent>().HasData(
                new CompetitionContent { CompetitionContentId = 1, Name = "Competition 1", TimeStartCompetition = DateTime.UtcNow, TimeEndCompetition = DateTime.UtcNow.AddDays(7), SurveyId = 1, Location = "District 1" },
                new CompetitionContent { CompetitionContentId = 2, Name = "Competition 2", TimeStartCompetition = DateTime.UtcNow, TimeEndCompetition = DateTime.UtcNow.AddDays(14), SurveyId = 2, Location = "District 2" },
                new CompetitionContent { CompetitionContentId = 3, Name = "Competition 3", TimeStartCompetition = DateTime.UtcNow, TimeEndCompetition = DateTime.UtcNow.AddDays(21), SurveyId = 3, Location = "District 3" }
            );



            modelBuilder.Entity<Faq>().HasData(
                new Faq { FaqId = 1, FaqQuestion = "What is your return policy?", FaqContent = "We accept returns within 30 days of purchase with a valid receipt." },
                new Faq { FaqId = 2, FaqQuestion = "How do I track my order?", FaqContent = "You can track your order by logging into your account or by using the tracking number provided in your shipping confirmation email." },
                new Faq { FaqId = 3, FaqQuestion = "Do you offer free shipping?", FaqContent = "We offer free shipping on orders over $50." }
            );




        }
    }
}
