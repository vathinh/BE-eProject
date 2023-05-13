using survey_be.Models;

namespace survey_be.Dtos
{
    public class ResponseDTO
    {
        public int ResponseId { get; set; }
        public int TotalMark { get; set; }
        public int SurveyId { get; set; }
        public int UserId { get; set; }
    }
}
