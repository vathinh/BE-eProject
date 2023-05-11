namespace survey_be.Dtos
{
    public class CompetitionContentDTO
    {
        public int CompetitionContentId { get; set; }
        public string Name { get; set; }
        public DateTime TimeStartCompetition { get; set; }
        public DateTime TimeEndCompetition { get; set; }
        public string Location { get; set; }
        public int SurveyId { get; set; }
        public virtual ICollection<CompetitionResultDTO>? CompetitionResults { get; set; }

    }
}
