using survey_be.Models;

namespace survey_be.Dtos
{
    public class AnswerDTO
    {
        public int AnswerId { get; set; }
        public bool CorrectAnswer { get; set; }
        public string AnswerContent { get; set; }
        public int QuestionId { get; set; }
    }
}
