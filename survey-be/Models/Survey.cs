using System.ComponentModel.DataAnnotations;

namespace survey_be.Models
{
    public class Survey
    {
        [Key]
        public int SurveyId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Img { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<Response> Responses { get; set; }
        public virtual ICollection<CompetitionContent> CompetitionContents { get; set; }



    }
}
