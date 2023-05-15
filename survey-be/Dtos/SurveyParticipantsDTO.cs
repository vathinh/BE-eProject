namespace survey_be.Dtos
{
    public class SurveyParticipantsDTO
    {
        public int SurveyId { get; set; }
        public string Title { get; set; }
        public virtual ICollection<ParticipatesDTO> Responses { get; set; }
    }
}
