using survey_be.Models;

namespace survey_be.Dtos
{
    public class SurveyDTO
    {
        public int SurveyId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Img { get; set; }
        public int UserRoleId { get; set; }
        public virtual UserRole UserRole { get; set; }
        public virtual ICollection<QuestionDTO> Questions { get; set; }
    }
}
