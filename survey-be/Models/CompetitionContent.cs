using System.ComponentModel.DataAnnotations;

namespace survey_be.Models
{
    public class CompetitionContent
    {
        [Key]
        public int CompetitionContentId { get; set; }
        public string Name { get; set; }
        public DateTime TimeStartCompetition { get; set; }
        public DateTime TimeEndCompetition { get; set; }
        public string Location { get; set; }

        public int SurveyId { get; set; }
        public virtual Survey Survey { get; set; }

        public virtual ICollection<CompetitionResult> CompetitionResults { get; set; }

    }
}