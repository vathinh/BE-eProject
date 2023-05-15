namespace survey_be.Models
{
    public class Response
    {
        public int ResponseId { get; set; }
        public int TotalMark { get; set; }

        public int SurveyId { get; set; }
        public virtual Survey Survey { get; set; }

        public int UserId { get; set; }
        public virtual UserInfo UserInfo { get; set; }

        public virtual ICollection<CompetitionResult> CompetitionResults { get; set; }

    }
}
