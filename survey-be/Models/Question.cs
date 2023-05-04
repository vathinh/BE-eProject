using System.ComponentModel.DataAnnotations;

namespace survey_be.Models
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string QuestionContent { get; set; }
        public int SurveyId { get; set; }
        public virtual Survey Survey { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
    }
}
