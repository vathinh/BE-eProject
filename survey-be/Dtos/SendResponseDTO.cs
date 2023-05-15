namespace survey_be.Dtos
{
    public class SendResponseDTO
    {
        public int ResponseId { get; set; }
        public int SurveyId { get; set; }
        public int UserId { get; set; }
        public List<QuestionResponseDTO> Questions { get; set; }
    }
}
