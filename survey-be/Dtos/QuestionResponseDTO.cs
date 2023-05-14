namespace survey_be.Dtos
{
    public class QuestionResponseDTO
    {
        public int QuestionId { get; set; }
        public List<int> SelectedAnswerIds { get; set; }
    }
}
