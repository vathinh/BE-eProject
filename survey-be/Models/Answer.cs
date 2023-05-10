using System.ComponentModel.DataAnnotations;

namespace survey_be.Models
{
    public class Answer
    {
        [Key]
        public int AnswerId { get; set; }
        public bool CorrectAnswer { get; set; }
        public string AnswerContent { get; set; }
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
    }
}
