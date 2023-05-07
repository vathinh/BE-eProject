
namespace survey_be.Dtos
{
    public class QuestionDTO
    {
        public int QuestionId { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string QuestionContent { get; set; }
        public int SurveyId { get; set; }
        public virtual ICollection<AnswerDTO> Answers { get; set; }
    }
}
